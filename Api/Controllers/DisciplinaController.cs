using System.Collections.Generic;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DisciplinaController : Controller
    {
        private readonly IDisciplinaService DisciplinaService;

        public DisciplinaController(IDisciplinaService DisciplinaService)
        {
            this.DisciplinaService = DisciplinaService;
        }

        [HttpGet("{cursoId}")]
        public IEnumerable<DisciplinaDTO> ListarDisciplinasDeUmCurso(int cursoId)
        {
            return DisciplinaService.ListarDisciplinasDeUmCurso(cursoId);
        }
    }
}