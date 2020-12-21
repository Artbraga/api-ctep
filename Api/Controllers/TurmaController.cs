using System.Collections.Generic;
using Entities.DTOs;
using Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService TurmaService;

        public TurmaController(ITurmaService TurmaService)
        {
            this.TurmaService = TurmaService;
        }

        [HttpGet]
        public IEnumerable<TurmaDTO> ListarTurmasDeUmCurso(int cursoId)
        {
            return TurmaService.ListarTurmasDeUmCurso(cursoId);
        }
        
        [HttpGet]
        public IEnumerable<TurmaDTO> ListarTurmasAtivas()
        {
            return TurmaService.ListarTurmasAtivas();
        }

        [HttpGet]
        public string GerarCodigoDaTurma(int cursoId, int anoTurma)
        {
            return TurmaService.GerarCodigoDaTurma(cursoId, anoTurma);
        }
        
        [HttpGet]
        public IEnumerable<TurmaDTO> BuscarTurmasPorCodigoECurso(string codigo, int? cursoId)
        {
            return TurmaService.BuscarTurmasPorCodigoECurso(codigo, cursoId);
        }

        [HttpGet]
        public TurmaDTO GetById(int id)
        {
            return (TurmaDTO)TurmaService.GetById(id);
        }

        [HttpPost]
        public TurmaDTO Salvar(TurmaDTO turma)
        {
            return TurmaService.SalvarTurma(turma);
        }

        [HttpDelete]
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

        [HttpDelete]
        public bool ExcluirRegistro(int id)
        {
            return TurmaService.ExcluirRegistro(id);
        }
    }
}