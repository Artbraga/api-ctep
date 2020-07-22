using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class TurmaAluno : BaseEntity
    {
        public string Matricula { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string CodigoConlusaoSistec { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
