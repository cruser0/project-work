using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class fixFavPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FavouritePages",
                columns: new[] { "FavouritePageID", "Name" },
                values: new object[] { 22, "Show User" });

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 19, 17, 16, 33, 884, DateTimeKind.Local).AddTicks(7320), new DateTime(2025, 3, 29, 17, 16, 33, 884, DateTimeKind.Local).AddTicks(7375) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 19, 16, 12, 15, 689, DateTimeKind.Local).AddTicks(5157), new DateTime(2025, 3, 29, 16, 12, 15, 689, DateTimeKind.Local).AddTicks(5213) });
        }
    }
}
