using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystemV2.Application.BLL;

namespace InventoryManagementSystemV2.Presentation
{
    public partial class frmProductInventory : Form
    {
        public frmProductInventory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Custom input dialog to replace Microsoft.VisualBasic.Interaction.InputBox
        /// (Not available in .NET Framework WinForms without extra reference)
        /// </summary>
        private string ShowInputBox(string prompt, string title, string defaultValue = "")
        {
            var form = new Form
            {
                Text = title,
                Size = new Size(320, 180),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                AcceptButton = null,
                CancelButton = null
            };

            var lblPrompt = new Label
            {
                Text = prompt,
                Location = new Point(15, 15),
                Size = new Size(270, 30),
                AutoSize = false
            };

            var txtInput = new TextBox
            {
                Location = new Point(15, 45),
                Size = new Size(270, 23),
                Text = defaultValue,
                Font = new Font("Segoe UI", 9F)
            };

            var btnOk = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(130, 90),
                Size = new Size(75, 25),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(47, 133, 90),
                ForeColor = Color.White
            };

            var btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(210, 90),
                Size = new Size(75, 25),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(150, 150, 150),
                ForeColor = Color.White
            };

            form.Controls.Add(lblPrompt);
            form.Controls.Add(txtInput);
            form.Controls.Add(btnOk);
            form.Controls.Add(btnCancel);
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            return form.ShowDialog() == DialogResult.OK ? txtInput.Text.Trim() : null;
        }

        /// <summary>
        /// Loads categories and products when form initializes.
        /// </summary>
        private async void frmProductInventory_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadProductsAsync();
            await LoadLowStockAsync();
        }

        /// <summary>
        /// Loads categories into the dropdown filter.
        /// </summary>
        private async Task LoadCategoriesAsync()
        {
            try
            {
                var dt = await Task.Run(() => ProductBLL.GetCategories());

                // Add "All Categories" option at top
                var allRow = dt.NewRow();
                allRow["CategoryID"] = 0;
                allRow["CategoryName"] = "All Categories";
                dt.Rows.InsertAt(allRow, 0);

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads products into the main grid with optional search/category filter.
        /// </summary>
        private async Task LoadProductsAsync(string keyword = "", int categoryId = 0)
        {
            dgvInventory.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                var dt = await Task.Run(() => ProductBLL.SearchProducts(keyword, categoryId));

                dgvInventory.DataSource = dt;
                FormatGrid(dgvInventory);

                // Auto-size columns
                if (dt.Columns.Contains("UnitPrice"))
                    dgvInventory.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
                if (dt.Columns.Contains("UnitsInStock"))
                    dgvInventory.Columns["UnitsInStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvInventory.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Loads low-stock products from vw_LowStock view into the alert tab.
        /// </summary>
        private async Task LoadLowStockAsync()
        {
            try
            {
                var dt = await Task.Run(() => ProductBLL.GetLowStockProducts());

                dgvLowStock.DataSource = dt;
                FormatGrid(dgvLowStock);

                // Highlight low-stock rows in red
                foreach (DataGridViewRow row in dgvLowStock.Rows)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.DefaultCellStyle.Font = new Font(dgvLowStock.Font, FontStyle.Bold);
                }

                // Update tab title with count
                tabControl.TabPages["tabLowStock"].Text = $" ⚠️ Low Stock ({dt.Rows.Count}) ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load low stock alerts: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Applies consistent formatting to any DataGridView in this form.
        /// </summary>
        private void FormatGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ClearSelection();
        }

        /// <summary>
        /// Search button: filters products by name/phone and category.
        /// </summary>
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            int catId = cmbCategory.SelectedIndex > 0 ? Convert.ToInt32(cmbCategory.SelectedValue) : 0;
            await LoadProductsAsync(txtSearch.Text.Trim(), catId);
        }

        /// <summary>
        /// Refresh button: reloads all data and clears filters.
        /// </summary>
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            await LoadProductsAsync();
            await LoadLowStockAsync();
            MessageBox.Show("Data refreshed successfully.", "Refresh Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Add Product: prompts for details and inserts via BLL.
        /// </summary>
        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Prompt for product details using custom dialog
            string name = ShowInputBox("Product Name:", "Add New Product");
            if (string.IsNullOrWhiteSpace(name)) return;

            string priceStr = ShowInputBox("Unit Price (e.g., 19.99):", "Add New Product", "0.00");
            if (!decimal.TryParse(priceStr, out decimal price) || price < 0)
            {
                MessageBox.Show("Invalid price. Please enter a positive number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string stockStr = ShowInputBox("Initial Stock Quantity:", "Add New Product", "0");
            if (!int.TryParse(stockStr, out int stock) || stock < 0)
            {
                MessageBox.Show("Invalid stock quantity.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reorderStr = ShowInputBox("Reorder Level (alert when below):", "Add New Product", "10");
            if (!int.TryParse(reorderStr, out int reorder) || reorder < 0)
            {
                MessageBox.Show("Invalid reorder level.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category first.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            btnAddProduct.Enabled = false;
            try
            {
                await Task.Run(() => ProductBLL.InsertProduct(name, price, stock, reorder, categoryId));

                MessageBox.Show($"✅ Product '{name}' added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadProductsAsync();
                await LoadLowStockAsync();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // Unique constraint
            {
                MessageBox.Show("A product with this name already exists.", "Duplicate Entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAddProduct.Enabled = true;
            }
        }

        /// <summary>
        /// Edit Product: loads selected row data and updates via BLL.
        /// </summary>
        private async void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product from the grid to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvInventory.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["ProductID"].Value);
            string currentName = row.Cells["ProductName"].Value?.ToString();
            decimal currentPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
            int currentStock = Convert.ToInt32(row.Cells["UnitsInStock"].Value);
            int currentReorder = Convert.ToInt32(row.Cells["ReorderLevel"].Value);

            // Prompt with current values as defaults
            string name = ShowInputBox("Product Name:", "Edit Product", currentName);
            if (string.IsNullOrWhiteSpace(name)) return;

            string priceStr = ShowInputBox("Unit Price:", "Edit Product", currentPrice.ToString("F2"));
            if (!decimal.TryParse(priceStr, out decimal price) || price < 0)
            {
                MessageBox.Show("Invalid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string stockStr = ShowInputBox("Units In Stock:", "Edit Product", currentStock.ToString());
            if (!int.TryParse(stockStr, out int stock) || stock < 0)
            {
                MessageBox.Show("Invalid stock quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reorderStr = ShowInputBox("Reorder Level:", "Edit Product", currentReorder.ToString());
            if (!int.TryParse(reorderStr, out int reorder) || reorder < 0)
            {
                MessageBox.Show("Invalid reorder level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            btnEditProduct.Enabled = false;
            try
            {
                await Task.Run(() => ProductBLL.UpdateProduct(id, name, price, stock, reorder, categoryId));

                MessageBox.Show($"✅ Product '{name}' updated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadProductsAsync(txtSearch.Text.Trim(),
                    cmbCategory.SelectedIndex > 0 ? Convert.ToInt32(cmbCategory.SelectedValue) : 0);
                await LoadLowStockAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEditProduct.Enabled = true;
            }
        }

        /// <summary>
        /// Delete Product: removes selected product with FK violation handling.
        /// </summary>
        private async void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product from the grid to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvInventory.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["ProductID"].Value);
            string productName = row.Cells["ProductName"].Value?.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete '{productName}'?\n\n" +
                "⚠️ Note: Deletion will fail if this product has existing sales records.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            btnDeleteProduct.Enabled = false;
            try
            {
                await Task.Run(() => ProductBLL.DeleteProduct(id));

                MessageBox.Show($"✅ Product '{productName}' deleted.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadProductsAsync(txtSearch.Text.Trim(),
                    cmbCategory.SelectedIndex > 0 ? Convert.ToInt32(cmbCategory.SelectedValue) : 0);
            }
            catch (SqlException ex) when (ex.Number == 547) // Foreign Key Constraint Violation
            {
                MessageBox.Show(
                    $"❌ Cannot delete '{productName}'.\n\n" +
                    "This product is linked to existing sales records.\n" +
                    "To delete it, first remove or void all related sales, or mark it as inactive instead.",
                    "Foreign Key Constraint",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDeleteProduct.Enabled = true;
            }
        }
    }
}