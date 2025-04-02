using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class costreg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleName",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Country_CountryName",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_ISOCode",
                table: "Country");

            migrationBuilder.DeleteData(
                table: "CostRegistries",
                keyColumn: "CostRegistryID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);



            migrationBuilder.AddColumn<bool>(
                name: "ShowInvoiceCode",
                table: "SupplierInvoiceDGVs",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowSaleBoL",
                table: "SupplierInvoiceDGVs",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowSaleBookingNumber",
                table: "SupplierInvoiceDGVs",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "Statuses",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Roles",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshTokens",
                type: "varchar(MAX)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expires",
                table: "RefreshTokens",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "RefreshTokens",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");



            migrationBuilder.AddColumn<bool>(
                name: "ShowInvoiceCode",
                table: "CustomerInvoiceDGVs",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowSaleBoL",
                table: "CustomerInvoiceDGVs",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowSaleBookingNumber",
                table: "CustomerInvoiceDGVs",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Country",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ISOCode",
                table: "Country",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Country",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CostRegistryName",
                table: "CostRegistries",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CostRegistryDGVs",
                columns: table => new
                {
                    CostRegistryDGVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ShowRegistryID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowRegistryCode = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowRegistryName = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowRegistryPrice = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowRegistryQuantity = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostRegistryDGVs", x => x.CostRegistryDGVID);
                    table.ForeignKey(
                        name: "FK_CostRegistryDGVs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.InsertData(
                table: "CostRegistries",
                columns: new[] { "CostRegistryID", "CostRegistryName", "CostRegistryPrice", "CostRegistryQuantity", "CostRegistryUniqueCode" },
                values: new object[] { 1, "Generic", 1m, 1, "GNC" });

            migrationBuilder.InsertData(
                table: "FavouritePages",
                columns: new[] { "FavouritePageID", "Name" },
                values: new object[] { 23, "Show Registry Cost" });

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 4, 2, 14, 28, 31, 59, DateTimeKind.Local).AddTicks(7473), new DateTime(2025, 4, 12, 14, 28, 31, 59, DateTimeKind.Local).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Email",
                value: "Admin@admin.com");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true,
                filter: "[RoleName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CountryName",
                table: "Country",
                column: "CountryName",
                unique: true,
                filter: "[CountryName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ISOCode",
                table: "Country",
                column: "ISOCode",
                unique: true,
                filter: "[ISOCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CostRegistryDGVs_UserID",
                table: "CostRegistryDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.InsertData(
                table: "CostRegistryDGVs",
                columns: new[] { "CostRegistryDGVID", "UserID" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostRegistryDGVs");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleName",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Country_CountryName",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_ISOCode",
                table: "Country");

            migrationBuilder.DeleteData(
                table: "CostRegistries",
                keyColumn: "CostRegistryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 23);

            migrationBuilder.DropColumn(
                name: "ShowInvoiceCode",
                table: "SupplierInvoiceDGVs");

            migrationBuilder.DropColumn(
                name: "ShowSaleBoL",
                table: "SupplierInvoiceDGVs");

            migrationBuilder.DropColumn(
                name: "ShowSaleBookingNumber",
                table: "SupplierInvoiceDGVs");

            migrationBuilder.DropColumn(
                name: "ShowInvoiceCode",
                table: "CustomerInvoiceDGVs");

            migrationBuilder.DropColumn(
                name: "ShowSaleBoL",
                table: "CustomerInvoiceDGVs");

            migrationBuilder.DropColumn(
                name: "ShowSaleBookingNumber",
                table: "CustomerInvoiceDGVs");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);



            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "Statuses",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Roles",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshTokens",
                type: "varchar(MAX)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expires",
                table: "RefreshTokens",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "RefreshTokens",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);


            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Country",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISOCode",
                table: "Country",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Country",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CostRegistryName",
                table: "CostRegistries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "CostRegistries",
                columns: new[] { "CostRegistryID", "CostRegistryName", "CostRegistryPrice", "CostRegistryQuantity", "CostRegistryUniqueCode" },
                values: new object[] { 1, "Generic", 1m, 1, "GNC" });



            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 20, 15, 27, 7, 471, DateTimeKind.Local).AddTicks(7226), new DateTime(2025, 3, 30, 15, 27, 7, 471, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Email",
                value: "Admin");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);

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

            migrationBuilder.DeleteData(
                table: "CostRegistryDGVs",
                keyColumn: "CostRegistryDGVID",
                keyValue: 1);
        }
    }
}
