-- Member 05: Performance Indexes
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Products_CategoryID')
    CREATE NONCLUSTERED INDEX IX_Products_CategoryID ON dbo.Products(CategoryID);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Sales_CustomerID')
    CREATE NONCLUSTERED INDEX IX_Sales_CustomerID ON dbo.Sales(CustomerID);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Sales_SaleDate')
    CREATE NONCLUSTERED INDEX IX_Sales_SaleDate ON dbo.Sales(SaleDate);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SalesDetails_SaleID')
    CREATE NONCLUSTERED INDEX IX_SalesDetails_SaleID ON dbo.SalesDetails(SaleID);