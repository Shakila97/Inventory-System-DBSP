using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Inventory_Management_System.Application.DAL
{
    /// <summary>
    /// Centralized Data Access Layer helper.
    /// All DB operations must route through this class. Never instantiate SqlConnection directly in Forms or BLL.
    /// </summary>
    public static class DatabaseHelper
    {
        // Reads connection string from App.config (name must match exactly)
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["InventoryDB"]?.ConnectionString;

        static DatabaseHelper()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new ConfigurationErrorsException("Missing or empty 'InventoryDB' connection string in App.config.");
        }

        /// <summary>
        /// Executes a parameterized SELECT query and returns results as a DataTable.
        /// </summary>
        public static DataTable GetDataTable(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(parameters ?? Array.Empty<SqlParameter>());
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        /// <summary>
        /// Executes INSERT, UPDATE, DELETE, or Stored Procedures.
        /// Returns number of rows affected.
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters ?? Array.Empty<SqlParameter>());
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Returns the first column of the first row. Ideal for SCOPE_IDENTITY(), COUNT(), etc.
        /// </summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters ?? Array.Empty<SqlParameter>());
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Returns a forward-only, read-only SqlDataReader.
        /// ⚠️ Caller MUST wrap in 'using' to dispose reader and close connection.
        /// </summary>
        public static SqlDataReader GetDataReader(string sql, params SqlParameter[] parameters)
        {
            var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters ?? Array.Empty<SqlParameter>());
            conn.Open();
            // Ensures connection closes automatically when reader is disposed
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}