using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Filters
{
    public class AlunoFilter : IPageFilter
    {
        private readonly int _tamanhoPagina = 50;

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CodigoTurma { get; set; }
        public int? CursoId { get; set; }
        public string Matricula { get; set; }
        public IEnumerable<int> SituacaoId { get; set; }
        public int Pagina { get; set; }
        public int Total { get; set; }
        public int TamanhoPagina { get => this._tamanhoPagina; }
    }
}
