using Entities.DTOs;
using Entities.Entities;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface IProfessorRepository : IBaseRepository<Professor>
    {
        IEnumerable<Professor> ListarProfessoresAtivos();
    }
}
