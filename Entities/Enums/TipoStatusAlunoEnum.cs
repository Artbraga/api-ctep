using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entities.Enums
{
    public enum TipoStatusAlunoEnum
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Concluido")]
        Concluido = 2,
        [Description("Trancado")]
        Trancado = 3,
        [Description("Abandono")]
        Abandono = 4
    }
}
