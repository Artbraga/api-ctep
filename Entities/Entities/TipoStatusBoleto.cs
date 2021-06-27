using System.Collections.Generic;

namespace Entities.Entities
{
    public class TipoStatusBoleto: BaseEntity
    {
        public string Nome { get; set; }
        public virtual IEnumerable<Boleto> Boletos { get; set; }
    }
}
