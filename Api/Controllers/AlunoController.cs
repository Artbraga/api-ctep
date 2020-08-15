using System.Collections.Generic;
using Entities.DTOs;
using Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService AlunoService;

        public AlunoController(IAlunoService AlunoService)
        {
            this.AlunoService = AlunoService;
        }

        [HttpGet]
        public string GerarNumeroDeMatricula(int cursoId, int anoMatricula)
        {
            return AlunoService.GerarNumeroDeMatricula(cursoId, anoMatricula);
        }

        [HttpPost]
        public AlunoDTO Salvar(AlunoDTO aluno)
        {
            return AlunoService.SalvarAluno(aluno);
        }

        [HttpGet]
        public AlunoDTO GetById(int id)
        {
            return (AlunoDTO)AlunoService.GetById(id);
        }

        [HttpPost]
        public IEnumerable<AlunoDTO> FiltrarAlunos(AlunoFilter filter)
        {
            return AlunoService.FiltrarAlunos(filter);
        }
    }
}