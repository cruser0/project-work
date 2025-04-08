BEGIN TRY
    BEGIN TRANSACTION;

DECLARE @StartTime DATETIME = GETDATE();
DECLARE @StepStartTime DATETIME;
PRINT 'Query started at: ' + CONVERT(VARCHAR, @StartTime, 120);

-- =============================================
-- CONFIGURATION VARIABLES
-- =============================================
DECLARE @SupplierAmount int = 10;                      -- Number of suppliers to generate
DECLARE @CustomerAmount int = 10;                      -- Number of customers to generate
DECLARE @MaxSalePerCustomer int = 10;                   -- Maximum sales per customer
DECLARE @MaxSupplierInvoicePerSale int = 10;            -- Maximum supplier invoices per sale
DECLARE @MaxCustomerInvoicePerSale int = 10;            -- Maximum customer invoices per sale
DECLARE @MaxCostPerSupplierInvoice int = 10;            -- Maximum cost entries per supplier invoice
DECLARE @MaxCostPerCustomerInvoice int = 10;            -- Maximum cost entries per customer invoice
DECLARE @PercentageClosedSupplierInvoices int = 30;     -- % of supplier invoices to be closed (for open sales)
DECLARE @PercentageClosedCustomerInvoices int = 20;     -- % of customer invoices to be closed (for open sales)
DECLARE @PercentageClosedSales int = 15;                -- % of sales to be marked as closed

-- =============================================
-- CLEAN EXISTING DATA
-- =============================================
-- Delete existing data in reverse order of dependencies
DELETE FROM CustomerInvoiceAmoutPaids;
DELETE FROM CustomerInvoiceCosts;
DELETE FROM SupplierInvoiceCosts;
DELETE FROM CustomerInvoices;
DELETE FROM SupplierInvoices;
DELETE FROM Sales;
DELETE FROM Suppliers;
DELETE FROM Customers;

-- Reset identity columns to start fresh
DBCC CHECKIDENT ('Customers', RESEED, 0);
DBCC CHECKIDENT ('Suppliers', RESEED, 0);
DBCC CHECKIDENT ('Sales', RESEED, 0);
DBCC CHECKIDENT ('CustomerInvoices', RESEED, 0);
DBCC CHECKIDENT ('SupplierInvoices', RESEED, 0);
DBCC CHECKIDENT ('CustomerInvoiceCosts', RESEED, 0);
DBCC CHECKIDENT ('SupplierInvoiceCosts', RESEED, 0);
DBCC CHECKIDENT ('CustomerInvoiceAmoutPaids', RESEED, 0);

-- =============================================
-- GENERATE BASE ENTITIES
-- =============================================
-- Insert Suppliers with random country assignments
INSERT INTO Suppliers (SupplierName, CountryID, Deprecated, CreatedAt, OriginalID)
SELECT TOP (@SupplierAmount)
    CONCAT('Supplier', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))), -- Sequential names
    FLOOR(RAND(CHECKSUM(NEWID())) * 195) + 1,                       -- Random country from 1-195
    0,                                                              -- Not deprecated
    GETDATE(),                                                      -- Current date
    ROW_NUMBER() OVER (ORDER BY (SELECT NULL))                      -- Original ID matches sequence
FROM master.dbo.spt_values v1;

-- Insert Customers with random country assignments
INSERT INTO Customers (CustomerName, CountryID, Deprecated, CreatedAt, OriginalID)
SELECT TOP (@CustomerAmount)
    CONCAT('Customer', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))), -- Sequential names
    FLOOR(RAND(CHECKSUM(NEWID())) * 195) + 1,                       -- Random country from 1-195
    0,                                                              -- Not deprecated
    GETDATE(),                                                      -- Current date
    ROW_NUMBER() OVER (ORDER BY (SELECT NULL))                      -- Original ID matches sequence
FROM master.dbo.spt_values v1;

