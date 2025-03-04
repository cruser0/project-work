using API.Models.Entities;
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
        public virtual DbSet<SalesView> SalesViews { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierInvoice> SupplierInvoices { get; set; } = null!;
        public virtual DbSet<SupplierInvoiceCost> SupplierInvoiceCosts { get; set; } = null!;
        public virtual DbSet<CustomerInvoiceCost> CustomerInvoiceCosts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;




        public virtual DbSet<FavouritePages> FavouritePages { get; set; } = null!;
        public virtual DbSet<UserFavouritePage> UserFavouritePage { get; set; } = null!;
        public virtual DbSet<CustomerDGV> CustomerDGV { get; set; } = null!;
        public virtual DbSet<CustomerInvoiceDGV> CustomerInvoiceDGV{ get; set; } = null!;
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
        public virtual DbSet<ProfitClassification> ProfitClassifications { get; set; } = null!;
        public virtual DbSet<CustomerInvoiceStatus> CustomerInvoiceStatuses { get; set; } = null!;
        public virtual DbSet<ProfitSaleID> ProfitSaleIDs { get; set; } = null!;
        public virtual DbSet<SaleByBOL> SalesByBOLs { get; set; } = null!;
        public virtual DbSet<SaleByBooking> SalesBybookings { get; set; } = null!;
        public virtual DbSet<SaleByCustomerID> SalesByCustomerIDs { get; set; } = null!;
        public virtual DbSet<SaleByStatus> SalesByStatuses { get; set; } = null!;
        public virtual DbSet<SupplierInvoiceByStatus> SupplierInvoiceByStatuses { get; set; } = null!;
        public virtual DbSet<RevenuePerSaleID> RevenuePerSaleIDs { get; set; } = null!;
        public virtual DbSet<AmountSpentSaleID> AmountSpentSaleIDs { get; set; } = null!;
        public virtual DbSet<TotalSpentPerSupplier> TotalSpentPerSuppliers { get; set; } = null!;
        public virtual DbSet<TotalSpentPerCustomerInvoiceID> TotalSpentPerCustomerInvoiceIDs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\localhost;Database=Progetto_Formativo;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID");

                entity.HasIndex(c => new { c.CustomerName, c.Country })
                .IsUnique();

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Deprecated)
                    .HasColumnType("bit")
                    .HasDefaultValue(false);
                entity.Property(e => e.OriginalID).HasColumnType("int");
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
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
                entity.HasKey(e=>e.CustomerDGVID);
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

                //entity.HasOne(d => d.User)
                //    .WithOne(p => p.CustomerDGV)
                //    .HasForeignKey<CustomerDGV>(d => d.UserID);
            });
            modelBuilder.Entity<SaleDGV>(entity =>
            {
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
                entity.Property(e => e.ShowBoLNumber)
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

                //entity.HasOne(d => d.User)
                //    .WithOne(p => p.CustomerDGV)
                //    .HasForeignKey<CustomerDGV>(d=>d.UserID);
            });
            modelBuilder.Entity<SupplierDGV>(entity =>
            {
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

                //entity.HasOne(d => d.User)
                //    .WithOne(p => p.CustomerDGV)
                //    .HasForeignKey<CustomerDGV>(d=>d.UserID);
            });
            modelBuilder.Entity<CustomerGroupSplit>(entity =>
            {
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
            });

            modelBuilder.Entity<SupplierGroupSplit>(entity =>
            {
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
            });
            modelBuilder.Entity<CustomerInvoiceCostDGV>(entity =>
            {
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

                //entity.HasOne(d => d.User)
                //    .WithOne(p => p.CustomerDGV)
                //    .HasForeignKey<CustomerDGV>(d=>d.UserID);
            });
            modelBuilder.Entity<SupplierInvoiceCostDGV>(entity =>
            {
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

                //entity.HasOne(d => d.User)
                //    .WithOne(p => p.CustomerDGV)
                //    .HasForeignKey<CustomerDGV>(d=>d.UserID);
            });
            modelBuilder.Entity<CustomerInvoiceDGV>(entity =>
            {
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

                //entity.HasOne(d => d.User)
                //    .WithOne(p => p.CustomerDGV)
                //    .HasForeignKey<CustomerDGV>(d=>d.UserID);
            });
            modelBuilder.Entity<SupplierInvoiceDGV>(entity =>
            {
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
                entity.Property(e => e.ShowDate)
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
                entity.Property(e => e.ShowSupplierCountry)
                   .HasColumnType("bit")
                   .HasDefaultValue(true);

                //entity.HasOne(d => d.User)
                //    .WithOne(p => p.CustomerDGV)
                //    .HasForeignKey<CustomerDGV>(d=>d.UserID);
            });
            modelBuilder.Entity<UserDGV>(entity =>
            {
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
                //entity.HasOne(d => d.User)
                //    .WithOne(p => p.CustomerDGV)
                //    .HasForeignKey<CustomerDGV>(d=>d.UserID);
            });



            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenID);

                entity.Property(e => e.TokenID)
                    .HasColumnName("TokenID");

                entity.Property(e => e.UserID)
                    .HasColumnName("UserID");

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
                    .HasConstraintName("FK_RefreshTokens_Users");

            });

            modelBuilder.Entity<UserFavouritePage>()
          .HasKey(ur => new { ur.UserID, ur.FavouritePageID });

            modelBuilder.Entity<UserFavouritePage>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserFavouritePages)
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<UserFavouritePage>()
                .HasOne(ur => ur.FavouritePage)
                .WithMany(r => r.UserFavourtitePages)
                .HasForeignKey(ur => ur.FavouritePageID);

            modelBuilder.Entity<UserRole>()
           .HasKey(ur => new { ur.UserID, ur.RoleID });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleID);


            modelBuilder.Entity<CustomerInvoice>(entity =>
            {
                entity.Property(e => e.CustomerInvoiceId)

                    .HasColumnName("CustomerInvoiceID");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.CustomerInvoices)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("sale_CustomerInvoices_fk");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.SaleId)

                    .HasColumnName("SaleID");

                entity.Property(e => e.BoLnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BoLNumber");

                entity.Property(e => e.BookingNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalRevenue).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("customer_sales_fk");
            });

            modelBuilder.Entity<SalesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Sales_view");

                entity.Property(e => e.BoLnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BoLNumber");

                entity.Property(e => e.BookingNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Expr1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TotalRevenue).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.SupplierId)

                    .HasColumnName("SupplierID");

                entity.HasIndex(c => new { c.SupplierName, c.Country })
               .IsUnique();

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Deprecated)
                    .HasColumnType("bit")
                    .HasDefaultValue(false);
                entity.Property(e => e.OriginalID).HasColumnType("int");
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<SupplierInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK__Supplier__D796AAD52AAE58B4");

                entity.Property(e => e.InvoiceId)

                    .HasColumnName("InvoiceID");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SupplierInvoices)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("sale_supplierInvoices_fk");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierInvoices)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("supplier_supplierInvoices_fk");

            });

            modelBuilder.Entity<SupplierInvoiceCost>(entity =>
            {
                entity.HasKey(e => e.SupplierInvoiceCostsId)
                    .HasName("PK__Supplier__45346B41A6779A70");

                entity.Property(e => e.SupplierInvoiceCostsId)

                    .HasColumnName("SupplierInvoiceCostsID");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SupplierInvoiceId).HasColumnName("SupplierInvoiceID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.SupplierInvoice)
                    .WithMany(p => p.SupplierInvoiceCosts)
                    .HasForeignKey(d => d.SupplierInvoiceId)
                    .HasConstraintName("SupplierInvoiceID_SupplierInvoiceCosts_fk");
            });

            modelBuilder.Entity<CustomerInvoiceCost>(entity =>
            {
                entity.HasKey(e => e.CustomerInvoiceCostsId)
                    .HasName("PK__Customer__45346B41A6779A70");

                entity.Property(e => e.CustomerInvoiceCostsId)

                    .HasColumnName("CustomerInvoiceCostsID");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CustomerInvoiceId).HasColumnName("CustomerInvoiceID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerInvoice)
                    .WithMany(p => p.CustomerInvoiceCosts)
                    .HasForeignKey(d => d.CustomerInvoiceId)
                    .HasConstraintName("FK_CustomerInvoiceCosts_CustomerInvoices");
            });

            modelBuilder.Entity<ProfitClassification>().HasNoKey().ToView(null);
            modelBuilder.Entity<CustomerInvoiceStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ProfitSaleID>().HasNoKey().ToView(null);
            modelBuilder.Entity<SaleByBOL>().HasNoKey().ToView(null);
            modelBuilder.Entity<SaleByBooking>().HasNoKey().ToView(null);
            modelBuilder.Entity<SaleByCustomerID>().HasNoKey().ToView(null);
            modelBuilder.Entity<SaleByStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<SupplierInvoiceByStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<RevenuePerSaleID>().HasNoKey().ToView(null);
            modelBuilder.Entity<AmountSpentSaleID>().HasNoKey().ToView(null);
            modelBuilder.Entity<TotalSpentPerSupplier>().HasNoKey().ToView(null);
            modelBuilder.Entity<TotalSpentPerCustomerInvoiceID>().HasNoKey().ToView(null);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
