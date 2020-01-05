using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IQMVCProject.Model
{
    public partial class InquiryDBContext : DbContext
    {
        public InquiryDBContext()
        {
        }

        public InquiryDBContext(DbContextOptions<InquiryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<Inquiries> Inquiries { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=InquiryDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("categories", "inquirydb");

                entity.HasIndex(e => e.FeatureId)
                    .HasName("fk_feature");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("categoryName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FeatureId)
                    .HasColumnName("featureId")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("fk_feature");
            });

            modelBuilder.Entity<Features>(entity =>
            {
                entity.HasKey(e => e.FeatureId);

                entity.ToTable("features", "inquirydb");

                entity.Property(e => e.FeatureId)
                    .HasColumnName("featureId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FeatureName)
                    .IsRequired()
                    .HasColumnName("featureName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inquiries>(entity =>
            {
                entity.HasKey(e => e.InquiryId);

                entity.ToTable("inquiries", "inquirydb");

                entity.HasIndex(e => e.ProductId)
                    .HasName("fk_product");

                entity.Property(e => e.InquiryId).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Attchments)
                    .HasColumnName("attchments")
                    .HasColumnType("blob");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customerName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerNotes)
                    .IsRequired()
                    .HasColumnName("customerNotes")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updatedDate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inquiries)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_product");
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("logins", "inquirydb");

                entity.Property(e => e.LoginId)
                    .HasColumnName("loginId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("products", "inquirydb");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("fk_category");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_category");
            });
        }
    }
}
