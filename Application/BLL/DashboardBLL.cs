using System;
using System.Data;
using System.Data.SqlClient;
using InventorySystem.DAL;

namespace InventorySystem.BLL
{
    /// <summary>
    /// Routes Dashboard data requests to DatabaseHelper.
    /// Zero SQL in Presentation layer.
    /// </summary>
    public static class DashboardBLL
    {
        public static DataTable GetSummaryCounts()
        {
            // Single optimized query for all summary widgets
            string sql = @"
                SELECT 
                    (SELECT COUNT(*) FROM Products) AS TotalProducts,
                    (SELECT COUNT(*) FROM vw_LowStock) AS LowStockCount,
                    (SELECT COUNT(*) FROM Customers) AS TotalCustomers,
                    (SELECT ISNULL(SUM(TotalAmount), 0) FROM Sales WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)) AS TodayRevenue";
            return DatabaseHelper.GetDataTable(sql);
        }

        public static DataTable GetDailyRevenue(DateTime startDate, DateTime endDate)
        {
            // Calls Table-Valued Function per Blueprint
            string sql = "SELECT SaleDate, TotalRevenue, Transactions, AvgOrderValue FROM fn_DailyRevenue(@start, @end) ORDER BY SaleDate";
            var parameters = new[]
            {
                new SqlParameter("@start", SqlDbType.Date) { Value = startDate },
                new SqlParameter("@end", SqlDbType.Date) { Value = endDate }
            };
            return DatabaseHelper.GetDataTable(sql, parameters);
        }

        public static DataTable GetLowStockAlerts()
        {
            // Directly binds to vw_LowStock view
            return DatabaseHelper.GetDataTable("SELECT ProductID, ProductName, UnitsInStock, ReorderLevel, CategoryName FROM vw_LowStock ORDER BY UnitsInStock ASC");
        }
    }
}