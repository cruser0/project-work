using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerDGVs",
                columns: table => new
                {
                    CustomerDGVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ShowID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowName = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowCountry = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowDate = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowOriginalID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowStatus = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDGVs", x => x.CustomerDGVID);
                });


            migrationBuilder.CreateTable(
                name: "CustomerGroupSplits",
                columns: table => new
                {
                    CustomerGroupSplitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Split1 = table.Column<int>(type: "int", nullable: true),
                    Split2 = table.Column<int>(type: "int", nullable: true),
                    Split3 = table.Column<int>(type: "int", nullable: true),
                    Split4 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupSplits", x => x.CustomerGroupSplitID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvoiceCostDGVs",
                columns: table => new
                {
                    CustomerInvoiceCostDGVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ShowID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowInvoiceID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowCost = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowQuantity = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowName = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoiceCostDGVs", x => x.CustomerInvoiceCostDGVID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvoiceDGVs",
                columns: table => new
                {
                    CustomerInvoiceDGVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ShowID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowSaleID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowInvoiceAmount = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowDate = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowStatus = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoiceDGVs", x => x.CustomerInvoiceDGVID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Deprecated = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    OriginalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "FavouritePages",
                columns: table => new
                {
                    FavouritePageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritePages", x => x.FavouritePageID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "SaleDGVs",
                columns: table => new
                {
                    SaleDGVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ShowID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowBKNumber = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowBoL = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowDate = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowCustomerID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowStatus = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowCustomerName = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowCustomerCountry = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowTotalRevenue = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDGVs", x => x.SaleDGVID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierDGVs",
                columns: table => new
                {
                    SupplierDGVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ShowID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowName = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowCountry = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowDate = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowOriginalID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowStatus = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDGVs", x => x.SupplierDGVID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierGroupSplits",
                columns: table => new
                {
                    SupplierGroupSplitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Split1 = table.Column<int>(type: "int", nullable: true),
                    Split2 = table.Column<int>(type: "int", nullable: true),
                    Split3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierGroupSplits", x => x.SupplierGroupSplitID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierInvoiceCostDGVs",
                columns: table => new
                {
                    SupplierInvoiceCostDGVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ShowID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowSupplierInvoiceID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowCost = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowQuantity = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowName = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierInvoiceCostDGVs", x => x.SupplierInvoiceCostDGVID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierInvoiceDGVs",
                columns: table => new
                {
                    SupplierInvoiceDGVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ShowID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowSaleID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowInvoiceAmount = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowInvoiceDate = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowStatus = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowSupplierID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowSupplierName = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowCountry = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierInvoiceDGVs", x => x.SupplierInvoiceDGVID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Deprecated = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    OriginalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "UserDGVs",
                columns: table => new
                {
                    UserDGVID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ShowID = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ShowName = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowLastName = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowEmail = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowRoles = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDGVs", x => x.UserDGVID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(MAX)", unicode: false, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(MAX)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BoLNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SaleDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    TotalRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "customer_sales_fk",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    TokenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "varchar(MAX)", unicode: false, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.TokenID);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavouritePages",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FavouritePageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavouritePages", x => new { x.UserID, x.FavouritePageID });
                    table.ForeignKey(
                        name: "FK_UserFavouritePages_FavouritePages_FavouritePageID",
                        column: x => x.FavouritePageID,
                        principalTable: "FavouritePages",
                        principalColumn: "FavouritePageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavouritePages_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvoices",
                columns: table => new
                {
                    CustomerInvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleID = table.Column<int>(type: "int", nullable: true),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoices", x => x.CustomerInvoiceID);
                    table.ForeignKey(
                        name: "sale_CustomerInvoices_fk",
                        column: x => x.SaleID,
                        principalTable: "Sales",
                        principalColumn: "SaleID");
                });

            migrationBuilder.CreateTable(
                name: "SupplierInvoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleID = table.Column<int>(type: "int", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierInvoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "sale_supplierInvoices_fk",
                        column: x => x.SaleID,
                        principalTable: "Sales",
                        principalColumn: "SaleID");
                    table.ForeignKey(
                        name: "supplier_supplierInvoices_fk",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvoiceCosts",
                columns: table => new
                {
                    CustomerInvoiceCostsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerInvoiceID = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoiceCosts", x => x.CustomerInvoiceCostsID);
                    table.ForeignKey(
                        name: "FK_CustomerInvoiceCosts_CustomerInvoices",
                        column: x => x.CustomerInvoiceID,
                        principalTable: "CustomerInvoices",
                        principalColumn: "CustomerInvoiceID");
                });

            migrationBuilder.CreateTable(
                name: "SupplierInvoiceCosts",
                columns: table => new
                {
                    SupplierInvoiceCostsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierInvoiceID = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierInvoiceCosts", x => x.SupplierInvoiceCostsID);
                    table.ForeignKey(
                        name: "SupplierInvoiceID_SupplierInvoiceCosts_fk",
                        column: x => x.SupplierInvoiceID,
                        principalTable: "SupplierInvoices",
                        principalColumn: "InvoiceID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceCosts_CustomerInvoiceID",
                table: "CustomerInvoiceCosts",
                column: "CustomerInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_SaleID",
                table: "CustomerInvoices",
                column: "SaleID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerName_Country",
                table: "Customers",
                columns: new[] { "CustomerName", "Country" },
                unique: true,
                filter: "[CustomerName] IS NOT NULL AND [Country] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritePages_Name",
                table: "FavouritePages",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserID",
                table: "RefreshTokens",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerID",
                table: "Sales",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoiceCosts_SupplierInvoiceID",
                table: "SupplierInvoiceCosts",
                column: "SupplierInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoices_SaleID",
                table: "SupplierInvoices",
                column: "SaleID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoices_SupplierID",
                table: "SupplierInvoices",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierName_Country",
                table: "Suppliers",
                columns: new[] { "SupplierName", "Country" },
                unique: true,
                filter: "[SupplierName] IS NOT NULL AND [Country] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavouritePages_FavouritePageID",
                table: "UserFavouritePages",
                column: "FavouritePageID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDGVs");

            migrationBuilder.DropTable(
                name: "CustomerGroupSplits");

            migrationBuilder.DropTable(
                name: "CustomerInvoiceCostDGVs");

            migrationBuilder.DropTable(
                name: "CustomerInvoiceCosts");

            migrationBuilder.DropTable(
                name: "CustomerInvoiceDGVs");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SaleDGVs");

            migrationBuilder.DropTable(
                name: "SupplierDGVs");

            migrationBuilder.DropTable(
                name: "SupplierGroupSplits");

            migrationBuilder.DropTable(
                name: "SupplierInvoiceCostDGVs");

            migrationBuilder.DropTable(
                name: "SupplierInvoiceCosts");

            migrationBuilder.DropTable(
                name: "SupplierInvoiceDGVs");

            migrationBuilder.DropTable(
                name: "UserDGVs");

            migrationBuilder.DropTable(
                name: "UserFavouritePages");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "CustomerInvoices");

            migrationBuilder.DropTable(
                name: "SupplierInvoices");

            migrationBuilder.DropTable(
                name: "FavouritePages");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
