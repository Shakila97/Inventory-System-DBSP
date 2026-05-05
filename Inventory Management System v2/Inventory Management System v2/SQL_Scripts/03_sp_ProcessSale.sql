CREATE PROCEDURE sp_ProcessSale
    @CustomerID INT,
    @CartXML XML
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
    BEGIN TRY
        DECLARE @SaleID INT;
        DECLARE @TotalAmount DECIMAL(12,2) = 0;

        -- Validate stock for all items
        IF EXISTS (
            SELECT 1
            FROM (
                SELECT 
                    T.Item.value('@ProductID', 'INT') AS ProductID,
                    T.Item.value('@Qty', 'INT') AS Qty
                FROM @CartXML.nodes('/Cart/Item') AS T(Item)
            ) AS CartItems
            JOIN Products P ON CartItems.ProductID = P.ProductID
            WHERE P.UnitsInStock < CartItems.Qty
        )
        BEGIN
            RAISERROR('Insufficient stock for one or more items.', 16, 1);
        END

        -- Insert Sale Header
        INSERT INTO Sales (CustomerID, TotalAmount) VALUES (@CustomerID, 0);
        SET @SaleID = SCOPE_IDENTITY();

        -- Insert Details & Calculate Total
        INSERT INTO SalesDetails (SaleID, ProductID, Quantity, UnitPrice)
        SELECT 
            @SaleID,
            T.Item.value('@ProductID', 'INT'),
            T.Item.value('@Qty', 'INT'),
            T.Item.value('@Price', 'DECIMAL(10,2)')
        FROM @CartXML.nodes('/Cart/Item') AS T(Item);

        -- Calculate Total
        SELECT @TotalAmount = SUM(Quantity * UnitPrice) FROM SalesDetails WHERE SaleID = @SaleID;

        -- Update Sale Total
        UPDATE Sales SET TotalAmount = @TotalAmount WHERE SaleID = @SaleID;

        COMMIT TRANSACTION;
        SELECT @SaleID AS NewSaleID, @TotalAmount AS TotalAmount;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;