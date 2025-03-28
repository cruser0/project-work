-- Assign Variables
DECLARE @SupplierAmount int = 500;
DECLARE @CustomerAmount int = 250;
DECLARE @SaleAmount int = 2500;
DECLARE @MaxSupplierInvoicePerSale int = 3;
DECLARE @MaxCustomerInvoicePerSale int = 5;
DECLARE @MaxCostPerSupplierInvoice int = 8;
DECLARE @MaxCostPerCustomerInvoice int = 8;
DECLARE @PercentageClosedSupplierInvoices int = 70;
DECLARE @PercentageClosedCustomerInvoices int = 50;
DECLARE @PercentageClosedSales int = 35;

-- Delete existing data
DELETE FROM CustomerInvoiceCosts;
DELETE FROM SupplierInvoiceCosts;
DELETE FROM CustomerInvoices;
DELETE FROM SupplierInvoices;
DELETE FROM Sales;
DELETE FROM Suppliers;
DELETE FROM Customers;

-- Reset Identity
DBCC CHECKIDENT ('Customers', RESEED, 0);
DBCC CHECKIDENT ('Suppliers', RESEED, 0);
DBCC CHECKIDENT ('Sales', RESEED, 0);
DBCC CHECKIDENT ('CustomerInvoices', RESEED, 0);
DBCC CHECKIDENT ('SupplierInvoices', RESEED, 0);
DBCC CHECKIDENT ('CustomerInvoiceCosts', RESEED, 0);
DBCC CHECKIDENT ('SupplierInvoiceCosts', RESEED, 0);

-- Insert Suppliers
INSERT INTO Suppliers (SupplierName, CountryID, Deprecated, CreatedAt, OriginalID)
SELECT TOP (@SupplierAmount)
    CONCAT('Supplier', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))),
    FLOOR(RAND(CHECKSUM(NEWID())) * 195) + 1,
    0,
    GETDATE(),
    ROW_NUMBER() OVER (ORDER BY (SELECT NULL))
FROM master.dbo.spt_values v1;

-- Insert Customers
INSERT INTO Customers (CustomerName, CountryID, Deprecated, CreatedAt, OriginalID)
SELECT TOP (@CustomerAmount)
    CONCAT('Customer', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))), 
    FLOOR(RAND(CHECKSUM(NEWID())) * 195) + 1,
    0,
    GETDATE(),
    ROW_NUMBER() OVER (ORDER BY (SELECT NULL))
FROM master.dbo.spt_values v1;

-- Insert Sales with 0 amount and open/unapproved status
INSERT INTO Sales (BookingNumber, BoLNumber, SaleDate, CustomerID, TotalRevenue, StatusID)
SELECT TOP (@SaleAmount)
    CONCAT('BN-', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))),
    CONCAT('BoL-', Floor(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) /2)),
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 365, GETDATE()),
    (ABS(CHECKSUM(NEWID())) % (@CustomerAmount)) + 1,
    0,  -- Set TotalRevenue to 0
    1   -- Open status (1)
FROM master.dbo.spt_values v1;

-- Generate Customer Invoices with 1 to 5 invoices per sale
WITH CustomerInvoiceGeneration AS (
    SELECT 
        S.SaleID, 
        S.SaleDate,
        (ABS(CHECKSUM(NEWID()) + S.SaleID) % (@MaxCustomerInvoicePerSale)) + 1 AS InvoiceCount
    FROM Sales S
)

-- Insert Customer Invoices
INSERT INTO CustomerInvoices (SaleID, InvoiceAmount, InvoiceDate, StatusID, CustomerInvoiceCode)
SELECT 
    IG.SaleID,
    0,  -- Set InvoiceAmount to 0
    DATEADD(DAY, 
        (RN - 1) * (ABS(CHECKSUM(NEWID()) + IG.SaleID) % 30), 
        IG.SaleDate
    ),
    6,  -- Unpaid status
    CONCAT('CINV-', IG.SaleID, '-', RN)
FROM CustomerInvoiceGeneration IG
CROSS APPLY (
    SELECT TOP (IG.InvoiceCount) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RN
    FROM master.dbo.spt_values
) AS NumGen;

-- Generate Supplier Invoices with 1 to 3 invoices per sale
WITH SupplierInvoiceGeneration AS (
    SELECT 
        S.SaleID, 
        S.SaleDate,
        (ABS(CHECKSUM(NEWID()) + S.SaleID) % (@MaxSupplierInvoicePerSale)) + 1 AS InvoiceCount
    FROM Sales S
)

-- Insert Supplier Invoices
INSERT INTO SupplierInvoices (SaleID, InvoiceAmount, InvoiceDate, StatusID, SupplierInvoiceCode, SupplierID)
SELECT 
    IG.SaleID,
    0,  -- Set InvoiceAmount to 0
    DATEADD(DAY, 
        (RN - 1) * (ABS(CHECKSUM(NEWID()) + IG.SaleID) % 30), 
        IG.SaleDate
    ),
    4,  -- Unapproved status
    CONCAT('SINV-', IG.SaleID, '-', RN),
    (ABS(CHECKSUM(NEWID()) + IG.SaleID * RN) % (@SupplierAmount)) + 1
