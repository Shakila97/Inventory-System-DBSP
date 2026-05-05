using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryManagementSystem.Application.DAL;

namespace InventoryManagementSystem.Presentation
{
    public partial class frmLogin : Form
    {
        private int _failedAttempts = 0;
        public frmLogin() => InitializeComponent();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var result = DatabaseHelper.ExecuteScalar("SELECT PasswordHash FROM Users WHERE Username=@u AND IsLocked=0",
                    new SqlParameter("@u", txtUsername.Text));

                if (result != null && result.ToString() == txtPassword.Text)
                {
                    _failedAttempts = 0;
                    this.Hide();
                    new frmMainMenu().Show();
                }
                else
                {
                    _failedAttempts++;
                    if (_failedAttempts >= 3)
                    {
                        DatabaseHelper.ExecuteNonQuery("UPDATE Users SET IsLocked=1 WHERE Username=@u",
                            new SqlParameter("@u", txtUsername.Text));
                        MessageBox.Show("Account locked. Contact admin.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid credentials. {_failedAttempts}/3 attempts.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DB Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}