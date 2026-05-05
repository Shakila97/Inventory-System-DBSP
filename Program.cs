using System;
using System.Windows.Forms;
using Inventory_Management_System_IMS;
using InventorySystem.Presentation;

namespace Inventory_Management_System_IMS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // 'Application' වෙනුවට 'System.Windows.Forms.Application' ලෙස යොදන්න
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Global error trapping
            System.Windows.Forms.Application.ThreadException += (s, e) =>
                MessageBox.Show($"UI Thread Error:\n{e.Exception.Message}", "Critical", MessageBoxButtons.OK);

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                MessageBox.Show($"Fatal Runtime Error:\n{((Exception)e.ExceptionObject).Message}", "Fatal", MessageBoxButtons.OK);

            // Entry point: Login Form එක හරහා ආරම්භ වේ
            System.Windows.Forms.Application.Run(new frmLogin());
        }
    }


 }
