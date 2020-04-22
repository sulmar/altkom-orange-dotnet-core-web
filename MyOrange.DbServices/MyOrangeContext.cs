using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyOrange.DbServices.Configurations;
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
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }


    // ADO.NET ExecuteReader, 

    // Dapper

    // nHibernate
}
