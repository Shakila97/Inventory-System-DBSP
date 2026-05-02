-- Member 04: Automated Stock Decrement Trigger
IF OBJECT_ID('dbo.trg_DecrementStock', 'TR') IS NOT NULL DROP TRIGGER dbo.trg_DecrementStock;
GO

CREATE TRIGGER dbo.trg_DecrementStock
ON dbo.SalesDetails
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Decrement stock using INSERTED pseudo-table
        UPDATE p
        SET p.UnitsInStock = p.UnitsInStock - i.Quantity
        FROM dbo.Products p
        JOIN inserted i ON p.ProductID = i.ProductID;

        -- Safety rollback if any product goes negative
        IF EXISTS (SELECT 1 FROM dbo.Products WHERE UnitsInStock < 0)
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Insufficient stock! Transaction rolled back to prevent negative inventory.', 16, 1);
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO