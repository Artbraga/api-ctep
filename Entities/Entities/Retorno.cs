using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Retorno : BaseEntity
    {
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public DateTime DataReferencia { get; set; }
        public DateTime DataLeitura { get; set; }
        public virtual IEnumerable<RegistroRetorno> Registros { get; set; }
    }
}
