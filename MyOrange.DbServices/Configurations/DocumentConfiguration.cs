using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyOrange.Fakers;
using MyOrange.Models;

namespace MyOrange.DbServices.Configurations
{
    // dotnet add package Microsoft.EntityFrameworkCore.Relational
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            var converter = new EnumToStringConverter<DocumentType>();
            builder.Property(p => p.DocumentType).HasConversion(converter);

            builder.Property(p => p.CreatedOn)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");

            
            builder.Property(p => p.CreatedOn)
                .ValueGeneratedOnAdd();
            // [DatabaseGenerator(DatabasseGenerationOptions.Identity)]

            builder.Property(p => p.UpdatedOn)
                .ValueGeneratedOnUpdate();
            // [DatabaseGenerator(DatabasseGenerationOptions.Computed)]

            DocumentFaker documentFaker = new DocumentFaker();
            var documents = documentFaker.Generate(20);
            builder.HasData(documents);

        }
    }
}
