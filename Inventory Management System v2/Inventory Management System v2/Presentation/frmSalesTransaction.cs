using InventoryManagementSystem.Application.BLL;
using InventoryManagementSystem.Application.DAL;
using InventoryManagementSystemV2.Application.BLL;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem.Presentation
{
    public partial class frmSalesTransaction : Form
    {
        private DataTable _cart = new DataTable();

        public frmSalesTransaction()
        {
            InitializeComponent();
            _cart.Columns.Add("ProductID", typeof(int));
            _cart.Columns.Add("ProductName", typeof(string));
            _cart.Columns.Add("Quantity", typeof(int));
            _cart.Columns.Add("UnitPrice", typeof(decimal));
            dgvCart.DataSource = _cart;
        }

        private void frmSalesTransaction_Load(object sender, EventArgs e)
        {
            cmbCustomer.DataSource = DatabaseHelper.GetDataTable("SELECT CustomerID, CustomerName FROM Customers");
            cmbCustomer.DisplayMember = "CustomerName";
            cmbCustomer.ValueMember = "CustomerID";

            cmbProduct.DataSource = DatabaseHelper.GetDataTable("SELECT ProductID, ProductName, UnitPrice FROM Products WHERE UnitsInStock > 0");
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null || nudQuantity.Value <= 0) return;

            var row = _cart.NewRow();
            row["ProductID"] = cmbProduct.SelectedValue;
            row["ProductName"] = cmbProduct.Text;
            row["Quantity"] = nudQuantity.Value;
            row["UnitPrice"] = ((DataRowView)cmbProduct.SelectedItem)["UnitPrice"];
            _cart.Rows.Add(row);
            UpdateTotal();
        }

        private void UpdateTotal() => lblTotal.Text = $"${_cart.Compute("SUM(UnitPrice * Quantity)", ""):F2}";

        private async void btnFinalizeSale_Click(object sender, EventArgs e)
        {
            if (_cart.Rows.Count == 0 || cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Cart is empty or customer not selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnFinalizeSale.Enabled = false;
            lblStatus.Text = "Processing...";

            try
            {
                // Build XML Cart
                var xml = new StringBuilder("<Cart>");
                foreach (DataRow row in _cart.Rows)
                    xml.Append($"<Item ProductID=\"{row["ProductID"]}\" Qty=\"{row["Quantity"]}\" Price=\"{row["UnitPrice"]}\"/>");
                xml.Append("</Cart>");

                var result = await Task.Run(() => SaleBLL.ProcessSale((int)cmbCustomer.SelectedValue, xml.ToString()));

                if (result.Rows.Count > 0)
                {
                    MessageBox.Show($"Sale Complete! ID: {result.Rows[0]["NewSaleID"]}\nTotal: {result.Rows[0]["TotalAmount"]}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _cart.Clear();
                    UpdateTotal();
                }
            }
            catch (Exception ex) when (ex.Message.Contains("Insufficient stock") || ex.Message.Contains("Stock went negative"))
            {
                MessageBox.Show($"Stock Validation Failed: {ex.Message}", "Transaction Blocked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFinalizeSale.Enabled = true;
                lblStatus.Text = "Ready";
            }
        }
    }
}