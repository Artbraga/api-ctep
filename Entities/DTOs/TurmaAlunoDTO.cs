using Entities.Base;
using Entities.Entities;
using System;

namespace Entities.DTOs
{
    public class TurmaAlunoDTO : BaseDTO<TurmaAluno>
    {
        public string Matricula { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string CodigoConlusaoSistec { get; set; }
        public int AlunoId { get; set; }
        public TurmaDTO Turma { get; set; }

        public TurmaAlunoDTO()
        {
        }

        public TurmaAlunoDTO(TurmaAluno entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Matricula = entity.Matricula;
            this.DataConclusao = entity.DataConclusao;
            this.CodigoConlusaoSistec = entity.CodigoConlusaoSistec;
            this.Turma = new TurmaDTO(entity.Turma);
        }

        public override TurmaAluno ToEntity()
        {
            return new TurmaAluno()
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Matricula = this.Matricula,
                DataConclusao = this.DataConclusao,
                CodigoConlusaoSistec = this.CodigoConlusaoSistec,
                AlunoId = this.AlunoId
            };
        }
    }
}