FROM SupplierInvoiceGeneration IG
CROSS APPLY (
    SELECT TOP (IG.InvoiceCount) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RN
    FROM master.dbo.spt_values
) AS NumGen;

-- Ensure we have data in CostRegistry
IF NOT EXISTS (SELECT 1 FROM CostRegistries WHERE CostRegistryID = 1)
BEGIN
    INSERT INTO CostRegistries (CostRegistryName, CostRegistryPrice, CostRegistryQuantity)
    VALUES ('DefaultCost', 10, 1)
END;

-- Insert CustomerInvoiceCosts with 1 to 8 invoice costs per customer invoice
WITH CustomerInvoiceCostGeneration AS (
    SELECT 
        CI.CustomerInvoiceID, 
        (ABS(CHECKSUM(NEWID()) + CI.CustomerInvoiceID) % (@MaxCostPerCustomerInvoice)) + 1 AS CostCount
    FROM CustomerInvoices CI
)

INSERT INTO CustomerInvoiceCosts (CustomerInvoiceID, Cost, Quantity, Name, CostRegistryID)
SELECT 
    IG.CustomerInvoiceID,
    ROUND(RAND(CHECKSUM(NEWID()) + IG.CustomerInvoiceID + RN) * 1000, 2),
    FLOOR(RAND(CHECKSUM(NEWID()) + IG.CustomerInvoiceID * RN) * 100) + 1,
    CONCAT('Generated Customer Cost ', RN),
    1
FROM CustomerInvoiceCostGeneration IG
CROSS APPLY (
    SELECT TOP (IG.CostCount) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RN
    FROM master.dbo.spt_values
) AS NumGen;

-- Insert SupplierInvoiceCosts with 1 to 8 invoice costs per supplier invoice
WITH SupplierInvoiceCostGeneration AS (
    SELECT 
        SI.SupplierInvoiceID, 
        (ABS(CHECKSUM(NEWID()) + SI.SupplierInvoiceID) % (@MaxCostPerSupplierInvoice)) + 1 AS CostCount
    FROM SupplierInvoices SI
)

INSERT INTO SupplierInvoiceCosts (SupplierInvoiceID, Cost, Quantity, Name, CostRegistryID)
SELECT 
    IG.SupplierInvoiceID,
    ROUND(RAND(CHECKSUM(NEWID()) + IG.SupplierInvoiceID + RN) * 800, 2),
    FLOOR(RAND(CHECKSUM(NEWID()) + IG.SupplierInvoiceID * RN) * 80) + 1,
    CONCAT('Generated Supplier Cost ', RN),
    1
FROM SupplierInvoiceCostGeneration IG
CROSS APPLY (
    SELECT TOP (IG.CostCount) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RN
    FROM master.dbo.spt_values
) AS NumGen;

-- Update Supplier Invoice Amounts based on generated costs
UPDATE SI
SET InvoiceAmount = COALESCE((
    SELECT SUM(Cost * Quantity)
    FROM SupplierInvoiceCosts
    WHERE SupplierInvoiceID = SI.SupplierInvoiceID
), 0)
FROM SupplierInvoices SI;

-- Update Customer Invoice Amounts based on generated costs
UPDATE CI
SET InvoiceAmount = COALESCE((
    SELECT SUM(Cost * Quantity)
    FROM CustomerInvoiceCosts
    WHERE CustomerInvoiceID = CI.CustomerInvoiceID
), 0)
FROM CustomerInvoices CI;

-- Calculate and Update Total Revenue for Sales
UPDATE S
SET TotalRevenue = (
    SELECT SUM(InvoiceAmount)
    FROM CustomerInvoices CI
    WHERE CI.SaleID = S.SaleID
)
FROM Sales S;

-- Update Sales Status (35% to status 2)
UPDATE Sales
SET StatusID = 2
WHERE SaleID IN (
    SELECT TOP (@PercentageClosedSales) PERCENT SaleID 
    FROM Sales 
    ORDER BY NEWID()
);

-- Update Supplier Invoices Status (70% to status 3)
UPDATE SupplierInvoices
SET StatusID = 3
WHERE SupplierInvoiceID IN (
    SELECT TOP (@PercentageClosedSupplierInvoices) PERCENT SupplierInvoiceID 
    FROM SupplierInvoices 
    ORDER BY NEWID()
);

-- Update Customer Invoices Status (50% to status 5)
UPDATE CustomerInvoices
SET StatusID = 5
WHERE CustomerInvoiceID IN (
    SELECT TOP (@PercentageClosedCustomerInvoices) PERCENT CustomerInvoiceID 
    FROM CustomerInvoices 
    ORDER BY NEWID()
);

