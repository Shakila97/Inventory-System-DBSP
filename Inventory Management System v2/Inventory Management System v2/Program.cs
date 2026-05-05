using System;
using WinFormsApp = System.Windows.Forms.Application;
using System.Windows.Forms;
using InventoryManagementSystemV2.Presentation;

namespace InventoryManagementSystemV2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            WinFormsApp.EnableVisualStyles();
            WinFormsApp.SetCompatibleTextRenderingDefault(false);
            WinFormsApp.Run(new frmLogin());
        }
    }
}