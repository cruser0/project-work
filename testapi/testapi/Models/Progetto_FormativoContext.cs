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
                entity.Property(e => e.CreatedAt).HasColumnType("date");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);

                entity.Property(e => e.UserID)
                    .HasColumnName("UserID");
                
                entity.HasIndex(c =>c.Email)
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

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasColumnType("varbinary(MAX)")
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("varbinary(MAX)")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerInvoice>(entity =>
            {
                entity.Property(e => e.CustomerInvoiceId)

                    .HasColumnName("CustomerInvoiceID");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

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

                entity.Property(e => e.SaleDate).HasColumnType("date");

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

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.SaleDate).HasColumnType("date");

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
                entity.Property(e => e.CreatedAt).HasColumnType("date");
            });

            modelBuilder.Entity<SupplierInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK__Supplier__D796AAD52AAE58B4");

                entity.Property(e => e.InvoiceId)

                    .HasColumnName("InvoiceID");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

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
