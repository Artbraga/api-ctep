using Entities.Entities;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface ITurmaAlunoRepository : IBaseRepository<TurmaAluno>
    {
        IEnumerable<TurmaAluno> ListarTurmasDeUmAluno(int idAluno);
    }
}
