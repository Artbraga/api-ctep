using Entities.DTOs;
using Entities.Entities;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Impl.Util;
using Services.Services;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuarioDTO> ListarUsuarios()
        {
            return usuarioRepository.All().Select(x => new UsuarioDTO(x));
        }

        public UsuarioDTO BuscarUsuarioPorLoginESenha(UsuarioDTO usuario)
        {
            var senha = MD5Helper.GetMd5Hash(usuario.Senha);
            var usuarioSalvo = usuarioRepository.BuscarUsuarioPorLoginESenha(usuario.Login, senha);
            return usuarioSalvo != null ? new UsuarioDTO(usuarioSalvo) : null;
        }
    }
}
