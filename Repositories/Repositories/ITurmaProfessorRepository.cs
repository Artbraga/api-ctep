using Entities.Entities;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public interface ITurmaProfessorRepository : IBaseRepository<TurmaProfessor>
    {
        IEnumerable<TurmaProfessor> BuscarProfessoresDeUmaTurma(int turmaId);
    }
}
