using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SeederCountryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode" },
                values: new object[,]
                {
                    { 1, "Afghanistan", "AF" },
                    { 2, "Albania", "AL" },
                    { 3, "Algeria", "DZ" },
                    { 4, "Andorra", "AD" },
                    { 5, "Angola", "AO" },
                    { 6, "Antigua and Barbuda", "AG" },
                    { 7, "Argentina", "AR" },
                    { 8, "Armenia", "AM" },
                    { 9, "Australia", "AU" },
                    { 10, "Austria", "AT" },
                    { 11, "Azerbaijan", "AZ" },
                    { 12, "Bahamas", "BS" },
                    { 13, "Bahrain", "BH" },
                    { 14, "Bangladesh", "BD" },
                    { 15, "Barbados", "BB" },
                    { 16, "Belarus", "BY" },
                    { 17, "Belgium", "BE" },
                    { 18, "Belize", "BZ" },
                    { 19, "Benin", "BJ" },
                    { 20, "Bhutan", "BT" },
                    { 21, "Bolivia", "BO" },
                    { 22, "Bosnia and Herzegovina", "BA" },
                    { 23, "Botswana", "BW" },
                    { 24, "Brazil", "BR" },
                    { 25, "Brunei", "BN" },
                    { 26, "Bulgaria", "BG" },
                    { 27, "Burkina Faso", "BF" },
                    { 28, "Burundi", "BI" },
                    { 29, "Cabo Verde", "CV" },
                    { 30, "Cambodia", "KH" },
                    { 31, "Cameroon", "CM" },
                    { 32, "Canada", "CA" },
                    { 33, "Central African Republic", "CF" },
                    { 34, "Chad", "TD" },
                    { 35, "Chile", "CL" },
                    { 36, "China", "CN" },
                    { 37, "Colombia", "CO" },
                    { 38, "Comoros", "KM" },
                    { 39, "Congo Brazzaville", "CG" },
                    { 40, "Congo Kinshasa", "CD" },
                    { 41, "Costa Rica", "CR" },
                    { 42, "Croatia", "HR" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode" },
                values: new object[,]
                {
                    { 43, "Cuba", "CU" },
                    { 44, "Cyprus", "CY" },
                    { 45, "Czechia", "CZ" },
                    { 46, "Denmark", "DK" },
                    { 47, "Djibouti", "DJ" },
                    { 48, "Dominica", "DM" },
                    { 49, "Dominican Republic", "DO" },
                    { 50, "Ecuador", "EC" },
                    { 51, "Egypt", "EG" },
                    { 52, "El Salvador", "SV" },
                    { 53, "Equatorial Guinea", "GQ" },
                    { 54, "Eritrea", "ER" },
                    { 55, "Estonia", "EE" },
                    { 56, "Eswatini", "SZ" },
                    { 57, "Ethiopia", "ET" },
                    { 58, "Fiji", "FJ" },
                    { 59, "Finland", "FI" },
                    { 60, "France", "FR" },
                    { 61, "Gabon", "GA" },
                    { 62, "Gambia", "GM" },
                    { 63, "Georgia", "GE" },
                    { 64, "Germany", "DE" },
                    { 65, "Ghana", "GH" },
                    { 66, "Greece", "GR" },
                    { 67, "Grenada", "GD" },
                    { 68, "Guatemala", "GT" },
                    { 69, "Guinea", "GN" },
                    { 70, "Guinea-Bissau", "GW" },
                    { 71, "Guyana", "GY" },
                    { 72, "Haiti", "HT" },
                    { 73, "Honduras", "HN" },
                    { 74, "Hungary", "HU" },
                    { 75, "Iceland", "IS" },
                    { 76, "India", "IN" },
                    { 77, "Indonesia", "ID" },
                    { 78, "Iran", "IR" },
                    { 79, "Iraq", "IQ" },
                    { 80, "Ireland", "IE" },
                    { 81, "Israel", "IL" },
                    { 82, "Italy", "IT" },
                    { 83, "Jamaica", "JM" },
                    { 84, "Japan", "JP" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode" },
                values: new object[,]
                {
                    { 85, "Jordan", "JO" },
                    { 86, "Kazakhstan", "KZ" },
                    { 87, "Kenya", "KE" },
                    { 88, "Kiribati", "KI" },
                    { 89, "Korea North", "KP" },
                    { 90, "Korea South", "KR" },
                    { 91, "Kuwait", "KW" },
                    { 92, "Kyrgyzstan", "KG" },
                    { 93, "Laos", "LA" },
                    { 94, "Latvia", "LV" },
                    { 95, "Lebanon", "LB" },
                    { 96, "Lesotho", "LS" },
                    { 97, "Liberia", "LR" },
                    { 98, "Libya", "LY" },
                    { 99, "Liechtenstein", "LI" },
                    { 100, "Lithuania", "LT" },
                    { 101, "Luxembourg", "LU" },
                    { 102, "Madagascar", "MG" },
                    { 103, "Malawi", "MW" },
                    { 104, "Malaysia", "MY" },
                    { 105, "Maldives", "MV" },
                    { 106, "Mali", "ML" },
                    { 107, "Malta", "MT" },
                    { 108, "Marshall Islands", "MH" },
                    { 109, "Mauritania", "MR" },
                    { 110, "Mauritius", "MU" },
                    { 111, "Mexico", "MX" },
                    { 112, "Micronesia", "FM" },
                    { 113, "Moldova", "MD" },
                    { 114, "Monaco", "MC" },
                    { 115, "Mongolia", "MN" },
                    { 116, "Montenegro", "ME" },
                    { 117, "Morocco", "MA" },
                    { 118, "Mozambique", "MZ" },
                    { 119, "Myanmar", "MM" },
                    { 120, "Namibia", "NA" },
                    { 121, "Nauru", "NR" },
                    { 122, "Nepal", "NP" },
                    { 123, "Netherlands", "NL" },
                    { 124, "New Zealand", "NZ" },
                    { 125, "Nicaragua", "NI" },
                    { 126, "Niger", "NE" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode" },
                values: new object[,]
                {
                    { 127, "Nigeria", "NG" },
                    { 128, "North Macedonia", "MK" },
                    { 129, "Norway", "NO" },
                    { 130, "Oman", "OM" },
                    { 131, "Pakistan", "PK" },
                    { 132, "Palau", "PW" },
                    { 133, "Palestine", "PS" },
                    { 134, "Panama", "PA" },
                    { 135, "Papua New Guinea", "PG" },
                    { 136, "Paraguay", "PY" },
                    { 137, "Peru", "PE" },
                    { 138, "Philippines", "PH" },
                    { 139, "Poland", "PL" },
                    { 140, "Portugal", "PT" },
                    { 141, "Qatar", "QA" },
                    { 142, "Romania", "RO" },
                    { 143, "Russia", "RU" },
                    { 144, "Rwanda", "RW" },
                    { 145, "Saint Kitts and Nevis", "KN" },
                    { 146, "Saint Lucia", "LC" },
                    { 147, "Saint Vincent and the Grenadines", "VC" },
                    { 148, "Samoa", "WS" },
                    { 149, "San Marino", "SM" },
                    { 150, "Sao Tome and Principe", "ST" },
                    { 151, "Saudi Arabia", "SA" },
                    { 152, "Senegal", "SN" },
                    { 153, "Serbia", "RS" },
                    { 154, "Seychelles", "SC" },
                    { 155, "Sierra Leone", "SL" },
                    { 156, "Singapore", "SG" },
                    { 157, "Slovakia", "SK" },
                    { 158, "Slovenia", "SI" },
                    { 159, "Solomon Islands", "SB" },
                    { 160, "Somalia", "SO" },
                    { 161, "South Africa", "ZA" },
                    { 162, "South Sudan", "SS" },
                    { 163, "Spain", "ES" },
                    { 164, "Sri Lanka", "LK" },
                    { 165, "Sudan", "SD" },
                    { 166, "Suriname", "SR" },
                    { 167, "Sweden", "SE" },
                    { 168, "Switzerland", "CH" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "CountryName", "ISOCode" },
                values: new object[,]
                {
                    { 169, "Syria", "SY" },
                    { 170, "Taiwan", "TW" },
                    { 171, "Tajikistan", "TJ" },
                    { 172, "Tanzania", "TZ" },
                    { 173, "Thailand", "TH" },
                    { 174, "Timor Leste", "TL" },
                    { 175, "Togo", "TG" },
                    { 176, "Tonga", "TO" },
                    { 177, "Trinidad and Tobago", "TT" },
                    { 178, "Tunisia", "TN" },
                    { 179, "Turkey", "TR" },
                    { 180, "Turkmenistan", "TM" },
                    { 181, "Tuvalu", "TV" },
                    { 182, "Uganda", "UG" },
                    { 183, "Ukraine", "UA" },
                    { 184, "United Arab Emirates", "AE" },
                    { 185, "United Kingdom", "GB" },
                    { 186, "United States", "US" },
                    { 187, "Uruguay", "UY" },
                    { 188, "Uzbekistan", "UZ" },
                    { 189, "Vanuatu", "VU" },
                    { 190, "Vatican City", "VA" },
                    { 191, "Venezuela", "VE" },
                    { 192, "Vietnam", "VN" },
                    { 193, "Yemen", "YE" },
                    { 194, "Zambia", "ZM" },
                    { 195, "Zimbabwe", "ZW" }
                });

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 19, 16, 1, 57, 836, DateTimeKind.Local).AddTicks(8451), new DateTime(2025, 3, 29, 16, 1, 57, 836, DateTimeKind.Local).AddTicks(8511) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryID",
                keyValue: 195);

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "TokenID",
                keyValue: 1,
                columns: new[] { "Created", "Expires" },
                values: new object[] { new DateTime(2025, 3, 19, 16, 0, 20, 269, DateTimeKind.Local).AddTicks(9016), new DateTime(2025, 3, 29, 16, 0, 20, 269, DateTimeKind.Local).AddTicks(9096) });
        }
    }
}
