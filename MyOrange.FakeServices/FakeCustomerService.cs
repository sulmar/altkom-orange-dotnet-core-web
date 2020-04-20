using MyOrange.IServices;
using MyOrange.Models;
using System;
using System.Collections.Generic;

namespace MyOrange.FakeServices
{
    public class FakeCustomerService : ICustomerService
    {
        private IList<Customer> customers;

        public FakeCustomerService()
        {
            
        }

        public IList<Customer> Get()
        {
            return customers;
        }
    }
}
