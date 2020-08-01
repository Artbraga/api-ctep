using Entities.Entities;
using Entities.Enums;
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

        public int BuscarCodigoDaTurma(string trechoCodigo)
        {
            var query = Query().Include(x => x.TurmasAluno).AsQueryable();
            query = query.Where(x => x.Codigo.StartsWith(trechoCodigo));

            return query.Count();
        }

        public IEnumerable<Turma> ListarTurmasAtivas()
        {
            var query = Query()
                .Include(x => x.Curso)
                .AsQueryable();
            query = query.Where(x => x.TipoStatusTurmaId == (int)TipoStatusTurmaEnum.EmAndamento);

            return query.ToList();
        }
    }
}
