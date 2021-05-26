using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AlunoNotasDTO
    {
        public int AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public string Matricula { get; set; }
        public IEnumerable<NotaAlunoDTO> Notas { get; set; }
    }
}
