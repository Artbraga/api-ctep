using System.ComponentModel;

namespace Entities.Enums
{
    public enum TipoStatusAlunoEnum
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Concluído")]
        Concluido = 2,
        [Description("Trancado")]
        Trancado = 3,
        [Description("Abandono")]
        Abandono = 4
    }
}
