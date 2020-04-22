using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyOrange.Models;

namespace MyOrange.DbServices.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            var converter = new EnumToStringConverter<DocumentType>();
            builder.Property(p => p.DocumentType).HasConversion(converter);

        }
    }
}
