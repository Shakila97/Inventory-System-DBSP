using Inventory_System_DBSP;
using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void btnProceedToLogin_Click(object sender, EventArgs e)
        {
            // 1. Hide the welcome screen (keeps it in memory but off-screen)
            this.Hide();

            // 2. Instantiate and show Login as a modal dialog
            using (frmLogin loginForm = new frmLogin())
            {
                DialogResult result = loginForm.ShowDialog();

                // 3. If login succeeded, proceed to Main Menu
                if (result == DialogResult.OK)
                {
                    frmMainMenu mainMenu = new frmMainMenu();
                    mainMenu.ShowDialog();
                }
            }

            // 4. Cleanup: Close welcome & exit app if login was cancelled/failed
            this.Close();
            Application.Exit();
        }
    }
}