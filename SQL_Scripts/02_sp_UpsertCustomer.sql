-- Member 02: Customer Upsert Procedure
IF OBJECT_ID('dbo.sp_UpsertCustomer', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_UpsertCustomer;
GO

CREATE PROCEDURE dbo.sp_UpsertCustomer
    @CustomerID INT,
    @CustomerName NVARCHAR(200),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF @CustomerID = 0
    BEGIN
        INSERT INTO dbo.Customers (CustomerName, Phone, Email)
        VALUES (@CustomerName, @Phone, @Email);
    END
    ELSE
    BEGIN
        UPDATE dbo.Customers
        SET CustomerName = @CustomerName,
            Phone = @Phone,
            Email = @Email
        WHERE CustomerID = @CustomerID;
    END
END
GO