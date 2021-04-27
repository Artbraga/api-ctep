using System.Collections.Generic;
using Entities.DTOs;
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
    }
}
