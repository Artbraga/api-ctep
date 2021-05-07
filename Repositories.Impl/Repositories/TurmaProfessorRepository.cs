using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impl.Repositories
{
    public class TurmaProfessorRepository : BaseRepository<TurmaProfessor>, ITurmaProfessorRepository
    {
        public TurmaProfessorRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TurmaProfessor> BuscarProfessoresDeUmaTurma(int turmaId)
        {
            var query = Query();
            query = query.Include(x => x.Professor);
            query = query.Where(x => x.TurmaId == turmaId);

            return query.ToList();
        }
    }
}
