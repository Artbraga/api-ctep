using Entities;
using Entities.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impl.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        protected virtual DbSet<TEntity> EntitySet { get; }

        public BaseRepository(DbContext context)
        {
            _context = context;
            EntitySet = _context.Set<TEntity>();
        }

        public bool Add(TEntity entity)
        {
            EntitySet.Add(entity);
            return true;
        }

        public bool BulkAdd(IEnumerable<TEntity> entities)
        {
            EntitySet.AddRange(entities);
            return true;
        }

        public bool Update(TEntity entity)
        {
            EntitySet.Update(entity);
            return true;
        }

        public bool Delete(int id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                EntitySet.Remove(obj);
                SaveChanges();
            }
            return true;
        }

        public bool BulkDelete(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                Delete(e.Id);
            }
           
            return true;
        }

        public virtual TEntity GetById(int id)
        {
            return EntitySet.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<TEntity> All()
        {
            return EntitySet.AsEnumerable();
        }

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        public IDbContextTransaction GetTransaction()
        {
            return this._context.Database.BeginTransaction();
        }

        protected IQueryable<TEntity> Query()
        {
            return EntitySet.AsQueryable();
        }

        protected IEnumerable<TEntity> PaginarResultado(IEnumerable<TEntity> entities, IPageFilter filter)
        {
            return entities.Skip(filter.Pagina * filter.TamanhoPagina).Take(filter.TamanhoPagina);
        }
    }
}
