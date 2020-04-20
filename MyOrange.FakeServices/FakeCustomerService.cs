using Bogus;
using MyOrange.IServices;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyOrange.FakeServices
{
    public class FakeCustomerService : ICustomerService
    {
        private readonly IList<Customer> customers;

        public FakeCustomerService(Faker<Customer> faker)
        {
            customers = faker.Generate(20);
        }

        public IList<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Customer entity)
        {
            var customer = Get(entity.Id);
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.Email = entity.Email;
            customer.IsRemoved = entity.IsRemoved;
        }
    }


}
