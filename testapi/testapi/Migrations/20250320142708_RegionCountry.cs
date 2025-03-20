using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class RegionCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Country",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 1,
                column: "Region",
                value: "SA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 2,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 3,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 4,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 5,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 6,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 7,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 8,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 9,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 10,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 11,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 12,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 13,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 14,
                column: "Region",
                value: "SA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 15,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 16,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 17,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 18,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 19,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 20,
                column: "Region",
                value: "SA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 21,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 22,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 23,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 24,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 25,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 26,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 27,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 28,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 29,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 30,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 31,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 32,
                column: "Region",
                value: "NA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 33,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 34,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 35,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 36,
                column: "Region",
                value: "EAS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 37,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 38,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 39,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 40,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 41,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 42,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 43,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 44,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 45,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 46,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 47,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 48,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 49,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 50,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 51,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 52,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 53,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 54,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 55,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 56,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 57,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 58,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 59,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 60,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 61,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 62,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 63,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 64,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 65,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 66,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 67,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 68,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 69,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 70,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 71,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 72,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 73,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 74,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 75,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 76,
                column: "Region",
                value: "SA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 77,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 78,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 79,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 80,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 81,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 82,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 83,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 84,
                column: "Region",
                value: "EAS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 85,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 86,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 87,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 88,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 89,
                column: "Region",
                value: "EAS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 90,
                column: "Region",
                value: "EAS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 91,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 92,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 93,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 94,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 95,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 96,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 97,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 98,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 99,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 100,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 101,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 102,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 103,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 104,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 105,
                column: "Region",
                value: "SA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 106,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 107,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 108,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 109,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 110,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 111,
                column: "Region",
                value: "NA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 112,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 113,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 114,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 115,
                column: "Region",
                value: "EAS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 116,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 117,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 118,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 119,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 120,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 121,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 122,
                column: "Region",
                value: "SA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 123,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 124,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 125,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 126,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 127,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 128,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 129,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 130,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 131,
                column: "Region",
                value: "SA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 132,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 133,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 134,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 135,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 136,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 137,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 138,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 139,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 140,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 141,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 142,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 143,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 144,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 145,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 146,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 147,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 148,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 149,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 150,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 151,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 152,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 153,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 154,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 155,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 156,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 157,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 158,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 159,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 160,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 161,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 162,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 163,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 164,
                column: "Region",
                value: "SA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 165,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 166,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 167,
                column: "Region",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 168,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 169,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 170,
                column: "Region",
                value: "EAS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 171,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 172,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 173,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 174,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 175,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 176,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 177,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 178,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 179,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 180,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 181,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 182,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 183,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 184,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 185,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 186,
                column: "Region",
                value: "NA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 187,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 188,
                column: "Region",
                value: "CIS");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 189,
                column: "Region",
                value: "OCE");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 190,
                column: "Region",
                value: "NON_EU");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 191,
                column: "Region",
                value: "LATAM");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 192,
                column: "Region",
                value: "SEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 193,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 194,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 195,
                column: "Region",
                value: "MEA");

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 20, 15, 27, 7, 471, DateTimeKind.Local).AddTicks(7226), new DateTime(2025, 3, 30, 15, 27, 7, 471, DateTimeKind.Local).AddTicks(7280) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Country");

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 20, 14, 35, 42, 248, DateTimeKind.Local).AddTicks(8944), new DateTime(2025, 3, 30, 14, 35, 42, 248, DateTimeKind.Local).AddTicks(8996) });
        }
    }
}
