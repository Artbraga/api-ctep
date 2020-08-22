using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impl.Repositories
{
    public class TurmaAlunoRepository : BaseRepository<TurmaAluno>, ITurmaAlunoRepository
    {
        public TurmaAlunoRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TurmaAluno> ListarTurmasDeUmAluno(int idAluno)
        {
            var query = Query();
            query = query.Include(x => x.Turma).AsQueryable();

            query = query.Where(x => x.AlunoId == idAluno);

            return query.ToList();
        }
    }
}
