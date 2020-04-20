using Bogus;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOrange.FakeServices.Fakers
{
    public class CustomerFaker : Faker<Customer>
    {
        // snippet: ctor + 2 x tab
        public CustomerFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker + 1);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Email, f => f.Person.Email);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.3f));

        }
    }
}
