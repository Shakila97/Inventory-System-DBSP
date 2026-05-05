using System;
using System.Data;
using System.Data.SqlClient;
using InventoryManagementSystemV2.Application.DAL;


namespace InventoryManagementSystemV2.Application.BLL
{
    /// <summary>
    /// Business Logic for Sales Transactions & Revenue Reporting.
    /// Enforces cart validation, routes to ACID sp_ProcessSale, and queries TVF reports.
    /// </summary>
    public static class SaleBLL
    {
        public static DataTable GetCustomersForSale() =>
            DatabaseHelper.GetDataTable("sp_GetCustomersForSale"); // Returns: CustomerID, CustomerName

        public static DataTable GetActiveProductsForSale() =>
            DatabaseHelper.GetDataTable("sp_GetActiveProductsForSale"); // Returns: ProductID, ProductName, UnitPrice, UnitsInStock

        /// <summary>
        /// Executes the ACID-compliant sp_ProcessSale.
        /// Cart must be XML format: <Cart><Item ProductID="1" Qty="2" Price="10.50"/></Cart>
        /// </summary>
        public static DataTable ProcessSale(int customerId, string cartXml)
        {
            if (customerId <= 0) throw new ArgumentException("Invalid customer selection.");
            if (string.IsNullOrWhiteSpace(cartXml) || !cartXml.Contains("<Cart>"))
                throw new ArgumentException("Cart cannot be empty or malformed.");

            // Returns: NewSaleID, TotalAmount (or throws on stock/DB failure)
            return DatabaseHelper.GetDataTable("sp_ProcessSale",
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@CartXML", cartXml));
        }

        /// <summary>
        /// Calls the Table-Valued Function fn_DailyRevenue for date-range reporting.
        /// </summary>
        public static DataTable GetRevenueReport(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate) throw new ArgumentException("Start date cannot be after end date.");

            return DatabaseHelper.GetDataTable("fn_DailyRevenue",
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate));
        }

        public static DataTable GetSalesHistory(DateTime from, DateTime to) =>
            DatabaseHelper.GetDataTable("sp_GetSalesHistory",
                new SqlParameter("@StartDate", from),
                new SqlParameter("@EndDate", to));
    }
}