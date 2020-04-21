using MyOrange.Models;
using System;
using System.Collections.Generic;

namespace MyOrange.IServices
{
    public interface ICustomerService : IEntityService<Customer>
    {
        IList<Customer> Get(string country, string firstName);
    }

}
