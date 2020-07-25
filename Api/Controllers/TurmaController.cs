using System.Collections.Generic;
using Entities.DTOs;
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
        public IEnumerable<TurmaDTO> ListarTurmas()
        {
            return TurmaService.ListarTurmas();
        }

        [HttpGet]
        public IEnumerable<TurmaDTO> ListarTurmasDeUmCurso(int cursoId)
        {
            return TurmaService.ListarTurmasDeUmCurso(cursoId);
        }
    }
}