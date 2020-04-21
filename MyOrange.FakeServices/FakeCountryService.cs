using Bogus;
using MyOrange.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyOrange.FakeServices
{
    public class FakeCountryService : ICountryService
    {
        private readonly Faker faker;

        public FakeCountryService()
        {
            faker = new Faker();
        }

        public IEnumerable<string> Get()
        {
            var countries = Enumerable.Range(1, 150)
                .Select(_ => faker.Address.Country())
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            return countries;
        }
    }
}
