using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class CustomerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AlterColumn<int>(
                name: "CustomerInvoiceCostID",
                table: "SupplierInvoiceCosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "RefreshTokens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerUserID",
                table: "RefreshTokens",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerInvoiceID",
                table: "CustomerInvoiceAmoutPaids",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CustomerUsers",
                columns: table => new
                {
                    CustomerUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(MAX)", unicode: false, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(MAX)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerUsers", x => x.CustomerUserID);
                    table.ForeignKey(
                        name: "FK_CustomerUsers_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerUsers_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 4, 8, 17, 14, 24, 317, DateTimeKind.Local).AddTicks(95), new DateTime(2025, 4, 18, 17, 14, 24, 317, DateTimeKind.Local).AddTicks(153) });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_CustomerUserID",
                table: "RefreshTokens",
                column: "CustomerUserID");


            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_CustomerID",
                table: "CustomerUsers",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_Email",
                table: "CustomerUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_RoleID",
                table: "CustomerUsers",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_CustomerUsers",
                table: "RefreshTokens",
                column: "CustomerUserID",
                principalTable: "CustomerUsers",
                principalColumn: "CustomerUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_CustomerUsers",
                table: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "CustomerUsers");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_CustomerUserID",
                table: "RefreshTokens");


            migrationBuilder.DropColumn(
                name: "CustomerUserID",
                table: "RefreshTokens");


            migrationBuilder.AlterColumn<int>(
                name: "CustomerInvoiceCostID",
                table: "SupplierInvoiceCosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "RefreshTokens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "CustomerInvoiceAmoutPaids",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 4, 3, 17, 52, 12, 143, DateTimeKind.Local).AddTicks(2224), new DateTime(2025, 4, 13, 17, 52, 12, 143, DateTimeKind.Local).AddTicks(2282) });

        }
    }
}
