-- Member 02: Customer & Security Lead
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers;
GO

CREATE TABLE dbo.Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(200) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100) UNIQUE
);
GO

-- Login table (required by Blueprint & frmLogin)
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
GO

CREATE TABLE dbo.Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(100) NOT NULL
);
GO

-- Seed default credentials per README
INSERT INTO dbo.Users (Username, PasswordHash) VALUES ('admin', 'admin123');