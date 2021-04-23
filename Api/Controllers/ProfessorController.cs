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

        [HttpGet("{codigo}/{cursoId?}")]
        public IEnumerable<ProfessorDTO> BuscarTurmasPorCodigoECurso(string codigo, int? cursoId)
        {
            return professorService.ListarProfessores(codigo, cursoId);
        }

        [HttpGet("{id}")]
        public ProfessorDTO GetById(int id)
        {
            return (ProfessorDTO)professorService.GetById(id);
        }

    }
}
