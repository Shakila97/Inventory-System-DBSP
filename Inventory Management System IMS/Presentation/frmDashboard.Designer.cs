namespace Inventory_Management_System
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel panelWidgets;
        private System.Windows.Forms.Panel pnlTotalProducts;
        private System.Windows.Forms.Label lblTotalProductsValue;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Panel dgvLowStock;
        private System.Windows.Forms.Label lblLowStockValue;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Panel lblTodayRevenue;
        private System.Windows.Forms.Label lblTodaysRevenueValue;
        private System.Windows.Forms.Label lblTodaysRevenue;
        private System.Windows.Forms.Panel pnlTotalCustomers;
        private System.Windows.Forms.Label lblTotalCustomersValue;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.GroupBox grpRevenueChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.GroupBox grpLowStockAlert;
        private System.Windows.Forms.DataGridView dgvLowStockAlert;
        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelWidgets = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTotalProducts = new System.Windows.Forms.Panel();
            this.lblTotalProductsValue = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.dgvLowStock = new System.Windows.Forms.Panel();
            this.lblLowStockValue = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblTodayRevenue = new System.Windows.Forms.Panel();
            this.lblTodaysRevenueValue = new System.Windows.Forms.Label();
            this.lblTodaysRevenue = new System.Windows.Forms.Label();
            this.pnlTotalCustomers = new System.Windows.Forms.Panel();
            this.lblTotalCustomersValue = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.grpRevenueChart = new System.Windows.Forms.GroupBox();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpLowStockAlert = new System.Windows.Forms.GroupBox();
            this.dgvLowStockAlert = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelWidgets.SuspendLayout();
            this.pnlTotalProducts.SuspendLayout();
            this.dgvLowStock.SuspendLayout();
            this.lblTodayRevenue.SuspendLayout();
            this.pnlTotalCustomers.SuspendLayout();
            this.grpRevenueChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.grpLowStockAlert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStockAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(89)))));
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1284, 80);
            this.panelTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(92)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1150, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(140, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";
            // 
            // panelWidgets
            // 
            this.panelWidgets.Controls.Add(this.pnlTotalProducts);
            this.panelWidgets.Controls.Add(this.dgvLowStock);
            this.panelWidgets.Controls.Add(this.lblTodayRevenue);
            this.panelWidgets.Controls.Add(this.pnlTotalCustomers);
            this.panelWidgets.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWidgets.Location = new System.Drawing.Point(0, 80);
            this.panelWidgets.Name = "panelWidgets";
            this.panelWidgets.Size = new System.Drawing.Size(1284, 120);
            this.panelWidgets.TabIndex = 1;
            // 
            // pnlTotalProducts
            // 
            this.pnlTotalProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(120)))), ((int)(((byte)(197)))));
            this.pnlTotalProducts.Controls.Add(this.lblTotalProductsValue);
            this.pnlTotalProducts.Controls.Add(this.lblTotalProducts);
            this.pnlTotalProducts.Location = new System.Drawing.Point(3, 3);
            this.pnlTotalProducts.Name = "pnlTotalProducts";
            this.pnlTotalProducts.Size = new System.Drawing.Size(280, 110);
            this.pnlTotalProducts.TabIndex = 0;
            // 
            // lblTotalProductsValue
            // 
            this.lblTotalProductsValue.AutoSize = true;
            this.lblTotalProductsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalProductsValue.Location = new System.Drawing.Point(20, 50);
            this.lblTotalProductsValue.Name = "lblTotalProductsValue";
            this.lblTotalProductsValue.Size = new System.Drawing.Size(36, 37);
            this.lblTotalProductsValue.TabIndex = 1;
            this.lblTotalProductsValue.Text = "0";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTotalProducts.ForeColor = System.Drawing.Color.White;
            this.lblTotalProducts.Location = new System.Drawing.Point(20, 20);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(100, 17);
            this.lblTotalProducts.TabIndex = 0;
            this.lblTotalProducts.Text = "Total Products";
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.dgvLowStock.Controls.Add(this.lblLowStockValue);
            this.dgvLowStock.Controls.Add(this.lblLowStock);
            this.dgvLowStock.Location = new System.Drawing.Point(289, 3);
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.Size = new System.Drawing.Size(280, 110);
            this.dgvLowStock.TabIndex = 1;
            // 
            // lblLowStockValue
            // 
            this.lblLowStockValue.AutoSize = true;
            this.lblLowStockValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblLowStockValue.ForeColor = System.Drawing.Color.White;
            this.lblLowStockValue.Location = new System.Drawing.Point(20, 50);
            this.lblLowStockValue.Name = "lblLowStockValue";
            this.lblLowStockValue.Size = new System.Drawing.Size(36, 37);
            this.lblLowStockValue.TabIndex = 1;
            this.lblLowStockValue.Text = "0";
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblLowStock.ForeColor = System.Drawing.Color.White;
            this.lblLowStock.Location = new System.Drawing.Point(20, 20);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(109, 17);
            this.lblLowStock.TabIndex = 0;
            this.lblLowStock.Text = "Low Stock Items";
            // 
            // lblTodayRevenue
            // 
            this.lblTodayRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(92)))));
            this.lblTodayRevenue.Controls.Add(this.lblTodaysRevenueValue);
            this.lblTodayRevenue.Controls.Add(this.lblTodaysRevenue);
            this.lblTodayRevenue.Location = new System.Drawing.Point(575, 3);
            this.lblTodayRevenue.Name = "lblTodayRevenue";
            this.lblTodayRevenue.Size = new System.Drawing.Size(280, 110);
            this.lblTodayRevenue.TabIndex = 2;
            // 
            // lblTodaysRevenueValue
            // 
            this.lblTodaysRevenueValue.AutoSize = true;
            this.lblTodaysRevenueValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTodaysRevenueValue.ForeColor = System.Drawing.Color.White;
            this.lblTodaysRevenueValue.Location = new System.Drawing.Point(20, 50);
            this.lblTodaysRevenueValue.Name = "lblTodaysRevenueValue";
            this.lblTodaysRevenueValue.Size = new System.Drawing.Size(103, 37);
            this.lblTodaysRevenueValue.TabIndex = 1;
            this.lblTodaysRevenueValue.Text = "$0.00";
            // 
            // lblTodaysRevenue
            // 
            this.lblTodaysRevenue.AutoSize = true;
            this.lblTodaysRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTodaysRevenue.ForeColor = System.Drawing.Color.White;
            this.lblTodaysRevenue.Location = new System.Drawing.Point(20, 20);
            this.lblTodaysRevenue.Name = "lblTodaysRevenue";
            this.lblTodaysRevenue.Size = new System.Drawing.Size(119, 17);
            this.lblTodaysRevenue.TabIndex = 0;
            this.lblTodaysRevenue.Text = "Today\'s Revenue";
            // 
            // pnlTotalCustomers
            // 
            this.pnlTotalCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(194)))));
            this.pnlTotalCustomers.Controls.Add(this.lblTotalCustomersValue);
            this.pnlTotalCustomers.Controls.Add(this.lblTotalCustomers);
            this.pnlTotalCustomers.Location = new System.Drawing.Point(861, 3);
            this.pnlTotalCustomers.Name = "pnlTotalCustomers";
            this.pnlTotalCustomers.Size = new System.Drawing.Size(280, 110);
            this.pnlTotalCustomers.TabIndex = 3;
            this.pnlTotalCustomers.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotalCustomers_Paint);
            // 
            // lblTotalCustomersValue
            // 
            this.lblTotalCustomersValue.AutoSize = true;
            this.lblTotalCustomersValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomersValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalCustomersValue.Location = new System.Drawing.Point(20, 50);
            this.lblTotalCustomersValue.Name = "lblTotalCustomersValue";
            this.lblTotalCustomersValue.Size = new System.Drawing.Size(36, 37);
            this.lblTotalCustomersValue.TabIndex = 1;
            this.lblTotalCustomersValue.Text = "0";
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.AutoSize = true;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.White;
            this.lblTotalCustomers.Location = new System.Drawing.Point(20, 20);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(111, 17);
            this.lblTotalCustomers.TabIndex = 0;
            this.lblTotalCustomers.Text = "Total Customers";
            // 
            // grpRevenueChart
            // 
            this.grpRevenueChart.Controls.Add(this.chartRevenue);
            this.grpRevenueChart.Location = new System.Drawing.Point(20, 210);
            this.grpRevenueChart.Name = "grpRevenueChart";
            this.grpRevenueChart.Size = new System.Drawing.Size(800, 350);
            this.grpRevenueChart.TabIndex = 2;
            this.grpRevenueChart.TabStop = false;
            this.grpRevenueChart.Text = "Revenue Trend (Last 7 Days)";
            // 
            // chartRevenue
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea2);
            this.chartRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend2);
            this.chartRevenue.Location = new System.Drawing.Point(3, 16);
            this.chartRevenue.Name = "chartRevenue";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Revenue";
            this.chartRevenue.Series.Add(series2);
            this.chartRevenue.Size = new System.Drawing.Size(794, 331);
            this.chartRevenue.TabIndex = 0;
            this.chartRevenue.Text = "chart1";
            this.chartRevenue.Click += new System.EventHandler(this.chartRevenue_Click);
            // 
            // grpLowStockAlert
            // 
            this.grpLowStockAlert.Controls.Add(this.dgvLowStockAlert);
            this.grpLowStockAlert.Location = new System.Drawing.Point(840, 210);
            this.grpLowStockAlert.Name = "grpLowStockAlert";
            this.grpLowStockAlert.Size = new System.Drawing.Size(424, 350);
            this.grpLowStockAlert.TabIndex = 3;
            this.grpLowStockAlert.TabStop = false;
            this.grpLowStockAlert.Text = "Low Stock Alert";
            // 
            // dgvLowStockAlert
            // 
            this.dgvLowStockAlert.AllowUserToAddRows = false;
            this.dgvLowStockAlert.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvLowStockAlert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStockAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLowStockAlert.Location = new System.Drawing.Point(3, 16);
            this.dgvLowStockAlert.Name = "dgvLowStockAlert";
            this.dgvLowStockAlert.ReadOnly = true;
            this.dgvLowStockAlert.Size = new System.Drawing.Size(418, 331);
            this.dgvLowStockAlert.TabIndex = 0;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.grpLowStockAlert);
            this.Controls.Add(this.grpRevenueChart);
            this.Controls.Add(this.panelWidgets);
            this.Controls.Add(this.panelTop);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelWidgets.ResumeLayout(false);
            this.pnlTotalProducts.ResumeLayout(false);
            this.pnlTotalProducts.PerformLayout();
            this.dgvLowStock.ResumeLayout(false);
            this.dgvLowStock.PerformLayout();
            this.lblTodayRevenue.ResumeLayout(false);
            this.lblTodayRevenue.PerformLayout();
            this.pnlTotalCustomers.ResumeLayout(false);
            this.pnlTotalCustomers.PerformLayout();
            this.grpRevenueChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.grpLowStockAlert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStockAlert)).EndInit();
            this.ResumeLayout(false);

        }
    }
}