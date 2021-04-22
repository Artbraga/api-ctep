using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class NotaAluno : BaseEntity
    {
        public float ValorNota { get; set; }
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public int? ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
