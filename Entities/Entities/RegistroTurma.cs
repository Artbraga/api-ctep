using System;

namespace Entities.Entities
{
    public class RegistroTurma : BaseEntity
    {
        public DateTime Data { get; set; }
        public string Registro { get; set; }
        public int TurmaId { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
