using Entities.Entities;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public interface INotaAlunoRepository : IBaseRepository<NotaAluno>
    {
        IEnumerable<NotaAluno> ListarNotasDeUmAluno(int alunoId);
    }
}
