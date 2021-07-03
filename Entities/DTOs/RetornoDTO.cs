using Entities.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.DTOs
{
    public class RetornoDTO : BaseDTO<Retorno>
    {
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public DateTime DataReferencia { get; set; }
        public DateTime DataLeitura { get; set; }
        public IEnumerable<RegistroRetornoDTO> Registros { get; set; }
        public IEnumerable<BoletoDTO> Movimentacoes { get; set; }

        public RetornoDTO()
        {
        }

        public RetornoDTO(Retorno entity) : base(entity)
        {
            this.Numero = entity.Numero;
            this.Tipo = Tipo;
            this.DataLeitura = entity.DataLeitura;
            this.DataReferencia = entity.DataReferencia;
            this.Registros = entity.Registros.Select(x => new RegistroRetornoDTO(x));
        }

        public override Retorno ToEntity()
        {
            return new Retorno()
            {
                Numero = this.Numero,
                Tipo = this.Tipo,
                DataLeitura = this.DataLeitura,
                DataReferencia = this.DataReferencia,
                Registros = this.Registros.Select(x => x.ToEntity())
            };
        }
    }
}
