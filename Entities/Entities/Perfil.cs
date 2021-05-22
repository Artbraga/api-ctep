
using System.Collections.Generic;

namespace Entities.Entities
{
    public class Perfil : BaseEntity
    {
        public string Nome { get; set; }
        public virtual IEnumerable<PerfilPermissao> PerfisPermissao { get; set; }
        public virtual IEnumerable<Usuario> Usuarios { get; set; }
    }
}
