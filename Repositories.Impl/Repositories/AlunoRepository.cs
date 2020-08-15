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

        public int BuscarCodigoParaMatricula(string trechoMatricula)
        {
            var query = Query().Include(x => x.TurmasAluno).AsQueryable();
            query = query.Where(x => x.TurmasAluno.Any(y => y.Matricula.StartsWith(trechoMatricula)));

            return query.Count();
        }

        public IEnumerable<Aluno> FiltrarAlunos(AlunoFilter filter)
        {
            var query = Include();
            if (!string.IsNullOrEmpty(filter.Nome)) {
                query = query.Where(x => x.Nome.Contains(filter.Nome));
            }
            if (!string.IsNullOrEmpty(filter.CPF))
            {
                query = query.Where(x => x.CPF.Equals(filter.CPF));
            }
            if (!string.IsNullOrEmpty(filter.CodigoTurma))
            {
                query = query.Where(x => x.TurmasAluno.Any(y => y.Turma.Codigo.Contains(filter.CodigoTurma)));
            }
            if (filter.CursoId.HasValue)
            {
                query = query.Where(x => x.TurmasAluno.Any(y => y.Turma.CursoId == filter.CursoId));
            }
            if (filter.SituacaoId != null && filter.SituacaoId.Any())
            {
                query = query.Where(x => filter.SituacaoId.Contains(x.TipoStatusAlunoId));
            }

            return query;
        }

        public override Aluno GetById(int id)
        {
            var query = Include();

            return query.FirstOrDefault(x => x.Id == id);
        }

        private IQueryable<Aluno> Include()
        {
            var query = Query();
            query = query
                .Include(x => x.TurmasAluno).ThenInclude(x => x.Turma)
                .Include(x => x.TipoStatusAluno)
                .AsQueryable();
            return query;
        }
    }
}
