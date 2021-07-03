using System;

namespace Entities.Entities
{
    public class RegistroRetorno: BaseEntity
    {
        public string Registro { get; set; }
        public int RetornoId { get; set; }
        public virtual Retorno Retorno { get; set; }
    }
}
