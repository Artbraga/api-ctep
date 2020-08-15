using Entities.Entities;
using Entities.Filters;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        int BuscarCodigoParaMatricula(string trechoMatricula);
        IEnumerable<Aluno> FiltrarAlunos(AlunoFilter filter);
    }
}
