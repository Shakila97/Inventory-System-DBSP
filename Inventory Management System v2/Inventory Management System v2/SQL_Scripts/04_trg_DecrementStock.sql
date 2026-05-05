CREATE TRIGGER trg_DecrementStock
ON SalesDetails
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE P SET UnitsInStock = UnitsInStock - i.Quantity
    FROM Products P
    JOIN INSERTED i ON P.ProductID = i.ProductID;

    IF EXISTS (SELECT 1 FROM Products WHERE UnitsInStock < 0)
    BEGIN
        RAISERROR('Stock went negative. Transaction rolled back.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;