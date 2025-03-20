using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class fixstored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 20, 14, 35, 42, 248, DateTimeKind.Local).AddTicks(8944), new DateTime(2025, 3, 30, 14, 35, 42, 248, DateTimeKind.Local).AddTicks(8996) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 20, 11, 36, 13, 830, DateTimeKind.Local).AddTicks(2187), new DateTime(2025, 3, 30, 11, 36, 13, 830, DateTimeKind.Local).AddTicks(2245) });
        }
    }
}
