using MyOrange.Models;
using System.Collections.Generic;

namespace MyOrange.IServices
{
    public interface IDocumentService : IEntityService<Document>
    {
        IList<Document> GetByCustomer(int customerId);

        int GetCount();

        IList<Document> GetByAuthor(string author);
    }

}
