using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class TurmaProfessor : BaseEntity
    {
        public int ProfessorId { get; set; }
        public int TurmaId { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