-- =============================================
-- GENERATE SALES RECORDS
-- =============================================
-- Generate between 1 and @MaxSalePerCustomer sales for each customer
WITH SaleGeneration AS (
    SELECT 
        C.CustomerID,
        (ABS(CHECKSUM(NEWID()) + C.CustomerID) % (@MaxSalePerCustomer)) + 1 AS SaleCount
    FROM Customers C
) 

INSERT INTO Sales (BookingNumber, BoLNumber, SaleDate, CustomerID, TotalRevenue, StatusID)
SELECT 
   CONCAT('BN-', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))),        -- Unique booking number
   CONCAT('BoL-', Floor(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) /2)), -- Bill of Lading number (shared between 2 sales)
   DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 365, GETDATE()),          -- Random date within past year
   SG.CustomerID,
   0,                                                               -- Initial TotalRevenue (will update later)
   1                                                                -- Open status (1)
FROM SaleGeneration SG
CROSS APPLY (
    SELECT TOP (SG.SaleCount) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RN
    FROM master.dbo.spt_values
) AS NumGen;

-- =============================================
-- GENERATE CUSTOMER INVOICES
-- =============================================
-- Generate between 1 and @MaxCustomerInvoicePerSale invoices per sale
WITH CustomerInvoiceGeneration AS (
    SELECT 
        S.SaleID, 
        S.SaleDate,
        (ABS(CHECKSUM(NEWID())) % (@MaxCustomerInvoicePerSale)) + 1 AS InvoiceCount
    FROM Sales S
)

INSERT INTO CustomerInvoices (SaleID, InvoiceAmount, InvoiceDate, StatusID, CustomerInvoiceCode)
SELECT 
    IG.SaleID,
    0,                                                               -- Initial InvoiceAmount (will update later)
    DATEADD(DAY,                                                     -- Invoice date is sale date + random days
        (RN - 1) * (ABS(CHECKSUM(NEWID())) % 30), 
        IG.SaleDate
    ),
    6,                                                               -- Default status: Unpaid (6)
    CONCAT('CINV-', IG.SaleID, '-', RN)                             -- Unique invoice code

FROM CustomerInvoiceGeneration IG
CROSS APPLY (
    SELECT TOP (IG.InvoiceCount) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RN
    FROM master.dbo.spt_values
) AS NumGen;

-- =============================================
-- GENERATE SUPPLIER INVOICES
-- =============================================
-- Generate between 1 and @MaxSupplierInvoicePerSale invoices per sale
WITH SupplierInvoiceGeneration AS (
    SELECT 
        S.SaleID, 
        S.SaleDate,
        (ABS(CHECKSUM(NEWID())) % (@MaxSupplierInvoicePerSale)) + 1 AS InvoiceCount
    FROM Sales S
)

INSERT INTO SupplierInvoices (SaleID, InvoiceAmount, InvoiceDate, StatusID, SupplierInvoiceCode, SupplierID)
SELECT 
    IG.SaleID,
    0,                                                               -- Initial InvoiceAmount (will update later)
    DATEADD(DAY,                                                     -- Invoice date is sale date + random days
        (RN - 1) * (ABS(CHECKSUM(NEWID())) % 30), 
        IG.SaleDate
    ),
    4,                                                               -- Default status: Unapproved (4)
    CONCAT('SINV-', IG.SaleID, '-', RN),                            -- Unique invoice code
    (ABS(CHECKSUM(NEWID()) + IG.SaleID * RN) % (@SupplierAmount)) + 1 -- Random supplier assignment
FROM SupplierInvoiceGeneration IG
CROSS APPLY (
    SELECT TOP (IG.InvoiceCount) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RN
    FROM master.dbo.spt_values
) AS NumGen;

-- =============================================
-- GENERATE CUSTOMER INVOICE COSTS
-- =============================================
-- Generate between 1 and @MaxCostPerCustomerInvoice costs per customer invoice
WITH CustomerInvoiceCostGeneration AS (
    SELECT 
        CI.CustomerInvoiceID, 
        1 + ABS(CHECKSUM(NEWID()) % @MaxCostPerCustomerInvoice) AS CostCount
    FROM CustomerInvoices CI
)

