using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Filters
{
    public class AlunoFilter
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CodigoTurma { get; set; }
        public int? CursoId { get; set; }
        public string Matricula { get; set; }
        public IEnumerable<int> SituacaoId { get; set; }
    }
}
