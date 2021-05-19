using Entities.DTOs;
using Entities.Entities;
using Entities.Filters;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impl.Repositories
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Professor> FiltrarProfessores(ProfessorFilter filter)
        {
            var query = Query();
            query = query.OrderBy(a => a.Nome);

            if (!string.IsNullOrEmpty(filter.Nome))
            {
                query = query.Where(x => x.Nome.Contains(filter.Nome));
            }
            return query.ToList();
        }

        public IEnumerable<Professor> ListarProfessoresAtivos()
        {
            var query = Query();
            query = query.Where(x => !x.FlagExclusao);

            return query.ToList();
        }
    }
}
