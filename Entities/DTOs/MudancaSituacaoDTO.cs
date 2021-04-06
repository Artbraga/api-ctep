using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MudancaSituacaoDTO
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public int SituacaoId { get; set; }
        public string Registro { get; set; }
        public string CodigoSistec { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
