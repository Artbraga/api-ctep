using Entities.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BoletoDTO : BaseDTO<Boleto>
    {
        public string SeuNumero { get; set; }
        public string NossoNumero { get; set; }
        public DateTime DataVencimento { get; set; }
        public float Valor { get; set; }
        public DateTime? DataEmissao { get; set; }
        public DateTime? DataPagamento { get; set; }
        public float? ValorPago { get; set; }
        public float? ValorJuros { get; set; }
        public float? PercentualMulta { get; set; }
        public string Status { get; set; }
        public string NomeAluno { get; set; }
        public AlunoDTO Aluno { get; set; }

        public BoletoDTO()
        {
        }

        public BoletoDTO(Boleto entity) : base(entity)
        {
            this.Id = entity.Id;
            this.SeuNumero = entity.SeuNumero;
            this.NossoNumero = entity.NossoNumero;
            this.DataVencimento = entity.DataVencimento;
            this.Valor = entity.Valor;
            this.DataEmissao = entity.DataEmissao;
            this.DataPagamento = entity.DataPagamento;
            this.ValorJuros = entity.ValorJuros;
            this.PercentualMulta = entity.PercentualMulta;
            this.ValorPago = entity.ValorPago;
            this.Status = entity.TipoStatusBoleto.Nome;
            this.Aluno = entity.Aluno != null ?  new AlunoDTO(entity.Aluno) : null;
        }

        public override Boleto ToEntity()
        {
            return new Boleto()
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                SeuNumero = this.SeuNumero,
                NossoNumero = this.NossoNumero,
                DataVencimento = this.DataVencimento,
                Valor = this.Valor,
                DataEmissao = this.DataEmissao,
                DataPagamento = this.DataPagamento,
                ValorJuros = this.ValorJuros,
                ValorPago = this.ValorPago,
            };
        }
    }
}
