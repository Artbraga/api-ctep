using Entities.DTOs;
using Entities.Entities;
using Services.Base;
using System.Collections.Generic;

namespace Services.Services
{
    public interface ICursoService : IBaseService<Curso>
    {
        IEnumerable<CursoDTO> ListarCursos();
    }
}
