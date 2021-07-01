using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Filters
{
    public class BoletoFilter : IPageFilter
    {
        private readonly int _tamanhoPagina = 50;

        public DateTime? DataVencimentoDe { get; set; }
        public DateTime? DataVencimentoAte { get; set; }
        public IEnumerable<int> StatusId { get; set; }
        public string Nome { get; set; }
        public int Pagina { get; set; }
        public int Total { get; set; }
        public int TamanhoPagina { get => this._tamanhoPagina; }
    }
}
