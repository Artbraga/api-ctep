using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl
{
    public class CursoService : BaseService<Curso>, ICursoService
    {
        private readonly ICursoRepository CursoRepository;
        public CursoService(ICursoRepository CursoRepository) : base(CursoRepository)
        {
            this.CursoRepository = CursoRepository;
        }

        public override BaseDTO<Curso> GetById(int id)
        {
            var curso = new CursoDTO();

            return curso;
        }

        public IEnumerable<CursoDTO> ListarCursos()
        {
            return CursoRepository.All().Select(x => new CursoDTO(x));
        }
    }
}
