﻿using Microsoft.EntityFrameworkCore;
using MyOrange.IServices;
using MyOrange.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MyOrange.DbServices
{
    public class DbCustomerService : ICustomerService
    {
        private readonly MyOrangeContext context;

        private DbSet<Customer> customers => context.Customers;

        public DbCustomerService(MyOrangeContext context)
        {
            this.context = context;

        }

        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]

        // https://docs.microsoft.com/en-us/ef/core/modeling/sequences

        public void Add(Customer entity)
        {
            customers.Add(entity);

            var entities = context.ChangeTracker.Entries();

            context.SaveChanges();
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

            return query.AsNoTracking().ToList();
        }

        public IList<Customer> Get()
        {
            return context.Customers.AsNoTracking().ToList();
        }

        public Customer Get(int id)
        {
            return context.Customers.Find(id);
        }

        public void Remove(int id)
        {
            // Customer customer = Get(id);

            Customer customer = new Customer { Id = id };

            Trace.WriteLine(context.Entry(customer).State);

            context.Customers.Remove(customer);

            Trace.WriteLine(context.Entry(customer).State);

            context.SaveChanges();

            Trace.WriteLine(context.Entry(customer).State);
        }

        public void Update(Customer entity)
        {
            // context.Customers.Attach(entity);
            // context.Entry(entity).State = EntityState.Modified;

            // TransactionScope

            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Customers.Update(entity);
                        context.SaveChanges();

                        context.Customers.Update(entity);
                        context.SaveChanges();

                        transaction.Commit();

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }


                }

            }
            catch (DbUpdateConcurrencyException)
            {

                // TODO: obsluga
            }
        }

        public void UpdatePatch(Customer customer, string propertyName, string value)
        {
            customer[propertyName] = value;
            context.Entry(customer).Property(propertyName).IsModified = true;
            context.SaveChanges();
        }

        // string json = @"{'LastName': Novak, 'IsRemoved': true }

        public void UpdatePatch(int id, string json)
        {
            Customer customer = new Customer { Id = id };

            // dotnet add package Newtonsoft.Json
            JsonConvert.PopulateObject(json, customer);

            context.Customers.Update(customer);
            context.SaveChanges();
        }

        public int GetActive()
        {
            return customers.Count(c => !c.IsRemoved);
        }
    }
}
