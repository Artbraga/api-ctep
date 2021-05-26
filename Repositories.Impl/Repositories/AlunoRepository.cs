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
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(DbContext context) : base(context)
        {
        }

        public int BuscarNumeroDeMatriculasPorTrecho(string trechoMatricula)
        {
            var query = Query().Include(x => x.TurmasAluno).AsQueryable();
            query = query.Where(x => x.TurmasAluno.Any(y => y.Matricula.StartsWith(trechoMatricula)));
            return query.Count();
        }

        public bool ExisteMatricula(string matricula)
        {
            var query = Query().Include(x => x.TurmasAluno).AsQueryable();
            query = query.Where(x => x.TurmasAluno.Any(t => t.Matricula == matricula));

            return query.Any();
        }

        public IEnumerable<Aluno> FiltrarAlunos(AlunoFilter filter, bool paginar = false)
        {
            var query = IncludeTabela();
            query = query.OrderBy(a => a.Nome);

            if (!string.IsNullOrEmpty(filter.Nome)) {
                query = query.Where(x => x.Nome.Contains(filter.Nome));
            }
            if (!string.IsNullOrEmpty(filter.CPF))
            {
                query = query.Where(x => x.CPF.Equals(filter.CPF));
            }
            query = query.Where(x => x.TurmasAluno.Any(y =>
                (string.IsNullOrEmpty(filter.CodigoTurma) || y.Turma.Codigo.Contains(filter.CodigoTurma)) &&
                (!filter.CursoId.HasValue || y.Turma.CursoId == filter.CursoId) &&
                (string.IsNullOrEmpty(filter.Matricula) || y.Matricula == filter.Matricula) &&
                (filter.SituacaoId == null || !filter.SituacaoId.Any() || filter.SituacaoId.Contains(y.TipoStatusAlunoId))
            ));

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

        public override Aluno GetById(int id)
        {
            var query = IncludeCompleto();

            return query.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Aluno> BuscarAlunosENotasDeTurma(int turmaId)
        {
            var query = Query();
            query = query.Include(x => x.TurmasAluno).ThenInclude(x => x.Turma)
                         .Include(x => x.NotasAluno).ThenInclude(x => x.Disciplina);

            query = query.Where(x => x.TurmasAluno.Any(y => y.TurmaId == turmaId));

            return query.ToList();
        }

        private IQueryable<Aluno> IncludeTabela()
        {
            var query = Query();
            query = query
                .Include(x => x.Registros)
                .Include(x => x.TurmasAluno).ThenInclude(x => x.Turma)
                .Include(x => x.TurmasAluno).ThenInclude(x => x.TipoStatusAluno)
                .AsQueryable();
            return query;
        }

        private IQueryable<Aluno> IncludeCompleto()
        {
            var query = Query();
            query = query
                .Include(x => x.TurmasAluno).ThenInclude(x => x.Turma)
                .Include(x => x.TurmasAluno).ThenInclude(x => x.TipoStatusAluno)
                .Include(x => x.Registros)
                .AsQueryable();
            return query;
        }
    }
}
