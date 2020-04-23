using System;
using System.Collections.Generic;

namespace MyOrange.DbServices.DbModels
{
    public partial class DocumentDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public int? DocumentId { get; set; }

        public virtual Documents Document { get; set; }
    }
}
