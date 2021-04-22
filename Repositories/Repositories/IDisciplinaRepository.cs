using Entities.Entities;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public interface IDisciplinaRepository : IBaseRepository<Disciplina>
    {
        IEnumerable<Disciplina> ListarDisciplinasDeUmCurso(int cursoId);
    }
}
