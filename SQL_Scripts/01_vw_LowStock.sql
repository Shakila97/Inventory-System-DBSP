-- Member 01: Low Stock Reporting View
IF OBJECT_ID('dbo.vw_LowStock', 'V') IS NOT NULL DROP VIEW dbo.vw_LowStock;
GO

CREATE VIEW dbo.vw_LowStock AS
SELECT 
    p.ProductID,
    p.ProductName,
    p.UnitsInStock,
    p.ReorderLevel,
    c.CategoryName
FROM dbo.Products p
JOIN dbo.Categories c ON p.CategoryID = c.CategoryID
WHERE p.UnitsInStock < p.ReorderLevel;
GO