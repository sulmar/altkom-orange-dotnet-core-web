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
            customers = faker.Generate(100);
        }

        public IList<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public IList<Customer> Get(string country, string firstName)
        {
            IQueryable<Customer> query = customers.AsQueryable();

            if (!string.IsNullOrEmpty(country))
            {
                query = query.Where(c => c.Country == country);
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(c => c.FirstName == firstName);
            }

            return query.ToList();
        }

        public void Update(Customer entity)
        {
            var customer = Get(entity.Id);
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.Email = entity.Email;
            customer.Country = entity.Country;
            customer.Photo = entity.Photo;
            customer.IsRemoved = entity.IsRemoved;
        }
    }


}
