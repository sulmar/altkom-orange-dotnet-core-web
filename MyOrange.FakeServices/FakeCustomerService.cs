using Bogus;
using MyOrange.IServices;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyOrange.FakeServices
{
    public class FakeCustomerService : FakeEntityService<Customer>, ICustomerService
    {
        public FakeCustomerService(Faker<Customer> faker) : base(faker)
        {
        }

        private IEnumerable<Customer> customers => entities;

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

        public override void Update(Customer entity)
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

    /*
    public class FakeCustomerService : ICustomerService
    {
        private readonly IList<Customer> customers;

        public FakeCustomerService(Faker<Customer> faker)
        {
            customers = faker.Generate(100);
        }

        public void Add(Customer customer)
        {
            customer.Id = customers.Max(e => e.Id) + 1;
            customers.Add(customer);
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

        public void Remove(int id)
        {
            customers.Remove(Get(id));
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

    */

}
