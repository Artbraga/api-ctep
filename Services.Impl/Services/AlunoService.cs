using Entities.Entities;
using Repositories.Base;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;

namespace Services.Impl.Services
{
    public class AlunoService : BaseService<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository alunoRepository;
        private readonly ICursoRepository cursoRepository;
        public AlunoService(IAlunoRepository alunoRepository, 
            ICursoRepository cursoRepository) : base(alunoRepository)
        {
            this.alunoRepository = alunoRepository;
            this.cursoRepository = cursoRepository;
        }

        public string GerarNumeroDeMatricula(int cursoId, int anoMatricula)
        {
            var curso = cursoRepository.GetById(cursoId);
            var trecho = $"{curso.Sigla}{anoMatricula % 100}";
            var numero = alunoRepository.BuscarCodigoParaMatricula(trecho);
            return $"{trecho}{numero}";
        }
    }
}
