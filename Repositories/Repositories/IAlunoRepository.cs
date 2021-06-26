using Entities.Entities;
using Entities.Filters;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        int BuscarNumeroDeMatriculasPorTrecho(string trechoMatricula);
        IEnumerable<Aluno> FiltrarAlunos(AlunoFilter filter, bool paginar = false);
        IEnumerable<Aluno> ListarAlunosPorVencimento(IPageFilter pageFilter);
        bool ExisteMatricula(string matricula);
        IEnumerable<Aluno> BuscarAlunosENotasDeTurma(int turmaId);
    }
}
