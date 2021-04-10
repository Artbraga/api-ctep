using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impl.Repositories
{
    public class NotaAlunoRepository : BaseRepository<NotaAluno>, INotaAlunoRepository
    {
        public NotaAlunoRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<NotaAluno> ListarNotasDeUmAluno(int alunoId)
        {
            var query = Query();
            query = query.Where(x => x.AlunoId == alunoId);

            return query.ToList();
        }
    }
}
