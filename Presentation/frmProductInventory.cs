using Inventory_Management_System_IMS.Application.BLL;
    
using InventorySystem.DAL;  
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Inventory_Management_System_IMS
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

                // "All Categories" පේළිය DataTable එකටම නිවැරදිව එක් කිරීම
                DataRow dr = dtCategories.NewRow();
                dr["CategoryName"] = "All Categories";
                dr["CategoryID"] = 0;
                dtCategories.Rows.InsertAt(dr, 0);

                cmbCategory.DataSource = dtCategories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
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

            // අඩු තොග (Low stock) ඇති පේළි වර්ණ ගැන්වීම
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.Cells["UnitsInStock"].Value != DBNull.Value &&
                    row.Cells["ReorderLevel"].Value != DBNull.Value)
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
            OpenProductDialog(0); // 0 = අලුත් භාණ්ඩයක් සඳහා
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
                int categoryID = 0;

                // ComboBox එකෙන් තෝරාගත් Category ID එක ලබා ගැනීම
                if (cmbCategory.SelectedIndex > 0)
                {
                    DataRowView selectedRow = (DataRowView)cmbCategory.SelectedItem;
                    categoryID = Convert.ToInt32(selectedRow["CategoryID"]);
                }

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

        private void LoadLowStockProducts()
        {
            try
            {
                // DatabaseHelper හරහා දත්ත ලබා ගැනීම (dgvLowStock යන නම UI එකේ ඇති බව තහවුරු කරගන්න)
                DataTable dtLowStock = DAL.DatabaseHelper.GetDataTable("EXEC vw_LowStock");
                if (dgvLowStock != null)
                {
                    dgvLowStock.DataSource = dtLowStock;
                    dgvLowStock.AutoResizeColumns();
                    dgvLowStock.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading low stock products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenProductDialog(int productID)
        {
            // දැනට frmProductDialog පන්තිය නිර්මාණය කර නොමැති නිසා, 
            // Error එක ඉවත් කිරීමට මෙය Comment කර ඇත.
            /*
            using (frmProductDialog dialog = new frmProductDialog(productID))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
            */
            MessageBox.Show("Product Dialog is not implemented yet.", "Notice");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}