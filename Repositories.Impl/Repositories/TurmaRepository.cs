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
            var query = Query().Where(x => x.CursoId == cursoId);

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

        public override Turma GetById(int id)
        {
            var query = Query()
                .Include(x => x.Curso)
                .Include(x => x.TipoStatusTurma)
                .Include(x => x.Registros);

            return query.Where(x => x.Id == id).Take(1).FirstOrDefault();
        }

        public IEnumerable<Turma> BuscarTurmasPorCodigoECurso(string codigo, int? cursoId)
        {
            var query = Query()
                .Include(x => x.Curso)
                .AsQueryable();
            query = query.Where(x => x.Codigo.Contains(codigo));
            if (cursoId.HasValue)
            {
                query = query.Where(x => x.CursoId == cursoId);
            }

            return query.ToList();
        }
    }
}
