using System.Collections.Generic;

namespace Entities.Entities
{
    public class Disciplina : BaseEntity
    {
        public string Nome { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual IEnumerable<NotaAluno> NotasAluno { get; set; }
    }
}
