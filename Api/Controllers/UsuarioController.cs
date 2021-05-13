using System.Collections.Generic;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : Controller
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

        [HttpGet("{id:int}")]
        public UsuarioDTO GetById(int id)
        {
            return (UsuarioDTO)usuarioService.GetById(id);
        }

        [HttpPost]
        public UsuarioDTO Salvar(UsuarioDTO aluno)
        {
            return usuarioService.SalvarUsuario(aluno);
        }

        [HttpGet]
        public IEnumerable<PerfilDTO> ListarPerfis()
        {
            return usuarioService.ListarPerfis();
        }

        [HttpGet]
        public IEnumerable<PerfilDTO> BuscarPerfisComUsuarios()
        {
            return usuarioService.BuscarPerfisComUsuarios();
        }
    }
}