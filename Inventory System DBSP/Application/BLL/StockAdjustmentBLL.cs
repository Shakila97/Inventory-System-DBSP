using Inventory_System_DBSP;
using InventorySystem.DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem.BLL
{
    /// <summary>
    /// Business Logic for manual stock adjustments (returns, damages, restocks).
    /// Validates before DB call, prevents negative stock, and routes through DAL.
    /// </summary>
    public static class StockAdjustmentBLL
    {
        public static int GetCurrentStock(int productId)
        {
            string sql = "SELECT UnitsInStock FROM Products WHERE ProductID = @id";
            object result = DatabaseHelper.ExecuteScalar(sql, new SqlParameter("@id", productId));
            return result != DBNull.Value && result != null ? Convert.ToInt32(result) : 0;
        }

        public static int ApplyAdjustment(int productId, int quantity, string reason, bool isAdd)
        {
            if (productId <= 0) throw new ArgumentException("Invalid product selected.");
            if (quantity <= 0) throw new ArgumentException("Adjustment quantity must be greater than 0.");
            if (string.IsNullOrWhiteSpace(reason)) throw new ArgumentException("Adjustment reason is required.");

            int currentStock = GetCurrentStock(productId);

            // Pre-validation: prevent removing more than available
            if (!isAdd && quantity > currentStock)
                throw new InvalidOperationException($"Insufficient stock. Available: {currentStock}, Requested removal: {quantity}.");

            int newStock = isAdd ? currentStock + quantity : currentStock - quantity;

            string sql = "UPDATE Products SET UnitsInStock = @newStock WHERE ProductID = @id";
            var parameters = new[]
            {
                new SqlParameter("@newStock", SqlDbType.Int) { Value = newStock },
                new SqlParameter("@id", SqlDbType.Int) { Value = productId }
            };

            return ExecuteWithIntegrityCheck(() => DatabaseHelper.ExecuteNonQuery(sql, parameters));
        }

        private static int ExecuteWithIntegrityCheck(Func<int> dbAction)
        {
            try { return dbAction(); }
            catch (SqlException ex) when (ex.Number == 547)
            { throw new InvalidOperationException("Operation blocked by database constraints.", ex); }
            catch (SqlException ex)
            { throw new InvalidOperationException($"Database error: {ex.Message.Trim()}", ex); }
        }
    }
}