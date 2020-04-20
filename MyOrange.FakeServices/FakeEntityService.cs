using Bogus;
using MyOrange.IServices;
using System.Collections.Generic;

namespace MyOrange.FakeServices
{
    public class FakeEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : class
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
    }


}
