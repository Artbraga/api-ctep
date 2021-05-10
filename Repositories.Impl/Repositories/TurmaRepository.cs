using Entities.Entities;
using Entities.Enums;
using Entities.Filters;
using Microsoft.EntityFrameworkCore;
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
            var query = Query().Where(x => x.CursoId == cursoId && x.TipoStatusTurmaId == (int)TipoStatusTurmaEnum.EmAndamento);

            return query.OrderBy(x => x.Codigo).ToList();
        }

        public int BuscarCodigoDaTurma(string trechoCodigo)
        {
            var query = Query().Include(x => x.TurmasAluno).AsQueryable();
            query = query.Where(x => x.Codigo.StartsWith(trechoCodigo));

            return query.Count();
        }

        public bool ExisteCodigo(string codigo)
        {
            var query = Query();
            query = query.Where(x => x.Codigo == codigo);

            return query.Any();
        }


        public IEnumerable<Turma> ListarTurmasAtivas()
        {
            var query = Query()
                .Include(x => x.Curso)
                .Include(x => x.TipoStatusTurma)
                .AsQueryable();
            query = query.Where(x => x.TipoStatusTurmaId == (int)TipoStatusTurmaEnum.EmAndamento);

            return query.OrderBy(x => x.Codigo).ToList();
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

        public IEnumerable<Turma> FiltrarTurmas(TurmaFilter filter)
        {
            var query = Query()
                .Include(x => x.Curso)
                .Include(x => x.TipoStatusTurma)
               .AsQueryable();
            if (!string.IsNullOrEmpty(filter.Codigo))
            {
                query = query.Where(x => x.Codigo.Contains(filter.Codigo));
            }
            if (filter.CursoId.HasValue)
            {
                query = query.Where(x => x.CursoId == filter.CursoId);
            }
            if (filter.AnoInicio.HasValue)
            {
                query = query.Where(x => x.DataInicio.Year == filter.AnoInicio.Value.Year);
            }
            if (!filter.Concluidas)
            {
                query = query.Where(x => x.TipoStatusTurmaId == (int)TipoStatusTurmaEnum.EmAndamento);
            }

            return query.OrderBy(x => x.Codigo).ToList();
        }
    }
}
