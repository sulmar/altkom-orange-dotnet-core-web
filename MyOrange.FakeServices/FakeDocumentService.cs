using Bogus;
using MyOrange.IServices;
using MyOrange.Models;

namespace MyOrange.FakeServices
{
    public class FakeDocumentService : FakeEntityService<Document>, IDocumentService
    {
        public FakeDocumentService(Faker<Document> faker) : base(faker)
        {
        }
    }


}
