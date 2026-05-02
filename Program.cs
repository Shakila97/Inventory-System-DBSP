using System;
using System.Windows.Forms;
using Inventory_Management_System_IMS;
using InventoryManagementSystem;
using InventorySystem.Presentation;

namespace InventorySystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Global error trapping for unhandled UI/Domain exceptions
            Application.ThreadException += (s, e) =>
                MessageBox.Show($"UI Thread Error:\n{e.Exception.Message}", "Critical", MessageBoxButtons.OK, MessageBoxIcon.Error);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                MessageBox.Show($"Fatal Runtime Error:\n{((Exception)e.ExceptionObject).Message}", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Entry point per Blueprint: Login → Main Menu
            Application.Run(new frmWelcome());
        }
    }
}