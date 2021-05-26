using System.Collections.Generic;
using Entities.DTOs;
using Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using Services.Services;


namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        private readonly IProfessorService professorService;

        public ProfessorController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpGet()]
        public IEnumerable<ProfessorDTO> ListarProfessores()
        {
            return professorService.ListarProfessores();
        }

        [HttpGet()]
        public IEnumerable<ProfessorDTO> ListarProfessoresAtivos()
        {
            return professorService.ListarProfessoresAtivos();
        }

        [HttpGet("{turmaId}")]
        public IEnumerable<ProfessorDTO> ListarProfessoresDaTurma(int turmaId)
        {
            return professorService.ListarProfessoresDaTurma(turmaId);
        }

        [HttpGet("{id}")]
        public ProfessorDTO GetById(int id)
        {
            return (ProfessorDTO)professorService.GetById(id);
        }

        [HttpDelete("{id:int}")]
        public bool Deletar(int id)
        {
            return professorService.ExcluirProfessor(id);
        }

        [HttpPost]
        public ProfessorDTO Salvar(ProfessorDTO professor)
        {
            return professorService.SalvarProfessor(professor);
        }

        [HttpPost]
        public IEnumerable<ProfessorDTO> FiltrarProfessores(ProfessorFilter filter)
        {
            return professorService.FiltrarProfessores(filter);
        }

    }
}
