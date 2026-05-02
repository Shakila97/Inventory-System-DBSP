-- Member 04: Stock Logic & Automation Lead
IF OBJECT_ID('dbo.SalesDetails', 'U') IS NOT NULL DROP TABLE dbo.SalesDetails;
GO

CREATE TABLE dbo.SalesDetails (
    SalesDetailID INT IDENTITY(1,1) PRIMARY KEY,
    SaleID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10,2) NOT NULL, -- Snapshot of price at time of sale
    CONSTRAINT FK_SalesDetails_Sales FOREIGN KEY (SaleID)
        REFERENCES dbo.Sales(SaleID) ON DELETE CASCADE,
    CONSTRAINT FK_SalesDetails_Products FOREIGN KEY (ProductID)
        REFERENCES dbo.Products(ProductID) ON DELETE NO ACTION
);