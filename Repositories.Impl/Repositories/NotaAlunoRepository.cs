using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Impl.Repositories
{
    public class NotaAlunoRepository : BaseRepository<NotaAluno>, INotaAlunoRepository
    {
        public NotaAlunoRepository(DbContext context) : base(context)
        {
        }
    }
}
