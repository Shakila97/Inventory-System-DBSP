// frmDashboard.Designer.cs
namespace IMS
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 =
                new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 =
                new System.Windows.Forms.DataVisualization.Charting.Series();

            // ── Controls ────────────────────────────────────────────────────────
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.pnlMetrics = new System.Windows.Forms.Panel();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.lblTodayRevenue = new System.Windows.Forms.Label();
            this.lblCustomerCount = new System.Windows.Forms.Label();

            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();

            // ── Top bar ─────────────────────────────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(28, 20, 7);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 56;
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblTitle, this.lblStatus, this.btnRefresh });

            this.lblTitle.Text = "Management Dashboard";
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(253, 230, 138);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.AutoSize = true;

            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblStatus.Font = new System.Drawing.Font("Consolas", 8f);
            this.lblStatus.Location = new System.Drawing.Point(260, 20);
            this.lblStatus.AutoSize = true;
            this.lblStatus.Text = "Loading...";

            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(253, 230, 138);
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(217, 119, 6);
            this.btnRefresh.Location = new System.Drawing.Point(820, 14);
            this.btnRefresh.Size = new System.Drawing.Size(90, 28);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── Metric labels (simple large numbers) ────────────────────────────
            this.pnlMetrics.Location = new System.Drawing.Point(8, 64);
            this.pnlMetrics.Size = new System.Drawing.Size(940, 80);
            this.pnlMetrics.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                MakeMetricPanel("Total Products",  this.lblProductCount,  0),
                MakeMetricPanel("Low Stock Items", this.lblLowStockCount, 1),
                MakeMetricPanel("Today's Revenue", this.lblTodayRevenue,  2),
                MakeMetricPanel("Total Customers", this.lblCustomerCount, 3)
            });

            // ── Revenue chart ────────────────────────────────────────────────────
            chartArea1.Name = "ChartArea1";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Revenue";
            this.chartRevenue.ChartAreas.Add(chartArea1);
            this.chartRevenue.Series.Add(series1);
            this.chartRevenue.Location = new System.Drawing.Point(8, 152);
            this.chartRevenue.Size = new System.Drawing.Size(580, 280);

            // ── Low stock grid ───────────────────────────────────────────────────
            this.dgvLowStock.Location = new System.Drawing.Point(596, 152);
            this.dgvLowStock.Size = new System.Drawing.Size(360, 280);
            this.dgvLowStock.ReadOnly = true;
            this.dgvLowStock.AllowUserToAddRows = false;
            this.dgvLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ── Form ─────────────────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(966, 460);
            this.Text = "IMS — Management Dashboard";
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.pnlTop,
                this.pnlMetrics,
                this.chartRevenue,
                this.dgvLowStock
            });
            this.Load += new System.EventHandler(this.frmDashboard_Load);
        }

        // Helper: creates a metric panel with a label and value
        private System.Windows.Forms.Panel MakeMetricPanel(
            string caption, System.Windows.Forms.Label valueLabel, int index)
        {
            var pnl = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(228, 70),
                Location = new System.Drawing.Point(index * 234, 0),
                BackColor = System.Drawing.Color.FromArgb(245, 245, 240),
            };
            pnl.Paint += (s, e) =>
            {
                using (var pen = new System.Drawing.Pen(
                    System.Drawing.Color.FromArgb(217, 119, 6), 2))
                    e.Graphics.DrawLine(pen, 0, 0, pnl.Width, 0);
            };

            var lbl = new System.Windows.Forms.Label
            {
                Text = caption,
                Font = new System.Drawing.Font("Consolas", 8f),
                ForeColor = System.Drawing.Color.FromArgb(120, 53, 15),
                Location = new System.Drawing.Point(10, 8),
                AutoSize = true
            };
            valueLabel.Text = "—";
            valueLabel.Font = new System.Drawing.Font("Segoe UI", 22f, System.Drawing.FontStyle.Bold);
            valueLabel.ForeColor = System.Drawing.Color.FromArgb(28, 20, 7);
            valueLabel.Location = new System.Drawing.Point(10, 26);
            valueLabel.AutoSize = true;

            pnl.Controls.Add(lbl);
            pnl.Controls.Add(valueLabel);
            return pnl;
        }

        // ── Fields ───────────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlMetrics;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label lblTodayRevenue;
        private System.Windows.Forms.Label lblCustomerCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.DataGridView dgvLowStock;
    }
}