using InventoryManagementSystemV2.Application.BLL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InventoryManagementSystemV2.Presentation
{
    public partial class frmCustomerDirectory : Form
    {
        private int _currentCustomerId = 0;
        private bool _isEditMode = false;

        public frmCustomerDirectory() => InitializeComponent();

        private async void frmCustomerDirectory_Load(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
            ClearForm();
        }

        private async Task LoadCustomersAsync(string keyword = "")
        {
            dgvCustomers.Enabled = false;
            try
            {
                dgvCustomers.DataSource = await Task.Run(() =>
                    string.IsNullOrWhiteSpace(keyword) ? CustomerBLL.GetAllCustomers() : CustomerBLL.SearchCustomers(keyword));
                FormatGrid(dgvCustomers);
            }
            catch (Exception ex) { MessageBox.Show($"Load failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { dgvCustomers.Enabled = true; }
        }

        private void FormatGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }

        private void ClearForm()
        {
            txtName.Clear(); txtPhone.Clear(); txtEmail.Clear();
            _currentCustomerId = 0; _isEditMode = false;
            btnSave.Text = " Save New"; txtName.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e) => LoadCustomersAsync(txtSearch.Text.Trim());
        private void btnClear_Click(object sender, EventArgs e) { txtSearch.Clear(); LoadCustomersAsync(); ClearForm(); }
        private void btnAdd_Click(object sender, EventArgs e) { ClearForm(); dgvCustomers.ClearSelection(); }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0) return;
            var row = dgvCustomers.SelectedRows[0];
            _currentCustomerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
            txtName.Text = row.Cells["CustomerName"].Value?.ToString();
            txtPhone.Text = row.Cells["Phone"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            _isEditMode = true; btnSave.Text = "💾 Update"; txtName.Focus();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Name required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            btnSave.Enabled = false;
            try
            {
                await Task.Run(() => CustomerBLL.SaveCustomer(_isEditMode ? _currentCustomerId : 0, txtName.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim()));
                MessageBox.Show("Saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(); await LoadCustomersAsync(txtSearch.Text.Trim());
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Email already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { btnSave.Enabled = true; }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0) return;
            var row = dgvCustomers.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["CustomerID"].Value);
            if (MessageBox.Show($"Delete '{row.Cells["CustomerName"].Value}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                await Task.Run(() => CustomerBLL.DeleteCustomer(id));
                MessageBox.Show("Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(); await LoadCustomersAsync(txtSearch.Text.Trim());
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Cannot delete: Customer has existing sales records.", "FK Constraint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}