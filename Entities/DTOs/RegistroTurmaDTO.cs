using Entities.Base;
using Entities.Entities;
using System;

namespace Entities.DTOs
{
    public class RegistroAlunoDTO : BaseDTO<RegistroAluno>
    {
        public DateTime Data { get; set; }
        public string Registro { get; set; }
        public int AlunoId { get; set; }

        public RegistroAlunoDTO()
        {
        }

        public RegistroAlunoDTO(RegistroAluno entity) : base(entity)
        {
            this.Id = entity.Id;
            this.AlunoId = entity.AlunoId;
            this.Data = entity.Data;
            this.Registro = entity.Registro;
        }

        public override RegistroAluno ToEntity()
        {
            return new RegistroAluno
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                AlunoId = this.AlunoId,
                Data = this.Data,
                Registro = this.Registro
            };
        }
    }
}
