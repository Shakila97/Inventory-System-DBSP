using InventorySystem.DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem.BLL
{
    /// <summary>
    /// Handles authentication routing. Never call DB directly from frmLogin.
    /// </summary>
    public static class AuthBLL
    {
        public static bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Credentials cannot be empty.");

            // Assumes a 'Users' table exists per Blueprint (Member 02)
            string sql = "SELECT UserID FROM Users WHERE Username = @user AND PasswordHash = @pass";
            var parameters = new[]
            {
                new SqlParameter("@user", SqlDbType.NVarChar, 50) { Value = username },
                new SqlParameter("@pass", SqlDbType.NVarChar, 100) { Value = password } // Hash before calling in production
            };

            object result = DatabaseHelper.ExecuteScalar(sql, parameters);
            return result != null && result != DBNull.Value;
        }
    }
}