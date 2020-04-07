using Entities;
using Repositories.Base;
using Services.Base;
using System.Collections.Generic;

namespace Services.Impl.Base
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> repository;

        protected BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public bool Add(TEntity entity)
        {
            return repository.Add(entity);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool Update(TEntity entity)
        {
            return repository.Update(entity);
        }

        public IEnumerable<TEntity> All()
        {
            return repository.All();
        }
    }
}
