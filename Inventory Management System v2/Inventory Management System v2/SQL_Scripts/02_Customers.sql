CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(200) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100) UNIQUE
);

-- Simple auth table
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    IsLocked BIT DEFAULT 0,
    FailedAttempts INT DEFAULT 0
);

-- Seed admin (password: admin123)
INSERT INTO Users (Username, PasswordHash) VALUES ('admin', 'admin123');