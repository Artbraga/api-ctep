using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using log4net;
using Repositories.Base;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Impl.Services
{
    public class ProfessorService : BaseService<Professor>, IProfessorService
    {
        private readonly IProfessorRepository professorRepository;

        private static readonly ILog log = LogManager.GetLogger(typeof(AlunoService));

        public ProfessorService(IProfessorRepository professorRepository) : base(professorRepository)
        {
            this.professorRepository = professorRepository;
        }

        public override BaseDTO<Professor> GetById(int id)
        {
            var professor = professorRepository.GetById(id);
            return new ProfessorDTO(professor);
        }

        public IEnumerable<ProfessorDTO> ListarProfessores()
        {
            var professores = professorRepository.All();
            return professores.Select(x => new ProfessorDTO(x));
        }

        public IEnumerable<ProfessorDTO> ListarProfessoresAtivos()
        {
            var professores = professorRepository.ListarProfessoresAtivos();
            return professores.Select(x => new ProfessorDTO(x));
        }
    }
}
