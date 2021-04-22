using Entities.DTOs;
using Entities.Entities;
using Services.Base;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IDisciplinaService : IBaseService<Disciplina>
    {
        IEnumerable<DisciplinaDTO> ListarDisciplinasDeUmCurso(int cursoId);
    }
}
