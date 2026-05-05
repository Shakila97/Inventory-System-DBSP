using System;
using System.Windows.Forms;

namespace InventoryManagementSystemV2.Presentation
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu() => InitializeComponent();

        // All button click handlers are wired in Designer.cs via lambda expressions.
        // Example: btnDashboard.Click += (s,e) => new frmDashboard().ShowDialog();
        // This keeps navigation clean and modal.
    }
}