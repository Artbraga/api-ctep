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
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string DiasDaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public int AnoInicio { get; set; }
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public CursoDTO Curso { get; set; }
        
        public TurmaDTO()
        {
        }

        public TurmaDTO(Turma entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Codigo = entity.Codigo;
            this.DiasDaSemana = entity.DiasDaSemana;
            this.HoraFim = entity.HoraFim;
            this.HoraInicio = entity.HoraInicio;
            this.AnoInicio = entity.AnoInicio;
            this.DataInicio = entity.DataInicio;
            this.DataFim = entity.DataFim;
            this.Status = ((StatusTurma)entity.Status).GetDescription();
            this.Curso = entity.Curso == null ? null : new CursoDTO(entity.Curso);
        }

        public override Turma ToEntity()
        {
            return new Turma
            {
                Id = this.Id,
                Nome = this.Nome,
                Codigo = this.Codigo,
                DiasDaSemana = this.DiasDaSemana,
                HoraFim = this.HoraFim,
                HoraInicio = this.HoraInicio,
                AnoInicio = this.AnoInicio,
                DataInicio = this.DataInicio,
                DataFim = this.DataFim,
                Status = (int)EnumExtensions.GetEnumValue<StatusTurma>(this.Status),
                CursoId = this.Curso.Id
            };
        }
    }
}
