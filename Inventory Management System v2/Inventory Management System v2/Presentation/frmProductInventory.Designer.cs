namespace InventoryManagementSystemV2.Presentation
{
    partial class frmProductInventory
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.tabLowStock = new System.Windows.Forms.TabPage();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tabLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnDeleteProduct);
            this.pnlHeader.Controls.Add(this.btnEditProduct);
            this.pnlHeader.Controls.Add(this.btnAddProduct);
            this.pnlHeader.Controls.Add(this.btnSearch);
            this.pnlHeader.Controls.Add(this.cmbCategory);
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            this.pnlHeader.TabIndex = 0;

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(15, 18);
            this.txtSearch.Name = "txtSearch";
            
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            this.txtSearch.TabIndex = 0;

            // cmbCategory
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(225, 18);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 23);
            this.cmbCategory.TabIndex = 1;

            // Buttons (Consistent Sizing)
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(43, 108, 176); this.btnSearch.FlatAppearance.BorderSize = 0; this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(385, 18); this.btnSearch.Name = "btnSearch"; this.btnSearch.Size = new System.Drawing.Size(80, 23); this.btnSearch.Text = "🔍 Search"; this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(47, 133, 90); this.btnAddProduct.FlatAppearance.BorderSize = 0; this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(475, 18); this.btnAddProduct.Name = "btnAddProduct"; this.btnAddProduct.Size = new System.Drawing.Size(90, 23); this.btnAddProduct.Text = "➕ Add New"; this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);

            this.btnEditProduct.BackColor = System.Drawing.Color.FromArgb(43, 108, 176); this.btnEditProduct.FlatAppearance.BorderSize = 0; this.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnEditProduct.ForeColor = System.Drawing.Color.White;
            this.btnEditProduct.Location = new System.Drawing.Point(575, 18); this.btnEditProduct.Name = "btnEditProduct"; this.btnEditProduct.Size = new System.Drawing.Size(80, 23); this.btnEditProduct.Text = "✏️ Edit"; this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);

            this.btnDeleteProduct.BackColor = System.Drawing.Color.FromArgb(180, 50, 50); this.btnDeleteProduct.FlatAppearance.BorderSize = 0; this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnDeleteProduct.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProduct.Location = new System.Drawing.Point(665, 18); this.btnDeleteProduct.Name = "btnDeleteProduct"; this.btnDeleteProduct.Size = new System.Drawing.Size(90, 23); this.btnDeleteProduct.Text = "🗑️ Delete"; this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(150, 150, 150); this.btnRefresh.FlatAppearance.BorderSize = 0; this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(765, 18); this.btnRefresh.Name = "btnRefresh"; this.btnRefresh.Size = new System.Drawing.Size(25, 23); this.btnRefresh.Text = "🔄"; this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // TabControl
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 440);
            this.tabControl.TabIndex = 1;

            // Tab: All Products
            this.dgvInventory.AllowUserToAddRows = false; this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None; this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvInventory.Location = new System.Drawing.Point(3, 3); this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true; this.dgvInventory.RowHeadersVisible = false; this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(786, 406); this.dgvInventory.TabIndex = 0;
            this.tabProducts.Controls.Add(this.dgvInventory);
            this.tabProducts.Location = new System.Drawing.Point(4, 26); this.tabProducts.Name = "tabProducts"; this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(792, 412); this.tabProducts.TabIndex = 0; this.tabProducts.Text = " All Products "; this.tabProducts.UseVisualStyleBackColor = true;

            // Tab: Low Stock
            this.dgvLowStock.AllowUserToAddRows = false; this.dgvLowStock.AllowUserToDeleteRows = false;
            this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvLowStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvLowStock.BorderStyle = System.Windows.Forms.BorderStyle.None; this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvLowStock.Location = new System.Drawing.Point(3, 3); this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.ReadOnly = true; this.dgvLowStock.RowHeadersVisible = false; this.dgvLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLowStock.Size = new System.Drawing.Size(786, 406); this.dgvLowStock.TabIndex = 1;
            this.tabLowStock.Controls.Add(this.dgvLowStock);
            this.tabLowStock.Location = new System.Drawing.Point(4, 26); this.tabLowStock.Name = "tabLowStock"; this.tabLowStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabLowStock.Size = new System.Drawing.Size(792, 412); this.tabLowStock.TabIndex = 1; this.tabLowStock.Text = " ⚠️ Low Stock Alert "; this.tabLowStock.UseVisualStyleBackColor = true;

            // frmProductInventory
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmProductInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Inventory";
            this.Load += new System.EventHandler(this.frmProductInventory_Load);
            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            this.tabControl.ResumeLayout(false); this.tabProducts.ResumeLayout(false); this.tabLowStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabLowStock;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvLowStock;
    }
}