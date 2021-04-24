using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class PerfilPermissao : BaseEntity
    {
        public int PerfilId { get; set; }
        public int PermissaoId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Permissao Permissao { get; set; }
    }
}
