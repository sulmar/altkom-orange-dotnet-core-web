using System;
using System.Collections.Generic;

namespace MyOrange.DbServices.DbModels
{
    public partial class Documents
    {
        public Documents()
        {
            DocumentDetails = new HashSet<DocumentDetails>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Author { get; set; }
        public string DocumentType { get; set; }
        public long Size { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<DocumentDetails> DocumentDetails { get; set; }
    }
}
