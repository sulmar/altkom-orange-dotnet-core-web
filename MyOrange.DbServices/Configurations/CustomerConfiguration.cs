using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOrange.DbServices.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(250).IsUnicode(false);
            builder.Property(p => p.Country).HasMaxLength(50);
            builder.Property(p => p.Photo).HasMaxLength(250);
        }
    }
}
