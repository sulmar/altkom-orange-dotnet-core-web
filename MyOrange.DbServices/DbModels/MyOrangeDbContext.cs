using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyOrange.DbServices.DbModels
{
    public partial class MyOrangeDbContext : DbContext
    {
        public MyOrangeDbContext()
        {
        }

        public MyOrangeDbContext(DbContextOptions<MyOrangeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DocumentDetails> DocumentDetails { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyOrangeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Photo).HasMaxLength(250);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<DocumentDetails>(entity =>
            {
                entity.HasIndex(e => e.DocumentId);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentDetails)
                    .HasForeignKey(d => d.DocumentId);
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.DocumentType).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CustomerId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
