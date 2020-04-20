using System.Collections.Generic;

namespace MyOrange.IServices
{
    public interface IEntityService<TEntity>

    {
        IList<TEntity> Get();
        TEntity Get(int id);
    }

}
