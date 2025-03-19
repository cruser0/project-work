using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_SupplierName_Country",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerName_Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SupplierInvoices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CustomerInvoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceID",
                table: "SupplierInvoices",
                newName: "SupplierInvoiceID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "CustomerID");

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "SupplierInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostRegistryID",
                table: "SupplierInvoiceCosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "CustomerInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostRegistryID",
                table: "CustomerInvoiceCosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CostRegistries",
                columns: table => new
                {
                    CostRegistryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostRegistryUniqueCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CostRegistryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostRegistryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CostRegistryQuantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostRegistries", x => x.CostRegistryID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ISOCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDGVs_UserID",
                table: "UserDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CountryID",
                table: "Suppliers",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierName_CountryID",
                table: "Suppliers",
                columns: new[] { "SupplierName", "CountryID" },
                unique: true,
                filter: "[SupplierName] IS NOT NULL AND [CountryID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoices_StatusID",
                table: "SupplierInvoices",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoiceDGVs_UserID",
                table: "SupplierInvoiceDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoiceCosts_CostRegistryID",
                table: "SupplierInvoiceCosts",
                column: "CostRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoiceCostDGVs_UserID",
                table: "SupplierInvoiceCostDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierGroupSplits_UserID",
                table: "SupplierGroupSplits",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierDGVs_UserID",
                table: "SupplierDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BoLNumber_BookingNumber",
                table: "Sales",
                columns: new[] { "BoLNumber", "BookingNumber" },
                unique: true,
                filter: "[BoLNumber] IS NOT NULL AND [BookingNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_StatusID",
                table: "Sales",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDGVs_UserID",
                table: "SaleDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryID",
                table: "Customers",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerName_CountryID",
                table: "Customers",
                columns: new[] { "CustomerName", "CountryID" },
                unique: true,
                filter: "[CustomerName] IS NOT NULL AND [CountryID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_StatusID",
                table: "CustomerInvoices",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceDGVs_UserID",
                table: "CustomerInvoiceDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceCosts_CostRegistryID",
                table: "CustomerInvoiceCosts",
                column: "CostRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceCostDGVs_UserID",
                table: "CustomerInvoiceCostDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupSplits_UserID",
                table: "CustomerGroupSplits",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDGVs_UserID",
                table: "CustomerDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CountryName",
                table: "Country",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_ISOCode",
                table: "Country",
                column: "ISOCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDGVs_Users_UserID",
                table: "CustomerDGVs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroupSplits_Users_UserID",
                table: "CustomerGroupSplits",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInvoiceCostDGVs_Users_UserID",
                table: "CustomerInvoiceCostDGVs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "costRegistry_CustomerInvoiceCosts_fk",
                table: "CustomerInvoiceCosts",
                column: "CostRegistryID",
                principalTable: "CostRegistries",
                principalColumn: "CostRegistryID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInvoiceDGVs_Users_UserID",
                table: "CustomerInvoiceDGVs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "status_CustomerInvoices_fk",
                table: "CustomerInvoices",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "customer_country_fk",
                table: "Customers",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users",
                table: "RefreshTokens",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDGVs_Users_UserID",
                table: "SaleDGVs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "status_Sales_fk",
                table: "Sales",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierDGVs_Users_UserID",
                table: "SupplierDGVs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierGroupSplits_Users_UserID",
                table: "SupplierGroupSplits",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceCostDGVs_Users_UserID",
                table: "SupplierInvoiceCostDGVs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "costRegistry_SupplierInvoiceCosts_fk",
                table: "SupplierInvoiceCosts",
                column: "CostRegistryID",
                principalTable: "CostRegistries",
                principalColumn: "CostRegistryID");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceDGVs_Users_UserID",
                table: "SupplierInvoiceDGVs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "status_supplierInvoices_fk",
                table: "SupplierInvoices",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "supplier_country_fk",
                table: "Suppliers",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDGVs_Users_UserID",
                table: "UserDGVs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDGVs_Users_UserID",
                table: "CustomerDGVs");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroupSplits_Users_UserID",
                table: "CustomerGroupSplits");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInvoiceCostDGVs_Users_UserID",
                table: "CustomerInvoiceCostDGVs");

            migrationBuilder.DropForeignKey(
                name: "costRegistry_CustomerInvoiceCosts_fk",
                table: "CustomerInvoiceCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInvoiceDGVs_Users_UserID",
                table: "CustomerInvoiceDGVs");

            migrationBuilder.DropForeignKey(
                name: "status_CustomerInvoices_fk",
                table: "CustomerInvoices");

            migrationBuilder.DropForeignKey(
                name: "customer_country_fk",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDGVs_Users_UserID",
                table: "SaleDGVs");

            migrationBuilder.DropForeignKey(
                name: "status_Sales_fk",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierDGVs_Users_UserID",
                table: "SupplierDGVs");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierGroupSplits_Users_UserID",
                table: "SupplierGroupSplits");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierInvoiceCostDGVs_Users_UserID",
                table: "SupplierInvoiceCostDGVs");

            migrationBuilder.DropForeignKey(
                name: "costRegistry_SupplierInvoiceCosts_fk",
                table: "SupplierInvoiceCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierInvoiceDGVs_Users_UserID",
                table: "SupplierInvoiceDGVs");

            migrationBuilder.DropForeignKey(
                name: "status_supplierInvoices_fk",
                table: "SupplierInvoices");

            migrationBuilder.DropForeignKey(
                name: "supplier_country_fk",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDGVs_Users_UserID",
                table: "UserDGVs");

            migrationBuilder.DropTable(
                name: "CostRegistries");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_UserDGVs_UserID",
                table: "UserDGVs");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CountryID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_SupplierName_CountryID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_SupplierInvoices_StatusID",
                table: "SupplierInvoices");

            migrationBuilder.DropIndex(
                name: "IX_SupplierInvoiceDGVs_UserID",
                table: "SupplierInvoiceDGVs");

            migrationBuilder.DropIndex(
                name: "IX_SupplierInvoiceCosts_CostRegistryID",
                table: "SupplierInvoiceCosts");

            migrationBuilder.DropIndex(
                name: "IX_SupplierInvoiceCostDGVs_UserID",
                table: "SupplierInvoiceCostDGVs");

            migrationBuilder.DropIndex(
                name: "IX_SupplierGroupSplits_UserID",
                table: "SupplierGroupSplits");

            migrationBuilder.DropIndex(
                name: "IX_SupplierDGVs_UserID",
                table: "SupplierDGVs");

            migrationBuilder.DropIndex(
                name: "IX_Sales_BoLNumber_BookingNumber",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_StatusID",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_SaleDGVs_UserID",
                table: "SaleDGVs");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CountryID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerName_CountryID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInvoices_StatusID",
                table: "CustomerInvoices");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInvoiceDGVs_UserID",
                table: "CustomerInvoiceDGVs");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInvoiceCosts_CostRegistryID",
                table: "CustomerInvoiceCosts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInvoiceCostDGVs_UserID",
                table: "CustomerInvoiceCostDGVs");

            migrationBuilder.DropIndex(
                name: "IX_CustomerGroupSplits_UserID",
                table: "CustomerGroupSplits");

            migrationBuilder.DropIndex(
                name: "IX_CustomerDGVs_UserID",
                table: "CustomerDGVs");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "SupplierInvoices");

            migrationBuilder.DropColumn(
                name: "CostRegistryID",
                table: "SupplierInvoiceCosts");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "CustomerInvoices");

            migrationBuilder.DropColumn(
                name: "CostRegistryID",
                table: "CustomerInvoiceCosts");

            migrationBuilder.RenameColumn(
                name: "SupplierInvoiceID",
                table: "SupplierInvoices",
                newName: "InvoiceID");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Suppliers",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SupplierInvoices",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Sales",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customers",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CustomerInvoices",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierName_Country",
                table: "Suppliers",
                columns: new[] { "SupplierName", "Country" },
                unique: true,
                filter: "[SupplierName] IS NOT NULL AND [Country] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerName_Country",
                table: "Customers",
                columns: new[] { "CustomerName", "Country" },
                unique: true,
                filter: "[CustomerName] IS NOT NULL AND [Country] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users",
                table: "RefreshTokens",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
