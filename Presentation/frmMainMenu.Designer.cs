namespace Inventory_Management_System_IMS
{
    partial class frmMainMenu
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnProductInventory;
        private System.Windows.Forms.Button btnCustomerDirectory;
        private System.Windows.Forms.Button btnSalesTransaction;
        private System.Windows.Forms.Button btnStockAdjustment;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox pictureBoxLogo;

        #endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnStockAdjustment = new System.Windows.Forms.Button();
            this.btnSalesTransaction = new System.Windows.Forms.Button();
            this.btnCustomerDirectory = new System.Windows.Forms.Button();
            this.btnProductInventory = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
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
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 720);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(12, 620);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(226, 45);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnStockAdjustment
            // 
            this.btnStockAdjustment.BackColor = System.Drawing.Color.Transparent;
            this.btnStockAdjustment.FlatAppearance.BorderSize = 0;
            this.btnStockAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockAdjustment.ForeColor = System.Drawing.Color.White;
            this.btnStockAdjustment.Image = ((System.Drawing.Image)(resources.GetObject("btnStockAdjustment.Image")));
            this.btnStockAdjustment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockAdjustment.Location = new System.Drawing.Point(12, 420);
            this.btnStockAdjustment.Name = "btnStockAdjustment";
            this.btnStockAdjustment.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStockAdjustment.Size = new System.Drawing.Size(226, 45);
            this.btnStockAdjustment.TabIndex = 4;
            this.btnStockAdjustment.Text = "Stock Adjustment";
            this.btnStockAdjustment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockAdjustment.UseVisualStyleBackColor = false;
            this.btnStockAdjustment.Click += new System.EventHandler(this.btnStockAdjustment_Click);
            // 
            // btnSalesTransaction
            // 
            this.btnSalesTransaction.BackColor = System.Drawing.Color.Transparent;
            this.btnSalesTransaction.FlatAppearance.BorderSize = 0;
            this.btnSalesTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesTransaction.ForeColor = System.Drawing.Color.White;
            this.btnSalesTransaction.Image = ((System.Drawing.Image)(resources.GetObject("btnSalesTransaction.Image")));
            this.btnSalesTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesTransaction.Location = new System.Drawing.Point(12, 353);
            this.btnSalesTransaction.Name = "btnSalesTransaction";
            this.btnSalesTransaction.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSalesTransaction.Size = new System.Drawing.Size(226, 45);
            this.btnSalesTransaction.TabIndex = 3;
            this.btnSalesTransaction.Text = "Sales Transaction";
            this.btnSalesTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalesTransaction.UseVisualStyleBackColor = false;
            this.btnSalesTransaction.Click += new System.EventHandler(this.btnSalesTransaction_Click);
            // 
            // btnCustomerDirectory
            // 
            this.btnCustomerDirectory.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomerDirectory.FlatAppearance.BorderSize = 0;
            this.btnCustomerDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerDirectory.ForeColor = System.Drawing.Color.White;
            this.btnCustomerDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerDirectory.Image")));
            this.btnCustomerDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerDirectory.Location = new System.Drawing.Point(12, 286);
            this.btnCustomerDirectory.Name = "btnCustomerDirectory";
            this.btnCustomerDirectory.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCustomerDirectory.Size = new System.Drawing.Size(226, 45);
            this.btnCustomerDirectory.TabIndex = 2;
            this.btnCustomerDirectory.Text = "Customer Directory";
            this.btnCustomerDirectory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomerDirectory.UseVisualStyleBackColor = false;
            this.btnCustomerDirectory.Click += new System.EventHandler(this.btnCustomerDirectory_Click);
            // 
            // btnProductInventory
            // 
            this.btnProductInventory.BackColor = System.Drawing.Color.Transparent;
            this.btnProductInventory.FlatAppearance.BorderSize = 0;
            this.btnProductInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductInventory.ForeColor = System.Drawing.Color.White;
            this.btnProductInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnProductInventory.Image")));
            this.btnProductInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductInventory.Location = new System.Drawing.Point(12, 219);
            this.btnProductInventory.Name = "btnProductInventory";
            this.btnProductInventory.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProductInventory.Size = new System.Drawing.Size(226, 45);
            this.btnProductInventory.TabIndex = 1;
            this.btnProductInventory.Text = "Product Inventory";
            this.btnProductInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductInventory.UseVisualStyleBackColor = false;
            this.btnProductInventory.Click += new System.EventHandler(this.btnProductInventory_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(92)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(12, 152);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(226, 45);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.panelTop.Controls.Add(this.lblSubtitle);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(250, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(984, 80);
            this.panelTop.TabIndex = 1;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblSubtitle.Location = new System.Drawing.Point(20, 50);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(287, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Inventory & Sales Management Platform";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(363, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Inventory Management System";
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelMainContent.Controls.Add(this.pictureBoxLogo);
            this.panelMainContent.Controls.Add(this.lblWelcome);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(250, 80);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(984, 640);
            this.panelMainContent.TabIndex = 2;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(392, 220);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(89)))));
            this.lblWelcome.Location = new System.Drawing.Point(342, 150);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(300, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome Back!";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 720);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1250, 760);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management System - Main Menu";
            this.panelSidebar.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMainContent.ResumeLayout(false);
            this.panelMainContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}