-- Member 01: Product & Catalog Lead
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;
GO

CREATE TABLE dbo.Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryID INT NOT NULL,
    ProductName NVARCHAR(200) NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice > 0),
    UnitsInStock INT NOT NULL DEFAULT 0 CHECK (UnitsInStock >= 0),
    ReorderLevel INT NOT NULL DEFAULT 10,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryID)
        REFERENCES dbo.Categories(CategoryID) ON DELETE NO ACTION -- Acts as RESTRICT in SQL Server
);