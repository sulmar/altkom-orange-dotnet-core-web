using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyOrange.Models;
using System;

namespace MyOrange.DbServices
{

    // dotnet add package Microsoft.EntityFrameworkCore
    public class MyOrangeContext : DbContext
    {
        public MyOrangeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Customer>().HasKey(p => p.Id);

            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Customer>().Property(p => p.Email).HasMaxLength(250).IsUnicode(false);
            modelBuilder.Entity<Customer>().Property(p => p.Country).HasMaxLength(50);

            var converter = new EnumToStringConverter<DocumentType>();
            modelBuilder.Entity<Document>().Property(p => p.DocumentType).HasConversion(converter);

            base.OnModelCreating(modelBuilder);
        }


    }


    // ADO.NET ExecuteReader, 

    // Dapper

    // nHibernate
}
