using InventoryManagementSystemV2.Application.DAL;
using System;
using System.Data;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystemV2.Presentation
{
    public partial class frmStockAdjustment : Form
    {
        private int _currentProductId = 0;
        private int _baseStock = 0;

        public frmStockAdjustment() => InitializeComponent();

        private async void frmStockAdjustment_Load(object sender, EventArgs e)
        {
            cmbProduct.DataSource = await Task.Run(() => DatabaseHelper.GetDataTable("SELECT ProductID, ProductName FROM Products ORDER BY ProductName"));
            cmbProduct.DisplayMember = "ProductName"; cmbProduct.ValueMember = "ProductID";
            cmbType.SelectedIndex = 0;
        }

        private async void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null) return;
            _currentProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            var row = await Task.Run(() => DatabaseHelper.GetDataTable("SELECT UnitsInStock FROM Products WHERE ProductID=@id",
                new System.Data.SqlClient.SqlParameter("@id", _currentProductId)));
            if (row.Rows.Count > 0)
            {
                _baseStock = Convert.ToInt32(row.Rows[0]["UnitsInStock"]);
                UpdatePreview();
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e) => UpdatePreview();
        private void nudQty_ValueChanged(object sender, EventArgs e) => UpdatePreview();

        private void UpdatePreview()
        {
            int change = (int)nudQty.Value;
            int after = cmbType.SelectedIndex == 0 ? _baseStock + change : _baseStock - change;
            lblCurrent.Text = $"Current: {_baseStock}";
            lblAfter.Text = $"After: {after}";
            lblAfter.ForeColor = after < 0 ? System.Drawing.Color.Red : System.Drawing.Color.FromArgb(47, 133, 90);
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            if (_currentProductId == 0) return;
            int change = (int)nudQty.Value;
            if (cmbType.SelectedIndex == 1 && change > _baseStock)
            {
                MessageBox.Show("Cannot remove more stock than currently available.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnApply.Enabled = false;
            try
            {
                int newStock = cmbType.SelectedIndex == 0 ? _baseStock + change : _baseStock - change;
                await Task.Run(() => DatabaseHelper.ExecuteNonQuery("UPDATE Products SET UnitsInStock=@qty WHERE ProductID=@id",
                    new System.Data.SqlClient.SqlParameter("@qty", newStock),
                    new System.Data.SqlClient.SqlParameter("@id", _currentProductId)));

                // Optional: Log adjustment here
                MessageBox.Show("✅ Stock adjusted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { btnApply.Enabled = true; }
        }

        private void ClearForm()
        {
            nudQty.Value = 1; txtReason.Clear(); cmbType.SelectedIndex = 0;
            lblCurrent.Text = "Current: 0"; lblAfter.Text = "After: 0";
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();
    }
}