-- Verification Queries for Invoice Distribution
WITH CustomerInvoiceCountPerSale AS (
    SELECT 
        SaleID, 
        COUNT(*) AS InvoiceCount
    FROM CustomerInvoices
    GROUP BY SaleID
)
SELECT 
    'Customer Invoices per Sale' AS Statistic,
    InvoiceCount, 
    COUNT(*) AS NumberOfSales,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Sales), 2) AS Percentage
FROM CustomerInvoiceCountPerSale
GROUP BY InvoiceCount
ORDER BY InvoiceCount;

WITH SupplierInvoiceCountPerSale AS (
    SELECT 
        SaleID, 
        COUNT(*) AS InvoiceCount
    FROM SupplierInvoices
    GROUP BY SaleID
)
SELECT 
    'Supplier Invoices per Sale' AS Statistic,
    InvoiceCount, 
    COUNT(*) AS NumberOfSales,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Sales), 2) AS Percentage
FROM SupplierInvoiceCountPerSale
GROUP BY InvoiceCount
ORDER BY InvoiceCount;

-- Verification Queries for Status Distribution
SELECT 'Sales Status Distribution' AS Statistic, 
       StatusID, 
       COUNT(*) AS Count, 
       ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Sales), 2) AS Percentage
FROM Sales
GROUP BY StatusID
ORDER BY StatusID;

SELECT 'Supplier Invoices Status Distribution' AS Statistic, 
       StatusID, 
       COUNT(*) AS Count, 
       ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM SupplierInvoices), 2) AS Percentage
FROM SupplierInvoices
GROUP BY StatusID
ORDER BY StatusID;

SELECT 'Customer Invoices Status Distribution' AS Statistic, 
       StatusID, 
       COUNT(*) AS Count, 
       ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM CustomerInvoices), 2) AS Percentage
FROM CustomerInvoices
GROUP BY StatusID
ORDER BY StatusID;

-- Verification Queries for Invoice Cost Distribution
WITH CustomerInvoiceCostCountPerInvoice AS (
    SELECT 
        CustomerInvoiceID, 
        COUNT(*) AS CostCount
    FROM CustomerInvoiceCosts
    GROUP BY CustomerInvoiceID
)
SELECT 
    'Customer Invoice Costs per Invoice' AS Statistic,
    CostCount, 
    COUNT(*) AS NumberOfInvoices,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM CustomerInvoices), 2) AS Percentage
FROM CustomerInvoiceCostCountPerInvoice
GROUP BY CostCount
ORDER BY CostCount;

WITH SupplierInvoiceCostCountPerInvoice AS (
    SELECT 
        SupplierInvoiceID, 
        COUNT(*) AS CostCount
    FROM SupplierInvoiceCosts
    GROUP BY SupplierInvoiceID
)
SELECT 
    'Supplier Invoice Costs per Invoice' AS Statistic,
    CostCount, 
    COUNT(*) AS NumberOfInvoices,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM SupplierInvoices), 2) AS Percentage
FROM SupplierInvoiceCostCountPerInvoice
GROUP BY CostCount
ORDER BY CostCount;

-- Statistical Summaries
SELECT 
    'Sales Statistics' AS Statistic,
    COUNT(*) AS TotalCount,
    SUM(TotalRevenue) AS TotalRevenue,
    AVG(TotalRevenue) AS AverageRevenue,
    MIN(TotalRevenue) AS MinRevenue,
    MAX(TotalRevenue) AS MaxRevenue
FROM Sales;

SELECT 
    'Customer Invoices Statistics' AS Statistic,
    COUNT(*) AS TotalInvoices,
    SUM(InvoiceAmount) AS TotalInvoiceAmount,
    AVG(InvoiceAmount) AS AverageInvoiceAmount,
    MIN(InvoiceAmount) AS MinInvoiceAmount,
    MAX(InvoiceAmount) AS MaxInvoiceAmount
FROM CustomerInvoices;

SELECT 
    'Supplier Invoices Statistics' AS Statistic,
    COUNT(*) AS TotalInvoices,
    SUM(InvoiceAmount) AS TotalInvoiceAmount,
    AVG(InvoiceAmount) AS AverageInvoiceAmount,
    MIN(InvoiceAmount) AS MinInvoiceAmount,
    MAX(InvoiceAmount) AS MaxInvoiceAmount
FROM SupplierInvoices;

-- Statistics for Invoice Costs
SELECT 
    'Customer Invoice Costs Statistics' AS Statistic,
    COUNT(*) AS TotalCosts,
    SUM(Cost * Quantity) AS TotalCostAmount,
    AVG(Cost) AS AverageCost,
    MIN(Cost) AS MinCost,
    MAX(Cost) AS MaxCost
FROM CustomerInvoiceCosts;

SELECT 
    'Supplier Invoice Costs Statistics' AS Statistic,
    COUNT(*) AS TotalCosts,
    SUM(Cost * Quantity) AS TotalCostAmount,
    AVG(Cost) AS AverageCost,
    MIN(Cost) AS MinCost,
    MAX(Cost) AS MaxCost
FROM SupplierInvoiceCosts;