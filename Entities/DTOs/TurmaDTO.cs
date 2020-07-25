using Entities.Base;
using Entities.Entities;
using Entities.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TurmaDTO : BaseDTO<Turma>
    {
        public string Codigo { get; set; }
        public string DiasDaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public int AnoInicio { get; set; }
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public CursoDTO Curso { get; set; }
        
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
            this.AnoInicio = entity.AnoInicio;
            this.DataInicio = entity.DataInicio;
            this.DataFim = entity.DataFim;
            this.Curso = entity.Curso == null ? null : new CursoDTO(entity.Curso);
        }

        public override Turma ToEntity()
        {
            return new Turma
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Codigo = this.Codigo,
                DiasDaSemana = this.DiasDaSemana,
                //HoraFim = this.HoraFim,
                //HoraInicio = this.HoraInicio,
                AnoInicio = this.AnoInicio,
                DataInicio = this.DataInicio,
                DataFim = this.DataFim,
                CursoId = this.Curso.Id.HasValue ? this.Curso.Id.Value : 0,
            };
        }
    }
}
