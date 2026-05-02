-- Member 03: ACID Sale Transaction Procedure
IF OBJECT_ID('dbo.sp_ProcessSale', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_ProcessSale;
GO

CREATE PROCEDURE dbo.sp_ProcessSale
    @CustomerID INT,
    @CartXML XML
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Parse XML cart into temp table
        DECLARE @CartTable TABLE (
            ProductID INT,
            Quantity INT,
            UnitPrice DECIMAL(10,2)
        );

        INSERT INTO @CartTable (ProductID, Quantity, UnitPrice)
        SELECT 
            x.item.value('@productid', 'INT'),
            x.item.value('@qty', 'INT'),
            x.item.value('@price', 'DECIMAL(10,2)')
        FROM @CartXML.nodes('/cart/item') AS x(item);

        -- Step 1: Validate Stock (Atomic Check)
        IF EXISTS (
            SELECT 1 FROM @CartTable c
            JOIN dbo.Products p ON c.ProductID = p.ProductID
            WHERE p.UnitsInStock < c.Quantity
        )
        BEGIN
            RAISERROR('Insufficient stock for one or more items. Transaction rolled back.', 16, 1);
        END

        -- Step 2: Insert Sale Header
        INSERT INTO dbo.Sales (CustomerID, TotalAmount) VALUES (@CustomerID, 0);
        DECLARE @SaleID INT = SCOPE_IDENTITY();

        -- Step 3: Insert Sale Details (Trigger fires automatically here)
        INSERT INTO dbo.SalesDetails (SaleID, ProductID, Quantity, UnitPrice)
        SELECT @SaleID, c.ProductID, c.Quantity, c.UnitPrice FROM @CartTable c;

        -- Step 4: Calculate & Update TotalAmount
        DECLARE @TotalAmount DECIMAL(12,2);
        SELECT @TotalAmount = SUM(Quantity * UnitPrice) FROM dbo.SalesDetails WHERE SaleID = @SaleID;
        UPDATE dbo.Sales SET TotalAmount = @TotalAmount WHERE SaleID = @SaleID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END
GO