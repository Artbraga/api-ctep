using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class TipoStatusAluno : BaseEntity
    {
        public string Nome { get; set; }
        public virtual IEnumerable<Aluno> Alunos { get; set; }
    }
}
