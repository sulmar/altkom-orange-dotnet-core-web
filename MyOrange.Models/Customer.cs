using System;
using System.ComponentModel.DataAnnotations;

namespace MyOrange.Models
{

    public class Customer : Base
    {
        //[Required]
        //[StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        //[Required]
        //[StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        //[Required]
        //[EmailAddress]
        public string Email { get; set; }
        public string Country { get; set; }
        public string Photo { get; set; }
        public bool IsRemoved { get; set; }
        public byte[] RowVersion { get; set; }

        public object this[string propertyName]
        {
            get => GetType().GetProperty(propertyName).GetValue(this);

            set => GetType().GetProperty(propertyName).SetValue(this, value, null);
        }

    }
}
