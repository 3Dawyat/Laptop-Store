using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

#nullable disable

namespace Book.Models
{
    public partial class StoreWebSite2Context : IdentityDbContext<AplicationUser>
    {
        public StoreWebSite2Context()
        {
        }
        public StoreWebSite2Context(DbContextOptions<StoreWebSite2Context> options)
            : base(options)
        {
        }
        public virtual DbSet<FinalyInvoice> FinalyInvoices { get; set; }
        public virtual DbSet<TbBusniesInfu> TbBusniesInfus { get; set; }
        public virtual DbSet<TbCashTransaction> TbCashTransactions { get; set; }
        public virtual DbSet<TbCategory> TbCategories { get; set; }
        public virtual DbSet<TbCustomer> TbCustomers { get; set; }
        public virtual DbSet<TbCustomerItem> TbCustomerItems { get; set; }
        public virtual DbSet<TbItem> TbItems { get; set; }
        public virtual DbSet<TbItemImage> TbItemImages { get; set; }
        public virtual DbSet<TbPurchaseInvoice> TbPurchaseInvoices { get; set; }
        public virtual DbSet<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; }
        public virtual DbSet<TbSalesInvoice> TbSalesInvoices { get; set; }
        public virtual DbSet<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }
        public virtual DbSet<TbSupplier> TbSuppliers { get; set; }
        public virtual DbSet<TbSlider> TbSlider { get; set; }
        public virtual DbSet<TbDiscound> TbDiscound { get; set; }
        public virtual DbSet<VwItemCategories> VwItemCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<FinalyInvoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Finaly_Invoice");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoicePrice).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });
            modelBuilder.Entity<VwItemCategories>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwItemCategories");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<TbBusniesInfu>(entity =>
            {
                entity.HasKey(e => e.BusniesId);

                entity.ToTable("TbBusniesInfu");

                entity.HasIndex(e => e.CustomerId, "IX_TbBusniesInfu_CustomerId")
                    .IsUnique();

                entity.Property(e => e.Budget).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.BusniesCardNum).HasMaxLength(12);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.TbBusniesInfu)
                    .HasForeignKey<TbBusniesInfu>(d => d.CustomerId);
            });

            modelBuilder.Entity<TbCashTransaction>(entity =>
            {
                entity.HasKey(e => e.CashTransactionId);

                entity.ToTable("TbCashTransaction");

                entity.Property(e => e.CashDate).HasColumnType("date");

                entity.Property(e => e.CashValue).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TbCashTransactions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbCashTransaction_TbCustomers");
            });
            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<TbCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<TbCustomerItem>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ItemId });

                entity.HasIndex(e => e.ItemId, "IX_TbCustomerItems_ItemId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TbCustomerItems)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbCustomerItems)
                    .HasForeignKey(d => d.ItemId);
            });

            modelBuilder.Entity<TbItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItems_TbCategories");
            });

            modelBuilder.Entity<TbItemImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbItemImages)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItemImages_TbItems");
            });
            modelBuilder.Entity<TbDiscound>(entity =>
            {
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbDiscound)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbDiscound_TbItems");
            });

            modelBuilder.Entity<TbPurchaseInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TbPurchaseInvoices)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbPurchaseInvoices_TbSuppliers");
            });

            modelBuilder.Entity<TbPurchaseInvoiceItem>(entity =>
            {
                entity.HasKey(e => e.InvoiceItemId);

                entity.Property(e => e.InvoiceItemId).ValueGeneratedNever();

                entity.Property(e => e.InvoicePrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Notes).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Qty).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.TbPurchaseInvoiceItems)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbPurchaseInvoiceItems_TbPurchaseInvoices");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbPurchaseInvoiceItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbPurchaseInvoiceItems_TbItems");
            });
            modelBuilder.Entity<TbSalesInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.Property(e => e.DelivryDate).HasColumnType("date");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TbSalesInvoices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoices_TbCustomers");
            });

            modelBuilder.Entity<TbSalesInvoiceItem>(entity =>
            {
                entity.HasKey(e => e.InvoiceItemId);

                entity.Property(e => e.InvoicePrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Notes).UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Qty).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.TbSalesInvoiceItems)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoiceItems_TbSalesInvoices");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbSalesInvoiceItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoiceItems_TbItems");
            });
            modelBuilder.Entity<TbSupplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK_TbSupplier");
                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
