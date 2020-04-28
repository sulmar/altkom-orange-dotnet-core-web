using Bogus;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOrange.Fakers
{
    public class CustomerFaker : Faker<Customer>
    {
        // snippet: ctor + 2 x tab
        public CustomerFaker()
        {
           // StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker + 1);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            
            // RuleFor(p => p.Email, f => f.Person.Email);
            
            // john.smith@orange.pl
            RuleFor(p => p.Email, (f, c) => $"{c.FirstName}.{c.LastName}@orange.pl");

            RuleFor(p => p.Country, f => f.Address.Country());
            RuleFor(p => p.Photo, f => f.Person.Avatar);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.3f));
            RuleFor(p => p.Birthday, f => f.Date.Past(-50));
            Ignore(p => p.RowVersion);
        }
    }
}
