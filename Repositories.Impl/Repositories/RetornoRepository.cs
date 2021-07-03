using Entities.Entities;
using Entities.Filters;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Impl.Repositories
{
    public class RetornoRepository : BaseRepository<Retorno>, IRetornoRepository
    {
        public RetornoRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Retorno> FiltrarRetornos(IPageFilter filter, bool paginar = false)
        {
            var query = Query();
            query = query.Include(x => x.Registros);
            query = query.OrderBy(a => a.DataReferencia);

            if (paginar)
            {
                filter.Total = query.Count();
                return PaginarResultado(query, filter).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}
