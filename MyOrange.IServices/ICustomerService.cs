using MyOrange.Models;
using System;
using System.Collections.Generic;

namespace MyOrange.IServices
{
    public interface ICustomerService
    {
        IList<Customer> Get();
    }
}
