namespace InventorySystem.Presentation
{
    partial class frmMainMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnProductInventory;
        private System.Windows.Forms.Button btnCustomerDirectory;
        private System.Windows.Forms.Button btnSalesTransaction;
        private System.Windows.Forms.Button btnStockAdjustment;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel panelMain;

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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnStockAdjustment = new System.Windows.Forms.Button();
            this.btnSalesTransaction = new System.Windows.Forms.Button();
            this.btnCustomerDirectory = new System.Windows.Forms.Button();
            this.btnProductInventory = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(89)))));
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnStockAdjustment);
            this.panelSidebar.Controls.Add(this.btnSalesTransaction);
            this.panelSidebar.Controls.Add(this.btnCustomerDirectory);
            this.panelSidebar.Controls.Add(this.btnProductInventory);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.lblAppName);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 661);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 596);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(250, 65);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnStockAdjustment
            // 
            this.btnStockAdjustment.BackColor = System.Drawing.Color.Transparent;
            this.btnStockAdjustment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockAdjustment.FlatAppearance.BorderSize = 0;
            this.btnStockAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnStockAdjustment.ForeColor = System.Drawing.Color.White;
            this.btnStockAdjustment.Location = new System.Drawing.Point(0, 390);
            this.btnStockAdjustment.Name = "btnStockAdjustment";
            this.btnStockAdjustment.Size = new System.Drawing.Size(250, 65);
            this.btnStockAdjustment.TabIndex = 5;
            this.btnStockAdjustment.Text = "Stock Adjustment";
            this.btnStockAdjustment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockAdjustment.UseVisualStyleBackColor = false;
            this.btnStockAdjustment.Click += new System.EventHandler(this.btnStockAdjustment_Click);
            // 
            // btnSalesTransaction
            // 
            this.btnSalesTransaction.BackColor = System.Drawing.Color.Transparent;
            this.btnSalesTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalesTransaction.FlatAppearance.BorderSize = 0;
            this.btnSalesTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSalesTransaction.ForeColor = System.Drawing.Color.White;
            this.btnSalesTransaction.Location = new System.Drawing.Point(0, 325);
            this.btnSalesTransaction.Name = "btnSalesTransaction";
            this.btnSalesTransaction.Size = new System.Drawing.Size(250, 65);
            this.btnSalesTransaction.TabIndex = 4;
            this.btnSalesTransaction.Text = "Sales Transaction";
            this.btnSalesTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesTransaction.UseVisualStyleBackColor = false;
            this.btnSalesTransaction.Click += new System.EventHandler(this.btnSalesTransaction_Click);
            // 
            // btnCustomerDirectory
            // 
            this.btnCustomerDirectory.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomerDirectory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomerDirectory.FlatAppearance.BorderSize = 0;
            this.btnCustomerDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCustomerDirectory.ForeColor = System.Drawing.Color.White;
            this.btnCustomerDirectory.Location = new System.Drawing.Point(0, 260);
            this.btnCustomerDirectory.Name = "btnCustomerDirectory";
            this.btnCustomerDirectory.Size = new System.Drawing.Size(250, 65);
            this.btnCustomerDirectory.TabIndex = 3;
            this.btnCustomerDirectory.Text = "Customer Directory";
            this.btnCustomerDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerDirectory.UseVisualStyleBackColor = false;
            this.btnCustomerDirectory.Click += new System.EventHandler(this.btnCustomerDirectory_Click);
            // 
            // btnProductInventory
            // 
            this.btnProductInventory.BackColor = System.Drawing.Color.Transparent;
            this.btnProductInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductInventory.FlatAppearance.BorderSize = 0;
            this.btnProductInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnProductInventory.ForeColor = System.Drawing.Color.White;
            this.btnProductInventory.Location = new System.Drawing.Point(0, 195);
            this.btnProductInventory.Name = "btnProductInventory";
            this.btnProductInventory.Size = new System.Drawing.Size(250, 65);
            this.btnProductInventory.TabIndex = 2;
            this.btnProductInventory.Text = "Product Inventory";
            this.btnProductInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductInventory.UseVisualStyleBackColor = false;
            this.btnProductInventory.Click += new System.EventHandler(this.btnProductInventory_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 130);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(250, 65);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // lblAppName
            // 
            this.lblAppName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(92)))));
            this.lblAppName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(0, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblAppName.Size = new System.Drawing.Size(250, 130);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "IMS\r\nInventory Management";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(250, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(814, 661);
            this.panelMain.TabIndex = 1;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 661);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.MinimumSize = new System.Drawing.Size(1080, 700);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management System - Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}