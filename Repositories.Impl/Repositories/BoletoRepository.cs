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
    public class BoletoRepository : BaseRepository<Boleto>, IBoletoRepository
    {
        public BoletoRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Boleto> FiltrarBoletos(BoletoFilter filter, bool paginar = false)
        {
            var query = Query();

            if (!string.IsNullOrEmpty(filter.Nome))
            {
                query = query.Where(x => x.Aluno.Nome.Contains(filter.Nome));
            }
            if (!string.IsNullOrEmpty(filter.Numero))
            {
                query = query.Where(x => x.SeuNumero.Contains(filter.Numero));
            }
            if (filter.DataVencimentoDe.HasValue)
            {
                query = query.Where(x => x.DataVencimento >= filter.DataVencimentoDe);
            }
            if (filter.DataVencimentoAte.HasValue)
            {
                query = query.Where(x => x.DataVencimento <= filter.DataVencimentoAte);
            }
            if (filter.StatusId != null && filter.StatusId.Any())
            {
                query = query.Where(x => filter.StatusId == null || !filter.StatusId.Any() || filter.StatusId.Contains(x.TipoStatusBoletoId));
            }

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

        public Boleto BuscarBoletoPorNumero(string numero)
        {
            var query = Query();
            return query.FirstOrDefault(x => x.SeuNumero == numero);
        }

        protected override IQueryable<Boleto> Query()
        {
            var query = base.Query();
            query = query
                .Include(x => x.Aluno)
                .Include(x => x.TipoStatusBoleto)
                .AsQueryable();
            query = query.OrderBy(a => a.Aluno.Nome).ThenBy(x => x.SeuNumero);
            return query;
        }

    }
}
