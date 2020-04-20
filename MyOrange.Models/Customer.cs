using System;

namespace MyOrange.Models
{
    public abstract class Base
    {
        public int Id { get; set; }
    }

    public class Customer : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsRemoved { get; set; }
    }
}
