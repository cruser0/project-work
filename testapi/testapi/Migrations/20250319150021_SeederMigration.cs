using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SeederMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CostRegistries",
                columns: new[] { "CostRegistryID", "CostRegistryName", "CostRegistryPrice", "CostRegistryQuantity", "CostRegistryUniqueCode" },
                values: new object[] { 1, "Generic", 1m, 1, "GNC" });

            migrationBuilder.InsertData(
                table: "FavouritePages",
                columns: new[] { "FavouritePageID", "Name" },
                values: new object[,]
                {
                    { 1, "Show Customer" },
                    { 2, "Show Customer Invoice" },
                    { 3, "Show Sale" },
                    { 4, "Show Supplier" },
                    { 5, "Show Supplier Invoice" },
                    { 6, "Show Supplier Invoice Cost" },
                    { 7, "Show Customer Invoice Cost" },
                    { 8, "Group Customer" },
                    { 9, "Create Customer" },
                    { 10, "Create Customer Invoice" },
                    { 11, "Create Customer Invoice Cost" },
                    { 12, "Create Supplier" },
                    { 13, "Create Supplier Invoice" },
                    { 14, "Create Supplier Invoice Cost" },
                    { 15, "Create Sale" },
                    { 16, "Create User" },
                    { 17, "Group Supplier" },
                    { 18, "Report Customer Invoice" },
                    { 19, "User Area" },
                    { 20, "Report Sale" },
                    { 21, "Report Supplier Invoice" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "CustomerRead" },
                    { 3, "CustomerWrite" },
                    { 4, "CustomerAdmin" },
                    { 5, "CustomerInvoiceRead" },
                    { 6, "CustomerInvoiceWrite" },
                    { 7, "CustomerInvoiceAdmin" },
                    { 8, "CustomerInvoiceCostRead" },
                    { 9, "CustomerInvoiceCostWrite" },
                    { 10, "CustomerInvoiceCostAdmin" },
                    { 11, "SupplierRead" },
                    { 12, "SupplierWrite" },
                    { 13, "SupplierAdmin" },
                    { 14, "SupplierInvoiceRead" },
                    { 15, "SupplierInvoiceWrite" },
                    { 16, "SupplierInvoiceAdmin" },
                    { 17, "SupplierInvoiceCostRead" },
                    { 18, "SupplierInvoiceCostWrite" },
                    { 19, "SupplierInvoiceCostAdmin" },
                    { 20, "SaleRead" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 21, "SaleWrite" },
                    { 22, "SaleAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusID", "StatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Closed" },
                    { 3, "Approved" },
                    { 4, "Unapproved" },
                    { 5, "Paid" },
                    { 6, "Unpaid" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "LastName", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "Admin@admin.com", "Admin", "Admin", new byte[] { 115, 99, 121, 33, 251, 228, 182, 244, 226, 19, 236, 198, 68, 236, 133, 37, 79, 115, 185, 68, 146, 249, 57, 2, 155, 70, 91, 59, 192, 229, 221, 48, 39, 239, 222, 133, 50, 226, 8, 10, 90, 251, 143, 163, 176, 200, 142, 252, 45, 37, 117, 117, 164, 22, 75, 31, 80, 104, 233, 157, 177, 112, 239, 40 }, new byte[] { 168, 43, 60, 32, 88, 171, 47, 210, 179, 226, 6, 17, 15, 40, 203, 210, 236, 150, 51, 40, 39, 169, 190, 237, 6, 183, 229, 137, 127, 188, 132, 159, 254, 118, 120, 111, 9, 174, 130, 199, 185, 44, 87, 88, 106, 19, 186, 16, 181, 203, 169, 12, 77, 186, 5, 87, 9, 240, 72, 64, 22, 84, 220, 221, 118, 149, 55, 66, 8, 163, 1, 90, 96, 154, 244, 26, 7, 17, 171, 60, 155, 135, 162, 57, 112, 34, 60, 192, 78, 239, 234, 180, 146, 157, 71, 45, 17, 14, 16, 225, 107, 240, 166, 243, 74, 197, 201, 166, 62, 131, 59, 7, 23, 98, 49, 161, 122, 17, 40, 74, 3, 62, 132, 253, 237, 3, 136, 236 } });

            migrationBuilder.InsertData(
                table: "CustomerDGVs",
                columns: new[] { "CustomerDGVID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CustomerGroupSplits",
                columns: new[] { "CustomerGroupSplitID", "Split1", "Split2", "Split3", "Split4", "UserID" },
                values: new object[] { 1, null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "CustomerInvoiceCostDGVs",
                columns: new[] { "CustomerInvoiceCostDGVID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CustomerInvoiceDGVs",
                columns: new[] { "CustomerInvoiceDGVID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "RefreshTokens",
                columns: new[] { "TokenID", "Created", "Expires", "Token", "UserID" },
                values: new object[] { 1, new DateTime(2025, 3, 19, 16, 0, 20, 269, DateTimeKind.Local).AddTicks(9016), new DateTime(2025, 3, 29, 16, 0, 20, 269, DateTimeKind.Local).AddTicks(9096), "BASEADMINTOKEN", 1 });

            migrationBuilder.InsertData(
                table: "SaleDGVs",
                columns: new[] { "SaleDGVID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "SupplierDGVs",
                columns: new[] { "SupplierDGVID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "SupplierGroupSplits",
                columns: new[] { "SupplierGroupSplitID", "Split1", "Split2", "Split3", "UserID" },
                values: new object[] { 1, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "SupplierInvoiceCostDGVs",
                columns: new[] { "SupplierInvoiceCostDGVID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "SupplierInvoiceDGVs",
                columns: new[] { "SupplierInvoiceDGVID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserDGVs",
                columns: new[] { "UserDGVID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserFavouritePages",
                columns: new[] { "FavouritePageID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleID", "UserID" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CostRegistries",
                keyColumn: "CostRegistryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerDGVs",
                keyColumn: "CustomerDGVID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerGroupSplits",
                keyColumn: "CustomerGroupSplitID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerInvoiceCostDGVs",
                keyColumn: "CustomerInvoiceCostDGVID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerInvoiceDGVs",
                keyColumn: "CustomerInvoiceDGVID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SaleDGVs",
                keyColumn: "SaleDGVID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SupplierDGVs",
                keyColumn: "SupplierDGVID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SupplierGroupSplits",
                keyColumn: "SupplierGroupSplitID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SupplierInvoiceCostDGVs",
                keyColumn: "SupplierInvoiceCostDGVID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SupplierInvoiceDGVs",
                keyColumn: "SupplierInvoiceDGVID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserDGVs",
                keyColumn: "UserDGVID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserFavouritePages",
                keyColumns: new[] { "FavouritePageID", "UserID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleID", "UserID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "FavouritePages",
                keyColumn: "FavouritePageID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);
        }
    }
}
