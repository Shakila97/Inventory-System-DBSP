CREATE PROCEDURE sp_Login
    @Username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT PasswordHash, IsLocked
    FROM Users
    WHERE Username = @Username;
END