INSERT INTO CustomerInvoiceCosts (CustomerInvoiceID, Cost, Quantity, Name, CostRegistryID)
SELECT 
    IG.CustomerInvoiceID,
    ROUND(RAND(ABS(CHECKSUM(NEWID())) % 1000) * 1000, 2), -- Random cost up to $1000
    FLOOR(RAND(ABS(CHECKSUM(NEWID())) % 100) * 100) + 1,  -- Random quantity 1-100
    CONCAT('Generated Customer Cost ', RN),               -- Cost name
    1                                                     -- Default cost registry
FROM CustomerInvoiceCostGeneration IG
CROSS APPLY (
    SELECT TOP (IG.CostCount) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RN
    FROM master.dbo.spt_values
) AS NumGen;

-- =============================================
-- GENERATE SUPPLIER INVOICE COSTS
-- =============================================
-- Generate between 1 and @MaxCostPerSupplierInvoice costs per supplier invoice
WITH SupplierInvoiceCostGeneration AS (
    SELECT 
        SI.SupplierInvoiceID, 
        1 + ABS(CHECKSUM(NEWID()) % @MaxCostPerSupplierInvoice) AS CostCount
    FROM SupplierInvoices SI
)

INSERT INTO SupplierInvoiceCosts (SupplierInvoiceID, Cost, Quantity, Name, CostRegistryID, CustomerInvoiceCostID)
SELECT 
    IG.SupplierInvoiceID,
    ROUND(RAND(ABS(CHECKSUM(NEWID())) % 800) * 800, 2), -- Random cost up to $800
    FLOOR(RAND(ABS(CHECKSUM(NEWID())) % 80) * 80) + 1,  -- Random quantity 1-80
    CONCAT('Generated Supplier Cost ', RN),             -- Cost name
    1,                                                  -- Default cost registry
    NULL                                                -- No linked customer invoice cost
FROM SupplierInvoiceCostGeneration IG
CROSS APPLY (
    SELECT TOP (IG.CostCount) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RN
    FROM master.dbo.spt_values
) AS NumGen;

-- =============================================
-- UPDATE CALCULATED INVOICE AMOUNTS
-- =============================================
-- Calculate supplier invoice amounts based on their line items
UPDATE SI
SET InvoiceAmount = COALESCE((
    SELECT SUM(Cost * Quantity)
    FROM SupplierInvoiceCosts
    WHERE SupplierInvoiceID = SI.SupplierInvoiceID
), 0)
FROM SupplierInvoices SI;

-- Calculate customer invoice amounts based on their line items
UPDATE CI
SET InvoiceAmount = COALESCE((
    SELECT SUM(Cost * Quantity)
    FROM CustomerInvoiceCosts
    WHERE CustomerInvoiceID = CI.CustomerInvoiceID
), 0)
FROM CustomerInvoices CI;

-- Update total revenue for each sale based on sum of customer invoices
UPDATE S
SET TotalRevenue = (
    SELECT SUM(InvoiceAmount)
    FROM CustomerInvoices CI
    WHERE CI.SaleID = S.SaleID
)
FROM Sales S;

-- =============================================
-- UPDATE STATUSES
-- =============================================
-- Update selected sales to Closed status (2)
UPDATE Sales
SET StatusID = 2
WHERE SaleID IN (
    SELECT TOP (@PercentageClosedSales) PERCENT SaleID 
    FROM Sales 
    ORDER BY NEWID()
);

-- Auto-close all supplier invoices for closed sales
UPDATE SupplierInvoices
SET StatusID = 3 -- Paid status
WHERE SaleID IN (
    SELECT SaleID
    FROM Sales
    WHERE StatusID = 2
);

-- Close a percentage of supplier invoices for open sales
UPDATE SupplierInvoices
SET StatusID = 3 -- Paid status
WHERE SupplierInvoiceID IN (
    SELECT TOP (@PercentageClosedSupplierInvoices) PERCENT SupplierInvoiceID 
    FROM SupplierInvoices 
    ORDER BY NEWID()
) AND 
SaleID IN (
    SELECT SaleID
    FROM Sales
    WHERE StatusID = 1 -- Open sales only
);

