using Entities.Entities;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        IEnumerable<Turma> ListarTurmasDeUmCurso(int cursoId);
    }
}
