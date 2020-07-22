using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class TipoStatusTurma : BaseEntity
    {
        public string Nome { get; set; }
        public virtual IEnumerable<Turma> Turmas { get; set; }
    }
}
