using Bogus;
using MyOrange.IServices;
using MyOrange.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyOrange.FakeServices
{
    public class FakeDocumentService : FakeEntityService<Document>, IDocumentService
    {
        public FakeDocumentService(Faker<Document> faker) : base(faker)
        {
        }

        public IList<Document> GetByAuthor(string author)
        {
            return entities.Where(d => d.Author == author).ToList();
        }

        public IList<Document> GetByCustomer(int customerId)
        {
            return entities.Where(d => d.Customer.Id == customerId).ToList();
        }

        public int GetCount()
        {
            return entities.Count;
        }
    }

}
