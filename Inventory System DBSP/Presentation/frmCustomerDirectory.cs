using Inventory_System_DBSP.Application.BLL;
using InventorySystem.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Presentation
{
    public partial class frmCustomerDirectory : Form
    {
        private int _selectedCustomerId = 0;

        public frmCustomerDirectory()
        {
            InitializeComponent();
            this.Load += frmCustomerDirectory_Load;
        }

        private async void frmCustomerDirectory_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            await LoadCustomersAsync();
        }

        private async Task LoadCustomersAsync()
        {
            SetUIState(false, "Loading...");
            try
            {
                var dt = await Task.Run(() => CustomerBLL.GetAllCustomers());
                dgvCustomers.DataSource = dt;
                SetStatus($"✅ Loaded {dt.Rows.Count} customers.", Color.Green);
            }
            catch (Exception ex) { SetStatus($"❌ Load failed: {ex.Message}", Color.Crimson); }
            finally { SetUIState(true, "Ready"); }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(term)) { await LoadCustomersAsync(); return; }

            try
            {
                var dt = await Task.Run(() => CustomerBLL.SearchCustomers(term));
                dgvCustomers.DataSource = dt;
                SetStatus($"🔍 Found {dt.Rows.Count} matches.", Color.Blue);
            }
            catch (Exception ex) { SetStatus($"❌ Search failed: {ex.Message}", Color.Crimson); }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCustomers.Rows.Count)
            {
                var row = dgvCustomers.Rows[e.RowIndex];
                _selectedCustomerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
                txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
            }
        }

        private async void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            { SetStatus("❌ Customer name is required.", Color.Orange); return; }

            SetUIState(false, "Saving...");
            try
            {
                await Task.Run(() => CustomerBLL.UpsertCustomer(_selectedCustomerId, txtCustomerName.Text, txtPhone.Text, txtEmail.Text));
                SetStatus("✅ Customer saved successfully.", Color.Green);
                ClearForm();
                await LoadCustomersAsync();
            }
            catch (Exception ex) { SetStatus($"❌ {ex.Message}", Color.Crimson); }
            finally { SetUIState(true, "Ready"); }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == 0) { SetStatus("❌ Select a customer to delete.", Color.Orange); return; }
            if (MessageBox.Show("Delete this customer? This will fail if related sales exist.", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No) return;

            SetUIState(false, "Deleting...");
            try
            {
                await Task.Run(() => CustomerBLL.DeleteCustomer(_selectedCustomerId));
                SetStatus("✅ Customer deleted.", Color.Green);
                ClearForm();
                await LoadCustomersAsync();
            }
            catch (Exception ex) { SetStatus($"❌ {ex.Message}", Color.Crimson); }
            finally { SetUIState(true, "Ready"); }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            _selectedCustomerId = 0;
            txtCustomerName.Clear(); txtPhone.Clear(); txtEmail.Clear(); txtSearch.Clear();
            dgvCustomers.ClearSelection();
            SetStatus("Ready", Color.Gray);
        }

        private void ConfigureGrid()
        {
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetUIState(bool enabled, string btnText)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetUIState(enabled, btnText))); return; }
            btnAddUpdate.Enabled = enabled; btnDelete.Enabled = enabled; btnClear.Enabled = enabled;
            txtCustomerName.Enabled = enabled; txtPhone.Enabled = enabled; txtEmail.Enabled = enabled;
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