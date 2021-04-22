using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string OrgaoEmissor { get; set; }
        public char Sexo { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CursoAnterior { get; set; }
        public DateTime DataMatricula { get; set; }
        public DateTime? DataValidade{ get; set; }
        public DateTime DataNascimento{ get; set; }
        public virtual IEnumerable<TurmaAluno> TurmasAluno { get; set; }
        public virtual IEnumerable<NotaAluno> NotasAluno { get; set; }
        public virtual IEnumerable<RegistroAluno> Registros { get; set; }
    }
}
