using System;

namespace Entities.Filters
{
    public class TurmaFilter
    {
        public string Codigo { get; set; }
        public DateTime? AnoInicio { get; set; }
        public int? CursoId { get; set; }
        public bool Concluidas { get; set; }
    }
}
