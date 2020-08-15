using Entities.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.DTOs
{
    public class AlunoDTO : BaseDTO<Aluno>
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
        public bool NotaFiscal { get; set; }
        public DateTime DataMatricula { get; set; }
        public DateTime? DataValidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TipoStatusAluno { get; set; }

        public IEnumerable<TurmaAlunoDTO> TurmasAluno { get; set; }

        public AlunoDTO()
        {
        }

        public AlunoDTO(Aluno entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.CPF = entity.CPF;
            this.RG = entity.RG;
            this.OrgaoEmissor = entity.OrgaoEmissor;
            this.Sexo = entity.Sexo;
            this.NomePai = entity.NomePai;
            this.NomeMae = entity.NomeMae;
            this.Endereco = entity.Endereco;
            this.CEP = entity.CEP;
            this.Bairro = entity.Bairro;
            this.Cidade = entity.Cidade;
            this.Complemento = entity.Complemento;
            this.DataMatricula = entity.DataMatricula;
            this.DataNascimento = entity.DataNascimento;
            this.DataValidade = entity.DataValidade;
            this.Telefone = entity.Telefone;
            this.Celular = entity.Celular;
            this.Email = entity.Email;
            this.CursoAnterior = entity.CursoAnterior;
            this.NotaFiscal = entity.NotaFiscal;
            this.TipoStatusAluno = entity.TipoStatusAluno.Nome;
            this.TurmasAluno = entity.TurmasAluno == null ? null : entity.TurmasAluno.Select(x => new TurmaAlunoDTO(x));
        }

        public override Aluno ToEntity()
        {
            return new Aluno()
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Nome = this.Nome,
                CPF = this.CPF,
                RG = this.RG,
                OrgaoEmissor = this.OrgaoEmissor,
                Sexo = this.Sexo,
                NomePai = this.NomePai,
                NomeMae = this.NomeMae,
                Endereco = this.Endereco,
                CEP = this.CEP,
                Bairro = this.Bairro,
                Cidade = this.Cidade,
                Complemento = this.Complemento,
                DataMatricula = this.DataMatricula,
                DataNascimento = this.DataNascimento,
                DataValidade = this.DataValidade,
                Telefone = this.Telefone,
                Celular = this.Celular,
                Email = this.Email,
                CursoAnterior = this.CursoAnterior,
                NotaFiscal = this.NotaFiscal,
            };
        }
    }
}
