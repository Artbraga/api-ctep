using Entities.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.DTOs
{
    public class PerfilDTO : BaseDTO<Perfil>
    {
        public string Nome { get; set; }
        public IEnumerable<UsuarioDTO> Usuarios { get; set; } 
        public IEnumerable<string> Permissoes { get; set; }
        public PerfilDTO()
        {
        }

        public PerfilDTO(Perfil entity) : base(entity)
        {
            this.Nome = entity.Nome;
            this.Usuarios = entity.Usuarios.Select(x => new UsuarioDTO(x));
            this.Permissoes = entity.PerfisPermissao?.Select(x => x.Permissao.Nome);
        }

        public override Perfil ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
