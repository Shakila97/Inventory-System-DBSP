using Inventory_Management_System_IMS.Application.BLL;
using Inventory_Management_System_IMS.Application.DAL;
using InventorySystem.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Inventory_Management_System_IMS.Presentation
{
    public partial class frmProductInventory : Form
    {
        private ProductBLL _productBLL;
        private DataTable _dtProducts;

        public frmProductInventory()
        {
            InitializeComponent();
            _productBLL = new ProductBLL();
        }

        private void frmProductInventory_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadProducts()
        {
            try
            {
                _dtProducts = _productBLL.GetAllProducts();
                dgvInventory.DataSource = _dtProducts;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                DataTable dtCategories = _productBLL.GetAllCategories();
                cmbCategory.DataSource = dtCategories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.Items.Insert(0, new DataRowView(null, "All Categories"));
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dgvInventory.AutoResizeColumns();
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.ReadOnly = true;

            // Highlight low stock rows
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.Cells["UnitsInStock"].Value != null &&
                    row.Cells["ReorderLevel"].Value != null)
                {
                    int stock = Convert.ToInt32(row.Cells["UnitsInStock"].Value);
                    int reorder = Convert.ToInt32(row.Cells["ReorderLevel"].Value);

                    if (stock < reorder)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            OpenProductDialog(0); // 0 = new product
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                int productID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["ProductID"].Value);
                OpenProductDialog(productID);
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int productID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["ProductID"].Value);
                        if (_productBLL.DeleteProduct(productID))
                        {
                            MessageBox.Show("Product deleted successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProducts();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting product: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts();
        }

        private void SearchProducts()
        {
            try
            {
                string searchQuery = txtSearch.Text.Trim();
                int categoryID = cmbCategory.SelectedIndex > 0 ?
                    Convert.ToInt32(((DataRowView)cmbCategory.SelectedItem).Row["CategoryID"]) : 0;

                _dtProducts = _productBLL.SearchProducts(searchQuery, categoryID);
                dgvInventory.DataSource = _dtProducts;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabLowStock_Click(object sender, EventArgs e)
        {
            LoadLowStockProducts();
        }

        private void LoadLowStockProducts()
        {
            try
            {
                DataTable dtLowStock = DatabaseHelper.GetDataTable("EXEC vw_LowStock");
                dgvLowStock.DataSource = dtLowStock;
                dgvLowStock.AutoResizeColumns();
                dgvLowStock.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading low stock products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenProductDialog(int productID)
        {
            // Create dialog form programmatically or open existing form
            using (frmProductDialog dialog = new frmProductDialog(productID))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}