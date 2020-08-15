using Entities.DTOs;
using Entities.Entities;
using Entities.Filters;
using Services.Base;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IAlunoService : IBaseService<Aluno>
    {
        string GerarNumeroDeMatricula(int cursoId, int anoMatricula);
        AlunoDTO SalvarAluno(AlunoDTO alunoDto);
        IEnumerable<AlunoDTO> FiltrarAlunos(AlunoFilter filter);
    }
}
