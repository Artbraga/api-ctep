using Entities.Entities;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface ICursoRepository : IBaseRepository<Curso>
    {
        IEnumerable<Curso> ListarCursos();
    }
}
