using System.Collections.Generic;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotaController : Controller
    {
        private readonly INotaAlunoService NotaAlunoService;

        public NotaController(INotaAlunoService notaAlunoService)
        {
            this.NotaAlunoService = notaAlunoService;
        }

        [HttpPost]
        public void SalvarNotas(IEnumerable<NotaAlunoDTO> notas)
        {
            NotaAlunoService.SalvarNotas(notas);
        }

        [HttpGet("{alunoId}")]
        public IEnumerable<NotaAlunoDTO> ListarNotasDeUmAluno(int alunoId)
        {
            return NotaAlunoService.ListarNotasDeUmAluno(alunoId);
        }
    }
}
