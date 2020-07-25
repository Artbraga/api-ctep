using Entities.Base;
using Entities.Entities;

namespace Entities.DTOs
{
    public class CursoDTO : BaseDTO<Curso>
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string SiglaTurma { get; set; }
        public bool Especializacao { get; set; }
        public int? CursoVinculadoId { get; set; }
        public CursoDTO CursoVinculado { get; set; }

        public CursoDTO()
        {
        }

        public CursoDTO(Curso entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Sigla = entity.Sigla;
            this.SiglaTurma = entity.SiglaTurma;
            this.Especializacao = entity.Especializacao;
            this.CursoVinculadoId = entity.CursoVinculadoId;
        }

        public override Curso ToEntity()
        {
            return new Curso
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Sigla = this.Sigla,
                SiglaTurma = this.SiglaTurma,
                Especializacao = this.Especializacao,
                CursoVinculadoId = this.CursoVinculadoId
            };
        }
    }
}
