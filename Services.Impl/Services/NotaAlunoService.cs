using Entities.Base;
using Entities.Entities;
using Repositories.Base;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Impl.Services
{
    public class NotaAlunoService : BaseService<NotaAluno>, INotaAlunoService
    {
        private readonly INotaAlunoRepository notaAlunoRepository;
        public NotaAlunoService(INotaAlunoRepository notaAlunoRepository) : base(notaAlunoRepository)
        {
            this.notaAlunoRepository = notaAlunoRepository;
        }

        public override BaseDTO<NotaAluno> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
