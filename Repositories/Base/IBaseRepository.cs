using Entities;
using System.Collections.Generic;

namespace Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        // IQueryable<TEntity> Filter(BaseFilter filter);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        TEntity GetById(int id);
        bool Delete(int id);
        IEnumerable<TEntity> All();
    }
}
