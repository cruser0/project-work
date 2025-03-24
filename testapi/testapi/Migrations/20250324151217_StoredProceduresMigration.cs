using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class StoredProceduresMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[pf_ClassifySalesByProfit]
                @TotalSpentFrom INT = NULL,
                @TotalSpentTo INT = NULL,
                @TotalRevenueFrom INT = NULL,
                @TotalRevenueTo INT = NULL,
                @FilterMargin NVARCHAR(50) = NULL,
                @ProfitFrom INT = NULL,
                @ProfitTo INT = NULL,
                @BoLNumber VARCHAR(100) = NULL,
                @BKNumber VARCHAR(100) = NULL,
                @CustomerID INT = NULL,
                @Status VARCHAR(20) = NULL,
                @CustomerName VARCHAR(100) = NULL,
                @CustomerCountry VARCHAR(100) = NULL,
                @CountryRegion VARCHAR(100) = NULL,
                @SaleID INT = NULL,
                @DateFrom DATETIME = NULL,
                @DateTo DATETIME = NULL
            AS
            BEGIN
                WITH SalesData AS (
                    SELECT 
                        aIN.*, sBolBk.BoLNumber, sBolBk.BookingNumber, sBolBk.SaleDate, sBolBk.Status, sBolBk.CustomerName, sBolBk.Country, sBolBk.Region,
                        aOUT.TotalSpent, 
                        (aIN.TotalRevenue - aOUT.TotalSpent) AS Profit, 
                        CASE 
                            WHEN (aIN.TotalRevenue - aOUT.TotalSpent) <= 0 THEN 'no profit'  
                            WHEN (aIN.TotalRevenue - aOUT.TotalSpent) <= 6000 THEN 'risky' 
                            WHEN (aIN.TotalRevenue - aOUT.TotalSpent) > 6000 THEN 'profit'
                            ELSE NULL 
                        END AS SaleMargins
                    FROM 
                        (SELECT 
                            cs.SaleID,
                            SUM(cs.InvoiceAmount) AS TotalRevenue 
                        FROM Progetto_Formativo.dbo.CustomerInvoices cs
                        GROUP BY cs.SaleID
                        HAVING 
                            (@TotalRevenueFrom IS NULL OR SUM(cs.InvoiceAmount) >= @TotalRevenueFrom) AND
                            (@TotalRevenueTo IS NULL OR SUM(cs.InvoiceAmount) <= @TotalRevenueTo)
                        ) AS aIN
                    JOIN 
                        (SELECT 
                            s.SaleID, 
                            SUM(si.InvoiceAmount) AS TotalSpent
                        FROM Progetto_Formativo.dbo.SupplierInvoices si
                        JOIN Progetto_Formativo.dbo.Sales s ON s.SaleID = si.SaleID
                        GROUP BY s.SaleID
                        HAVING 
                            (@TotalSpentFrom IS NULL OR SUM(si.InvoiceAmount) >= @TotalSpentFrom) AND
                            (@TotalSpentTo IS NULL OR SUM(si.InvoiceAmount) <= @TotalSpentTo)
                        ) AS aOUT 
                    ON aIN.SaleID = aOUT.SaleID
                    JOIN dbo.Sale_Filtered(@BKNumber, @BoLNumber, @CustomerID, @Status, @CustomerName, @CustomerCountry, @CountryRegion, @SaleID, @DateFrom, @DateTo) sBolBk 
                    ON sBolBk.SaleID = aIN.SaleID
                )
                SELECT * 
                FROM SalesData sd
                WHERE (@FilterMargin IS NULL OR SaleMargins = @FilterMargin) AND
                      (@ProfitFrom  IS NULL OR Profit >= @ProfitFrom) AND
                      (@ProfitTo  IS NULL OR Profit <= @ProfitTo) AND
                      (sd.TotalRevenue <> 0 OR sd.TotalSpent <> 0);
            END;
        ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[pf_TotalAmountGainedPerCustomerInvoice]
                    @customerInvoiceID INT = NULL,
                    @TotalGainedFrom INT = NULL,
                    @TotalGainedTo INT = NULL,
                    @DateFrom DATETIME = NULL,
                    @DateTo DATETIME = NULL,
                    @Status VARCHAR(20) = NULL,
                    @CustomerName VARCHAR(100) = NULL,
                    @CustomerCountry VARCHAR(100) = NULL,
                    @CountryRegion VARCHAR(100) = NULL
                AS
                BEGIN
                    SELECT DISTINCT ci.CustomerInvoiceID, ci.InvoiceDate, ci.SaleID, st.StatusName AS Status, cif.TotalGained, cus.CustomerName, co.CountryName  AS Country, co.Region
                    FROM Progetto_Formativo.dbo.CustomerinvoiceCosts AS c
                    LEFT JOIN Progetto_Formativo.dbo.CustomerInvoices ci ON c.CustomerInvoiceID = ci.CustomerInvoiceID
                    JOIN dbo.Sales s ON s.SaleID = ci.SaleID
                    JOIN dbo.Customers cus ON cus.CustomerID = s.CustomerID
		            JOIN dbo.Country co ON cus.CountryID = co.CountryID
		            JOIN dbo.Statuses st ON st.StatusID = ci.StatusID

                    JOIN dbo.Customer_Invoice_Filtered(@customerInvoiceID) cif ON cif.CustomerInvoiceID = ci.CustomerInvoiceID
                    WHERE (@TotalGainedFrom IS NULL OR cif.TotalGained >= @TotalGainedFrom) AND
                          (@TotalGainedTo IS NULL OR cif.TotalGained <= @TotalGainedTo) AND
                          (@Status IS NULL OR st.StatusName = @Status) AND
                          (@CustomerCountry IS NULL OR co.CountryName LIKE '%' + @CustomerCountry + '%') AND
                          (@CountryRegion IS NULL OR co.Region LIKE '%' + @CountryRegion + '%') AND
                          (@CustomerName IS NULL OR cus.CustomerName LIKE '%' + @CustomerName + '%') AND
                          (@DateFrom IS NULL OR ci.InvoiceDate >= @DateFrom) AND
                          (@DateTo IS NULL OR ci.InvoiceDate <= @DateTo);
                END;
            ");

            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[pf_TotalAmountSpentPerSupplierInvoice]
            (
                @SupplierInvoiceID int =null,
	            @TotalSpentFrom int =null,
	            @TotalSpentTo int=null,
	            @DateFrom DateTime =null,
	            @DateTo DateTime=null,
	            @Status varchar(20)=null,
	            @SupplierName varchar(100)=null,
	            @SupplierCountry varchar(100)=null,
                @CountryRegion VARCHAR(100) = NULL
            )

            AS
            BEGIN
                select distinct si.SupplierInvoiceID,si.SaleID,si.SupplierID,si.InvoiceDate,st.StatusName AS Status,sup.SupplierName,co.CountryName AS Country, co.Region, sif.TotalSpent
		            from Progetto_Formativo.dbo.SupplierInvoiceCosts as sic
		            left join Progetto_Formativo.dbo.SupplierInvoices si on si.SupplierInvoiceID=sic.SupplierInvoiceID
		            join dbo.Suppliers sup on sup.SupplierID = si.SupplierID
		            join dbo.Supplier_Invoice_Filtered(@SupplierInvoiceID) sif on sif.SupplierInvoiceID=si.SupplierInvoiceID
		            JOIN dbo.Country co ON sup.CountryID = co.CountryID
		            JOIN dbo.Statuses st ON st.StatusID = si.StatusID
		            where 
		            (@TotalSpentFrom is null or sif.TotalSpent>=@TotalSpentFrom)and
		            (@TotalSpentTo is null or sif.TotalSpent<=@TotalSpentTo)and
		            (@Status is null or st.StatusName=@Status)and
		            (@SupplierCountry is null or co.CountryName like '%'+@SupplierCountry+'%')and
                    (@CountryRegion IS NULL OR co.Region LIKE '%' + @CountryRegion + '%') AND
		            (@SupplierName is null or sup.SupplierName like '%'+@SupplierName+'%')and
		            (@DateFrom is null or si.InvoiceDate>=@DateFrom)and
		            (@DateTo is null or si.InvoiceDate<=@DateTo)
            END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[pf_ClassifySalesByProfit];");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[pf_TotalAmountGainedPerCustomerInvoice];");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[pf_TotalAmountSpentPerSupplierInvoice];");
        }
    }
}
