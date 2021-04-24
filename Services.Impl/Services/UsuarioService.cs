using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Exceptions;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Impl.Util;
using Services.Services;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IPerfilRepository perfilRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository) : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.perfilRepository = perfilRepository;
        }

        public IEnumerable<UsuarioDTO> ListarUsuarios()
        {
            return usuarioRepository.All().Select(x => new UsuarioDTO(x));
        }

        public UsuarioDTO BuscarUsuarioPorLoginESenha(UsuarioDTO usuario)
        {
            var senha = MD5Helper.GetMd5Hash(usuario.Senha);
            var usuarioSalvo = usuarioRepository.BuscarUsuarioPorLoginESenha(usuario.Login, senha);
            if (usuarioSalvo == null) {
                throw new BusinessException("Usuário ou senha incorretos.");
            }
            return new UsuarioDTO(usuarioSalvo);
        }

        public override BaseDTO<Usuario> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PerfilDTO> ListarPerfis()
        {
            var perfis = perfilRepository.All();
            return perfis.Select(x => new PerfilDTO(x));
        }

        public IEnumerable<PerfilDTO> BuscarPerfisComUsuarios()
        {
            var perfis = perfilRepository.BuscarPerfisComUsuarios();
            return perfis.Select(x => new PerfilDTO(x));
        }
    }
}
