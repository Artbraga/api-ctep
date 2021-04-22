using Entities.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class DisciplinaDTO : BaseDTO<Disciplina>
    {
        public string Nome { get; set; }
        public int CursoId { get; set; }

        public DisciplinaDTO()
        {
        }

        public DisciplinaDTO(Disciplina entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.CursoId = entity.CursoId;
        }

        public override Disciplina ToEntity()
        {
            return new Disciplina()
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Nome = this.Nome,
                CursoId = this.CursoId
            };
        }
    }
}
