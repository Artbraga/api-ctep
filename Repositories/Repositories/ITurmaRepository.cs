using Entities.Entities;
using Entities.Filters;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        IEnumerable<Turma> ListarTurmasDeUmCurso(int cursoId);
        int BuscarCodigoDaTurma(string trechoCodigo);
        bool ExisteCodigo(string codigo);
        IEnumerable<Turma> ListarTurmasAtivas();
        IEnumerable<Turma> BuscarTurmasPorCodigoECurso(string codigo, int? cursoId);
        IEnumerable<Turma> FiltrarTurmas(TurmaFilter filter);
    }
}
