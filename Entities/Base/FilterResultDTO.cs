using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Base
{
    public class FilterResultDTO<T> where T : BaseDTO
    {
        public int Total { get; set; }
        public int TamanhoPagina { get; set; }
        public int Pagina { get; set; }
        public IEnumerable<T> Lista { get; set; }
    }
}
