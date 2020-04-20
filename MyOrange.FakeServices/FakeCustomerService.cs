using Bogus;
using MyOrange.IServices;
using MyOrange.Models;
using System;
using System.Collections.Generic;

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
    }
}
