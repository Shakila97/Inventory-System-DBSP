using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;

namespace Inventory_System_DBSP
{
    public partial class frmMainMenu : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        public frmMainMenu()
        {
            InitializeComponent();

            // MaterialSkin අතුරුමුහුණත සැකසීම
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Amber700, Primary.Amber800,
                Primary.Amber500, Accent.Amber200,
                TextShade.WHITE
            );

            // Side Drawer එක Tab Control එකට සම්බන්ධ කිරීම
            // Designer එකේ materialTabControl1 නම නිවැරදි දැයි බලන්න
            DrawerTabControl = materialTabControl1;
        }

        private async void frmMainMenu_Load(object sender, EventArgs e)
        {
            // පළමු වරට Dashboard දත්ත Load කිරීම
            await LoadDashboardStatsAsync();

            // සෑම තත්පර 60කට වරක් Auto-Refresh වීමට Timer එකක්
            Timer refreshTimer = new Timer();
            refreshTimer.Interval = 60000;
            refreshTimer.Tick += async (s, ev) => await LoadDashboardStatsAsync();
            refreshTimer.Start();
        }

        // Blueprint 05: UI එක Freeze නොවී දත්ත Load කිරීම (Async/Await)
        private async Task LoadDashboardStatsAsync()
        {
            try
            {
                using (SqlConnection conn = DatabaseConfig.GetConnection())
                {
                    await conn.OpenAsync();

                    // 1. අද දින ආදායම (Member 05: Function එක භාවිතා කරමින්)
                    SqlCommand cmdRev = new SqlCommand("SELECT dbo.fn_DailyRevenue(CAST(GETDATE() AS DATE))", conn);
                    var revenue = await cmdRev.ExecuteScalarAsync();
                    lblRevenue.Text = "Rs. " + (revenue != DBNull.Value ? Convert.ToDecimal(revenue).ToString("N2") : "0.00");

                    // 2. අඩු තොග පවතින භාණ්ඩ (Member 01: View එක භාවිතා කරමින්)
                    SqlCommand cmdLowStock = new SqlCommand("SELECT COUNT(*) FROM vw_LowStock", conn);
                    int lowStockCount = (int)await cmdLowStock.ExecuteScalarAsync();
                    lblLowStockCount.Text = lowStockCount.ToString();
                    lblLowStockCount.ForeColor = lowStockCount > 0 ? Color.Red : Color.Green;

                    // 3. මුළු පාරිභෝගිකයින් (Member 02)
                    SqlCommand cmdCust = new SqlCommand("SELECT COUNT(*) FROM Customers", conn);
                    lblTotalCustomers.Text = (await cmdCust.ExecuteScalarAsync()).ToString();

                    // 4. මුළු භාණ්ඩ ගණන (Member 01)
                    SqlCommand cmdProd = new SqlCommand("SELECT COUNT(*) FROM Products", conn);
                    lblTotalProducts.Text = (await cmdProd.ExecuteScalarAsync()).ToString();
                }
            }
            catch (Exception ex)
            {
                // Error එකක් ආවොත් ලොකු අවුලක් නොවී Console එකේ පෙන්වන්න
                Console.WriteLine("Dashboard Update Error: " + ex.Message);
            }
        }

        // Logout කිරීමේ logic එක
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("ඔබට පද්ධතියෙන් ඉවත් වීමට අවශ්‍යද?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form1 login = new Form1(); // Form1 යනු ඔබේ Login Form එක නම්
                login.Show();
            }
        }

        private async void frmMainMenu_Load(object sender, EventArgs e)
        {
            // Dashboard දත්ත Load කිරීම ආරම්භ කරන්න
            await LoadDashboardStatsAsync();
        }
    }
}