using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using InventorySystem.DAL;

namespace InventorySystem.BLL
{
    /// <summary>
    /// Business Logic for Customers. Handles validation, CRUD routing, 
    /// and sp_UpsertCustomer execution with FK safety.
    /// </summary>
    public static class CustomerBLL
    {
        public static DataTable GetAllCustomers()
        {
            return DatabaseHelper.GetDataTable("SELECT CustomerID, CustomerName, Phone, Email FROM Customers ORDER BY CustomerName");
        }

        public static DataTable SearchCustomers(string searchTerm)
        {
            string sql = "SELECT CustomerID, CustomerName, Phone, Email FROM Customers WHERE CustomerName LIKE @search OR Email LIKE @search ORDER BY CustomerName";
            return DatabaseHelper.GetDataTable(sql, new SqlParameter("@search", "%" + searchTerm + "%"));
        }

        public static int UpsertCustomer(int customerId, string name, string phone, string email)
        {
            ValidateCustomer(name, phone, email);

            string sql = "sp_UpsertCustomer";
            var parameters = new[]
            {
                new SqlParameter("@CustomerID", SqlDbType.Int) { Value = customerId },
                new SqlParameter("@CustomerName", SqlDbType.NVarChar, 200) { Value = name },
                new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Value = string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone },
                new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = string.IsNullOrEmpty(email) ? (object)DBNull.Value : email }
            };

            return ExecuteWithIntegrityCheck(() => DatabaseHelper.ExecuteNonQuery(sql, parameters));
        }

        public static int DeleteCustomer(int customerId)
        {
            if (customerId <= 0) throw new ArgumentException("Invalid Customer ID.");
            string sql = "DELETE FROM Customers WHERE CustomerID = @id";
            return ExecuteWithIntegrityCheck(() => DatabaseHelper.ExecuteNonQuery(sql, new SqlParameter("@id", customerId)));
        }

        private static void ValidateCustomer(string name, string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Customer name is required.");
            if (!string.IsNullOrEmpty(phone) && !Regex.IsMatch(phone, @"^[\d\s\-\+\(\)]+$"))
                throw new ArgumentException("Invalid phone number format. Use digits, spaces, or dashes only.");
            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Invalid email format.");
        }

        private static int ExecuteWithIntegrityCheck(Func<int> dbAction)
        {
            try { return dbAction(); }
            catch (SqlException ex) when (ex.Number == 547)
            { throw new InvalidOperationException("Operation blocked: Customer has related sales records.", ex); }
            catch (SqlException ex)
            { throw new InvalidOperationException($"Database operation failed: {ex.Message.Trim()}", ex); }
        }
    }
}