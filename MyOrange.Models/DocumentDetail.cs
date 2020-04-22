using System;
using System.Collections.Generic;
using System.Text;

namespace MyOrange.Models
{
    public class DocumentDetail : Base
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
