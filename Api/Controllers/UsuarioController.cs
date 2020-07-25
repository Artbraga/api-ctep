using System.Collections.Generic;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public IEnumerable<UsuarioDTO> ListarUsuarios()
        {
            return usuarioService.ListarUsuarios();
        }

        [HttpPost]
        public UsuarioDTO BuscarUsuarioPorLoginESenha(UsuarioDTO usuario)
        {
            return usuarioService.BuscarUsuarioPorLoginESenha(usuario);
        }
    }
}