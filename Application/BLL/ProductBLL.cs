using System;
using System.Data;
using System.Data.SqlClient;
using InventorySystem.DAL;

namespace InventorySystem.BLL
{
    /// <summary>
    /// Business Logic Layer for Products. Handles validation, CRUD routing, 
    /// and ACID-ready error propagation to the Presentation Layer.
    /// </summary>
    public static class ProductBLL
    {
        public static DataTable GetAllProducts()
        {
            string sql = @"SELECT p.ProductID, p.ProductName, p.UnitPrice, p.UnitsInStock, 
                                  p.ReorderLevel, c.CategoryName
                           FROM Products p 
                           JOIN Categories c ON p.CategoryID = c.CategoryID 
                           ORDER BY p.ProductName";
            return DatabaseHelper.GetDataTable(sql);
        }

        public static DataTable GetLowStockAlerts()
        {
            // Directly queries the vw_LowStock view as specified in Blueprint
            return DatabaseHelper.GetDataTable("SELECT ProductID, ProductName, UnitsInStock, ReorderLevel, CategoryName FROM vw_LowStock ORDER BY UnitsInStock ASC");
        }

        public static int InsertProduct(string name, decimal price, int stock, int reorder, int categoryId)
        {
            ValidateProduct(name, price, stock, reorder, categoryId);

            string sql = @"INSERT INTO Products (ProductName, UnitPrice, UnitsInStock, ReorderLevel, CategoryID) 
                           VALUES (@name, @price, @stock, @reorder, @catId)";

            var parameters = new[]
            {
                new SqlParameter("@name", SqlDbType.NVarChar, 200) { Value = name },
                new SqlParameter("@price", SqlDbType.Decimal) { Value = price, Precision = 10, Scale = 2 },
                new SqlParameter("@stock", SqlDbType.Int) { Value = stock },
                new SqlParameter("@reorder", SqlDbType.Int) { Value = reorder },
                new SqlParameter("@catId", SqlDbType.Int) { Value = categoryId }
            };

            return ExecuteWithIntegrityCheck(() => DatabaseHelper.ExecuteNonQuery(sql, parameters));
        }

        public static int UpdateProduct(int productId, string name, decimal price, int stock, int reorder, int categoryId)
        {
            if (productId <= 0) throw new ArgumentException("Invalid Product ID.");
            ValidateProduct(name, price, stock, reorder, categoryId);

            string sql = @"UPDATE Products SET ProductName = @name, UnitPrice = @price, 
                           UnitsInStock = @stock, ReorderLevel = @reorder, CategoryID = @catId 
                           WHERE ProductID = @id";

            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = productId },
                new SqlParameter("@name", SqlDbType.NVarChar, 200) { Value = name },
                new SqlParameter("@price", SqlDbType.Decimal) { Value = price, Precision = 10, Scale = 2 },
                new SqlParameter("@stock", SqlDbType.Int) { Value = stock },
                new SqlParameter("@reorder", SqlDbType.Int) { Value = reorder },
                new SqlParameter("@catId", SqlDbType.Int) { Value = categoryId }
            };

            return ExecuteWithIntegrityCheck(() => DatabaseHelper.ExecuteNonQuery(sql, parameters));
        }

        public static int DeleteProduct(int productId)
        {
            if (productId <= 0) throw new ArgumentException("Invalid Product ID.");

            string sql = "DELETE FROM Products WHERE ProductID = @id";
            var parameters = new[] { new SqlParameter("@id", SqlDbType.Int) { Value = productId } };

            return ExecuteWithIntegrityCheck(() => DatabaseHelper.ExecuteNonQuery(sql, parameters));
        }

        private static void ValidateProduct(string name, decimal price, int stock, int reorder, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > 200)
                throw new ArgumentException("Product name must be 1-200 characters.");
            if (price <= 0) throw new ArgumentException("Unit price must be greater than 0.");
            if (stock < 0) throw new ArgumentException("Units in stock cannot be negative.");
            if (reorder < 0) throw new ArgumentException("Reorder level cannot be negative.");
            if (categoryId <= 0) throw new ArgumentException("Invalid Category ID.");
        }

        /// <summary>
        /// Wraps DB calls to catch SQL Server constraint violations (Error 547) 
        /// and propagate user-friendly messages to the UI.
        /// </summary>
        private static int ExecuteWithIntegrityCheck(Func<int> dbAction)
        {
            try
            {
                return dbAction();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new InvalidOperationException("Operation blocked: Foreign Key constraint violation. Related records exist or referenced record is missing.", ex);
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"Database operation failed: {ex.Message}", ex);
            }
        }
    }
}