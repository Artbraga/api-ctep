using Entities.DTOs;
using Entities.Entities;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl
{
    public class TurmaService : BaseService<Turma>, ITurmaService
    {
        private readonly ITurmaRepository TurmaRepository;
        public TurmaService(ITurmaRepository TurmaRepository) : base(TurmaRepository)
        {
            this.TurmaRepository = TurmaRepository;
        }

        public IEnumerable<TurmaDTO> ListarTurmas()
        {
            return TurmaRepository.All().Select(x => new TurmaDTO(x));
        }

        public IEnumerable<TurmaDTO> ListarTurmasDeUmCurso(int cursoId)
        {
            return TurmaRepository.ListarTurmasDeUmCurso(cursoId).Select(x => new TurmaDTO(x));
        }
    }
}
