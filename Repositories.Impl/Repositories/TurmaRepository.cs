using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impl.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Turma> ListarTurmasDeUmCurso(int cursoId)
        {
            var query = EntitySet.Where(x => x.CursoId == cursoId);

            return query.ToList();
        }
    }
}
