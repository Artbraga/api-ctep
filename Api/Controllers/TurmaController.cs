using System.Collections.Generic;
using Entities.DTOs;
using Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TurmaController : Controller
    {
        private readonly ITurmaService TurmaService;

        public TurmaController(ITurmaService TurmaService)
        {
            this.TurmaService = TurmaService;
        }

        [HttpGet("{cursoId:int}")]
        public IEnumerable<TurmaDTO> ListarTurmasDeUmCurso(int cursoId)
        {
            return TurmaService.ListarTurmasDeUmCurso(cursoId);
        }
        
        [HttpGet]
        public IEnumerable<TurmaDTO> ListarTurmasAtivas()
        {
            return TurmaService.ListarTurmasAtivas();
        }

        [HttpGet("{cursoId}/{anoTurma}")]
        public string GerarCodigoDaTurma(int cursoId, int anoTurma)
        {
            return TurmaService.GerarCodigoDaTurma(cursoId, anoTurma);
        }

        [HttpGet("{codigo}/{cursoId?}")]
        public IEnumerable<TurmaDTO> BuscarTurmasPorCodigoECurso(string codigo, int? cursoId)
        {
            return TurmaService.BuscarTurmasPorCodigoECurso(codigo, cursoId);
        }

        [HttpGet("{id}")]
        public TurmaDTO GetById(int id)
        {
            return (TurmaDTO)TurmaService.GetById(id);
        }

        [HttpPost]
        public TurmaDTO Salvar(TurmaDTO turma)
        {
            return TurmaService.SalvarTurma(turma);
        }

        [HttpDelete("{id:int}")]
        public bool Deletar(int id)
        {
            return TurmaService.Delete(id);
        }

        [HttpPost]
        public IEnumerable<TurmaDTO> FiltrarTurmas(TurmaFilter filter)
        {
            return TurmaService.FiltrarTurmas(filter);
        }

        [HttpPost]
        public bool AdicionarRegistro(RegistroTurmaDTO registro)
        {
            return TurmaService.AdicionarRegistro(registro);
        }

        [HttpDelete("{id:int}")]
        public bool ExcluirRegistro(int id)
        {
            return TurmaService.ExcluirRegistro(id);
        }
    }
}