using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using log4net;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;

namespace Services.Impl.Services
{
    public class DisciplinaService : BaseService<Disciplina>, IDisciplinaService
    {
        private readonly IDisciplinaRepository disciplinaRepository;

        private static readonly ILog log = LogManager.GetLogger(typeof(AlunoService));

        public DisciplinaService(IDisciplinaRepository repository) : base(repository)
        {
            this.disciplinaRepository = repository;
        }

        public IEnumerable<DisciplinaDTO> ListarDisciplinasDeUmCurso(int cursoId)
        {
            var disciplinas = this.disciplinaRepository.ListarDisciplinasDeUmCurso(cursoId);
            return disciplinas.Select(x => new DisciplinaDTO(x));
        }

        public override BaseDTO<Disciplina> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
