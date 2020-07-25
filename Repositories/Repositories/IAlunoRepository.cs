using Entities.Entities;
using Repositories.Base;

namespace Repositories.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        int BuscarCodigoParaMatricula(string trechoMatricula);
    }
}
