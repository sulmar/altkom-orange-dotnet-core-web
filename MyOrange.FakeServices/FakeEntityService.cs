using Bogus;
using MyOrange.IServices;
using MyOrange.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyOrange.FakeServices
{
    public class FakeEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : Base
    {
        private readonly IList<TEntity> entities;

        public FakeEntityService(Faker<TEntity> faker)
        {
            entities = faker.Generate(20);
        }

        public IList<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }
    }


}
