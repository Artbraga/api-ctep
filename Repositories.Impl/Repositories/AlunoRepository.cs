using Entities.Entities;
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
    }
}
