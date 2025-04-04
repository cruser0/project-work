using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddedRelationsWithCostsAndNewTableForCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerInvoiceCostID",
                table: "SupplierInvoiceCosts",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "SupplierInvoiceCosts",
                type: "decimal(18,2)",
                nullable: true,
                computedColumnSql: "[Cost] * [Quantity]");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "CustomerInvoiceCosts",
                type: "decimal(18,2)",
                nullable: true,
                computedColumnSql: "[Cost] * [Quantity]");

            migrationBuilder.CreateTable(
                name: "CustomerInvoiceAmoutPaids",
                columns: table => new
                {
                    CustomerInvoiceAmountPaidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerInvoiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoiceAmoutPaids", x => x.CustomerInvoiceAmountPaidID);
                    table.ForeignKey(
                        name: "FK_CustomerInvoice_CustomerInvoicePaidAmount",
                        column: x => x.CustomerInvoiceID,
                        principalTable: "CustomerInvoices",
                        principalColumn: "CustomerInvoiceID");
                });


            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoiceCosts_CustomerInvoiceCostID",
                table: "SupplierInvoiceCosts",
                column: "CustomerInvoiceCostID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceAmoutPaids_CustomerInvoiceID",
                table: "CustomerInvoiceAmoutPaids",
                column: "CustomerInvoiceID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceCosts_CustomerInvoiceCosts_CustomerInvoiceCostID",
                table: "SupplierInvoiceCosts",
                column: "CustomerInvoiceCostID",
                principalTable: "CustomerInvoiceCosts",
                principalColumn: "CustomerInvoiceCostsID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierInvoiceCosts_CustomerInvoiceCosts_CustomerInvoiceCostID",
                table: "SupplierInvoiceCosts");

            migrationBuilder.DropTable(
                name: "CustomerInvoiceAmoutPaids");

            migrationBuilder.DropIndex(
                name: "IX_SupplierInvoiceCosts_CustomerInvoiceCostID",
                table: "SupplierInvoiceCosts");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "SupplierInvoiceCosts");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "CustomerInvoiceCosts");

            migrationBuilder.DropColumn(
                name: "CustomerInvoiceCostID",
                table: "SupplierInvoiceCosts");

        }
    }
}
