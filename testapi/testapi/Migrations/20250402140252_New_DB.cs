using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class New_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CostRegistryDGVs",
                columns: new[] { "CostRegistryDGVID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 4, 2, 16, 2, 50, 959, DateTimeKind.Local).AddTicks(7973), new DateTime(2025, 4, 12, 16, 2, 50, 959, DateTimeKind.Local).AddTicks(8037) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CostRegistryDGVs",
                keyColumn: "CostRegistryDGVID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 4, 2, 15, 37, 25, 360, DateTimeKind.Local).AddTicks(8752), new DateTime(2025, 4, 12, 15, 37, 25, 360, DateTimeKind.Local).AddTicks(8807) });
        }
    }
}
