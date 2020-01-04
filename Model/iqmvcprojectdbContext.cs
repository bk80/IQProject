using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IQMVCProject.Model
{
    public partial class iqmvcprojectdbContext : DbContext
    {
        public iqmvcprojectdbContext()
        {
        }

        public iqmvcprojectdbContext(DbContextOptions<iqmvcprojectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inquiry> Inquiry { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=iqmvcprojectdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inquiry>(entity =>
            {
                entity.ToTable("inquiry", "iqmvcprojectdb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.AdditionalAttachment)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerNotes)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InterstedProduct)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NextFollowUp).HasColumnType("date");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login", "iqmvcprojectdb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "iqmvcprojectdb");

                entity.Property(e => e.Id)
                     .HasColumnName("id")
                     .HasColumnType("int(1000) unsigned")
                     .ValueGeneratedNever();

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerNotes)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
