using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ChangedEntitiesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupplierInvoiceCode",
                table: "SupplierInvoices",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerInvoiceCode",
                table: "CustomerInvoices",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 20, 11, 36, 13, 830, DateTimeKind.Local).AddTicks(2187), new DateTime(2025, 3, 30, 11, 36, 13, 830, DateTimeKind.Local).AddTicks(2245) });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoices_SupplierInvoiceCode",
                table: "SupplierInvoices",
                column: "SupplierInvoiceCode",
                unique: true,
                filter: "[SupplierInvoiceCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_CustomerInvoiceCode",
                table: "CustomerInvoices",
                column: "CustomerInvoiceCode",
                unique: true,
                filter: "[CustomerInvoiceCode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SupplierInvoices_SupplierInvoiceCode",
                table: "SupplierInvoices");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInvoices_CustomerInvoiceCode",
                table: "CustomerInvoices");

            migrationBuilder.DropColumn(
                name: "SupplierInvoiceCode",
                table: "SupplierInvoices");

            migrationBuilder.DropColumn(
                name: "CustomerInvoiceCode",
                table: "CustomerInvoices");

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 19, 17, 16, 33, 884, DateTimeKind.Local).AddTicks(7320), new DateTime(2025, 3, 29, 17, 16, 33, 884, DateTimeKind.Local).AddTicks(7375) });
        }
    }
}
