using API.Models.Entities;
using API.Models.Entities.Preference;
using API.Models.Procedures;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class Progetto_FormativoContext : DbContext
    {
        public Progetto_FormativoContext()
        {
        }

        public Progetto_FormativoContext(DbContextOptions<Progetto_FormativoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerInvoice> CustomerInvoices { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierInvoice> SupplierInvoices { get; set; } = null!;
        public virtual DbSet<SupplierInvoiceCost> SupplierInvoiceCosts { get; set; } = null!;
        public virtual DbSet<CustomerInvoiceCost> CustomerInvoiceCosts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<CostRegistry> CostRegistries { get; set; } = null!;




        public virtual DbSet<FavouritePages> FavouritePages { get; set; } = null!;
        public virtual DbSet<UserFavouritePage> UserFavouritePage { get; set; } = null!;
        public virtual DbSet<CustomerDGV> CustomerDGV { get; set; } = null!;
        public virtual DbSet<CustomerInvoiceDGV> CustomerInvoiceDGV { get; set; } = null!;
        public virtual DbSet<CustomerInvoiceCostDGV> CustomerInvoiceCostDGV { get; set; } = null!;
        public virtual DbSet<SupplierDGV> SupplierDGV { get; set; } = null!;
        public virtual DbSet<SupplierInvoiceDGV> SupplierInvoiceDGV { get; set; } = null!;
        public virtual DbSet<SupplierInvoiceCostDGV> SupplierInvoiceCostDGV { get; set; } = null!;
        public virtual DbSet<SaleDGV> SaleDGV { get; set; } = null!;
        public virtual DbSet<CustomerGroupSplit> CustomerGroupSplit { get; set; } = null!;
        public virtual DbSet<SupplierGroupSplit> SupplierGroupSplit { get; set; } = null!;
        public virtual DbSet<UserDGV> UserDGV { get; set; } = null!;



        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;


        public virtual DbSet<TotalAmountSpentPerSupplierInvoice> TotalAmountSpentPerSupplierInvoice { get; set; } = null!;
        public virtual DbSet<ClassifySalesByProfit> ClassifySalesByProfit { get; set; } = null!;
        public virtual DbSet<TotalAmountSpentPerSuppliers> TotalAmountSpentPerSuppliers { get; set; } = null!;
        public virtual DbSet<TotalAmountGainedPerCustomerInvoice> TotalAmountGainedPerCustomerInvoice { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(e => e.CustomerID);
                entity.HasIndex(c => new { c.CustomerName, c.CountryID })
                .IsUnique();
                entity.Property(e => e.CountryID);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Deprecated)
                    .HasColumnType("bit")
                    .HasDefaultValue(false);
                entity.Property(e => e.OriginalID).HasColumnType("int");
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountryID)
                    .HasConstraintName("customer_country_fk").OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");
                entity.HasKey(e => e.CountryID);
                entity.Property(entity => entity.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(entity => entity.ISOCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.HasIndex(x => x.CountryName).IsUnique();
                entity.HasIndex(x => x.ISOCode).IsUnique();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserID);

                entity.Property(e => e.UserID)
                    .HasColumnName("UserID");

                entity.HasIndex(c => c.Email)
                .IsUnique();

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasColumnType("varbinary(MAX)")
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("varbinary(MAX)")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.RoleID);

                entity.Property(e => e.RoleID)
                    .HasColumnName("RoleID");

                entity.HasIndex(c => c.RoleName)
                .IsUnique();

                entity.Property(e => e.RoleName)
                    .HasColumnName("RoleName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });
            modelBuilder.Entity<FavouritePages>(entity =>
            {
                entity.ToTable("FavouritePages");

                entity.HasKey(e => e.FavouritePageID);

                entity.Property(e => e.FavouritePageID)
                    .HasColumnName("FavouritePageID");

                entity.HasIndex(c => c.Name)
                .IsUnique();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<CustomerDGV>(entity =>
            {
                entity.ToTable("CustomerDGVs");

                entity.HasKey(e => e.CustomerDGVID);
                entity.Property(e => e.CustomerDGVID)
                    .HasColumnName("CustomerDGVID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.ShowName)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowCountry)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowDate)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowOriginalID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowStatus)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.CustomerDGV)
                    .HasForeignKey<CustomerDGV>(d => d.UserID).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<SaleDGV>(entity =>
            {
                entity.ToTable("SaleDGVs");
                entity.HasKey(e => e.SaleDGVID);
                entity.Property(e => e.SaleDGVID)
                    .HasColumnName("SaleDGVID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.ShowID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowBKNumber)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowBoL)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowDate)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowCustomerID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowStatus)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowCustomerName)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowCustomerCountry)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowTotalRevenue)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.SaleDGV)
                    .HasForeignKey<SaleDGV>(d => d.UserID).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<SupplierDGV>(entity =>
            {
                entity.ToTable("SupplierDGVs");
                entity.HasKey(e => e.SupplierDGVID);
                entity.Property(e => e.SupplierDGVID)
                    .HasColumnName("SupplierDGVID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.ShowID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowName)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowCountry)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowDate)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowOriginalID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowStatus)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.SupplierDGV)
                    .HasForeignKey<SupplierDGV>(d => d.UserID).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<CustomerGroupSplit>(entity =>
            {
                entity.ToTable("CustomerGroupSplits");

                entity.HasKey(e => e.CustomerGroupSplitID);
                entity.Property(e => e.CustomerGroupSplitID)
                    .HasColumnName("CustomerGroupSplitID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.Split1)
                   .HasColumnType("int");
                entity.Property(e => e.Split2)
                   .HasColumnType("int");
                entity.Property(e => e.Split3)
                   .HasColumnType("int");
                entity.Property(e => e.Split4)
                   .HasColumnType("int");
                entity.HasOne(d => d.User)
                    .WithOne(p => p.CustomerGroupSplit)
                    .HasForeignKey<CustomerGroupSplit>(d => d.UserID).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<SupplierGroupSplit>(entity =>
            {
                entity.ToTable("SupplierGroupSplits");

                entity.HasKey(e => e.SupplierGroupSplitID);
                entity.Property(e => e.SupplierGroupSplitID)
                    .HasColumnName("SupplierGroupSplitID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.Split1)
                   .HasColumnType("int");
                entity.Property(e => e.Split2)
                   .HasColumnType("int");
                entity.Property(e => e.Split3)
                   .HasColumnType("int");
                entity.HasOne(d => d.User)
                    .WithOne(p => p.SupplierGroupSplit)
                    .HasForeignKey<SupplierGroupSplit>(d => d.UserID).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<CustomerInvoiceCostDGV>(entity =>
            {
                entity.ToTable("CustomerInvoiceCostDGVs");

                entity.HasKey(e => e.CustomerInvoiceCostDGVID);
                entity.Property(e => e.CustomerInvoiceCostDGVID)
                    .HasColumnName("CustomerInvoiceCostDGVID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.ShowID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowInvoiceID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowCost)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowQuantity)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowName)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.CustomerInvoiceCostDGV)
                    .HasForeignKey<CustomerInvoiceCostDGV>(d => d.UserID);
            });
            modelBuilder.Entity<SupplierInvoiceCostDGV>(entity =>
            {
                entity.ToTable("SupplierInvoiceCostDGVs");

                entity.HasKey(e => e.SupplierInvoiceCostDGVID);
                entity.Property(e => e.SupplierInvoiceCostDGVID)
                    .HasColumnName("SupplierInvoiceCostDGVID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.ShowID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowSupplierInvoiceID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowCost)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowQuantity)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowName)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.SupplierInvoiceCostDGV)
                    .HasForeignKey<SupplierInvoiceCostDGV>(d => d.UserID);
            });
            modelBuilder.Entity<CustomerInvoiceDGV>(entity =>
            {
                entity.ToTable("CustomerInvoiceDGVs");

                entity.HasKey(e => e.CustomerInvoiceDGVID);
                entity.Property(e => e.CustomerInvoiceDGVID)
                    .HasColumnName("CustomerInvoiceDGVID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.ShowID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowSaleID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowInvoiceAmount)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowDate)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowStatus)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.CustomerInvoiceDGV)
                    .HasForeignKey<CustomerInvoiceDGV>(d => d.UserID);
            });
            modelBuilder.Entity<SupplierInvoiceDGV>(entity =>
            {
                entity.ToTable("SupplierInvoiceDGVs");

                entity.HasKey(e => e.SupplierInvoiceDGVID);
                entity.Property(e => e.SupplierInvoiceDGVID)
                    .HasColumnName("SupplierInvoiceDGVID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.ShowID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowSaleID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowInvoiceAmount)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowInvoiceDate)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowStatus)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowSupplierID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowSupplierName)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowCountry)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.SupplierInvoiceDGV)
                    .HasForeignKey<SupplierInvoiceDGV>(d => d.UserID);
            });
            modelBuilder.Entity<UserDGV>(entity =>
            {
                entity.ToTable("UserDGVs");
                entity.HasKey(e => e.UserDGVID);
                entity.Property(e => e.UserDGVID)
                    .HasColumnName("UserDGVID");
                entity.Property(e => e.UserID)
                   .HasColumnType("int");

                entity.Property(e => e.ShowID)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);
                entity.Property(e => e.ShowName)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowLastName)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowEmail)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.Property(e => e.ShowRoles)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);
                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserDGV)
                    .HasForeignKey<UserDGV>(d => d.UserID);
            });



            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshTokens");

                entity.HasKey(e => e.TokenID);

                entity.Property(e => e.TokenID)
                    .HasColumnName("TokenID")
                    .HasColumnType("int");

                entity.Property(e => e.UserID)
                    .HasColumnName("UserID")
                    .HasColumnType("int");

                entity.Property(e => e.Created)
                .HasColumnType("datetime");

                entity.Property(e => e.Expires)
                .HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .HasColumnType("varchar(MAX)")
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK_RefreshTokens_Users").OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<UserFavouritePage>(entity =>
            {
                entity.ToTable("UserFavouritePages");

                entity.HasKey(ur => new { ur.UserID, ur.FavouritePageID });

                entity.HasOne(ur => ur.User)
                      .WithMany(u => u.UserFavouritePages)
                      .HasForeignKey(ur => ur.UserID);

                entity.HasOne(ur => ur.FavouritePage)
                      .WithMany(r => r.UserFavourtitePages)
                      .HasForeignKey(ur => ur.FavouritePageID);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles");

                entity.HasKey(ur => new { ur.UserID, ur.RoleID });

                entity.HasOne(ur => ur.User)
                      .WithMany(u => u.UserRoles)
                      .HasForeignKey(ur => ur.UserID);

                entity.HasOne(ur => ur.Role)
                      .WithMany(r => r.UserRoles)
                      .HasForeignKey(ur => ur.RoleID);
            });



            modelBuilder.Entity<CustomerInvoice>(entity =>
            {
                entity.ToTable("CustomerInvoices");

                entity.Property(e => e.CustomerInvoiceID)
                    .HasColumnName("CustomerInvoiceID");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.SaleID).HasColumnName("SaleID");

                entity.Property(e => e.StatusID).HasColumnType("int");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CustomerInvoices)
                    .HasForeignKey(d => d.StatusID)
                    .HasConstraintName("status_CustomerInvoices_fk").OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.CustomerInvoices)
                    .HasForeignKey(d => d.SaleID)
                    .HasConstraintName("sale_CustomerInvoices_fk").OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sales");

                entity.Property(e => e.SaleID)

                    .HasColumnName("SaleID");

                entity.Property(e => e.BoLnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BoLNumber");

                entity.Property(e => e.BookingNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BookingNumber");

                entity.HasIndex(c => new { c.BoLnumber, c.BookingNumber })
               .IsUnique();

                entity.Property(e => e.CustomerID).HasColumnName("CustomerID");

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.Property(e => e.StatusID).HasColumnType("int");

                entity.Property(e => e.TotalRevenue).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StatusID)
                    .HasConstraintName("status_Sales_fk").OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerID)
                    .HasConstraintName("customer_sales_fk").OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Suppliers");

                entity.HasKey(e => e.SupplierID);

                entity.Property(e => e.SupplierID)

                    .HasColumnName("SupplierID");

                entity.HasIndex(c => new { c.SupplierName, c.CountryID })
               .IsUnique();

                entity.Property(e => e.CountryID)
                    .HasColumnType("int");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Deprecated)
                    .HasColumnType("bit")
                    .HasDefaultValue(false);
                entity.Property(e => e.OriginalID).HasColumnType("int");
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CountryID);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.CountryID)
                    .HasConstraintName("supplier_country_fk").OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<SupplierInvoice>(entity =>
            {
                entity.ToTable("SupplierInvoices");

                entity.HasKey(e => e.SupplierInvoiceID);

                entity.Property(e => e.SupplierInvoiceID)

                    .HasColumnName("SupplierInvoiceID");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.SaleID).HasColumnName("SaleID");

                entity.Property(e => e.StatusID).HasColumnType("int");

                entity.Property(e => e.SupplierID).HasColumnName("SupplierID");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SupplierInvoices)
                    .HasForeignKey(d => d.SaleID)
                    .HasConstraintName("sale_supplierInvoices_fk").OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierInvoices)
                    .HasForeignKey(d => d.SupplierID)
                    .HasConstraintName("supplier_supplierInvoices_fk").OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.SupplierInvoices)
                    .HasForeignKey(d => d.StatusID)
                    .HasConstraintName("status_supplierInvoices_fk").OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<SupplierInvoiceCost>(entity =>
            {
                entity.ToTable("SupplierInvoiceCosts");

                entity.HasKey(e => e.SupplierInvoiceCostsId);

                entity.Property(e => e.SupplierInvoiceCostsId)
                    .HasColumnName("SupplierInvoiceCostsID");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantity).HasColumnType("int");

                entity.Property(e => e.SupplierInvoiceId).HasColumnName("SupplierInvoiceID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostRegistryID)
                .HasColumnName("CostRegistryID");

                entity.HasOne(d => d.CostRegistry)
                    .WithMany(p => p.SupplierInvoiceCosts)
                    .HasForeignKey(d => d.CostRegistryID)
                    .HasConstraintName("costRegistry_SupplierInvoiceCosts_fk").OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.SupplierInvoice)
                    .WithMany(p => p.SupplierInvoiceCosts)
                    .HasForeignKey(d => d.SupplierInvoiceId)
                    .HasConstraintName("SupplierInvoiceID_SupplierInvoiceCosts_fk").OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<CustomerInvoiceCost>(entity =>
            {
                entity.ToTable("CustomerInvoiceCosts");

                entity.HasKey(e => e.CustomerInvoiceCostsID);

                entity.Property(e => e.CustomerInvoiceCostsID)

                    .HasColumnName("CustomerInvoiceCostsID");

                entity.Property(e => e.Quantity).HasColumnType("int");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CustomerInvoiceID).HasColumnName("CustomerInvoiceID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostRegistryID)
                .HasColumnName("CostRegistryID");

                entity.HasOne(d => d.CostRegistry)
                    .WithMany(p => p.CustomerInvoiceCosts)
                    .HasForeignKey(d => d.CostRegistryID)
                    .HasConstraintName("costRegistry_CustomerInvoiceCosts_fk").OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.CustomerInvoice)
                    .WithMany(p => p.CustomerInvoiceCosts)
                    .HasForeignKey(d => d.CustomerInvoiceID)
                    .HasConstraintName("FK_CustomerInvoiceCosts_CustomerInvoices").OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<CostRegistry>(entity =>
            {
                entity.ToTable("CostRegistries");

                entity.HasKey(e => e.CostRegistryID);

                entity.Property(e => e.CostRegistryID)
                    .HasColumnName("CostRegistryID");

                entity.Property(e => e.CostRegistryUniqueCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostRegistryUniqueCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostRegistryQuantity).HasColumnType("int");

                entity.Property(e => e.CostRegistryPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Statuses");

                entity.HasKey(e => e.StatusID);

                entity.Property(e => e.StatusID)
                    .HasColumnName("StatusID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClassifySalesByProfit>().HasNoKey().ToView(null);
            modelBuilder.Entity<TotalAmountSpentPerSupplierInvoice>().HasNoKey().ToView(null);
            modelBuilder.Entity<TotalAmountSpentPerSuppliers>().HasNoKey().ToView(null);
            modelBuilder.Entity<TotalAmountGainedPerCustomerInvoice>().HasNoKey().ToView(null);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
