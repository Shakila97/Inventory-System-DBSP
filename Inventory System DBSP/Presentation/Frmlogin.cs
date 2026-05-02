using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Inventory_System_DBSP
{
    public partial class frmLogin : MaterialForm
    {
        private int _attempts = 0;

        public frmLogin()
        {
            InitializeComponent();

            // MaterialSkin setup — same theme as your original Form1
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        // ── Form Load ────────────────────────────────────────────────────────
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        // ── Login Button ─────────────────────────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        // ── Press Enter on password field to login ───────────────────────────
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AttemptLogin();
        }

        // ── Press Enter on username field to jump to password ────────────────
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        // ── Core Login Logic ─────────────────────────────────────────────────
        private void AttemptLogin()
        {
            // Empty field validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowError("Username ඇතුළු කරන්න.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Password ඇතුළු කරන්න.");
                txtPassword.Focus();
                return;
            }

            try
            {
                string sql = @"SELECT COUNT(*) FROM Users
                               WHERE Username = @User
                               AND PasswordHash = HASHBYTES('SHA2_256', @Pass)";

                var parameters = new Dictionary<string, object>
                {
                    { "@User", txtUsername.Text.Trim() },
                    { "@Pass", txtPassword.Text }
                };

                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));

                if (count > 0)
                {
                    // ── Login success ─────────────────────────────────────
                    if (count > 0)
                    {
                        // ── Login success ─────────────────────────────────────────────
                        lblAttempts.Visible = false;
                        _attempts = 0;

                        MessageBox.Show("Login සාර්ථකයි! Main Menu ළඟදීම එයි.",
                            "සාර්ථකයි", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Close the whole app when Main Menu is closed
                        mainMenu.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    // ── Wrong credentials ─────────────────────────────────
                    _attempts++;
                    txtPassword.Clear();
                    txtPassword.Focus();

                    if (_attempts >= 3)
                    {
                        ShowError("Account lock වී ඇත. Admin හා සම්බන්ධ වන්න.");
                        btnLogin.Enabled = false;
                        txtUsername.Enabled = false;
                        txtPassword.Enabled = false;
                    }
                    else
                    {
                        ShowError($"Username හෝ Password වැරදිය. තවත් {3 - _attempts} වාර ඉතිරිය.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database සම්බන්ධතා දෝෂය:\n" + ex.Message,
                    "දෝෂය",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ── Helper ───────────────────────────────────────────────────────────
        private void ShowError(string message)
        {
            lblAttempts.Text = message;
            lblAttempts.Visible = true;
        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {

        }

        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }
    }
}