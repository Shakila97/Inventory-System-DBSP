using InventorySystem.DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inventory_Management_System_IMS.Application.BLL
{
    public class ProductBLL
    {
        public DataTable GetAllProducts()
        {
            string query = @"SELECT p.ProductID, p.ProductName, c.CategoryName, 
                                   p.UnitPrice, p.UnitsInStock, p.ReorderLevel
                            FROM Products p
                            INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                            ORDER BY p.ProductName";

            return DatabaseHelper.GetDataTable(query);
        }

        public DataTable GetAllCategories()
        {
            string query = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
            return DatabaseHelper.GetDataTable(query);
        }

        public DataTable SearchProducts(string searchQuery, int categoryID)
        {
            string query = @"SELECT p.ProductID, p.ProductName, c.CategoryName, 
                                   p.UnitPrice, p.UnitsInStock, p.ReorderLevel
                            FROM Products p
                            INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                            WHERE (@SearchQuery IS NULL OR p.ProductName LIKE @SearchQuery)
                            AND (@CategoryID = 0 OR p.CategoryID = @CategoryID)
                            ORDER BY p.ProductName";

            SqlParameter[] parameters = {
                new SqlParameter("@SearchQuery", string.IsNullOrEmpty(searchQuery) ? (object)DBNull.Value : "%" + searchQuery + "%"),
                new SqlParameter("@CategoryID", categoryID)
            };

            return DatabaseHelper.GetDataTable(query, parameters);
        }

        public bool SaveProduct(int productID, string productName, int categoryID,
                               decimal unitPrice, int unitsInStock, int reorderLevel)
        {
            string query = @"IF @ProductID = 0
                INSERT INTO Products (ProductName, CategoryID, UnitPrice, UnitsInStock, ReorderLevel)
                VALUES (@ProductName, @CategoryID, @UnitPrice, @UnitsInStock, @ReorderLevel)
            ELSE
                UPDATE Products 
                SET ProductName = @ProductName, CategoryID = @CategoryID, 
                    UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, 
                    ReorderLevel = @ReorderLevel
                WHERE ProductID = @ProductID";

            SqlParameter[] parameters = {
                new SqlParameter("@ProductID", productID),
                new SqlParameter("@ProductName", productName),
                new SqlParameter("@CategoryID", categoryID),
                new SqlParameter("@UnitPrice", unitPrice),
                new SqlParameter("@UnitsInStock", unitsInStock),
                new SqlParameter("@ReorderLevel", reorderLevel)
            };

            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteProduct(int productID)
        {
            string query = "DELETE FROM Products WHERE ProductID = @ProductID";
            SqlParameter[] parameters = {
                new SqlParameter("@ProductID", productID)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key violation
                {
                    throw new Exception("Cannot delete product. It is referenced in sales records.");
                }
                throw;
            }
        }

        public DataTable GetLowStockProducts()
        {
            return DatabaseHelper.GetDataTable("SELECT * FROM vw_LowStock");
        }
    }
}