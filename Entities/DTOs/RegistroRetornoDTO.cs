using Entities.Base;
using Entities.Entities;
using System;

namespace Entities.DTOs
{
    public class RegistroRetornoDTO : BaseDTO<RegistroRetorno>
    {
        public DateTime Data { get; set; }
        public string Registro { get; set; }
        public int TurmaId { get; set; }

        public RegistroRetornoDTO()
        {
        }

        public RegistroRetornoDTO(RegistroRetorno entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Registro = entity.Registro;
        }

        public override RegistroRetorno ToEntity()
        {
            return new RegistroRetorno
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Registro = this.Registro
            };
        }
    }
}
