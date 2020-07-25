using Entities;
using System.Collections.Generic;

namespace Services.Base
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(int id);

        bool Delete(int id);

        bool Update(TEntity entity);

        bool Add(TEntity entity);

        IEnumerable<TEntity> All();
    }
}
