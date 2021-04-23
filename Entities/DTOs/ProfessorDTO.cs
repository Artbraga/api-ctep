using Entities.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProfessorDTO : BaseDTO<Professor>
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
        public string Formacao { get; set; }
        public bool FlagExclusao { get; set; }

        public ProfessorDTO()
        {
        }

        public ProfessorDTO(Professor entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.CPF = entity.CPF;
            this.RG = entity.RG;
            this.Endereco = entity.Endereco;
            this.Bairro = entity.Bairro;
            this.Cidade = entity.Cidade;
            this.Complemento = entity.Complemento;
            this.CEP = entity.CEP;
            this.Telefone = entity.Telefone;
            this.Celular = entity.Celular;
            this.Email = entity.Email;
            this.Formacao = entity.Formacao;
            this.FlagExclusao = entity.FlagExclusao;
        }

        public override Professor ToEntity()
        {
            return new Professor()
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Nome = this.Nome,
                CPF = this.CPF,
                RG = this.RG,
                Endereco = this.Endereco,
                Bairro = this.Bairro,
                Cidade = this.Cidade,
                Complemento = this.Complemento,
                CEP = this.CEP,
                Telefone = this.Telefone,
                Celular = this.Celular,
                Email = this.Email
            };
        }
    }
}
