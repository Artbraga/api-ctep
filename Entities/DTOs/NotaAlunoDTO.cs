using Entities.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class NotaAlunoDTO : BaseDTO<NotaAluno>
    {
        public NotaAlunoDTO()
        {
        }

        public NotaAlunoDTO(NotaAluno entity) : base(entity)
        {
            this.Id = entity.Id;
            this.ValorNota = string.Format("{0:0,0}", entity.ValorNota);
            this.AlunoId = entity.AlunoId;
            this.DisciplinaId = entity.DisciplinaId;
            this.ProfessorId = entity.ProfessorId;
        }

        public string ValorNota { get; set; }
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public int? ProfessorId { get; set; }

        public override NotaAluno ToEntity()
        {
            return new NotaAluno()
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                ValorNota = float.Parse(this.ValorNota),
                AlunoId = this.AlunoId,
                DisciplinaId = this.DisciplinaId,
                ProfessorId = this.ProfessorId
            };
        }
    }
}
