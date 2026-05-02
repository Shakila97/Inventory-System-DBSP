// frmDashboard.cs
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Inventory_System_DBSP; // ← your namespace

namespace IMS   
{
    public partial class frmDashboard : Form
    {
        private System.Windows.Forms.Timer _autoRefreshTimer;

        public frmDashboard()
        {
            InitializeComponent();
        }

        // ─── FORM LOAD ───────────────────────────────────────────────────────────
        private async void frmDashboard_Load(object sender, EventArgs e)
        {
            SetupChart();
            SetupAutoRefresh();
            await LoadDashboardAsync();
        }

        // ─── MAIN ASYNC LOAD ─────────────────────────────────────────────────────
        private async Task LoadDashboardAsync()
        {
            lblStatus.Text = "Refreshing...";
            btnRefresh.Enabled = false;

            try
            {
                // Run all 4 summary queries concurrently
                var t1 = Task.Run(() => (int)DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Products"));

                var t2 = Task.Run(() => (int)DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM vw_LowStock"));

                var t3 = Task.Run(() => DatabaseHelper.GetDataTable(
                    @"SELECT * FROM dbo.fn_DailyRevenue(
                        CAST(GETDATE() AS DATE),
                        CAST(GETDATE() AS DATE))"));

                var t4 = Task.Run(() => (int)DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Customers"));

                var t5 = Task.Run(() => DatabaseHelper.GetDataTable(
                    @"SELECT * FROM dbo.fn_DailyRevenue(
                        DATEADD(DAY, -29, CAST(GETDATE() AS DATE)),
                        CAST(GETDATE() AS DATE))
                      ORDER BY SaleDate"));

                var t6 = Task.Run(() => DatabaseHelper.GetDataTable(
                    "SELECT * FROM vw_LowStock ORDER BY ShortfallQty DESC"));

                await Task.WhenAll(t1, t2, t3, t4, t5, t6);

                // ── Summary widgets ──────────────────────────────────────────
                lblProductCount.Text = (await t1).ToString("N0");
                lblLowStockCount.Text = (await t2).ToString();
                lblCustomerCount.Text = (await t4).ToString("N0");

                // Low stock count shown in red/orange
                int lowCount = await t2;
                lblLowStockCount.ForeColor = lowCount > 0 ? Color.OrangeRed : Color.SeaGreen;

                // Today's revenue from TVF
                DataTable todayData = await t3;
                decimal todayRevenue = todayData.Rows.Count > 0
                    ? Convert.ToDecimal(todayData.Rows[0]["TotalRevenue"])
                    : 0m;
                lblTodayRevenue.Text = todayRevenue.ToString("C2");

                // ── Revenue chart (last 30 days) ─────────────────────────────
                LoadRevenueChart(await t5);

                // ── Low stock DataGridView ────────────────────────────────────
                dgvLowStock.DataSource = await t6;
                StyleLowStockGrid();

                lblStatus.Text = "Last refresh: " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard load error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Load failed.";
            }
            finally
            {
                btnRefresh.Enabled = true;
            }
        }

        // ─── REVENUE CHART ────────────────────────────────────────────────────────
        private void SetupChart()
        {
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartRevenue.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
            chartRevenue.ChartAreas[0].BackColor = Color.White;
            chartRevenue.BackColor = Color.White;

            chartRevenue.Series["Revenue"].ChartType = SeriesChartType.Column;
            chartRevenue.Series["Revenue"].Color = Color.FromArgb(217, 119, 6);  // amber
            chartRevenue.Series["Revenue"].BorderWidth = 0;
        }

        private void LoadRevenueChart(DataTable dt)
        {
            chartRevenue.Series["Revenue"].Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string date = Convert.ToDateTime(row["SaleDate"]).ToString("MMM dd");
                decimal revenue = Convert.ToDecimal(row["TotalRevenue"]);
                chartRevenue.Series["Revenue"].Points.AddXY(date, revenue);
            }

            // Tooltip shows exact values on hover
            chartRevenue.Series["Revenue"]["PointWidth"] = "0.6";
            foreach (DataPoint pt in chartRevenue.Series["Revenue"].Points)
                pt.ToolTip = ((decimal)pt.YValues[0]).ToString("C2");
        }

        // ─── LOW STOCK GRID STYLING ───────────────────────────────────────────────
        private void StyleLowStockGrid()
        {
            dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLowStock.RowHeadersVisible = false;
            dgvLowStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLowStock.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvLowStock.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvLowStock.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(255, 251, 235);  // pale amber

            // Color rows by urgency
            foreach (DataGridViewRow row in dgvLowStock.Rows)
            {
                if (row.IsNewRow) continue;
                int stock = Convert.ToInt32(row.Cells["UnitsInStock"].Value);
                int reorder = Convert.ToInt32(row.Cells["ReorderLevel"].Value);
                double ratio = stock / (double)reorder;

                row.DefaultCellStyle.BackColor = ratio < 0.2
                    ? Color.FromArgb(254, 226, 226)   // red  — critical
                    : Color.FromArgb(254, 243, 199);  // amber — warning
            }
        }

        // ─── AUTO-REFRESH (every 60 seconds) ─────────────────────────────────────
        private void SetupAutoRefresh()
        {
            _autoRefreshTimer = new System.Windows.Forms.Timer();
            _autoRefreshTimer.Interval = 60_000;  // 60 seconds
            _autoRefreshTimer.Tick += async (s, e) => await LoadDashboardAsync();
            _autoRefreshTimer.Start();
        }

        // ─── BUTTON HANDLERS ──────────────────────────────────────────────────────
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDashboardAsync();
        }

        // ─── CLEANUP ──────────────────────────────────────────────────────────────
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _autoRefreshTimer?.Stop();
            _autoRefreshTimer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}