using Entities.DTOs;
using Entities.Entities;
using Entities.Filters;
using Services.Base;
using System.Collections.Generic;

namespace Services.Services
{
    public interface ITurmaService : IBaseService<Turma>
    {
        IEnumerable<TurmaDTO> ListarTurmas();
        IEnumerable<TurmaDTO> ListarTurmasDeUmCurso(int cursoId);
        string GerarCodigoDaTurma(int cursoId, int anoTurma);
        TurmaDTO SalvarTurma(TurmaDTO turma);
        bool FinalizarTurma(TurmaDTO turma);
        IEnumerable<TurmaDTO> ListarTurmasAtivas();
        IEnumerable<TurmaDTO> BuscarTurmasPorCodigoECurso(string codigo, int? cursoId);
        IEnumerable<TurmaDTO> FiltrarTurmas(TurmaFilter filter);
        bool AdicionarRegistro(RegistroTurmaDTO registro);
        bool ExcluirRegistro(int id);
        bool AdicionarProfessor(TurmaProfessorDTO turmaProfessor);
        bool ExcluirProfessor(int id);
        IEnumerable<TurmaProfessorDTO> BuscarProfessoresDeUmaTurma(int turmaId);
    }
}
