using System;

namespace MyOrange.Models
{

    public class Customer : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Photo { get; set; }
        public bool IsRemoved { get; set; }

    }
}
