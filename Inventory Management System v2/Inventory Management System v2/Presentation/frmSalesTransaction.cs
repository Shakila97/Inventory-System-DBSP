using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystemV2.Application.BLL;

namespace InventoryManagementSystemV2.Presentation
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
            _cart.Columns.Add("LineTotal", typeof(decimal), "Quantity * UnitPrice");
            dgvCart.DataSource = _cart;
        }

        private async void frmSalesTransaction_Load(object sender, EventArgs e)
        {
            cmbCustomer.DataSource = await Task.Run(() => SaleBLL.GetCustomersForSale());
            cmbCustomer.DisplayMember = "CustomerName"; cmbCustomer.ValueMember = "CustomerID";

            cmbProduct.DataSource = await Task.Run(() => SaleBLL.GetActiveProductsForSale());
            cmbProduct.DisplayMember = "ProductName"; cmbProduct.ValueMember = "ProductID";
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

        private void UpdateTotal() => lblTotal.Text = $"${_cart.Compute("SUM(LineTotal)", ""):F2}";

        private async void btnFinalizeSale_Click(object sender, EventArgs e)
        {
            if (_cart.Rows.Count == 0 || cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Cart empty or customer not selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnFinalizeSale.Enabled = false;
            lblStatus.Text = "Processing ACID Transaction...";

            try
            {
                var xml = new StringBuilder("<Cart>");
                foreach (DataRow r in _cart.Rows)
                    xml.Append($"<Item ProductID=\"{r["ProductID"]}\" Qty=\"{r["Quantity"]}\" Price=\"{r["UnitPrice"]}\"/>");
                xml.Append("</Cart>");

                var result = await Task.Run(() => SaleBLL.ProcessSale((int)cmbCustomer.SelectedValue, xml.ToString()));
                if (result.Rows.Count > 0)
                {
                    MessageBox.Show($"✅ Sale Complete!\nID: {result.Rows[0]["NewSaleID"]}\nTotal: {result.Rows[0]["TotalAmount"]}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _cart.Clear(); UpdateTotal();
                }
            }
            catch (Exception ex) when (ex.Message.Contains("Insufficient") || ex.Message.Contains("Stock"))
            {
                MessageBox.Show($"❌ Stock Validation Failed:\n{ex.Message}", "Transaction Blocked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Database Error:\n{ex.Message}", "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFinalizeSale.Enabled = true;
                lblStatus.Text = "Ready";
            }
        }
    }
}