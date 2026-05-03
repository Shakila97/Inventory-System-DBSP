using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventorySystem.BLL;

namespace Inventory_Management_System_IMS
{
    public partial class frmLogin : Form
    {
        private int _loginAttempts = 0;
        private const int MaxAttempts = 3;
        private bool _isLocked = false;

        public frmLogin()
        {
            InitializeComponent();
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.Text = "IMS - Secure Login";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = btnLogin;
            // Ensure designer controls match: txtUsername, txtPassword, btnLogin, lblStatus, lblAttempts
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (_isLocked) return;
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                SetStatus("Please enter both username and password.", Color.Orange);
                return;
            }

            // Disable UI during async operation
            SetUIState(false, "Authenticating...");
            SetStatus("Verifying credentials...", Color.Gray);

            try
            {
                // Run DB call on background thread to keep WinForms responsive
                bool isAuthenticated = await Task.Run(() => AuthBLL.ValidateUser(txtUsername.Text, txtPassword.Text));

                if (isAuthenticated)
                {
                    _loginAttempts = 0;
                    SetStatus("Login successful. Loading dashboard...", Color.Green);
                    this.Hide();
                    // new frmMainMenu().Show();
                }
                else
                {
                    HandleFailedLogin("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                HandleFailedLogin($"System error: {ex.Message}");
            }
            finally
            {
                SetUIState(true, "Login");
            }
        }

        private void HandleFailedLogin(string errorMessage)
        {
            _loginAttempts++;
            int remaining = MaxAttempts - _loginAttempts;

            if (remaining <= 0)
            {
                _isLocked = true;
                SetStatus("Account locked after 3 failed attempts. Restart application.", Color.Red);
                EnableControls(false);
            }
            else
            {
                SetStatus($"{errorMessage} ({remaining} attempts remaining)", Color.Orange);
                txtPassword.Clear();
                txtPassword.Focus();
            }
            lblAttempts.Text = $"Attempts: {_loginAttempts}/{MaxAttempts}";
        }

        private void SetUIState(bool enabled, string btnText)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetUIState(enabled, btnText))); return; }
            btnLogin.Enabled = enabled;
            btnLogin.Text = btnText;
        }

        private void EnableControls(bool enabled)
        {
            if (InvokeRequired) { Invoke(new Action(() => EnableControls(enabled))); return; }
            txtUsername.Enabled = enabled;
            txtPassword.Enabled = enabled;
        }

        private void SetStatus(string message, Color color)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetStatus(message, color))); return; }
            lblStatus.Text = message;
            lblStatus.ForeColor = color;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}