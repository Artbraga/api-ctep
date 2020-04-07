using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Turma : BaseEntity
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string DiasDaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public int AnoInicio { get; set; }
        public int Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
    }
}