using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impl.Repositories
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Curso> ListarCursos()
        {
            var query = Query();
            return query.ToList();
        }
    }
}
