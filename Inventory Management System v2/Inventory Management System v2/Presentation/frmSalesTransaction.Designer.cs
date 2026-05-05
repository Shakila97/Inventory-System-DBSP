namespace InventoryManagementSystemV2.Presentation
{
    partial class frmSalesTransaction
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
            this.pnlSelectors = new System.Windows.Forms.Panel();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnFinalizeSale = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlSelectors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlSelectors
            this.pnlSelectors.BackColor = System.Drawing.Color.White;
            this.pnlSelectors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectors.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectors.Controls.Add(this.btnAddToCart);
            this.pnlSelectors.Controls.Add(this.nudQuantity);
            this.pnlSelectors.Controls.Add(this.cmbProduct);
            this.pnlSelectors.Controls.Add(this.lblProduct);
            this.pnlSelectors.Controls.Add(this.cmbCustomer);
            this.pnlSelectors.Controls.Add(this.lblCustomer);
            this.pnlSelectors.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectors.Name = "pnlSelectors";
            this.pnlSelectors.Size = new System.Drawing.Size(800, 80);
            this.pnlSelectors.TabIndex = 0;

            // Customer Selector
            this.lblCustomer.AutoSize = true; this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblCustomer.Location = new System.Drawing.Point(15, 15); this.lblCustomer.Name = "lblCustomer"; this.lblCustomer.Text = "Customer:";
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(15, 35); this.cmbCustomer.Name = "cmbCustomer"; this.cmbCustomer.Size = new System.Drawing.Size(200, 23);

            // Product Selector
            this.lblProduct.AutoSize = true; this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblProduct.Location = new System.Drawing.Point(230, 15); this.lblProduct.Name = "lblProduct"; this.lblProduct.Text = "Product:";
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(230, 35); this.cmbProduct.Name = "cmbProduct"; this.cmbProduct.Size = new System.Drawing.Size(200, 23);

            // Quantity
            this.nudQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudQuantity.Location = new System.Drawing.Point(445, 35); this.nudQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 }); this.nudQuantity.Name = "nudQuantity"; this.nudQuantity.Size = new System.Drawing.Size(80, 23); this.nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // Add to Cart Button
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(47, 133, 90); this.btnAddToCart.FlatAppearance.BorderSize = 0; this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(540, 33); this.btnAddToCart.Name = "btnAddToCart"; this.btnAddToCart.Size = new System.Drawing.Size(120, 27); this.btnAddToCart.Text = "➕ Add to Cart"; this.btnAddToCart.UseVisualStyleBackColor = false; this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

            // dgvCart
            this.dgvCart.AllowUserToAddRows = false; this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.BackgroundColor = System.Drawing.Color.White; this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None; this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(15, 95); this.dgvCart.Name = "dgvCart"; this.dgvCart.ReadOnly = true; this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvCart.Size = new System.Drawing.Size(770, 330); this.dgvCart.TabIndex = 1;

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Controls.Add(this.lblTotal);
            this.pnlFooter.Controls.Add(this.btnFinalizeSale);
            this.pnlFooter.Location = new System.Drawing.Point(0, 435);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 65);
            this.pnlFooter.TabIndex = 2;

            // Total Label
            this.lblTotal.AutoSize = true; this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(43, 108, 176); this.lblTotal.Location = new System.Drawing.Point(400, 15); this.lblTotal.Name = "lblTotal"; this.lblTotal.Size = new System.Drawing.Size(90, 32); this.lblTotal.Text = "$0.00";

            // Finalize Button
            this.btnFinalizeSale.BackColor = System.Drawing.Color.FromArgb(47, 133, 90); this.btnFinalizeSale.FlatAppearance.BorderSize = 0; this.btnFinalizeSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizeSale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.btnFinalizeSale.ForeColor = System.Drawing.Color.White;
            this.btnFinalizeSale.Location = new System.Drawing.Point(15, 15); this.btnFinalizeSale.Name = "btnFinalizeSale"; this.btnFinalizeSale.Size = new System.Drawing.Size(200, 40); this.btnFinalizeSale.Text = "💰 FINALIZE SALE"; this.btnFinalizeSale.UseVisualStyleBackColor = false; this.btnFinalizeSale.Click += new System.EventHandler(this.btnFinalizeSale_Click);

            // Status Label
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true; this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(650, 45); this.lblStatus.Name = "lblStatus"; this.lblStatus.Size = new System.Drawing.Size(0, 13); this.lblStatus.TabIndex = 3;

            // frmSalesTransaction
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.pnlSelectors);
            this.Name = "frmSalesTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Sales Transaction";
            this.Load += new System.EventHandler(this.frmSalesTransaction_Load);
            this.pnlSelectors.ResumeLayout(false); this.pnlSelectors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlFooter.ResumeLayout(false); this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlSelectors;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnFinalizeSale;
        private System.Windows.Forms.Label lblStatus;
    }
}