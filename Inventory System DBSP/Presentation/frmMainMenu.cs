using IMS;
using Inventory_System_DBSP; // Replace with your actual namespace
using System;
using System.Windows.Forms;

namespace Inventory_System_DBSP
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnProductInventory_Click(object sender, EventArgs e)
        {
            new frmProductInventory().Show();
        }

        private void btnCustomerDirectory_Click(object sender, EventArgs e)
        {
            new frmCustomerDirectory().Show();
        }

        private void btnSalesTransaction_Click(object sender, EventArgs e)
        {
            new frmSalesTransaction().Show();
        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            new frmStockAdjustment().Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            new frmDashboard().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new frmLogin();
            loginForm.FormClosed += (s, args) => Application.Exit();
            loginForm.ShowDialog();
        }
    }
}