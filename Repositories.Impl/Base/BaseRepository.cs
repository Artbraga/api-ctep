using CTEP.Repositories.Impl.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            try
            {
                EntitySet.Add(entity);
                //_log.LogDebug($"Objeto adicionado com sucesso! {JsonConvert.SerializeObject(entity)}");
                return true;
            }
            catch (Exception e)
            {
               // _log.LogError(e.StackTrace);
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                EntitySet.Update(entity);
                return true;
            }
            catch (Exception e)
            {
               // _log.LogError(e.StackTrace);
                return false;
            }
        }

        public bool Delete(int id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                try
                {
                    EntitySet.Remove(obj);
                    return true;
                }
                catch (Exception e)
                {
                    //_log.LogError(e.StackTrace);
                    return false;
                }
            }
            return true;
        }

        public TEntity GetById(int id)
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
    }
}
