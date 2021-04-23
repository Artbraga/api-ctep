using Entities.DTOs;
using Entities.Entities;
using Services.Base;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IProfessorService : IBaseService<Professor>
    {
        IEnumerable<ProfessorDTO> ListarProfessores();
        IEnumerable<ProfessorDTO> ListarProfessoresAtivos();
    }
}
