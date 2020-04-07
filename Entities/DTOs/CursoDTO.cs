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
        public int CursoVinculadoId { get; set; }
        public CursoDTO CursoVinculado { get; set; }

        public CursoDTO()
        {
        }

        public CursoDTO(Curso entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Sigla = entity.Sigla;
            this.SiglaTurma = entity.SiglaTurma;
            this.Especializacao = entity.Especializacao;
            this.CursoVinculadoId = entity.CursoVinculadoId;
            this.CursoVinculado = entity.CursoVinculado == null ? null : new CursoDTO(entity.CursoVinculado);
        }

        public override Curso ToEntity()
        {
            return new Curso
            {
                Id = this.Id,
                Sigla = this.Sigla,
                SiglaTurma = this.SiglaTurma,
                Especializacao = this.Especializacao,
                CursoVinculadoId =this.CursoVinculadoId
            };
        }
    }
}
