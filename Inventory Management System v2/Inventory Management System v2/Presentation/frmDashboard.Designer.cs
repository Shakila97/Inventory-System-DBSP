namespace InventoryManagementSystemV2.Presentation
{
    partial class frmDashboard
    {
                private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblTodayRevenue = new System.Windows.Forms.Label();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.SuspendLayout();

            // pnlStats (Top Header)
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Controls.Add(this.lblTodayRevenue);
            this.pnlStats.Controls.Add(this.lblLowStockCount);
            this.pnlStats.Controls.Add(this.lblTotalCustomers);
            this.pnlStats.Controls.Add(this.lblTotalProducts);
            this.pnlStats.Location = new System.Drawing.Point(0, 0);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(900, 80);
            this.pnlStats.TabIndex = 0;

            // Stat Labels
            this.lblTotalProducts.AutoSize = true; this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.ForeColor = System.Drawing.Color.FromArgb(47, 133, 90); this.lblTotalProducts.Location = new System.Drawing.Point(30, 25); this.lblTotalProducts.Name = "lblTotalProducts"; this.lblTotalProducts.Text = " Products: 0";

            this.lblTotalCustomers.AutoSize = true; this.lblTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.FromArgb(43, 108, 176); this.lblTotalCustomers.Location = new System.Drawing.Point(250, 25); this.lblTotalCustomers.Name = "lblTotalCustomers"; this.lblTotalCustomers.Text = "👥 Customers: 0";

            this.lblLowStockCount.AutoSize = true; this.lblLowStockCount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLowStockCount.ForeColor = System.Drawing.Color.FromArgb(180, 80, 50); this.lblLowStockCount.Location = new System.Drawing.Point(470, 25); this.lblLowStockCount.Name = "lblLowStockCount"; this.lblLowStockCount.Text = "⚠️ Low Stock: 0";

            this.lblTodayRevenue.AutoSize = true; this.lblTodayRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTodayRevenue.ForeColor = System.Drawing.Color.FromArgb(100, 80, 180); this.lblTodayRevenue.Location = new System.Drawing.Point(690, 25); this.lblTodayRevenue.Name = "lblTodayRevenue"; this.lblTodayRevenue.Text = "💰 Today: $0.00";

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(150, 150, 150); this.btnRefresh.FlatAppearance.BorderSize = 0; this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White; this.btnRefresh.Location = new System.Drawing.Point(800, 20); this.btnRefresh.Name = "btnRefresh"; this.btnRefresh.Size = new System.Drawing.Size(80, 30); this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // chartRevenue (Left Content)
            this.chartRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.chartRevenue.BackColor = System.Drawing.Color.White; this.chartRevenue.Location = new System.Drawing.Point(20, 100);
            this.chartRevenue.Name = "chartRevenue"; this.chartRevenue.Size = new System.Drawing.Size(600, 380);
            this.chartRevenue.TabIndex = 1;

            // dgvLowStock (Right Content)
            this.dgvLowStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLowStock.BackgroundColor = System.Drawing.Color.White; this.dgvLowStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize; this.dgvLowStock.Location = new System.Drawing.Point(640, 100);
            this.dgvLowStock.Name = "dgvLowStock"; this.dgvLowStock.ReadOnly = true; this.dgvLowStock.RowHeadersVisible = false;
            this.dgvLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvLowStock.Size = new System.Drawing.Size(240, 380);
            this.dgvLowStock.TabIndex = 2;

            // lblStatus
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true; this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(20, 490); this.lblStatus.Name = "lblStatus"; this.lblStatus.Size = new System.Drawing.Size(0, 13); this.lblStatus.TabIndex = 3;

            // frmDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvLowStock);
            this.Controls.Add(this.chartRevenue);
            this.Controls.Add(this.pnlStats);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Management Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.pnlStats.ResumeLayout(false); this.pnlStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label lblTodayRevenue;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.Label lblStatus;
    }
}