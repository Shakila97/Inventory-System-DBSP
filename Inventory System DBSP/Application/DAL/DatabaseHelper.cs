using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Inventory_System_DBSP
{
    public static class DatabaseHelper
    {
        private static string connString = DatabaseConfig.GetConnection().ConnectionString;

        // ── Helper: attach parameters to a command ────────────────────────────
        private static void AddParameters(SqlCommand cmd, Dictionary<string, object> parameters)
        {
            if (parameters == null) return;
            foreach (var kv in parameters)
                cmd.Parameters.AddWithValue(kv.Key, kv.Value ?? DBNull.Value);
        }

        // ── METHOD 1: Returns a single value (COUNT, SUM, SCOPE_IDENTITY) ─────
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    AddParameters(cmd, parameters);
                    var result = cmd.ExecuteScalar();
                    return (result == null || result == DBNull.Value) ? 0 : result;
                }
            }
        }

        // ── METHOD 2: Returns a DataTable (for DataGridViews) ─────────────────
        public static DataTable GetDataTable(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    AddParameters(cmd, parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // ── METHOD 3: INSERT / UPDATE / DELETE — returns rows affected ─────────
        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    AddParameters(cmd, parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}