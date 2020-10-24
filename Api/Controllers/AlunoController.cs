using System.Collections.Generic;
using System.IO;
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

        [HttpPost, DisableRequestSizeLimit]
        public bool SalvarImagemAluno()
        {
            var idAluno = int.Parse(Request.Form["idAluno"]);
            byte[] imagem;
            using (var ms = new MemoryStream())
            {
                Request.Form.Files[0].CopyTo(ms);

                imagem = ms.ToArray();
            }
            var retorno = AlunoService.SalvarImagemAluno(idAluno, imagem);
            return retorno;
        }

        [HttpPost]
        public bool VincularAlunoTurma(TurmaAlunoDTO turmaAlunoDTO)
        {
            return AlunoService.VincularAlunoTurma(turmaAlunoDTO);
        }

        [HttpGet]
        public AlunoDTO GetById(int id)
        {
            return (AlunoDTO)AlunoService.GetById(id);
        }

        public IActionResult BuscarImagemAluno(int id)
        {
            var bytes = AlunoService.BuscarImagemAluno(id);
            if(bytes != null)
            {
                return File(bytes, "image/jpeg");
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        public IEnumerable<AlunoDTO> FiltrarAlunos(AlunoFilter filter)
        {
            return AlunoService.FiltrarAlunos(filter);
        }
    }
}