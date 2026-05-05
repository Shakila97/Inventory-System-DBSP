namespace InventoryManagementSystemV2.Presentation
{
    partial class frmStockAdjustment
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.lblAfter = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.btnClear);
            this.pnlMain.Controls.Add(this.btnApply);
            this.pnlMain.Controls.Add(this.pnlPreview);
            this.pnlMain.Controls.Add(this.txtReason);
            this.pnlMain.Controls.Add(this.lblReason);
            this.pnlMain.Controls.Add(this.cmbType);
            this.pnlMain.Controls.Add(this.nudQty);
            this.pnlMain.Controls.Add(this.cmbProduct);
            this.pnlMain.Controls.Add(this.lblProduct);
            this.pnlMain.Location = new System.Drawing.Point(50, 40);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(500, 400);
            this.pnlMain.TabIndex = 0;

            // lblProduct
            this.lblProduct.AutoSize = true; this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.lblProduct.Location = new System.Drawing.Point(30, 30); this.lblProduct.Name = "lblProduct"; this.lblProduct.Text = "Select Product:";

            // cmbProduct
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(30, 55); this.cmbProduct.Name = "cmbProduct"; this.cmbProduct.Size = new System.Drawing.Size(440, 23);

            // Adjustment Controls (Inline)
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] { " Add Stock (Restock)", "➖ Remove Stock (Damaged/Sold)" });
            this.cmbType.Location = new System.Drawing.Point(30, 110); this.cmbType.Name = "cmbType"; this.cmbType.Size = new System.Drawing.Size(250, 23);

            this.nudQty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudQty.Location = new System.Drawing.Point(300, 108); this.nudQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.nudQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 }); this.nudQty.Name = "nudQty"; this.nudQty.Size = new System.Drawing.Size(170, 25); this.nudQty.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // Reason Field
            this.lblReason.AutoSize = true; this.lblReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblReason.Location = new System.Drawing.Point(30, 160); this.lblReason.Name = "lblReason"; this.lblReason.Text = "Adjustment Reason:";
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtReason.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReason.Location = new System.Drawing.Point(30, 180); this.txtReason.Multiline = true; this.txtReason.Name = "txtReason"; this.txtReason.Size = new System.Drawing.Size(440, 60); this.txtReason.TabIndex = 3;

            // pnlPreview
            this.pnlPreview.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreview.Controls.Add(this.lblAfter);
            this.pnlPreview.Controls.Add(this.lblCurrent);
            this.pnlPreview.Location = new System.Drawing.Point(30, 260);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(440, 60);
            this.pnlPreview.TabIndex = 4;

            this.lblCurrent.AutoSize = true; this.lblCurrent.Font = new System.Drawing.Font("Segoe UI", 11F); this.lblCurrent.Location = new System.Drawing.Point(30, 15); this.lblCurrent.Name = "lblCurrent"; this.lblCurrent.Text = "Current Stock: 0";
            this.lblAfter.AutoSize = true; this.lblAfter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAfter.ForeColor = System.Drawing.Color.FromArgb(47, 133, 90); this.lblAfter.Location = new System.Drawing.Point(250, 15); this.lblAfter.Name = "lblAfter"; this.lblAfter.Text = "New Stock: 0";

            // Action Buttons
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(47, 133, 90); this.btnApply.FlatAppearance.BorderSize = 0; this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(30, 340); this.btnApply.Name = "btnApply"; this.btnApply.Size = new System.Drawing.Size(200, 35); this.btnApply.Text = "✅ APPLY ADJUSTMENT"; this.btnApply.UseVisualStyleBackColor = false; this.btnApply.Click += new System.EventHandler(this.btnApply_Click);

            this.btnClear.BackColor = System.Drawing.Color.FromArgb(150, 150, 150); this.btnClear.FlatAppearance.BorderSize = 0; this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(250, 340); this.btnClear.Name = "btnClear"; this.btnClear.Size = new System.Drawing.Size(220, 35); this.btnClear.Text = "🔄 RESET FORM"; this.btnClear.UseVisualStyleBackColor = false; this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // frmStockAdjustment
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmStockAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Adjustment";
            this.Load += new System.EventHandler(this.frmStockAdjustment_Load);
            this.pnlMain.ResumeLayout(false); this.pnlMain.PerformLayout();
            this.pnlPreview.ResumeLayout(false); this.pnlPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Label lblAfter;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblProduct;
    }
}