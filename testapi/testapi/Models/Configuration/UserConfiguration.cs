using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
            {
                User user = new User() { Name="Admin",LastName="Admin",Email="Admin",PasswordSalt= 0xA82B3C2058AB2FD2B3E206110F28CBD2EC96332827A9BEED06B7E5897FBC849FFE76786F09AE82C7B92C57586A13BA10B5CBA90C4DBA055709F048401654DCDD7695374208A3015A609AF41A0711AB3C9B87A23970223CC04EEFEAB4929D472D110E10E16BF0A6F34AC5C9A63E833B07176231A17A11284A033E84FDED0388EC,PasswordHash=0x73637921FBE4B6F4E213ECC644EC85254F73B94492F939029B465B3BC0E5DD3027EFDE8532E2080A5AFB8FA3B0C88EFC2D257575A4164B1F5068E99DB170EF28 };
            });
        }
    }
}
