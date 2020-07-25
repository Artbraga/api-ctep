using Entities.Entities;
using Services.Base;

namespace Services.Services
{
    public interface IAlunoService : IBaseService<Aluno>
    {
        string GerarNumeroDeMatricula(int cursoId, int anoMatricula);
    }
}
