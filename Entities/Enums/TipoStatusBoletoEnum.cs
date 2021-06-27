using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entities.Enums
{
    public enum TipoStatusBoletoEnum
    {
        [Description("Em Aberto")]
        EmAberto = 1,
        [Description("Baixado")]
        Baixado = 2,
        [Description("Liquidado")]
        Liquidado = 3,
        [Description("Negativado")]
        Negativado = 4,
        [Description("Outro")]
        Outro = 9,
    }
}
