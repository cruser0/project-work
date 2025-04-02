using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class New_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostRegistries",
                columns: table => new
                {
                    CostRegistryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostRegistryUniqueCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CostRegistryName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
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
                    CountryName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ISOCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Region = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
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
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
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
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: true),
                    Deprecated = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    OriginalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "customer_country_fk",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Deprecated = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CountryID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    OriginalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                    table.ForeignKey(
                        name: "supplier_country_fk",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID");
                });

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
                    table.ForeignKey(
                        name: "FK_CustomerDGVs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    table.ForeignKey(
                        name: "FK_CustomerGroupSplits_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    table.ForeignKey(
                        name: "FK_CustomerInvoiceCostDGVs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    ShowStatus = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowInvoiceCode = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowSaleBookingNumber = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowSaleBoL = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoiceDGVs", x => x.CustomerInvoiceDGVID);
                    table.ForeignKey(
                        name: "FK_CustomerInvoiceDGVs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    TokenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "varchar(MAX)", unicode: false, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.TokenID);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    table.ForeignKey(
                        name: "FK_SaleDGVs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    table.ForeignKey(
                        name: "FK_SupplierDGVs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    table.ForeignKey(
                        name: "FK_SupplierGroupSplits_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    table.ForeignKey(
                        name: "FK_SupplierInvoiceCostDGVs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    ShowCountry = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowInvoiceCode = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowSaleBookingNumber = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ShowSaleBoL = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierInvoiceDGVs", x => x.SupplierInvoiceDGVID);
                    table.ForeignKey(
                        name: "FK_SupplierInvoiceDGVs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    table.ForeignKey(
                        name: "FK_UserDGVs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
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
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "customer_sales_fk",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "status_Sales_fk",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID");
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvoices",
                columns: table => new
                {
                    CustomerInvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerInvoiceCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SaleID = table.Column<int>(type: "int", nullable: true),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoices", x => x.CustomerInvoiceID);
                    table.ForeignKey(
                        name: "sale_CustomerInvoices_fk",
                        column: x => x.SaleID,
                        principalTable: "Sales",
                        principalColumn: "SaleID");
                    table.ForeignKey(
                        name: "status_CustomerInvoices_fk",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID");
                });

            migrationBuilder.CreateTable(
                name: "SupplierInvoices",
                columns: table => new
                {
                    SupplierInvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierInvoiceCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SaleID = table.Column<int>(type: "int", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierInvoices", x => x.SupplierInvoiceID);
                    table.ForeignKey(
                        name: "sale_supplierInvoices_fk",
                        column: x => x.SaleID,
                        principalTable: "Sales",
                        principalColumn: "SaleID");
                    table.ForeignKey(
                        name: "status_supplierInvoices_fk",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID");
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
                    CostRegistryID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoiceCosts", x => x.CustomerInvoiceCostsID);
                    table.ForeignKey(
                        name: "costRegistry_CustomerInvoiceCosts_fk",
                        column: x => x.CostRegistryID,
                        principalTable: "CostRegistries",
                        principalColumn: "CostRegistryID");
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
                    CostRegistryID = table.Column<int>(type: "int", nullable: true),
                    SupplierInvoiceID = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierInvoiceCosts", x => x.SupplierInvoiceCostsID);
                    table.ForeignKey(
                        name: "costRegistry_SupplierInvoiceCosts_fk",
                        column: x => x.CostRegistryID,
                        principalTable: "CostRegistries",
                        principalColumn: "CostRegistryID");
                    table.ForeignKey(
                        name: "SupplierInvoiceID_SupplierInvoiceCosts_fk",
                        column: x => x.SupplierInvoiceID,
                        principalTable: "SupplierInvoices",
                        principalColumn: "SupplierInvoiceID");
                });

            migrationBuilder.InsertData(
                table: "CostRegistries",
                columns: new[] { "CostRegistryID", "CostRegistryName", "CostRegistryPrice", "CostRegistryQuantity", "CostRegistryUniqueCode" },
                values: new object[] { 1, "Generic", 1m, 1, "GNC" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode", "Region" },
                values: new object[,]
                {
                    { 1, "Afghanistan", "AF", "SA" },
                    { 2, "Albania", "AL", "NON_EU" },
                    { 3, "Algeria", "DZ", "MEA" },
                    { 4, "Andorra", "AD", "NON_EU" },
                    { 5, "Angola", "AO", "MEA" },
                    { 6, "Antigua and Barbuda", "AG", "LATAM" },
                    { 7, "Argentina", "AR", "LATAM" },
                    { 8, "Armenia", "AM", "CIS" },
                    { 9, "Australia", "AU", "OCE" },
                    { 10, "Austria", "AT", "EU" },
                    { 11, "Azerbaijan", "AZ", "CIS" },
                    { 12, "Bahamas", "BS", "LATAM" },
                    { 13, "Bahrain", "BH", "MEA" },
                    { 14, "Bangladesh", "BD", "SA" },
                    { 15, "Barbados", "BB", "LATAM" },
                    { 16, "Belarus", "BY", "CIS" },
                    { 17, "Belgium", "BE", "EU" },
                    { 18, "Belize", "BZ", "LATAM" },
                    { 19, "Benin", "BJ", "MEA" },
                    { 20, "Bhutan", "BT", "SA" },
                    { 21, "Bolivia", "BO", "LATAM" },
                    { 22, "Bosnia and Herzegovina", "BA", "NON_EU" },
                    { 23, "Botswana", "BW", "MEA" },
                    { 24, "Brazil", "BR", "LATAM" },
                    { 25, "Brunei", "BN", "SEA" },
                    { 26, "Bulgaria", "BG", "EU" },
                    { 27, "Burkina Faso", "BF", "MEA" },
                    { 28, "Burundi", "BI", "MEA" },
                    { 29, "Cabo Verde", "CV", "MEA" },
                    { 30, "Cambodia", "KH", "SEA" },
                    { 31, "Cameroon", "CM", "MEA" },
                    { 32, "Canada", "CA", "NA" },
                    { 33, "Central African Republic", "CF", "MEA" },
                    { 34, "Chad", "TD", "MEA" },
                    { 35, "Chile", "CL", "LATAM" },
                    { 36, "China", "CN", "EAS" },
                    { 37, "Colombia", "CO", "LATAM" },
                    { 38, "Comoros", "KM", "MEA" },
                    { 39, "Congo Brazzaville", "CG", "MEA" },
                    { 40, "Congo Kinshasa", "CD", "MEA" },
                    { 41, "Costa Rica", "CR", "LATAM" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode", "Region" },
                values: new object[,]
                {
                    { 42, "Croatia", "HR", "EU" },
                    { 43, "Cuba", "CU", "LATAM" },
                    { 44, "Cyprus", "CY", "EU" },
                    { 45, "Czechia", "CZ", "EU" },
                    { 46, "Denmark", "DK", "EU" },
                    { 47, "Djibouti", "DJ", "MEA" },
                    { 48, "Dominica", "DM", "LATAM" },
                    { 49, "Dominican Republic", "DO", "LATAM" },
                    { 50, "Ecuador", "EC", "LATAM" },
                    { 51, "Egypt", "EG", "MEA" },
                    { 52, "El Salvador", "SV", "LATAM" },
                    { 53, "Equatorial Guinea", "GQ", "MEA" },
                    { 54, "Eritrea", "ER", "MEA" },
                    { 55, "Estonia", "EE", "EU" },
                    { 56, "Eswatini", "SZ", "MEA" },
                    { 57, "Ethiopia", "ET", "MEA" },
                    { 58, "Fiji", "FJ", "OCE" },
                    { 59, "Finland", "FI", "EU" },
                    { 60, "France", "FR", "EU" },
                    { 61, "Gabon", "GA", "MEA" },
                    { 62, "Gambia", "GM", "MEA" },
                    { 63, "Georgia", "GE", "CIS" },
                    { 64, "Germany", "DE", "EU" },
                    { 65, "Ghana", "GH", "MEA" },
                    { 66, "Greece", "GR", "EU" },
                    { 67, "Grenada", "GD", "LATAM" },
                    { 68, "Guatemala", "GT", "LATAM" },
                    { 69, "Guinea", "GN", "MEA" },
                    { 70, "Guinea Bissau", "GW", "MEA" },
                    { 71, "Guyana", "GY", "LATAM" },
                    { 72, "Haiti", "HT", "LATAM" },
                    { 73, "Honduras", "HN", "LATAM" },
                    { 74, "Hungary", "HU", "EU" },
                    { 75, "Iceland", "IS", "NON_EU" },
                    { 76, "India", "IN", "SA" },
                    { 77, "Indonesia", "ID", "SEA" },
                    { 78, "Iran", "IR", "MEA" },
                    { 79, "Iraq", "IQ", "MEA" },
                    { 80, "Ireland", "IE", "EU" },
                    { 81, "Israel", "IL", "MEA" },
                    { 82, "Italy", "IT", "EU" },
                    { 83, "Jamaica", "JM", "LATAM" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode", "Region" },
                values: new object[,]
                {
                    { 84, "Japan", "JP", "EAS" },
                    { 85, "Jordan", "JO", "MEA" },
                    { 86, "Kazakhstan", "KZ", "CIS" },
                    { 87, "Kenya", "KE", "MEA" },
                    { 88, "Kiribati", "KI", "OCE" },
                    { 89, "Korea North", "KP", "EAS" },
                    { 90, "Korea South", "KR", "EAS" },
                    { 91, "Kuwait", "KW", "MEA" },
                    { 92, "Kyrgyzstan", "KG", "CIS" },
                    { 93, "Laos", "LA", "SEA" },
                    { 94, "Latvia", "LV", "EU" },
                    { 95, "Lebanon", "LB", "MEA" },
                    { 96, "Lesotho", "LS", "MEA" },
                    { 97, "Liberia", "LR", "MEA" },
                    { 98, "Libya", "LY", "MEA" },
                    { 99, "Liechtenstein", "LI", "NON_EU" },
                    { 100, "Lithuania", "LT", "EU" },
                    { 101, "Luxembourg", "LU", "EU" },
                    { 102, "Madagascar", "MG", "MEA" },
                    { 103, "Malawi", "MW", "MEA" },
                    { 104, "Malaysia", "MY", "SEA" },
                    { 105, "Maldives", "MV", "SA" },
                    { 106, "Mali", "ML", "MEA" },
                    { 107, "Malta", "MT", "EU" },
                    { 108, "Marshall Islands", "MH", "OCE" },
                    { 109, "Mauritania", "MR", "MEA" },
                    { 110, "Mauritius", "MU", "MEA" },
                    { 111, "Mexico", "MX", "NA" },
                    { 112, "Micronesia", "FM", "OCE" },
                    { 113, "Moldova", "MD", "CIS" },
                    { 114, "Monaco", "MC", "NON_EU" },
                    { 115, "Mongolia", "MN", "EAS" },
                    { 116, "Montenegro", "ME", "NON_EU" },
                    { 117, "Morocco", "MA", "MEA" },
                    { 118, "Mozambique", "MZ", "MEA" },
                    { 119, "Myanmar", "MM", "SEA" },
                    { 120, "Namibia", "NA", "MEA" },
                    { 121, "Nauru", "NR", "OCE" },
                    { 122, "Nepal", "NP", "SA" },
                    { 123, "Netherlands", "NL", "EU" },
                    { 124, "New Zealand", "NZ", "OCE" },
                    { 125, "Nicaragua", "NI", "LATAM" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode", "Region" },
                values: new object[,]
                {
                    { 126, "Niger", "NE", "MEA" },
                    { 127, "Nigeria", "NG", "MEA" },
                    { 128, "North Macedonia", "MK", "NON_EU" },
                    { 129, "Norway", "NO", "NON_EU" },
                    { 130, "Oman", "OM", "MEA" },
                    { 131, "Pakistan", "PK", "SA" },
                    { 132, "Palau", "PW", "OCE" },
                    { 133, "Palestine", "PS", "MEA" },
                    { 134, "Panama", "PA", "LATAM" },
                    { 135, "Papua New Guinea", "PG", "OCE" },
                    { 136, "Paraguay", "PY", "LATAM" },
                    { 137, "Peru", "PE", "LATAM" },
                    { 138, "Philippines", "PH", "SEA" },
                    { 139, "Poland", "PL", "EU" },
                    { 140, "Portugal", "PT", "EU" },
                    { 141, "Qatar", "QA", "MEA" },
                    { 142, "Romania", "RO", "EU" },
                    { 143, "Russia", "RU", "CIS" },
                    { 144, "Rwanda", "RW", "MEA" },
                    { 145, "Saint Kitts and Nevis", "KN", "LATAM" },
                    { 146, "Saint Lucia", "LC", "LATAM" },
                    { 147, "Saint Vincent and the Grenadines", "VC", "LATAM" },
                    { 148, "Samoa", "WS", "OCE" },
                    { 149, "San Marino", "SM", "NON_EU" },
                    { 150, "Sao Tome and Principe", "ST", "MEA" },
                    { 151, "Saudi Arabia", "SA", "MEA" },
                    { 152, "Senegal", "SN", "MEA" },
                    { 153, "Serbia", "RS", "NON_EU" },
                    { 154, "Seychelles", "SC", "MEA" },
                    { 155, "Sierra Leone", "SL", "MEA" },
                    { 156, "Singapore", "SG", "SEA" },
                    { 157, "Slovakia", "SK", "EU" },
                    { 158, "Slovenia", "SI", "EU" },
                    { 159, "Solomon Islands", "SB", "OCE" },
                    { 160, "Somalia", "SO", "MEA" },
                    { 161, "South Africa", "ZA", "MEA" },
                    { 162, "South Sudan", "SS", "MEA" },
                    { 163, "Spain", "ES", "EU" },
                    { 164, "Sri Lanka", "LK", "SA" },
                    { 165, "Sudan", "SD", "MEA" },
                    { 166, "Suriname", "SR", "LATAM" },
                    { 167, "Sweden", "SE", "EU" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode", "Region" },
                values: new object[,]
                {
                    { 168, "Switzerland", "CH", "NON_EU" },
                    { 169, "Syria", "SY", "MEA" },
                    { 170, "Taiwan", "TW", "EAS" },
                    { 171, "Tajikistan", "TJ", "CIS" },
                    { 172, "Tanzania", "TZ", "MEA" },
                    { 173, "Thailand", "TH", "SEA" },
                    { 174, "Timor Leste", "TL", "SEA" },
                    { 175, "Togo", "TG", "MEA" },
                    { 176, "Tonga", "TO", "OCE" },
                    { 177, "Trinidad and Tobago", "TT", "LATAM" },
                    { 178, "Tunisia", "TN", "MEA" },
                    { 179, "Turkey", "TR", "MEA" },
                    { 180, "Turkmenistan", "TM", "CIS" },
                    { 181, "Tuvalu", "TV", "OCE" },
                    { 182, "Uganda", "UG", "MEA" },
                    { 183, "Ukraine", "UA", "CIS" },
                    { 184, "United Arab Emirates", "AE", "MEA" },
                    { 185, "United Kingdom", "GB", "NON_EU" },
                    { 186, "United States", "US", "NA" },
                    { 187, "Uruguay", "UY", "LATAM" },
                    { 188, "Uzbekistan", "UZ", "CIS" },
                    { 189, "Vanuatu", "VU", "OCE" },
                    { 190, "Vatican City", "VA", "NON_EU" },
                    { 191, "Venezuela", "VE", "LATAM" },
                    { 192, "Vietnam", "VN", "SEA" },
                    { 193, "Yemen", "YE", "MEA" },
                    { 194, "Zambia", "ZM", "MEA" },
                    { 195, "Zimbabwe", "ZW", "MEA" }
                });

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
                    { 14, "Create Supplier Invoice Cost" }
                });

            migrationBuilder.InsertData(
                table: "FavouritePages",
                columns: new[] { "FavouritePageID", "Name" },
                values: new object[,]
                {
                    { 15, "Create Sale" },
                    { 16, "Create User" },
                    { 17, "Group Supplier" },
                    { 18, "Report Customer Invoice" },
                    { 19, "User Area" },
                    { 20, "Report Sale" },
                    { 21, "Report Supplier Invoice" },
                    { 22, "Show User" },
                    { 23, "Show Registry Cost" }
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
                    { 20, "SaleRead" },
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
                table: "CostRegistryDGVs",
                columns: new[] { "CostRegistryDGVID", "UserID" },
                values: new object[] { 1, 1 });

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
                values: new object[] { 1, new DateTime(2025, 4, 2, 16, 13, 3, 31, DateTimeKind.Local).AddTicks(5169), new DateTime(2025, 4, 12, 16, 13, 3, 31, DateTimeKind.Local).AddTicks(5233), "BASEADMINTOKEN", 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_CostRegistryDGVs_UserID",
                table: "CostRegistryDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

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
                name: "IX_CustomerDGVs_UserID",
                table: "CustomerDGVs",
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
                name: "IX_CustomerInvoiceCostDGVs_UserID",
                table: "CustomerInvoiceCostDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceCosts_CostRegistryID",
                table: "CustomerInvoiceCosts",
                column: "CostRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceCosts_CustomerInvoiceID",
                table: "CustomerInvoiceCosts",
                column: "CustomerInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoiceDGVs_UserID",
                table: "CustomerInvoiceDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_CustomerInvoiceCode",
                table: "CustomerInvoices",
                column: "CustomerInvoiceCode",
                unique: true,
                filter: "[CustomerInvoiceCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_SaleID",
                table: "CustomerInvoices",
                column: "SaleID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_StatusID",
                table: "CustomerInvoices",
                column: "StatusID");

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
                unique: true,
                filter: "[RoleName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDGVs_UserID",
                table: "SaleDGVs",
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
                name: "IX_Sales_CustomerID",
                table: "Sales",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_StatusID",
                table: "Sales",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierDGVs_UserID",
                table: "SupplierDGVs",
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
                name: "IX_SupplierInvoiceCostDGVs_UserID",
                table: "SupplierInvoiceCostDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoiceCosts_CostRegistryID",
                table: "SupplierInvoiceCosts",
                column: "CostRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoiceCosts_SupplierInvoiceID",
                table: "SupplierInvoiceCosts",
                column: "SupplierInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoiceDGVs_UserID",
                table: "SupplierInvoiceDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoices_SaleID",
                table: "SupplierInvoices",
                column: "SaleID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoices_StatusID",
                table: "SupplierInvoices",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoices_SupplierID",
                table: "SupplierInvoices",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoices_SupplierInvoiceCode",
                table: "SupplierInvoices",
                column: "SupplierInvoiceCode",
                unique: true,
                filter: "[SupplierInvoiceCode] IS NOT NULL");

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
                name: "IX_UserDGVs_UserID",
                table: "UserDGVs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

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
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostRegistryDGVs");

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
                name: "CostRegistries");

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

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
