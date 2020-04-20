using Bogus;
using MyOrange.Models;

namespace MyOrange.FakeServices.Fakers
{
    public class DocumentFaker : Faker<Document>
    {
        public DocumentFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker + 1);
            RuleFor(p => p.Title, f => f.System.FileName());
            RuleFor(p => p.Description, f => f.Lorem.Sentence());
            RuleFor(p => p.Size, f => f.Random.Long(100, 10000));
            RuleFor(p => p.DocumentType, f => f.PickRandom<DocumentType>());
            RuleFor(p => p.CreatedOn, f => f.Date.Past());
            RuleFor(p => p.UpdatedOn, f => f.Date.Recent());
            RuleFor(p => p.Author, f => f.Name.FullName());
        }
    }
}
