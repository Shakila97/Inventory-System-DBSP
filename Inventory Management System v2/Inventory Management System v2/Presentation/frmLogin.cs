using InventoryManagementSystemV2.Application.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystemV2.Presentation
{
    public partial class frmLogin : Form
    {
        private int _failedAttempts = 0;
        private string _lockedUsername = string.Empty;

        public frmLogin() => InitializeComponent();

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                ShowStatus("Username and password are required.", Color.Orange);
                return;
            }

            if (_lockedUsername == user)
            {
                ShowStatus("Account locked. Contact admin.", Color.Red);
                return;
            }

            btnLogin.Enabled = false;
            ShowStatus("Verifying...", Color.Gray);

            try
            {
                var dt = await Task.Run(() => DatabaseHelper.GetDataTable(
                      "sp_Login",  // ← Stored procedure name
                      new SqlParameter("@Username", user)));  // ← Parameter name must match SP

                if (dt.Rows.Count == 0)
                {
                    HandleFailedAttempt(user);
                    return;
                }

                var row = dt.Rows[0];
                if (Convert.ToBoolean(row["IsLocked"]))
                {
                    _lockedUsername = user;
                    ShowStatus("Account locked due to multiple failed attempts.", Color.Red);
                    return;
                }

                if (row["PasswordHash"].ToString() == pass) // In production, use BCrypt/SHA256
                {
                    _failedAttempts = 0;
                    _lockedUsername = string.Empty;
                    this.Hide();
                    new frmMainMenu().ShowDialog();
                    this.Close();
                }
                else
                {
                    HandleFailedAttempt(user);
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"Database Error: {ex.Message}", Color.Red);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void HandleFailedAttempt(string user)
        {
            _failedAttempts++;
            if (_failedAttempts >= 3)
            {
                _lockedUsername = user;
                DatabaseHelper.ExecuteNonQuery("UPDATE Users SET IsLocked=1 WHERE Username=@u",
                    new System.Data.SqlClient.SqlParameter("@u", user));
                ShowStatus("Too many attempts. Account locked.", Color.Red);
            }
            else
            {
                ShowStatus($"Invalid credentials. {_failedAttempts}/3 attempts.", Color.Orange);
            }
        }

        private void ShowStatus(string msg, Color color)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = color;
        }
    }
}