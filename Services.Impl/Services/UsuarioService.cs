using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Exceptions;
using log4net;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Impl.Util;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IPerfilRepository perfilRepository;
        private static readonly ILog log = LogManager.GetLogger(typeof(AlunoService));
       
        public UsuarioService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository) : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.perfilRepository = perfilRepository;
        }

        public IEnumerable<UsuarioDTO> ListarUsuarios()
        {
            return usuarioRepository.ListarUsuarios().Select(x => new UsuarioDTO(x));
        }

        public UsuarioDTO SalvarUsuario(UsuarioDTO usuario)
        {
            var transaction = this.usuarioRepository.GetTransaction();
            try
            {
                Usuario usr;
                if (usuario.Id.HasValue)
                {
                    usr = usuarioRepository.GetById(usuario.Id.Value);
                    if (usr.Login != usuario.Login)
                    {
                        if (usuarioRepository.VerificaLoginUnico(usuario.Login))
                        {
                            throw new BusinessException("Já existe um usuário com o login informado.");
                        }
                        usr.Login = usuario.Login;
                    }
                    usr.Nome = usuario.Nome;
                    if (!string.IsNullOrEmpty(usuario.Senha))
                    {
                        usr.Senha = MD5Helper.GetMd5Hash(usuario.Senha);
                    }
                }
                else
                {
                    if (usuarioRepository.VerificaLoginUnico(usuario.Login))
                    {
                        throw new BusinessException("Já existe um usuário com o login informado.");
                    }
                    usr = usuario.ToEntity();
                    usuarioRepository.Add(usr);
                }

                usuarioRepository.SaveChanges();

                transaction.Commit();
                transaction.Dispose();

                return new UsuarioDTO(usuarioRepository.GetById(usr.Id));
            }
            catch (Exception e)
            {
                log.Error("Erro ao salvar usuário.", e);
                throw new BusinessException("Erro desconhecido ao salvar usuário.");
            }
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
            var usuario = usuarioRepository.GetById(id);
            return new UsuarioDTO(usuario);
        }

        public IEnumerable<PerfilDTO> ListarPerfis()
        {
            var perfis = perfilRepository.All().ToList();
            return perfis.Select(x => new PerfilDTO(x));
        }

        public IEnumerable<PerfilDTO> BuscarPerfisComUsuarios()
        {
            var perfis = perfilRepository.BuscarPerfisComUsuarios();
            return perfis.Select(x => new PerfilDTO(x));
        }
    }
}
