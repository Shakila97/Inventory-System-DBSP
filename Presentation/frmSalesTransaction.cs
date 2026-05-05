using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventorySystem.BLL;

namespace InventorySystem.Presentation
{
    public partial class frmSalesTransaction : Form
    {
        private List<CartItem> _cart = new List<CartItem>();
        private DataTable _products;
        private DataTable _customers;

        public frmSalesTransaction()
        {
            InitializeComponent();
            this.Load += frmSalesTransaction_Load;
        }

        private async void frmSalesTransaction_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            await LoadLookupsAsync();
            UpdateTotal();
        }

        private async Task LoadLookupsAsync()
        {
            SetUIState(false, "Loading data...");
            try
            {
                var results = await Task.Run(() => (SaleBLL.GetAllCustomers(), SaleBLL.GetAllProducts()));
                _customers = results.Item1;
                _products = results.Item2;

                cmbCustomer.DisplayMember = "CustomerName"; cmbCustomer.ValueMember = "CustomerID"; cmbCustomer.DataSource = _customers;
                cmbProduct.DisplayMember = "ProductName"; cmbProduct.ValueMember = "ProductID"; cmbProduct.DataSource = _products;
            }
            catch (Exception ex) { SetStatus($"❌ Data load error: {ex.Message}", Color.Crimson); }
            finally { SetUIState(true, "Ready"); }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null) return;
            int qty = 1;
            if (!int.TryParse(txtQty.Text, out qty) || qty <= 0)
            { SetStatus("❌ Enter a valid quantity.", Color.Orange); return; }

            int prodId = Convert.ToInt32(cmbProduct.SelectedValue);
            var prod = _products.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["ProductID"]) == prodId);
            if (prod == null) return;

            string name = prod["ProductName"].ToString();
            decimal price = Convert.ToDecimal(prod["UnitPrice"]);
            int stock = Convert.ToInt32(prod["UnitsInStock"]);

            var existing = _cart.FirstOrDefault(c => c.ProductId == prodId);
            if (existing != null)
            {
                if (existing.Quantity + qty > stock)
                { SetStatus($"❌ Not enough stock. Available: {stock}", Color.Orange); return; }
                existing.Quantity += qty;
            }
            else
            {
                if (qty > stock)
                { SetStatus($"❌ Not enough stock. Available: {stock}", Color.Orange); return; }
                _cart.Add(new CartItem { ProductId = prodId, ProductName = name, Quantity = qty, UnitPrice = price });
            }

            RefreshCartGrid();
            UpdateTotal();
            txtQty.Text = "1";
            cmbProduct.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                _cart.RemoveAt(dgvCart.CurrentRow.Index);
                RefreshCartGrid();
                UpdateTotal();
            }
        }

        private async void btnFinalize_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0) { SetStatus("❌ Cart is empty.", Color.Orange); return; }
            if (cmbCustomer.SelectedValue == null) { SetStatus("❌ Select a customer.", Color.Orange); return; }

            int customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            SetUIState(false, "Processing ACID sale...");

            try
            {
                // Pass cart copy to prevent modification during async call
                await Task.Run(() => SaleBLL.ProcessSale(customerId, new List<CartItem>(_cart)));

                SetStatus($"✅ Sale completed! Total: {GetCartTotal():C2}", Color.Green);
                _cart.Clear();
                RefreshCartGrid();
                UpdateTotal();
                await LoadLookupsAsync(); // Refresh stock levels post-sale
            }
            catch (Exception ex)
            {
                SetStatus($"❌ {ex.Message}", Color.Crimson);
                // Cart remains intact on failure for user adjustment
            }
            finally { SetUIState(true, "Ready"); }
        }

        private void RefreshCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart.Select(c => new { Product = c.ProductName, Price = c.UnitPrice, Qty = c.Quantity, Total = c.LineTotal }).ToList();
            if (dgvCart.Columns.Count > 0)
            {
                dgvCart.Columns["Price"].DefaultCellStyle.Format = "C2";
                dgvCart.Columns["Total"].DefaultCellStyle.Format = "C2";
            }
        }

        private decimal GetCartTotal() => _cart.Sum(c => c.LineTotal);
        private void UpdateTotal() => lblTotal.Text = GetCartTotal().ToString("C2");

        private void ConfigureGrid()
        {
            dgvCart.ReadOnly = true;
            dgvCart.AllowUserToAddRows = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetUIState(bool enabled, string status)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetUIState(enabled, status))); return; }
            cmbCustomer.Enabled = enabled; cmbProduct.Enabled = enabled;
            btnAddToCart.Enabled = enabled; btnRemove.Enabled = enabled; btnFinalize.Enabled = enabled;
        }

        private void SetStatus(string msg, Color color)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetStatus(msg, color))); return; }
            if (this.Controls.ContainsKey("lblStatus"))
            {
                var lbl = (Label)this.Controls["lblStatus"];
                lbl.Text = msg; lbl.ForeColor = color;
            }
        }
    }
}