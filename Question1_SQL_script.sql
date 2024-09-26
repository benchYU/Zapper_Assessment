-- Create a table for customers
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(15),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Create a table for merchants
CREATE TABLE Merchants (
    MerchantID INT PRIMARY KEY IDENTITY(1,1),
    MerchantName NVARCHAR(100),
    ContactName NVARCHAR(100),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(15),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Create a table for transactions
CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    MerchantID INT,
    Amount DECIMAL(10, 2),
    TransactionDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (MerchantID) REFERENCES Merchants(MerchantID)
);

-- Create a table for transaction details
CREATE TABLE TransactionDetails (
    TransactionDetailID INT PRIMARY KEY IDENTITY(1,1),
    TransactionID INT,
    ItemName NVARCHAR(100),
    ItemPrice DECIMAL(10, 2),
    Quantity INT,
    FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID)
);

-- Create an index on Transactions for optimization
CREATE INDEX IDX_Transactions_CustomerID ON Transactions(CustomerID);
CREATE INDEX IDX_Transactions_MerchantID ON Transactions(MerchantID);

-- Create a table for transaction logs
CREATE TABLE TransactionLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    TransactionID INT,
    LogMessage NVARCHAR(255),
    LogTimestamp DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID)
);