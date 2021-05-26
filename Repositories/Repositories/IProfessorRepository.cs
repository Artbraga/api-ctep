using Entities.DTOs;
using Entities.Entities;
using Entities.Filters;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface IProfessorRepository : IBaseRepository<Professor>
    {
        IEnumerable<Professor> ListarProfessoresAtivos();
        IEnumerable<Professor> FiltrarProfessores(ProfessorFilter filter);
        IEnumerable<Professor> ListarProfessoresDaTurma(int turmaId);
    }
}
