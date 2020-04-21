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

        public void Add(TEntity entity)
        {
            entity.Id = entities.Max(e => e.Id) + 1;
            entities.Add(entity);
        }

        public IList<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            entities.Remove(Get(id));
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }


}
