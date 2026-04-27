using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Inventory_System_DBSP
{
    public class DatabaseConfig
    {
        public static SqlConnection GetConnection()
        {
            // App.config එකේ ඇති "InventoryDB" connection string එක ලබා ගනී
            string connString = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;
            return new SqlConnection(connString);
        }
    }
}