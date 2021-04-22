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
    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Disciplina> ListarDisciplinasDeUmCurso(int cursoId)
        {
            var query = Query();
            query = query.Where(x => x.CursoId == cursoId);
            return query.ToList();
        }
    }
}
