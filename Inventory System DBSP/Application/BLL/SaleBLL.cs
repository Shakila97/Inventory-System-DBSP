using Inventory_System_DBSP;
using InventorySystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace InventorySystem.BLL
{
    /// <summary>
    /// Business Logic for Sales. Handles ACID transaction routing via sp_ProcessSale.
    /// Cart is passed as XML to match Blueprint specifications.
    /// </summary>
    public static class SaleBLL
    {
        public static DataTable GetAllCustomers() => DatabaseHelper.GetDataTable("SELECT CustomerID, CustomerName FROM Customers ORDER BY CustomerName");
        public static DataTable GetAllProducts() => DatabaseHelper.GetDataTable("SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products ORDER BY ProductName");

        public static int ProcessSale(int customerId, List<CartItem> cartItems)
        {
            if (customerId <= 0) throw new ArgumentException("Invalid customer selected.");
            if (cartItems == null || cartItems.Count == 0) throw new ArgumentException("Cart is empty.");

            string cartXml = BuildCartXml(cartItems);

            string sql = "sp_ProcessSale";
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", SqlDbType.Int) { Value = customerId },
                new SqlParameter("@CartXML", SqlDbType.Xml) { Value = cartXml }
            };

            try
            {
                return DatabaseHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (SqlException ex)
            {
                // sp_ProcessSale uses RAISERROR → becomes SqlException in C#
                string msg = ex.Message.Trim();
                throw new InvalidOperationException($"Sale transaction failed: {msg}", ex);
            }
        }

        private static string BuildCartXml(List<CartItem> items)
        {
            var sb = new StringBuilder("<cart>");
            foreach (var item in items)
            {
                sb.AppendFormat("<item productid=\"{0}\" qty=\"{1}\" price=\"{2}\" />",
                    item.ProductId,
                    item.Quantity,
                    item.UnitPrice.ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.Append("</cart>");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Shared DTO for Cart UI & BLL communication.
    /// </summary>
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal => Quantity * UnitPrice;
    }
}