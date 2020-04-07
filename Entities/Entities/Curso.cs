using System.Collections.Generic;

namespace Entities.Entities
{
    public class Curso : BaseEntity
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string SiglaTurma { get; set; }
        public bool Especializacao { get; set; }
        public int CursoVinculadoId { get; set; }
        public virtual Curso CursoVinculado { get; set; }
        public virtual IEnumerable<Curso> CursosEspecializacao { get; set; }
        public virtual IEnumerable<Turma> Turmas { get; set; }
    }
}
