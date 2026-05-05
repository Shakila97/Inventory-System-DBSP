namespace InventoryManagementSystemV2.Presentation
{
    partial class frmCustomerDirectory
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Controls.Add(this.btnDelete);
            this.pnlHeader.Controls.Add(this.btnEdit);
            this.pnlHeader.Controls.Add(this.btnAdd);
            this.pnlHeader.Controls.Add(this.btnClear);
            this.pnlHeader.Controls.Add(this.btnSearch);
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(850, 60);
            this.pnlHeader.TabIndex = 0;

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(15, 18);
            this.txtSearch.Name = "txtSearch";
            //this.txtSearch.PlaceholderText = "Search customers...";
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            this.txtSearch.TabIndex = 0;

            // Action Buttons (Row 1)
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(43, 108, 176); this.btnSearch.FlatAppearance.BorderSize = 0; this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(225, 18); this.btnSearch.Name = "btnSearch"; this.btnSearch.Size = new System.Drawing.Size(80, 23); this.btnSearch.Text = "🔍 Search"; this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnClear.BackColor = System.Drawing.Color.FromArgb(150, 150, 150); this.btnClear.FlatAppearance.BorderSize = 0; this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(315, 18); this.btnClear.Name = "btnClear"; this.btnClear.Size = new System.Drawing.Size(80, 23); this.btnClear.Text = "🧹 Clear"; this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(47, 133, 90); this.btnAdd.FlatAppearance.BorderSize = 0; this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(420, 18); this.btnAdd.Name = "btnAdd"; this.btnAdd.Size = new System.Drawing.Size(80, 23); this.btnAdd.Text = " Add"; this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(43, 108, 176); this.btnEdit.FlatAppearance.BorderSize = 0; this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(510, 18); this.btnEdit.Name = "btnEdit"; this.btnEdit.Size = new System.Drawing.Size(80, 23); this.btnEdit.Text = "✏️ Edit"; this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(180, 50, 50); this.btnDelete.FlatAppearance.BorderSize = 0; this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(600, 18); this.btnDelete.Name = "btnDelete"; this.btnDelete.Size = new System.Drawing.Size(90, 23); this.btnDelete.Text = "️ Delete"; this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // dgvCustomers
            this.dgvCustomers.AllowUserToAddRows = false; this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None; this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(15, 75); this.dgvCustomers.MultiSelect = false; this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true; this.dgvCustomers.RowHeadersVisible = false; this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(550, 400); this.dgvCustomers.TabIndex = 1;

            // pnlForm (Right Side Panel)
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.lblPhone);
            this.pnlForm.Controls.Add(this.lblName);
            this.pnlForm.Location = new System.Drawing.Point(585, 75);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(250, 400);
            this.pnlForm.TabIndex = 2;

            // Form Fields
            this.lblName.AutoSize = true; this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblName.Location = new System.Drawing.Point(20, 25); this.lblName.Name = "lblName"; this.lblName.Text = "Full Name:";
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(20, 45); this.txtName.Name = "txtName"; this.txtName.Size = new System.Drawing.Size(210, 23); this.txtName.TabIndex = 0;

            this.lblPhone.AutoSize = true; this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblPhone.Location = new System.Drawing.Point(20, 85); this.lblPhone.Name = "lblPhone"; this.lblPhone.Text = "Phone:";
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.Location = new System.Drawing.Point(20, 105); this.txtPhone.Name = "txtPhone"; this.txtPhone.Size = new System.Drawing.Size(210, 23); this.txtPhone.TabIndex = 1;

            this.lblEmail.AutoSize = true; this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblEmail.Location = new System.Drawing.Point(20, 145); this.lblEmail.Name = "lblEmail"; this.lblEmail.Text = "Email Address:";
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(20, 165); this.txtEmail.Name = "txtEmail"; this.txtEmail.Size = new System.Drawing.Size(210, 23); this.txtEmail.TabIndex = 2;

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(47, 133, 90); this.btnSave.FlatAppearance.BorderSize = 0; this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White; this.btnSave.Location = new System.Drawing.Point(20, 220); this.btnSave.Name = "btnSave"; this.btnSave.Size = new System.Drawing.Size(210, 35); this.btnSave.TabIndex = 3;
            this.btnSave.Text = "💾 SAVE"; this.btnSave.UseVisualStyleBackColor = false; this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // frmCustomerDirectory
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmCustomerDirectory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Directory";
            this.Load += new System.EventHandler(this.frmCustomerDirectory_Load);
            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.pnlForm.ResumeLayout(false); this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblName;
    }
}