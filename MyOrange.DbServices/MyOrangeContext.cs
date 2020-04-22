using Microsoft.EntityFrameworkCore;
using MyOrange.Models;
using System;

namespace MyOrange.DbServices
{

    // dotnet add package Microsoft.EntityFrameworkCore
    public class MyOrangeContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Document> Documents { get; set; }
      

    }
}
