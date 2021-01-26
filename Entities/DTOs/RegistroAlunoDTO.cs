using Entities.Base;
using Entities.Entities;
using System;

namespace Entities.DTOs
{
    public class RegistroTurmaDTO : BaseDTO<RegistroTurma>
    {
        public DateTime Data { get; set; }
        public string Registro { get; set; }
        public int TurmaId { get; set; }

        public RegistroTurmaDTO()
        {
        }

        public RegistroTurmaDTO(RegistroTurma entity) : base(entity)
        {
            this.Id = entity.Id;
            this.TurmaId = entity.TurmaId;
            this.Data = entity.Data;
            this.Registro = entity.Registro;
        }

        public override RegistroTurma ToEntity()
        {
            return new RegistroTurma
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                TurmaId = this.TurmaId,
                Data = this.Data,
                Registro = this.Registro
            };
        }
    }
}
