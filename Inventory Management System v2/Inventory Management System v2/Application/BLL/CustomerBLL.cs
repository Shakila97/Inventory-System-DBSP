using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using InventoryManagementSystemV2.Application.DAL;

namespace InventoryManagementSystemV2.Application.BLL
{
    /// <summary>
    /// Business Logic for Customers & Authentication.
    /// Handles upsert validation, email format checks, and directory queries.
    /// </summary>
    public static class CustomerBLL
    {
        public static DataTable GetAllCustomers() =>
            DatabaseHelper.GetDataTable("sp_GetAllCustomers");

        public static DataTable SearchCustomers(string keyword) =>
            DatabaseHelper.GetDataTable("sp_SearchCustomers",
                new SqlParameter("@Keyword", $"%{keyword}%"));

        /// <summary>
        /// Wraps sp_UpsertCustomer. Handles both INSERT (@CustomerID = 0) and UPDATE.
        /// </summary>
        public static int SaveCustomer(int customerId, string name, string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name is required.");

            if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
                throw new ArgumentException("Invalid email format.");

            return DatabaseHelper.ExecuteNonQuery("sp_UpsertCustomer",
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@CustomerName", name),
                new SqlParameter("@Phone", phone ?? string.Empty),
                new SqlParameter("@Email", email ?? string.Empty));
        }

        public static int DeleteCustomer(int customerId)
        {
            // Will fail with FK violation if customer has existing sales (Error 547)
            return DatabaseHelper.ExecuteNonQuery("sp_DeleteCustomer",
                new SqlParameter("@CustomerID", customerId));
        }

        private static bool IsValidEmail(string email)
        {
            // RFC 5322 simplified check for WinForms
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
            return regex.IsMatch(email);
        }
    }
}