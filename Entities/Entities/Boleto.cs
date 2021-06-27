using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Boleto : BaseEntity
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
        public int AlunoId { get; set; }
        public int TipoStatusBoletoId { get; set; }
        public virtual Aluno Aluno{ get; set; }
        public virtual TipoStatusBoleto TipoStatusBoleto{ get; set; }

    }
}
