using System.Data;
using System.Data.SqlClient;
using InventoryManagementSystemV2.Application.DAL;

namespace InventoryManagementSystemV2.Application.BLL
{
    /// <summary>
    /// Business Logic for Products & Categories.
    /// Validates input, routes calls to DAL, and exposes data for Presentation.
    /// </summary>
    public static class ProductBLL
    {
        public static DataTable GetAllProducts() =>
            DatabaseHelper.GetDataTable("sp_GetAllProducts");

        public static DataTable SearchProducts(string keyword, int categoryId) =>
            DatabaseHelper.GetDataTable("sp_SearchProducts",
                new SqlParameter("@Keyword", $"%{keyword}%"),
                new SqlParameter("@CategoryID", categoryId == 0 ? (object)DBNull.Value : categoryId));

        /// <summary>
        /// Returns products where UnitsInStock < ReorderLevel
        /// </summary>
        public static DataTable GetLowStockProducts() =>
            DatabaseHelper.GetDataTable("vw_LowStock");

        public static DataTable GetCategories() =>
            DatabaseHelper.GetDataTable("sp_GetCategories");

        public static int InsertProduct(string name, decimal price, int stock, int reorderLevel, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Product name is required.");
            if (price < 0) throw new ArgumentException("Unit price cannot be negative.");
            if (stock < 0) throw new ArgumentException("Stock cannot be negative.");

            return DatabaseHelper.ExecuteNonQuery("sp_InsertProduct",
                new SqlParameter("@ProductName", name),
                new SqlParameter("@UnitPrice", price),
                new SqlParameter("@UnitsInStock", stock),
                new SqlParameter("@ReorderLevel", reorderLevel),
                new SqlParameter("@CategoryID", categoryId));
        }

        public static int UpdateProduct(int id, string name, decimal price, int stock, int reorderLevel, int categoryId)
        {
            if (id <= 0) throw new ArgumentException("Invalid product ID.");
            return DatabaseHelper.ExecuteNonQuery("sp_UpdateProduct",
                new SqlParameter("@ProductID", id),
                new SqlParameter("@ProductName", name),
                new SqlParameter("@UnitPrice", price),
                new SqlParameter("@UnitsInStock", stock),
                new SqlParameter("@ReorderLevel", reorderLevel),
                new SqlParameter("@CategoryID", categoryId));
        }

        public static int DeleteProduct(int id)
        {
            // FK constraint (ON DELETE RESTRICT) will throw SqlException 547 if products exist
            return DatabaseHelper.ExecuteNonQuery("sp_DeleteProduct",
                new SqlParameter("@ProductID", id));
        }
    }
}