CREATE VIEW vw_LowStock AS
SELECT p.ProductID, p.ProductName, p.UnitsInStock, p.ReorderLevel, c.CategoryName
FROM Products p
JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE p.UnitsInStock < p.ReorderLevel;