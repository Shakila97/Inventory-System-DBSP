using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using InventorySystem.BLL;


namespace Inventory_Management_System
{
    public partial class frmDashboard : Form
    {
        private readonly System.Timers.Timer _autoRefreshTimer;
        private readonly DateTime _startDate = DateTime.Today.AddDays(-30); // 30-day default window
        private readonly DateTime _endDate = DateTime.Today;

        public frmDashboard()
        {
            InitializeComponent();
            ConfigureForm();
            SetupChart();
            SetupAutoRefresh();
        }

        private void ConfigureForm()
        {
            this.Text = "IMS - Management Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += async (s, e) => await LoadDashboardDataAsync();
        }

        /// <summary>
        /// Loads all dashboard data on background thread to keep UI responsive.
        /// </summary>
        private async Task LoadDashboardDataAsync()
        {
            SetLoadingState(true);
            try
            {
                var results = await Task.Run(() => FetchDataFromBLL());
                UpdateWidgets(results.Summary);
                UpdateLowStockGrid(results.LowStock);
                UpdateRevenueChart(results.Revenue);
                SetStatus("✅ Dashboard refreshed.", Color.Green);
            }
            catch (Exception ex)
            {
                SetStatus($"❌ Load failed: {ex.Message}", Color.Crimson);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private (DataTable Summary, DataTable LowStock, DataTable Revenue) FetchDataFromBLL()
        {
            return (
                DashboardBLL.GetSummaryCounts(),
                DashboardBLL.GetLowStockAlerts(),
                DashboardBLL.GetDailyRevenue(_startDate, _endDate)
            );
        }

        private void UpdateWidgets(DataTable dt)
        {
            if (dt.Rows.Count == 0) return;
            var row = dt.Rows[0];

            lblTotalProducts.Text = Convert.ToInt32(row["TotalProducts"]).ToString("N0");
            lblLowStock.Text = Convert.ToInt32(row["LowStockCount"]).ToString("N0");
            lblTotalCustomers.Text = Convert.ToInt32(row["TotalCustomers"]).ToString("N0");
            lblTodayRevenue.Text = Convert.ToDecimal(row["TodayRevenue"]).ToString("C2", CultureInfo.CurrentCulture);

            // Dynamic color feedback for low stock
            lblLowStock.ForeColor = Convert.ToInt32(row["LowStockCount"]) > 0 ? Color.Crimson : Color.ForestGreen;
        }

        private void UpdateLowStockGrid(DataTable dt)
        {
            dgvLowStock.DataSource = dt;
            if (dgvLowStock.Columns.Count == 0) return;

            // Format columns
            dgvLowStock.Columns["ProductID"].Visible = false;
            dgvLowStock.Columns["UnitsInStock"].DefaultCellStyle.ForeColor = Color.Crimson;
            dgvLowStock.Columns["UnitsInStock"].DefaultCellStyle.Font = new Font(dgvLowStock.Font, FontStyle.Bold);
            dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLowStock.ReadOnly = true;
            dgvLowStock.AllowUserToAddRows = false;
        }

        private void UpdateRevenueChart(DataTable dt)
        {
            var series = chtRevenue.Series["Revenue"];
            series.Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                var date = Convert.ToDateTime(row["SaleDate"]).ToString("MM/dd");
                var revenue = Convert.ToDecimal(row["TotalRevenue"]);
                series.Points.AddXY(date, revenue);
            }

            chtRevenue.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd";
            chtRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
            chtRevenue.ChartAreas[0].AxisY.Title = "Revenue ($)";
            chtRevenue.ChartAreas[0].AxisX.Title = "Date";
        }

        private void SetupChart()
        {
            chtRevenue.Series.Clear();
            var series = new Series("Revenue")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(45, 128, 250),
                BorderWidth = 2,
                IsValueShownAsLabel = false
            };
            chtRevenue.Series.Add(series);
            chtRevenue.ChartAreas.Clear();
            chtRevenue.ChartAreas.Add(new ChartArea("MainArea") { BackColor = Color.Transparent });
            chtRevenue.Legends.Clear();
        }

        private void SetupAutoRefresh()
        {
            _autoRefreshTimer = new System.Timers.Timer(60000); // 60 seconds
            _autoRefreshTimer.Elapsed += (s, e) => this.Invoke(new Action(async () => await LoadDashboardDataAsync()));
            _autoRefreshTimer.AutoReset = true;
            _autoRefreshTimer.Start();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDashboardDataAsync();
        }

        private void SetLoadingState(bool isLoading)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetLoadingState(isLoading))); return; }
            btnRefresh.Enabled = !isLoading;
            this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        }

        private void SetStatus(string message, Color color)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetStatus(message, color))); return; }
            // Assuming a lblStatus exists on the form. Safe to call even if missing.
            if (this.Controls.ContainsKey("lblStatus"))
            {
                var lbl = (Label)this.Controls["lblStatus"];
                lbl.Text = message;
                lbl.ForeColor = color;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _autoRefreshTimer?.Stop();
            _autoRefreshTimer?.Dispose();
            base.OnFormClosing(e);
        }

        private void pnlTotalCustomers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartRevenue_Click(object sender, EventArgs e)
        {

        }
    }
}