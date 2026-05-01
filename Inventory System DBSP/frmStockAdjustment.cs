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
