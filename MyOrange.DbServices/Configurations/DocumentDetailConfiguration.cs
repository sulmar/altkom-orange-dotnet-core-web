using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOrange.DbServices.Configurations
{
    // dotnet add package Microsoft.EntityFrameworkCore.Relational
    public class DocumentDetailConfiguration : IEntityTypeConfiguration<DocumentDetail>
    {
        public void Configure(EntityTypeBuilder<DocumentDetail> builder)
        {
            builder.ToTable("DocumentDetails");
        }
    }
}
