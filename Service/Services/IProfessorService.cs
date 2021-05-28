using Entities.DTOs;
using Entities.Entities;
using Entities.Filters;
using Services.Base;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IProfessorService : IBaseService<Professor>
    {
        IEnumerable<ProfessorDTO> ListarProfessores();
        IEnumerable<ProfessorDTO> ListarProfessoresAtivos();
        bool ExcluirProfessor(int id);
        ProfessorDTO SalvarProfessor(ProfessorDTO professor);
        IEnumerable<ProfessorDTO> FiltrarProfessores(ProfessorFilter filter);
        IEnumerable<ProfessorDTO> ListarProfessoresDaTurma(int turmaId);
    }
}
