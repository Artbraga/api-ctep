using Entities.Base;
using Entities.Entities;
using Entities.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Entities.DTOs
{
    public class TurmaDTO : BaseDTO<Turma>
    {
        public string Codigo { get; set; }
        public string DiasDaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public CursoDTO Curso { get; set; }
        public IEnumerable<RegistroTurmaDTO> Registros { get; set; }
        
        public TurmaDTO()
        {
        }

        public TurmaDTO(Turma entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Codigo = entity.Codigo;
            this.DiasDaSemana = entity.DiasDaSemana;
            this.HoraFim = entity.HoraFim.ToString();
            this.HoraInicio = entity.HoraInicio.ToString();
            this.DataInicio = entity.DataInicio;
            this.DataFim = entity.DataFim;
            this.Curso = entity.Curso == null ? null : new CursoDTO(entity.Curso);
            this.Registros = entity.Registros == null ?  null : entity.Registros.Select(x => new RegistroTurmaDTO(x));
        }

        public override Turma ToEntity()
        {
            return new Turma
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Codigo = this.Codigo,
                DiasDaSemana = this.DiasDaSemana,
                HoraInicio = TimeSpan.Parse(this.HoraInicio, CultureInfo.InvariantCulture),
                HoraFim = TimeSpan.Parse(this.HoraFim, CultureInfo.InvariantCulture),
                DataInicio = this.DataInicio,
                DataFim = this.DataFim,
                CursoId = this.Curso != null && this.Curso.Id.HasValue ? this.Curso.Id.Value : 0,
            };
        }
    }
}
