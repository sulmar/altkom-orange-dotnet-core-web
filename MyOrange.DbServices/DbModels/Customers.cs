using System;
using System.Collections.Generic;

namespace MyOrange.DbServices.DbModels
{
    public partial class Customers
    {
        public Customers()
        {
            Documents = new HashSet<Documents>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Photo { get; set; }
        public bool IsRemoved { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Documents> Documents { get; set; }
    }
}
