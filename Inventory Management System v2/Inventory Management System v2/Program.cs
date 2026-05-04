using System;
using System.Windows.Forms;
using InventoryManagementSystemV2.Presentation; // ✅ Points to your Presentation/frmLogin.cs

namespace InventoryManagementSystemV2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable modern Windows visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the application at the Login screen
            Application.Run(new frmLogin());
        }
    }
}