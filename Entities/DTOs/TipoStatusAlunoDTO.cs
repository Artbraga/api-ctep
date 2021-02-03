using Entities.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TipoStatusAlunoDTO : BaseDTO<TipoStatusAluno>
    {
        public string Nome { get; set; }
        public TipoStatusAlunoDTO()
        {
        }

        public TipoStatusAlunoDTO(TipoStatusAluno entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
        }

        public override TipoStatusAluno ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
