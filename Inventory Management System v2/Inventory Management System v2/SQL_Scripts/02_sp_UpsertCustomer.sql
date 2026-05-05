CREATE PROCEDURE sp_UpsertCustomer
    @CustomerID INT,
    @CustomerName NVARCHAR(200),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100)
AS
BEGIN
    IF @CustomerID = 0
        INSERT INTO Customers (CustomerName, Phone, Email) VALUES (@CustomerName, @Phone, @Email);
    ELSE
        UPDATE Customers SET CustomerName = @CustomerName, Phone = @Phone, Email = @Email WHERE CustomerID = @CustomerID;
END;