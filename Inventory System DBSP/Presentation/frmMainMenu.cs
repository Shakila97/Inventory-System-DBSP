using IMS;
using Inventory_System_DBSP;
using InventorySystem.Presentation;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventorySystem.Presentation
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.Text = "IMS - Management Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // Designer controls: btnDashboard, btnProducts, btnCustomers, btnSales, btnStock, btnLogout, lblWelcome
        }

        /// <summary>
        /// Centralized navigation handler. Modal workflow prevents multiple form instances.
        /// </summary>
        private void NavigateToForm(Form targetForm)
        {
            this.Hide();
            targetForm.FormClosed += (s, e) => this.Show();
            targetForm.ShowDialog();
        }

        // Wire these in Designer: btnDashboard.Click, btnProducts.Click, etc.
        private void btnDashboard_Click(object sender, EventArgs e) => NavigateToForm(new frmDashboard());
        private void btnProducts_Click(object sender, EventArgs e) => NavigateToForm(new frmProductInventory());
        private void btnCustomers_Click(object sender, EventArgs e) => NavigateToForm(new frmCustomerDirectory());
        private void btnSales_Click(object sender, EventArgs e) => NavigateToForm(new frmSalesTransaction());
        private void btnStock_Click(object sender, EventArgs e) => NavigateToForm(new frmStockAdjustment());

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout and return to login?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                var login = new frmLogin();
                login.FormClosed += (s, e) => Application.Exit(); // Exit app if login closes
                login.ShowDialog();

                // If user logs in again, login form hides itself. Re-show main menu.
                if (!login.Visible) this.Show();
            }
        }
    }
}