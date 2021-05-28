using System.Collections.Generic;

namespace Entities.Entities
{
    public class Permissao : BaseEntity
    {
        public string Nome { get; set; }
        public virtual IEnumerable<PerfilPermissao> PerfisPermissao { get; set; }
    }
}