-- Auto-close all customer invoices for closed sales
UPDATE CustomerInvoices
SET StatusID = 5 -- Paid status
WHERE SaleID IN (
    SELECT SaleID
    FROM Sales
    WHERE StatusID = 2 -- Closed sales
);

-- Close a percentage of customer invoices for open sales
UPDATE CustomerInvoices
SET StatusID = 5 -- Paid status
WHERE CustomerInvoiceID IN (
    SELECT TOP (@PercentageClosedCustomerInvoices) PERCENT CustomerInvoiceID 
    FROM CustomerInvoices 
    ORDER BY NEWID()
) AND 
SaleID IN (
    SELECT SaleID
    FROM Sales
    WHERE StatusID = 1 -- Open sales only
);

-- =============================================
-- GENERATE PAYMENT RECORDS
-- =============================================
-- Insert payment records based on invoice status
INSERT INTO CustomerInvoiceAmoutPaids(CustomerInvoiceID, AmountPaid)
SELECT 
    CustomerInvoiceID, 
    CASE 
        WHEN StatusID = 6 THEN 0             -- Unpaid invoices: zero payment
        WHEN StatusID = 5 THEN InvoiceAmount -- Paid invoices: full payment
        ELSE 0                               -- Default case
    END AS AmountPaid
FROM CustomerInvoices;

-- =============================================
-- COMPREHENSIVE STATISTICS REPORTS
-- =============================================

-- =============================================
-- 1. ENTITY COUNT SUMMARY
-- =============================================
SELECT 'ENTITY COUNT SUMMARY' AS ReportSection;

SELECT 
    'Entity Counts' AS StatisticType,
    (SELECT COUNT(*) FROM Customers) AS TotalCustomers,
    (SELECT COUNT(*) FROM Suppliers) AS TotalSuppliers,
    (SELECT COUNT(*) FROM Sales) AS TotalSales,
    (SELECT COUNT(*) FROM CustomerInvoices) AS TotalCustomerInvoices,
    (SELECT COUNT(*) FROM SupplierInvoices) AS TotalSupplierInvoices,
    (SELECT COUNT(*) FROM CustomerInvoiceCosts) AS TotalCustomerCostItems,
    (SELECT COUNT(*) FROM SupplierInvoiceCosts) AS TotalSupplierCostItems;

-- =============================================
-- 2. INVOICE DISTRIBUTION ANALYSIS
-- =============================================
SELECT 'INVOICE DISTRIBUTION ANALYSIS' AS ReportSection;

-- Customer invoice distribution per sale
WITH CustomerInvoiceCountPerSale AS (
    SELECT 
        SaleID, 
        COUNT(*) AS InvoiceCount
    FROM CustomerInvoices
    GROUP BY SaleID
)
SELECT 
    'Customer Invoices per Sale' AS StatisticType,
    InvoiceCount, 
    COUNT(*) AS NumberOfSales,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Sales), 2) AS Percentage
FROM CustomerInvoiceCountPerSale
GROUP BY InvoiceCount
ORDER BY InvoiceCount;

-- Supplier invoice distribution per sale
WITH SupplierInvoiceCountPerSale AS (
    SELECT 
        SaleID, 
        COUNT(*) AS InvoiceCount
    FROM SupplierInvoices
    GROUP BY SaleID
)
SELECT 
    'Supplier Invoices per Sale' AS StatisticType,
    InvoiceCount, 
    COUNT(*) AS NumberOfSales,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Sales), 2) AS Percentage
FROM SupplierInvoiceCountPerSale
GROUP BY InvoiceCount
ORDER BY InvoiceCount;

-- =============================================
-- 3. STATUS DISTRIBUTION ANALYSIS
-- =============================================
SELECT 'STATUS DISTRIBUTION ANALYSIS' AS ReportSection;

