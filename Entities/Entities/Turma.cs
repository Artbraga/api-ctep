using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class Turma : BaseEntity
    {
        public string Codigo { get; set; }
        public string DiasDaSemana { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public int TipoStatusTurmaId { get; set; }
        public virtual TipoStatusTurma TipoStatusTurma { get; set; }
        public virtual IEnumerable<TurmaAluno> TurmasAluno { get; set; }
        public virtual IEnumerable<TurmaProfessor> TurmasProfessor { get; set; }
        public virtual IEnumerable<RegistroTurma> Registros { get; set; }
    }
}