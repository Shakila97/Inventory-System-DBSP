using System;
using System.Collections.Generic;

private int _currentStock = 0;

private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
{
    int productId = (int)cmbProduct.SelectedValue;
    string sql = "SELECT UnitsInStock FROM Products WHERE ProductID = @ID";
    var p = new Dictionary<string, object> { { "@ID", productId } };
    _currentStock = (int)DatabaseHelper.ExecuteScalar(sql, p);
    lblCurrentStock.Text = $"Current Stock: {_currentStock} units";
    UpdatePreview();
}

private void UpdatePreview()
{
    int qty = (int)nudQuantity.Value;
    bool isAdd = cmbAdjustType.SelectedIndex == 0;
    int newStock = isAdd ? _currentStock + qty : _currentStock - qty;

    lblNewStock.Text = $"New Stock: {newStock} units";
    lblNewStock.ForeColor = newStock < 0 ? Color.Red : Color.DarkGreen;
}

private void btnApplyAdjustment_Click(object sender, EventArgs e)
{
    // Validation before DB call
    if (string.IsNullOrWhiteSpace(txtReason.Text))
    {
        MessageBox.Show("Please enter a reason for this adjustment."); return;
    }
    int qty = (int)nudQuantity.Value;
    bool isAdd = cmbAdjustType.SelectedIndex == 0;
    int newQty = isAdd ? _currentStock + qty : _currentStock - qty;

    if (newQty < 0)
    {
        MessageBox.Show($"Cannot remove {qty} units. Only {_currentStock} available.");
        return;
    }

    // Apply the adjustment
    int productId = (int)cmbProduct.SelectedValue;
    string sql = "UPDATE Products SET UnitsInStock = @NewQty WHERE ProductID = @ID";
    var p = new Dictionary<string, object> {
        {"@NewQty", newQty},
        {"@ID",     productId}
    };
    DatabaseHelper.ExecuteNonQuery(sql, p);

    // Log the adjustment (optional but professional)
    LogAdjustment(productId, isAdd ? qty : -qty, txtReason.Text);

    MessageBox.Show($"Stock updated to {newQty} units.");
    RefreshAll();
}