-- Sale status distribution with status descriptions
WITH SaleStatuses AS (
    SELECT 1 AS ID, 'Open' AS StatusName
    UNION SELECT 2, 'Closed'
)
SELECT 
    'Sales Status Distribution' AS StatisticType, 
    S.StatusID,
    SS.StatusName, 
    COUNT(*) AS Count, 
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Sales), 2) AS Percentage
FROM Sales S
JOIN SaleStatuses SS ON S.StatusID = SS.ID
GROUP BY S.StatusID, SS.StatusName
ORDER BY S.StatusID;

-- Supplier invoice status distribution with status descriptions
WITH SupplierStatuses AS (
    SELECT 3 AS ID, 'Paid' AS StatusName
    UNION SELECT 4, 'Unapproved'
)
SELECT 
    'Supplier Invoices Status Distribution' AS StatisticType, 
    SI.StatusID,
    SS.StatusName, 
    COUNT(*) AS Count, 
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM SupplierInvoices), 2) AS Percentage
FROM SupplierInvoices SI
JOIN SupplierStatuses SS ON SI.StatusID = SS.ID
GROUP BY SI.StatusID, SS.StatusName
ORDER BY SI.StatusID;

-- Customer invoice status distribution with status descriptions
WITH CustomerStatuses AS (
    SELECT 5 AS ID, 'Paid' AS StatusName
    UNION SELECT 6, 'Unpaid'
)
SELECT 
    'Customer Invoices Status Distribution' AS StatisticType, 
    CI.StatusID,
    CS.StatusName, 
    COUNT(*) AS Count, 
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM CustomerInvoices), 2) AS Percentage
FROM CustomerInvoices CI
JOIN CustomerStatuses CS ON CI.StatusID = CS.ID
GROUP BY CI.StatusID, CS.StatusName
ORDER BY CI.StatusID;

-- =============================================
-- 4. COST DISTRIBUTION ANALYSIS
-- =============================================
SELECT 'COST DISTRIBUTION ANALYSIS' AS ReportSection;

-- Customer invoice cost distribution
WITH CustomerInvoiceCostCountPerInvoice AS (
    SELECT 
        CustomerInvoiceID, 
        COUNT(*) AS CostCount
    FROM CustomerInvoiceCosts
    GROUP BY CustomerInvoiceID
)
SELECT 
    'Customer Invoice Costs per Invoice' AS StatisticType,
    CostCount, 
    COUNT(*) AS NumberOfInvoices,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM CustomerInvoices), 2) AS Percentage
FROM CustomerInvoiceCostCountPerInvoice
GROUP BY CostCount
ORDER BY CostCount;

-- Supplier invoice cost distribution
WITH SupplierInvoiceCostCountPerInvoice AS (
    SELECT 
        SupplierInvoiceID, 
        COUNT(*) AS CostCount
    FROM SupplierInvoiceCosts
    GROUP BY SupplierInvoiceID
)
SELECT 
    'Supplier Invoice Costs per Invoice' AS StatisticType,
    CostCount, 
    COUNT(*) AS NumberOfInvoices,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM SupplierInvoices), 2) AS Percentage
FROM SupplierInvoiceCostCountPerInvoice
GROUP BY CostCount
ORDER BY CostCount;

-- =============================================
-- 5. FINANCIAL SUMMARY ANALYSIS
-- =============================================
SELECT 'FINANCIAL SUMMARY ANALYSIS' AS ReportSection;

-- Sales financial summary with percentile analysis
SELECT 
    'Sales Financial Summary' AS StatisticType,
    COUNT(*) AS TotalCount,
    FORMAT(SUM(TotalRevenue), 'C', 'en-us') AS TotalRevenue,
    FORMAT(AVG(TotalRevenue), 'C', 'en-us') AS AverageRevenue,
    FORMAT(MIN(TotalRevenue), 'C', 'en-us') AS MinRevenue,
    FORMAT(MAX(TotalRevenue), 'C', 'en-us') AS MaxRevenue,
    FORMAT(STDEV(TotalRevenue), 'C', 'en-us') AS StdDevRevenue
FROM Sales;

