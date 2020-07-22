using System;

namespace Entities.Entities
{
    public class RegistroAluno : BaseEntity
    {
        public DateTime Data { get; set; }
        public string Registro { get; set; }
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}
