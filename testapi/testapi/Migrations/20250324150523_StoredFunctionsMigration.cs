using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class FunctionSQLMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE FUNCTION [dbo].[Sale_Filtered] (
                    @BookingNumber VARCHAR(100),
                    @BoLNumber VARCHAR(100),
                    @CustomerID INT,
                    @Status VARCHAR(20),
                    @CustomerName VARCHAR(100),
                    @CustomerCountry VARCHAR(100),
                    @CountryRegion VARCHAR(100),
                    @SaleID INT,
                    @DateFrom DATETIME,
                    @DateTo DATETIME
                )
                RETURNS TABLE
                AS
                RETURN
                    SELECT 
                        s.SaleID, s.BoLNumber, s.BookingNumber, s.SaleDate, st.StatusName As Status, c.CustomerName, co.CountryName As Country, co.Region
                    FROM
                        dbo.Sales s
                    LEFT JOIN dbo.Customers c ON c.CustomerID = s.CustomerID
                    LEFT JOIN dbo.Country co ON co.CountryID = c.CountryID
                    LEFT JOIN dbo.Statuses st ON s.StatusID = st.StatusID
                    WHERE
                        (@CustomerID IS NULL OR @CustomerID = s.CustomerID) AND
                        (@BoLNumber IS NULL OR s.BoLNumber LIKE '%' + @BoLNumber + '%') AND
                        (@BookingNumber IS NULL OR @BookingNumber LIKE '%' + s.BookingNumber + '%') AND
                        (@Status IS NULL OR @Status = st.StatusName) AND
                        (@CustomerName IS NULL OR c.CustomerName LIKE '%' + @CustomerName + '%') AND
                        (@CustomerCountry IS NULL OR co.CountryName LIKE '%' + @CustomerCountry + '%') AND
                        (@CountryRegion IS NULL OR co.Region = @CountryRegion) AND
                        
                        (@SaleID IS NULL OR @SaleID = s.SaleID) AND
                        (@DateFrom IS NULL OR s.SaleDate >= @DateFrom) AND
                        (@DateTo IS NULL OR s.SaleDate <= @DateTo)
            ");

            migrationBuilder.Sql(@"
                CREATE FUNCTION [dbo].[Customer_Invoice_Filtered] (
                    @CustomerInvoiceID INT
                )
                RETURNS TABLE
                AS
                RETURN
                    SELECT c.CustomerInvoiceID, SUM(cic.Cost * cic.quantity) AS TotalGained
                    FROM Progetto_Formativo.dbo.CustomerinvoiceCosts AS cic
                    LEFT JOIN Progetto_Formativo.dbo.CustomerInvoices c ON c.CustomerInvoiceID = cic.CustomerInvoiceID
                    WHERE (@CustomerInvoiceID IS NULL OR @CustomerInvoiceID = c.CustomerInvoiceID)
                    GROUP BY c.CustomerInvoiceID;
            ");

            migrationBuilder.Sql(@"
                CREATE FUNCTION [dbo].[Supplier_Invoice_Filtered] (
                    @SupplierInvoiceID INT
                )
                RETURNS TABLE
                AS
                RETURN
                    SELECT s.SupplierInvoiceID, SUM(sic.Cost * sic.quantity) AS TotalSpent
                    FROM Progetto_Formativo.dbo.SupplierinvoiceCosts AS sic
                    LEFT JOIN Progetto_Formativo.dbo.SupplierInvoices s ON s.SupplierInvoiceID = sic.SupplierInvoiceID
                    WHERE (@SupplierInvoiceID IS NULL OR @SupplierInvoiceID = s.SupplierInvoiceID)
                    GROUP BY s.SupplierInvoiceID;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS [dbo].[Sale_Filtered];");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS [dbo].[Customer_Invoice_Filtered];");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS [dbo].[Supplier_Invoice_Filtered];");
        }
    }
}