-- Customer invoices financial summary with percentile analysis
SELECT 
    'Customer Invoices Financial Summary' AS StatisticType,
    COUNT(*) AS TotalInvoices,
    FORMAT(SUM(InvoiceAmount), 'C', 'en-us') AS TotalInvoiceAmount,
    FORMAT(AVG(InvoiceAmount), 'C', 'en-us') AS AvgInvoiceAmount,
    FORMAT(MIN(InvoiceAmount), 'C', 'en-us') AS MinInvoiceAmount,
    FORMAT(MAX(InvoiceAmount), 'C', 'en-us') AS MaxInvoiceAmount,
    FORMAT(STDEV(InvoiceAmount), 'C', 'en-us') AS StdDevInvoiceAmount
FROM CustomerInvoices;

-- Supplier invoices financial summary with percentile analysis
SELECT 
    'Supplier Invoices Financial Summary' AS StatisticType,
    COUNT(*) AS TotalInvoices,
    FORMAT(SUM(InvoiceAmount), 'C', 'en-us') AS TotalInvoiceAmount,
    FORMAT(AVG(InvoiceAmount), 'C', 'en-us') AS AvgInvoiceAmount,
    FORMAT(MIN(InvoiceAmount), 'C', 'en-us') AS MinInvoiceAmount,
    FORMAT(MAX(InvoiceAmount), 'C', 'en-us') AS MaxInvoiceAmount,
    FORMAT(STDEV(InvoiceAmount), 'C', 'en-us') AS StdDevInvoiceAmount
FROM SupplierInvoices;

-- =============================================
-- 6. COST ITEM ANALYSIS
-- =============================================
SELECT 'COST ITEM ANALYSIS' AS ReportSection;

-- Customer invoice cost items summary
SELECT 
    'Customer Invoice Cost Items Analysis' AS StatisticType,
    COUNT(*) AS TotalCostItems,
    FORMAT(SUM(Cost * Quantity), 'C', 'en-us') AS TotalCostValue,
    FORMAT(AVG(Cost), 'C', 'en-us') AS AverageCostPerItem,
    FORMAT(AVG(Quantity), 'N2') AS AverageQuantityPerItem,
    FORMAT(MIN(Cost), 'C', 'en-us') AS MinCost,
    FORMAT(MAX(Cost), 'C', 'en-us') AS MaxCost
FROM CustomerInvoiceCosts;

-- Supplier invoice cost items summary
SELECT 
    'Supplier Invoice Cost Items Analysis' AS StatisticType,
    COUNT(*) AS TotalCostItems,
    FORMAT(SUM(Cost * Quantity), 'C', 'en-us') AS TotalCostValue,
    FORMAT(AVG(Cost), 'C', 'en-us') AS AverageCostPerItem,
    FORMAT(AVG(Quantity), 'N2') AS AverageQuantityPerItem,
    FORMAT(MIN(Cost), 'C', 'en-us') AS MinCost,
    FORMAT(MAX(Cost), 'C', 'en-us') AS MaxCost
FROM SupplierInvoiceCosts;

-- =============================================
-- 7. PROFITABILITY ANALYSIS
-- =============================================
SELECT 'PROFITABILITY ANALYSIS' AS ReportSection;

-- Overall profitability summary
SELECT
    'Overall Profitability' AS StatisticType,
    FORMAT((SELECT SUM(InvoiceAmount) FROM CustomerInvoices), 'C', 'en-us') AS TotalRevenue,
    FORMAT((SELECT SUM(InvoiceAmount) FROM SupplierInvoices), 'C', 'en-us') AS TotalCost,
    FORMAT((SELECT SUM(InvoiceAmount) FROM CustomerInvoices) - 
           (SELECT SUM(InvoiceAmount) FROM SupplierInvoices), 'C', 'en-us') AS GrossProfit,
    FORMAT(((SELECT SUM(InvoiceAmount) FROM CustomerInvoices) - 
            (SELECT SUM(InvoiceAmount) FROM SupplierInvoices)) / 
            NULLIF((SELECT SUM(InvoiceAmount) FROM CustomerInvoices), 0) * 100, 'N2') + '%' AS GrossProfitMargin;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    THROW;
END CATCH;