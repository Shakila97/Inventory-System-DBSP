-- Member 03: Sales & Transaction Lead
IF OBJECT_ID('dbo.Sales', 'U') IS NOT NULL DROP TABLE dbo.Sales;
GO

CREATE TABLE dbo.Sales (
    SaleID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    SaleDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(12,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Sales_Customers FOREIGN KEY (CustomerID)
        REFERENCES dbo.Customers(CustomerID) ON DELETE NO ACTION
);