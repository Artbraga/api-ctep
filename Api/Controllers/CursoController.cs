using System.Collections.Generic;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService CursoService;

        public CursoController(ICursoService CursoService)
        {
            this.CursoService = CursoService;
        }

        public IEnumerable<CursoDTO> ListarCursos()
        {
            return CursoService.ListarCursos();
        }
    }
}