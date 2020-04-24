using Bogus;
using MyOrange.IServices;
using MyOrange.Models;
using System.Collections.Generic;

namespace MyOrange.FakeServices
{
    public class FakeDocumentService : FakeEntityService<Document>, IDocumentService
    {
        public FakeDocumentService(Faker<Document> faker) : base(faker)
        {
        }

        public IList<Document> GetByCustomer(int customerId)
        {
            throw new System.NotImplementedException();
        }
    }

}
