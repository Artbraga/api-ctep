using Entities.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TurmaProfessorDTO : BaseDTO<TurmaProfessor>
    {
        public int TurmaId { get; set; }
        public ProfessorDTO Professor { get; set; }

        public TurmaProfessorDTO()
        {
        }

        public TurmaProfessorDTO(TurmaProfessor entity) : base(entity)
        {
            this.Id = entity.Id;
            this.TurmaId = entity.TurmaId;
            this.Professor = new ProfessorDTO(entity.Professor);
        }

        public override TurmaProfessor ToEntity()
        {
            return new TurmaProfessor
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                TurmaId = this.TurmaId,
                ProfessorId = this.Professor.Id.Value
            };
        }
    }
}
