
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Entities.Preference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    UserID = 1,
                    Name = "Admin",
                    LastName = "Admin",
                    Email = "Admin@admin.com",
                    PasswordSalt = Convert.FromHexString("A82B3C2058AB2FD2B3E206110F28CBD2EC96332827A9BEED06B7E5897FBC849FFE76786F09AE82C7B92C57586A13BA10B5CBA90C4DBA055709F048401654DCDD7695374208A3015A609AF41A0711AB3C9B87A23970223CC04EEFEAB4929D472D110E10E16BF0A6F34AC5C9A63E833B07176231A17A11284A033E84FDED0388EC"),
                    PasswordHash = Convert.FromHexString("73637921FBE4B6F4E213ECC644EC85254F73B94492F939029B465B3BC0E5DD3027EFDE8532E2080A5AFB8FA3B0C88EFC2D257575A4164B1F5068E99DB170EF28"),
                }
            );
        }
    }
    public class CustomerDgvConfiguration : IEntityTypeConfiguration<CustomerDGV>
    {
        public void Configure(EntityTypeBuilder<CustomerDGV> builder)
        {
            builder.HasData(
                new CustomerDGV
                {
                    CustomerDGVID = 1,
                    UserID = 1,
                }
            );
        }
    }
    public class CustomerInvoiceDgvConfiguration : IEntityTypeConfiguration<CustomerInvoiceDGV>
    {
        public void Configure(EntityTypeBuilder<CustomerInvoiceDGV> builder)
        {
            builder.HasData(
                new CustomerInvoiceDGV
                {
                    CustomerInvoiceDGVID = 1,
                    UserID = 1,
                }
            );
        }
    }
    public class CustomerInvoiceCostDgvConfiguration : IEntityTypeConfiguration<CustomerInvoiceCostDGV>
    {
        public void Configure(EntityTypeBuilder<CustomerInvoiceCostDGV> builder)
        {
            builder.HasData(
                new CustomerInvoiceCostDGV
                {
                    CustomerInvoiceCostDGVID = 1,
                    UserID = 1,
                }
            );
        }
    }
    public class SupplierInvoiceCostDgvConfiguration : IEntityTypeConfiguration<SupplierInvoiceCostDGV>
    {
        public void Configure(EntityTypeBuilder<SupplierInvoiceCostDGV> builder)
        {
            builder.HasData(
                new SupplierInvoiceCostDGV
                {
                    SupplierInvoiceCostDGVID = 1,
                    UserID = 1,
                }
            );
        }
    }

    public class CostRegistryDgvConfiguration : IEntityTypeConfiguration<CostRegistryDGV>
    {
        public void Configure(EntityTypeBuilder<CostRegistryDGV> builder)
        {
            builder.HasData(
                new CostRegistryDGV
                {
                    CostRegistryDGVID = 1,
                    UserID = 1,
                }
            );
        }
    }

    public class SupplierInvoiceDgvConfiguration : IEntityTypeConfiguration<SupplierInvoiceDGV>
    {
        public void Configure(EntityTypeBuilder<SupplierInvoiceDGV> builder)
        {
            builder.HasData(
                new SupplierInvoiceDGV
                {
                    SupplierInvoiceDGVID = 1,
                    UserID = 1,
                }
            );
        }
    }
    public class SupplierDgvConfiguration : IEntityTypeConfiguration<SupplierDGV>
    {
        public void Configure(EntityTypeBuilder<SupplierDGV> builder)
        {
            builder.HasData(
                new SupplierDGV
                {
                    SupplierDGVID = 1,
                    UserID = 1,
                }
            );
        }
    }
    public class SaleDgvConfiguration : IEntityTypeConfiguration<SaleDGV>
    {
        public void Configure(EntityTypeBuilder<SaleDGV> builder)
        {
            builder.HasData(
                new SaleDGV
                {
                    SaleDGVID = 1,
                    UserID = 1,
                }
            );
        }
    }
    public class UserDgvConfiguration : IEntityTypeConfiguration<UserDGV>
    {
        public void Configure(EntityTypeBuilder<UserDGV> builder)
        {
            builder.HasData(
                new UserDGV
                {
                    UserDGVID = 1,
                    UserID = 1,
                }
            );
        }
    }
    public class CustomerGroupSplitConfiguration : IEntityTypeConfiguration<CustomerGroupSplit>
    {
        public void Configure(EntityTypeBuilder<CustomerGroupSplit> builder)
        {
            builder.HasData(
                new CustomerGroupSplit
                {
                    CustomerGroupSplitID = 1,
                    UserID = 1,
                }
            );
        }
    }

    public class SupplierGroupSplitConfiguration : IEntityTypeConfiguration<SupplierGroupSplit>
    {
        public void Configure(EntityTypeBuilder<SupplierGroupSplit> builder)
        {
            builder.HasData(
                new SupplierGroupSplit
                {
                    SupplierGroupSplitID = 1,
                    UserID = 1,
                }
            );
        }
    }
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasData(
                new RefreshToken
                {
                    UserID = 1,
                    TokenID = 1,
                    Created = DateTime.Now,
                    Expires = DateTime.Now.AddDays(10),
                    Token = "BASEADMINTOKEN"
                }
            );
        }
    }
    public class UserFavouritePageConfiguration : IEntityTypeConfiguration<UserFavouritePage>
    {
        public void Configure(EntityTypeBuilder<UserFavouritePage> builder)
        {
            builder.HasData(
                new UserFavouritePage
                {
                    UserID = 1,
                    FavouritePageID = 1
                }
            );
        }
    }
    public class FavouritePagesConfiguration : IEntityTypeConfiguration<FavouritePages>
    {
        public void Configure(EntityTypeBuilder<FavouritePages> builder)
        {
            builder.HasData(
                new FavouritePages() { FavouritePageID = 1, Name = "Show Customer" },
                new FavouritePages() { FavouritePageID = 2, Name = "Show Customer Invoice" },
                new FavouritePages() { FavouritePageID = 3, Name = "Show Sale" },
                new FavouritePages() { FavouritePageID = 4, Name = "Show Supplier" },
                new FavouritePages() { FavouritePageID = 5, Name = "Show Supplier Invoice" },
                new FavouritePages() { FavouritePageID = 6, Name = "Show Supplier Invoice Cost" },
                new FavouritePages() { FavouritePageID = 7, Name = "Show Customer Invoice Cost" },
                new FavouritePages() { FavouritePageID = 8, Name = "Group Customer" },
                new FavouritePages() { FavouritePageID = 9, Name = "Create Customer" },
                new FavouritePages() { FavouritePageID = 10, Name = "Create Customer Invoice" },
                new FavouritePages() { FavouritePageID = 11, Name = "Create Customer Invoice Cost" },
                new FavouritePages() { FavouritePageID = 12, Name = "Create Supplier" },
                new FavouritePages() { FavouritePageID = 13, Name = "Create Supplier Invoice" },
                new FavouritePages() { FavouritePageID = 14, Name = "Create Supplier Invoice Cost" },
                new FavouritePages() { FavouritePageID = 15, Name = "Create Sale" },
                new FavouritePages() { FavouritePageID = 16, Name = "Create User" },
                new FavouritePages() { FavouritePageID = 17, Name = "Group Supplier" },
                new FavouritePages() { FavouritePageID = 18, Name = "Report Customer Invoice" },
                new FavouritePages() { FavouritePageID = 19, Name = "User Area" },
                new FavouritePages() { FavouritePageID = 20, Name = "Report Sale" },
                new FavouritePages() { FavouritePageID = 21, Name = "Report Supplier Invoice" },
                new FavouritePages() { FavouritePageID = 22, Name = "Show User" },
                new FavouritePages() { FavouritePageID = 23, Name = "Show Registry Cost" }
            );
        }
    }
    public class RolesConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role() { RoleID = 1, RoleName = "Admin" },
                new Role() { RoleID = 2, RoleName = "CustomerRead" },
                new Role() { RoleID = 3, RoleName = "CustomerWrite" },
                new Role() { RoleID = 4, RoleName = "CustomerAdmin" },
                new Role() { RoleID = 5, RoleName = "CustomerInvoiceRead" },
                new Role() { RoleID = 6, RoleName = "CustomerInvoiceWrite" },
                new Role() { RoleID = 7, RoleName = "CustomerInvoiceAdmin" },
                new Role() { RoleID = 8, RoleName = "CustomerInvoiceCostRead" },
                new Role() { RoleID = 9, RoleName = "CustomerInvoiceCostWrite" },
                new Role() { RoleID = 10, RoleName = "CustomerInvoiceCostAdmin" },
                new Role() { RoleID = 11, RoleName = "SupplierRead" },
                new Role() { RoleID = 12, RoleName = "SupplierWrite" },
                new Role() { RoleID = 13, RoleName = "SupplierAdmin" },
                new Role() { RoleID = 14, RoleName = "SupplierInvoiceRead" },
                new Role() { RoleID = 15, RoleName = "SupplierInvoiceWrite" },
                new Role() { RoleID = 16, RoleName = "SupplierInvoiceAdmin" },
                new Role() { RoleID = 17, RoleName = "SupplierInvoiceCostRead" },
                new Role() { RoleID = 18, RoleName = "SupplierInvoiceCostWrite" },
                new Role() { RoleID = 19, RoleName = "SupplierInvoiceCostAdmin" },
                new Role() { RoleID = 20, RoleName = "SaleRead" },
                new Role() { RoleID = 21, RoleName = "SaleWrite" },
                new Role() { RoleID = 22, RoleName = "SaleAdmin" }
            );
        }
    }

    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole
                {
                    RoleID = 1,
                    UserID = 1,
                }
            );
        }
    }
}
