﻿using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country() { CountryID = 1, CountryName = "Afghanistan", ISOCode = "AF", Region = "SA" },
                new Country() { CountryID = 2, CountryName = "Albania", ISOCode = "AL", Region = "NON_EU" },
                new Country() { CountryID = 3, CountryName = "Algeria", ISOCode = "DZ", Region = "MEA" },
                new Country() { CountryID = 4, CountryName = "Andorra", ISOCode = "AD", Region = "NON_EU" },
                new Country() { CountryID = 5, CountryName = "Angola", ISOCode = "AO", Region = "MEA" },
                new Country() { CountryID = 6, CountryName = "Antigua and Barbuda", ISOCode = "AG", Region = "LATAM" },
                new Country() { CountryID = 7, CountryName = "Argentina", ISOCode = "AR", Region = "LATAM" },
                new Country() { CountryID = 8, CountryName = "Armenia", ISOCode = "AM", Region = "CIS" },
                new Country() { CountryID = 9, CountryName = "Australia", ISOCode = "AU", Region = "OCE" },
                new Country() { CountryID = 10, CountryName = "Austria", ISOCode = "AT", Region = "EU" },
                new Country() { CountryID = 11, CountryName = "Azerbaijan", ISOCode = "AZ", Region = "CIS" },
                new Country() { CountryID = 12, CountryName = "Bahamas", ISOCode = "BS", Region = "LATAM" },
                new Country() { CountryID = 13, CountryName = "Bahrain", ISOCode = "BH", Region = "MEA" },
                new Country() { CountryID = 14, CountryName = "Bangladesh", ISOCode = "BD", Region = "SA" },
                new Country() { CountryID = 15, CountryName = "Barbados", ISOCode = "BB", Region = "LATAM" },
                new Country() { CountryID = 16, CountryName = "Belarus", ISOCode = "BY", Region = "CIS" },
                new Country() { CountryID = 17, CountryName = "Belgium", ISOCode = "BE", Region = "EU" },
                new Country() { CountryID = 18, CountryName = "Belize", ISOCode = "BZ", Region = "LATAM" },
                new Country() { CountryID = 19, CountryName = "Benin", ISOCode = "BJ", Region = "MEA" },
                new Country() { CountryID = 20, CountryName = "Bhutan", ISOCode = "BT", Region = "SA" },
                new Country() { CountryID = 21, CountryName = "Bolivia", ISOCode = "BO", Region = "LATAM" },
                new Country() { CountryID = 22, CountryName = "Bosnia and Herzegovina", ISOCode = "BA", Region = "NON_EU" },
                new Country() { CountryID = 23, CountryName = "Botswana", ISOCode = "BW", Region = "MEA" },
                new Country() { CountryID = 24, CountryName = "Brazil", ISOCode = "BR", Region = "LATAM" },
                new Country() { CountryID = 25, CountryName = "Brunei", ISOCode = "BN", Region = "SEA" },
                new Country() { CountryID = 26, CountryName = "Bulgaria", ISOCode = "BG", Region = "EU" },
                new Country() { CountryID = 27, CountryName = "Burkina Faso", ISOCode = "BF", Region = "MEA" },
                new Country() { CountryID = 28, CountryName = "Burundi", ISOCode = "BI", Region = "MEA" },
                new Country() { CountryID = 29, CountryName = "Cabo Verde", ISOCode = "CV", Region = "MEA" },
                new Country() { CountryID = 30, CountryName = "Cambodia", ISOCode = "KH", Region = "SEA" },
                new Country() { CountryID = 31, CountryName = "Cameroon", ISOCode = "CM", Region = "MEA" },
                new Country() { CountryID = 32, CountryName = "Canada", ISOCode = "CA", Region = "NA" },
                new Country() { CountryID = 33, CountryName = "Central African Republic", ISOCode = "CF", Region = "MEA" },
                new Country() { CountryID = 34, CountryName = "Chad", ISOCode = "TD", Region = "MEA" },
                new Country() { CountryID = 35, CountryName = "Chile", ISOCode = "CL", Region = "LATAM" },
                new Country() { CountryID = 36, CountryName = "China", ISOCode = "CN", Region = "EAS" },
                new Country() { CountryID = 37, CountryName = "Colombia", ISOCode = "CO", Region = "LATAM" },
                new Country() { CountryID = 38, CountryName = "Comoros", ISOCode = "KM", Region = "MEA" },
                new Country() { CountryID = 39, CountryName = "Congo (Congo-Brazzaville)", ISOCode = "CG", Region = "MEA" },
                new Country() { CountryID = 40, CountryName = "Congo (Congo-Kinshasa)", ISOCode = "CD", Region = "MEA" },
                new Country() { CountryID = 41, CountryName = "Costa Rica", ISOCode = "CR", Region = "LATAM" },
                new Country() { CountryID = 42, CountryName = "Croatia", ISOCode = "HR", Region = "EU" },
                new Country() { CountryID = 43, CountryName = "Cuba", ISOCode = "CU", Region = "LATAM" },
                new Country() { CountryID = 44, CountryName = "Cyprus", ISOCode = "CY", Region = "EU" },
                new Country() { CountryID = 45, CountryName = "Czechia", ISOCode = "CZ", Region = "EU" },
                new Country() { CountryID = 46, CountryName = "Denmark", ISOCode = "DK", Region = "EU" },
                new Country() { CountryID = 47, CountryName = "Djibouti", ISOCode = "DJ", Region = "MEA" },
                new Country() { CountryID = 48, CountryName = "Dominica", ISOCode = "DM", Region = "LATAM" },
                new Country() { CountryID = 49, CountryName = "Dominican Republic", ISOCode = "DO", Region = "LATAM" },
                new Country() { CountryID = 50, CountryName = "Ecuador", ISOCode = "EC", Region = "LATAM" },
                new Country() { CountryID = 51, CountryName = "Egypt", ISOCode = "EG", Region = "MEA" },
                new Country() { CountryID = 52, CountryName = "El Salvador", ISOCode = "SV", Region = "LATAM" },
                new Country() { CountryID = 53, CountryName = "Equatorial Guinea", ISOCode = "GQ", Region = "MEA" },
                new Country() { CountryID = 54, CountryName = "Eritrea", ISOCode = "ER", Region = "MEA" },
                new Country() { CountryID = 55, CountryName = "Estonia", ISOCode = "EE", Region = "EU" },
                new Country() { CountryID = 56, CountryName = "Eswatini", ISOCode = "SZ", Region = "MEA" },
                new Country() { CountryID = 57, CountryName = "Ethiopia", ISOCode = "ET", Region = "MEA" },
                new Country() { CountryID = 58, CountryName = "Fiji", ISOCode = "FJ", Region = "OCE" },
                new Country() { CountryID = 59, CountryName = "Finland", ISOCode = "FI", Region = "EU" },
                new Country() { CountryID = 60, CountryName = "France", ISOCode = "FR", Region = "EU" },
                new Country() { CountryID = 61, CountryName = "Gabon", ISOCode = "GA", Region = "MEA" },
                new Country() { CountryID = 62, CountryName = "Gambia", ISOCode = "GM", Region = "MEA" },
                new Country() { CountryID = 63, CountryName = "Georgia", ISOCode = "GE", Region = "CIS" },
                new Country() { CountryID = 64, CountryName = "Germany", ISOCode = "DE", Region = "EU" },
                new Country() { CountryID = 65, CountryName = "Ghana", ISOCode = "GH", Region = "MEA" },
                new Country() { CountryID = 66, CountryName = "Greece", ISOCode = "GR", Region = "EU" },
                new Country() { CountryID = 67, CountryName = "Grenada", ISOCode = "GD", Region = "LATAM" },
                new Country() { CountryID = 68, CountryName = "Guatemala", ISOCode = "GT", Region = "LATAM" },
                new Country() { CountryID = 69, CountryName = "Guinea", ISOCode = "GN", Region = "MEA" },
                new Country() { CountryID = 70, CountryName = "Guinea-Bissau", ISOCode = "GW", Region = "MEA" },
                new Country() { CountryID = 71, CountryName = "Guyana", ISOCode = "GY", Region = "LATAM" },
                new Country() { CountryID = 72, CountryName = "Haiti", ISOCode = "HT", Region = "LATAM" },
                new Country() { CountryID = 73, CountryName = "Honduras", ISOCode = "HN", Region = "LATAM" },
                new Country() { CountryID = 74, CountryName = "Hungary", ISOCode = "HU", Region = "EU" },
                new Country() { CountryID = 75, CountryName = "Iceland", ISOCode = "IS", Region = "NON_EU" },
                new Country() { CountryID = 76, CountryName = "India", ISOCode = "IN", Region = "SA" },
                new Country() { CountryID = 77, CountryName = "Indonesia", ISOCode = "ID", Region = "SEA" },
                new Country() { CountryID = 78, CountryName = "Iran", ISOCode = "IR", Region = "MEA" },
                new Country() { CountryID = 79, CountryName = "Iraq", ISOCode = "IQ", Region = "MEA" },
                new Country() { CountryID = 80, CountryName = "Ireland", ISOCode = "IE", Region = "EU" },
                new Country() { CountryID = 81, CountryName = "Israel", ISOCode = "IL", Region = "MEA" },
                new Country() { CountryID = 82, CountryName = "Italy", ISOCode = "IT", Region = "EU" },
                new Country() { CountryID = 83, CountryName = "Jamaica", ISOCode = "JM", Region = "LATAM" },
                new Country() { CountryID = 84, CountryName = "Japan", ISOCode = "JP", Region = "EAS" },
                new Country() { CountryID = 85, CountryName = "Jordan", ISOCode = "JO", Region = "MEA" },
                new Country() { CountryID = 86, CountryName = "Kazakhstan", ISOCode = "KZ", Region = "CIS" },
                new Country() { CountryID = 87, CountryName = "Kenya", ISOCode = "KE", Region = "MEA" },
                new Country() { CountryID = 88, CountryName = "Kiribati", ISOCode = "KI", Region = "OCE" },
                new Country() { CountryID = 89, CountryName = "Korea, North", ISOCode = "KP", Region = "EAS" },
                new Country() { CountryID = 90, CountryName = "Korea, South", ISOCode = "KR", Region = "EAS" },
                new Country() { CountryID = 91, CountryName = "Kuwait", ISOCode = "KW", Region = "MEA" },
                new Country() { CountryID = 92, CountryName = "Kyrgyzstan", ISOCode = "KG", Region = "CIS" },
                new Country() { CountryID = 93, CountryName = "Laos", ISOCode = "LA", Region = "SEA" },
                new Country() { CountryID = 94, CountryName = "Latvia", ISOCode = "LV", Region = "EU" },
                new Country() { CountryID = 95, CountryName = "Lebanon", ISOCode = "LB", Region = "MEA" },
                new Country() { CountryID = 96, CountryName = "Lesotho", ISOCode = "LS", Region = "MEA" },
                new Country() { CountryID = 97, CountryName = "Liberia", ISOCode = "LR", Region = "MEA" },
                new Country() { CountryID = 98, CountryName = "Libya", ISOCode = "LY", Region = "MEA" },
                new Country() { CountryID = 99, CountryName = "Liechtenstein", ISOCode = "LI", Region = "NON_EU" },
                new Country() { CountryID = 100, CountryName = "Lithuania", ISOCode = "LT", Region = "EU" },
                new Country() { CountryID = 101, CountryName = "Luxembourg", ISOCode = "LU", Region = "EU" },
                new Country() { CountryID = 102, CountryName = "Madagascar", ISOCode = "MG", Region = "MEA" },
                new Country() { CountryID = 103, CountryName = "Malawi", ISOCode = "MW", Region = "MEA" },
                new Country() { CountryID = 104, CountryName = "Malaysia", ISOCode = "MY", Region = "SEA" },
                new Country() { CountryID = 105, CountryName = "Maldives", ISOCode = "MV", Region = "SA" },
                new Country() { CountryID = 106, CountryName = "Mali", ISOCode = "ML", Region = "MEA" },
                new Country() { CountryID = 107, CountryName = "Malta", ISOCode = "MT", Region = "EU" },
                new Country() { CountryID = 108, CountryName = "Marshall Islands", ISOCode = "MH", Region = "OCE" },
                new Country() { CountryID = 109, CountryName = "Mauritania", ISOCode = "MR", Region = "MEA" },
                new Country() { CountryID = 110, CountryName = "Mauritius", ISOCode = "MU", Region = "MEA" },
                new Country() { CountryID = 111, CountryName = "Mexico", ISOCode = "MX", Region = "NA" },
                new Country() { CountryID = 112, CountryName = "Micronesia", ISOCode = "FM", Region = "OCE" },
                new Country() { CountryID = 113, CountryName = "Moldova", ISOCode = "MD", Region = "CIS" },
                new Country() { CountryID = 114, CountryName = "Monaco", ISOCode = "MC", Region = "NON_EU" },
                new Country() { CountryID = 115, CountryName = "Mongolia", ISOCode = "MN", Region = "EAS" },
                new Country() { CountryID = 116, CountryName = "Montenegro", ISOCode = "ME", Region = "NON_EU" },
                new Country() { CountryID = 117, CountryName = "Morocco", ISOCode = "MA", Region = "MEA" },
                new Country() { CountryID = 118, CountryName = "Mozambique", ISOCode = "MZ", Region = "MEA" },
                new Country() { CountryID = 119, CountryName = "Myanmar", ISOCode = "MM", Region = "SEA" },
                new Country() { CountryID = 120, CountryName = "Namibia", ISOCode = "NA", Region = "MEA" },
                new Country() { CountryID = 121, CountryName = "Nauru", ISOCode = "NR", Region = "OCE" },
                new Country() { CountryID = 122, CountryName = "Nepal", ISOCode = "NP", Region = "SA" },
                new Country() { CountryID = 123, CountryName = "Netherlands", ISOCode = "NL", Region = "EU" },
                new Country() { CountryID = 124, CountryName = "New Zealand", ISOCode = "NZ", Region = "OCE" },
                new Country() { CountryID = 125, CountryName = "Nicaragua", ISOCode = "NI", Region = "LATAM" },
                new Country() { CountryID = 126, CountryName = "Niger", ISOCode = "NE", Region = "MEA" },
                new Country() { CountryID = 127, CountryName = "Nigeria", ISOCode = "NG", Region = "MEA" },
                new Country() { CountryID = 128, CountryName = "North Macedonia", ISOCode = "MK", Region = "NON_EU" },
                new Country() { CountryID = 129, CountryName = "Norway", ISOCode = "NO", Region = "NON_EU" },
                new Country() { CountryID = 130, CountryName = "Oman", ISOCode = "OM", Region = "MEA" },
                new Country() { CountryID = 131, CountryName = "Pakistan", ISOCode = "PK", Region = "SA" },
                new Country() { CountryID = 132, CountryName = "Palau", ISOCode = "PW", Region = "OCE" },
                new Country() { CountryID = 133, CountryName = "Palestine", ISOCode = "PS", Region = "MEA" },
                new Country() { CountryID = 134, CountryName = "Panama", ISOCode = "PA", Region = "LATAM" },
                new Country() { CountryID = 135, CountryName = "Papua New Guinea", ISOCode = "PG", Region = "OCE" },
                new Country() { CountryID = 136, CountryName = "Paraguay", ISOCode = "PY", Region = "LATAM" },
                new Country() { CountryID = 137, CountryName = "Peru", ISOCode = "PE", Region = "LATAM" },
                new Country() { CountryID = 138, CountryName = "Philippines", ISOCode = "PH", Region = "SEA" },
                new Country() { CountryID = 139, CountryName = "Poland", ISOCode = "PL", Region = "EU" },
                new Country() { CountryID = 140, CountryName = "Portugal", ISOCode = "PT", Region = "EU" },
                new Country() { CountryID = 141, CountryName = "Qatar", ISOCode = "QA", Region = "MEA" },
                new Country() { CountryID = 142, CountryName = "Romania", ISOCode = "RO", Region = "EU" },
                new Country() { CountryID = 143, CountryName = "Russia", ISOCode = "RU", Region = "CIS" },
                new Country() { CountryID = 144, CountryName = "Rwanda", ISOCode = "RW", Region = "MEA" },
                new Country() { CountryID = 145, CountryName = "Saint Kitts and Nevis", ISOCode = "KN", Region = "LATAM" },
                new Country() { CountryID = 146, CountryName = "Saint Lucia", ISOCode = "LC", Region = "LATAM" },
                new Country() { CountryID = 147, CountryName = "Saint Vincent and the Grenadines", ISOCode = "VC", Region = "LATAM" },
                new Country() { CountryID = 148, CountryName = "Samoa", ISOCode = "WS", Region = "OCE" },
                new Country() { CountryID = 149, CountryName = "San Marino", ISOCode = "SM", Region = "NON_EU" },
                new Country() { CountryID = 150, CountryName = "Sao Tome and Principe", ISOCode = "ST", Region = "MEA" },
                new Country() { CountryID = 151, CountryName = "Saudi Arabia", ISOCode = "SA", Region = "MEA" },
                new Country() { CountryID = 152, CountryName = "Senegal", ISOCode = "SN", Region = "MEA" },
                new Country() { CountryID = 153, CountryName = "Serbia", ISOCode = "RS", Region = "NON_EU" },
                new Country() { CountryID = 154, CountryName = "Seychelles", ISOCode = "SC", Region = "MEA" },
                new Country() { CountryID = 155, CountryName = "Sierra Leone", ISOCode = "SL", Region = "MEA" },
                new Country() { CountryID = 156, CountryName = "Singapore", ISOCode = "SG", Region = "SEA" },
                new Country() { CountryID = 157, CountryName = "Slovakia", ISOCode = "SK", Region = "EU" },
                new Country() { CountryID = 158, CountryName = "Slovenia", ISOCode = "SI", Region = "EU" },
                new Country() { CountryID = 159, CountryName = "Solomon Islands", ISOCode = "SB", Region = "OCE" },
                new Country() { CountryID = 160, CountryName = "Somalia", ISOCode = "SO", Region = "MEA" },
                new Country() { CountryID = 161, CountryName = "South Africa", ISOCode = "ZA", Region = "MEA" },
                new Country() { CountryID = 162, CountryName = "South Sudan", ISOCode = "SS", Region = "MEA" },
                new Country() { CountryID = 163, CountryName = "Spain", ISOCode = "ES", Region = "EU" },
                new Country() { CountryID = 164, CountryName = "Sri Lanka", ISOCode = "LK", Region = "SA" },
                new Country() { CountryID = 165, CountryName = "Sudan", ISOCode = "SD", Region = "MEA" },
                new Country() { CountryID = 166, CountryName = "Suriname", ISOCode = "SR", Region = "LATAM" },
                new Country() { CountryID = 167, CountryName = "Sweden", ISOCode = "SE", Region = "EU" },
                new Country() { CountryID = 168, CountryName = "Switzerland", ISOCode = "CH", Region = "NON_EU" },
                new Country() { CountryID = 169, CountryName = "Syria", ISOCode = "SY", Region = "MEA" },
                new Country() { CountryID = 170, CountryName = "Taiwan", ISOCode = "TW", Region = "EAS" },
                new Country() { CountryID = 171, CountryName = "Tajikistan", ISOCode = "TJ", Region = "CIS" },
                new Country() { CountryID = 172, CountryName = "Tanzania", ISOCode = "TZ", Region = "MEA" },
                new Country() { CountryID = 173, CountryName = "Thailand", ISOCode = "TH", Region = "SEA" },
                new Country() { CountryID = 174, CountryName = "Timor-Leste", ISOCode = "TL", Region = "SEA" },
                new Country() { CountryID = 175, CountryName = "Togo", ISOCode = "TG", Region = "MEA" },
                new Country() { CountryID = 176, CountryName = "Tonga", ISOCode = "TO", Region = "OCE" },
                new Country() { CountryID = 177, CountryName = "Trinidad and Tobago", ISOCode = "TT", Region = "LATAM" },
                new Country() { CountryID = 178, CountryName = "Tunisia", ISOCode = "TN", Region = "MEA" },
                new Country() { CountryID = 179, CountryName = "Turkey", ISOCode = "TR", Region = "MEA" },
                new Country() { CountryID = 180, CountryName = "Turkmenistan", ISOCode = "TM", Region = "CIS" },
                new Country() { CountryID = 181, CountryName = "Tuvalu", ISOCode = "TV", Region = "OCE" },
                new Country() { CountryID = 182, CountryName = "Uganda", ISOCode = "UG", Region = "MEA" },
                new Country() { CountryID = 183, CountryName = "Ukraine", ISOCode = "UA", Region = "CIS" },
                new Country() { CountryID = 184, CountryName = "United Arab Emirates", ISOCode = "AE", Region = "MEA" },
                new Country() { CountryID = 185, CountryName = "United Kingdom", ISOCode = "GB", Region = "NON_EU" },
                new Country() { CountryID = 186, CountryName = "United States", ISOCode = "US", Region = "NA" },
                new Country() { CountryID = 187, CountryName = "Uruguay", ISOCode = "UY", Region = "LATAM" },
                new Country() { CountryID = 188, CountryName = "Uzbekistan", ISOCode = "UZ", Region = "CIS" },
                new Country() { CountryID = 189, CountryName = "Vanuatu", ISOCode = "VU", Region = "OCE" },
                new Country() { CountryID = 190, CountryName = "Vatican City", ISOCode = "VA", Region = "NON_EU" },
                new Country() { CountryID = 191, CountryName = "Venezuela", ISOCode = "VE", Region = "LATAM" },
                new Country() { CountryID = 192, CountryName = "Vietnam", ISOCode = "VN", Region = "SEA" },
                new Country() { CountryID = 193, CountryName = "Yemen", ISOCode = "YE", Region = "MEA" },
                new Country() { CountryID = 194, CountryName = "Zambia", ISOCode = "ZM", Region = "MEA" },
                new Country() { CountryID = 195, CountryName = "Zimbabwe", ISOCode = "ZW", Region = "MEA" }
            );
        }
    }

}
