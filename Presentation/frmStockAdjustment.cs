using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventorySystem.BLL;

namespace InventorySystem.Presentation
{
    public partial class frmStockAdjustment : Form
    {
        private DataTable _products;
        private int _currentStock = 0;

        public frmStockAdjustment()
        {
            InitializeComponent();
            ConfigureForm();
            cmbAdjustType.SelectedIndex = 0; // Default: Add
        }

        private void ConfigureForm()
        {
            this.Load += async (s, e) => await LoadProductsAsync();
            cmbProduct.SelectedIndexChanged += (s, e) => UpdateProjection();
            txtQuantity.TextChanged += (s, e) => UpdateProjection();
            cmbAdjustType.SelectedIndexChanged += (s, e) => UpdateProjection();
        }

        private async Task LoadProductsAsync()
        {
            SetUIState(false, "Loading inventory...");
            try
            {
                _products = await Task.Run(() => StockAdjustmentBLL.GetAllProducts());
                cmbProduct.DisplayMember = "ProductName";
                cmbProduct.ValueMember = "ProductID";
                cmbProduct.DataSource = _products;
                SetStatus("✅ Products loaded.", Color.Green);
            }
            catch (Exception ex) { SetStatus($"❌ {ex.Message}", Color.Crimson); }
            finally { SetUIState(true, "Ready"); }
        }

        private void UpdateProjection()
        {
            if (cmbProduct.SelectedValue == null || !int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                lblCurrentStock.Text = "—";
                lblProjectedStock.Text = "—";
                return;
            }

            var row = _products.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["ProductID"]) == Convert.ToInt32(cmbProduct.SelectedValue));
            if (row != null)
            {
                _currentStock = Convert.ToInt32(row["UnitsInStock"]);
                bool isAdd = cmbAdjustType.Text.Contains("Add");
                int projected = isAdd ? _currentStock + qty : _currentStock - qty;

                lblCurrentStock.Text = _currentStock.ToString();
                lblProjectedStock.Text = projected.ToString();
                lblProjectedStock.ForeColor = projected < 0 ? Color.Crimson : Color.ForestGreen;
            }
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null || !int.TryParse(txtQuantity.Text, out int qty) || qty <= 0 || string.IsNullOrWhiteSpace(txtReason.Text))
            { SetStatus("❌ Complete all fields with valid values.", Color.Orange); return; }

            bool isAdd = cmbAdjustType.Text.Contains("Add");
            int productId = Convert.ToInt32(cmbProduct.SelectedValue);

            SetUIState(false, "Applying adjustment...");
            try
            {
                await Task.Run(() => StockAdjustmentBLL.ApplyAdjustment(productId, qty, txtReason.Text, isAdd));
                SetStatus($"✅ Stock {(isAdd ? "added" : "removed")} successfully.", Color.Green);
                ClearForm();
                await LoadProductsAsync(); // Refresh dropdown to reflect new stock levels
            }
            catch (Exception ex) { SetStatus($"❌ {ex.Message}", Color.Crimson); }
            finally { SetUIState(true, "Ready"); }
        }

        private void ClearForm()
        {
            txtQuantity.Clear(); txtReason.Clear();
            lblCurrentStock.Text = "—"; lblProjectedStock.Text = "—";
        }

        private void SetUIState(bool enabled, string status)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetUIState(enabled, status))); return; }
            btnApply.Enabled = enabled;
            cmbProduct.Enabled = enabled; cmbAdjustType.Enabled = enabled;
            txtQuantity.Enabled = enabled; txtReason.Enabled = enabled;
        }

        private void SetStatus(string msg, Color color)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetStatus(msg, color))); return; }
            if (Controls.ContainsKey("lblStatus"))
            { ((Label)Controls["lblStatus"]).Text = msg; ((Label)Controls["lblStatus"]).ForeColor = color; }
        }
    }
}