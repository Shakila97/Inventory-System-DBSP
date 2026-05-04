using InventoryManagementSystem.Application.BLL;
using InventoryManagementSystem.Application.DAL;
using InventoryManagementSystemV2.Application.BLL;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace InventoryManagementSystem.Presentation
{
    public partial class frmDashboard : UserControl // or Form
    {
        public frmDashboard() => InitializeComponent();

        private async void frmDashboard_Load(object sender, EventArgs e) => await LoadDashboardDataAsync();

        private async Task LoadDashboardDataAsync()
        {
            btnRefresh.Enabled = false;
            lblStatus.Text = "Loading...";

            await Task.Run(() =>
            {
                DataTable lowStock = DatabaseHelper.GetDataTable("vw_LowStock");
                DataTable revenue = SaleBLL.GetRevenueReport(DateTime.Today.AddDays(-30), DateTime.Today);
                int totalProducts = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Products"));
                int totalCustomers = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Customers"));

                Invoke(new Action(() =>
                {
                    lblTotalProducts.Text = totalProducts.ToString();
                    lblTotalCustomers.Text = totalCustomers.ToString();
                    dgvLowStock.DataSource = lowStock;
                    BindRevenueChart(revenue);
                    lblStatus.Text = "Ready";
                }));
            });
            btnRefresh.Enabled = true;
        }

        private void BindRevenueChart(DataTable data)
        {
            chartRevenue.Series.Clear();
            var series = new Series("Daily Revenue");
            series.ChartType = SeriesChartType.Column;
            series.XValueMember = "SaleDate";
            series.YValueMembers = "TotalRevenue";
            chartRevenue.DataSource = data;
            chartRevenue.Series.Add(series);
        }

        private async void btnRefresh_Click(object sender, EventArgs e) => await LoadDashboardDataAsync();
    }
}