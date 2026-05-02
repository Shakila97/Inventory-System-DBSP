namespace InventorySystem.Presentation
{
    partial class frmStockAdjustment
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpAdjustment;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblCurrentStock;
        private System.Windows.Forms.Label lblCurrentStockValue;
        private System.Windows.Forms.Label lblAdjustmentType;
        private System.Windows.Forms.ComboBox cmbAdjustmentType;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnAdjust;
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvAdjustmentHistory;

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
            this.SuspendLayout();
            // 
            // frmStockAdjustment
            // 
            this.ClientSize = new System.Drawing.Size(855, 484);
            this.Name = "frmStockAdjustment";
            this.ResumeLayout(false);

        }
    }
}