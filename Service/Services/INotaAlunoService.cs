using Entities.DTOs;
using Entities.Entities;
using Services.Base;
using System.Collections.Generic;

namespace Services.Services
{
    public interface INotaAlunoService : IBaseService<NotaAluno>
    {
        void SalvarNotas(IEnumerable<NotaAlunoDTO> notas);
        IEnumerable<NotaAlunoDTO> ListarNotasDeUmAluno(int alunoId);
    }
}
