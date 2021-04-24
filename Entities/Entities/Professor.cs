
using System.Collections.Generic;

namespace Entities.Entities
{
    public class Professor : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public virtual IEnumerable<TurmaProfessor> TurmasProfessor { get; set; }
        public virtual IEnumerable<NotaAluno> NotasAluno { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
