using System;
using System.Collections.Generic;
using System.Text;

namespace MyOrange.Models
{
    public class Document : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Author { get; set; }
        public DocumentType DocumentType { get; set; }
        public long Size { get; set; }
        public Customer Customer { get; set; }
        public ICollection<DocumentDetail> Details { get; set; }
    }
}
