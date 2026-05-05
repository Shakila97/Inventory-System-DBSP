using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystemV2.Application.BLL;
using InventoryManagementSystemV2.Application.DAL;
using System.Windows.Forms.DataVisualization.Charting;

namespace InventoryManagementSystemV2.Presentation
{
    public partial class frmDashboard : Form
    {
        public frmDashboard() => InitializeComponent();

        private async void frmDashboard_Load(object sender, EventArgs e) => await LoadDashboardDataAsync();
        private async void btnRefresh_Click(object sender, EventArgs e) => await LoadDashboardDataAsync();

        private async Task LoadDashboardDataAsync()
        {
            btnRefresh.Enabled = false;
            lblStatus.Text = "Loading analytics...";

            try
            {
                // Parallel async calls for performance
                var lowStockTask = Task.Run(() => ProductBLL.GetLowStockProducts());
                var revenueTask = Task.Run(() => SaleBLL.GetRevenueReport(DateTime.Today.AddDays(-30), DateTime.Today));
                var prodCountTask = Task.Run(() => DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Products"));
                var custCountTask = Task.Run(() => DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Customers"));
                var todayRevTask = Task.Run(() => DatabaseHelper.ExecuteScalar("SELECT ISNULL(SUM(TotalAmount),0) FROM Sales WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)"));

                await Task.WhenAll(lowStockTask, revenueTask, prodCountTask, custCountTask, todayRevTask);

                Invoke(new Action(() =>
                {
                    lblTotalProducts.Text = $"📦 Products: {prodCountTask.Result}";
                    lblTotalCustomers.Text = $" Customers: {custCountTask.Result}";
                    lblLowStockCount.Text = $"⚠️ Low Stock: {lowStockTask.Result.Rows.Count}";
                    lblTodayRevenue.Text = $"💰 Today: ${Convert.ToDecimal(todayRevTask.Result):F2}";

                    dgvLowStock.DataSource = lowStockTask.Result;
                    dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvLowStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvLowStock.ReadOnly = true;
                    dgvLowStock.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;

                    BindRevenueChart(revenueTask.Result);
                    lblStatus.Text = "✅ Dashboard loaded";
                }));
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"❌ Error: {ex.Message}";
            }
            finally
            {
                btnRefresh.Enabled = true;
            }
        }

        private void BindRevenueChart(DataTable data)
        {
            chartRevenue.Series.Clear();
            var series = new Series("Daily Revenue")
            {
                ChartType = SeriesChartType.Column,
                XValueMember = "SaleDate",
                YValueMembers = "TotalRevenue",
                Color = System.Drawing.Color.FromArgb(43, 108, 176),
                IsValueShownAsLabel = true,
                LabelFormat = "${0:F0}"
            };
            chartRevenue.DataSource = data;
            chartRevenue.Series.Add(series);
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.Format = "MMM dd";
            chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "${0:F0}";
        }
    }
}