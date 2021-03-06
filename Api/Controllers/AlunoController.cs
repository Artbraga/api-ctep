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
    public class AlunoController : Controller
    {
        private readonly IAlunoService AlunoService;

        public AlunoController(IAlunoService AlunoService)
        {
            this.AlunoService = AlunoService;
        }

        [HttpGet("{cursoId:int}/{anoMatricula:int}")]
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
            byte[] imagem = null;
            using (var ms = new MemoryStream())
            {
                if (Request.Form.Files.Count > 0)
                {
                    Request.Form.Files[0].CopyTo(ms);

                    imagem = ms.ToArray();
                }
            }
            var retorno = AlunoService.SalvarImagemAluno(idAluno, imagem);
            return retorno;
        }

        [HttpPost]
        public bool VincularAlunoTurma(TurmaAlunoDTO turmaAlunoDTO)
        {
            return AlunoService.VincularAlunoTurma(turmaAlunoDTO);
        }

        [HttpGet("{id:int}")]
        public AlunoDTO GetById(int id)
        {
            return (AlunoDTO)AlunoService.GetById(id);
        }

        [HttpDelete("{id:int}")]
        public bool Deletar(int id)
        {
            return AlunoService.ExcluirAluno(id);
        }

        [HttpPost]
        public bool AdicionarRegistro(RegistroAlunoDTO registro)
        {
            return AlunoService.AdicionarRegistro(registro);
        }

        [HttpDelete("{id:int}")]
        public bool ExcluirRegistro(int id)
        {
            return AlunoService.ExcluirRegistro(id);
        }

        [HttpGet("{id:int}")]
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
        
        [HttpPost]
        public byte[] BaixarPesquisa(AlunoFilter filter)
        {
            return AlunoService.ExportarPesquisa(filter);
        }

        [HttpPost]
        public bool AlterarSituacao(MudancaSituacaoDTO mudancaSituacao)
        {
            return AlunoService.AlterarSituacao(mudancaSituacao);
        }
    }
}