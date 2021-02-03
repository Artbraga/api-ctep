using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
namespace Repositories.Impl.Repositories
{
    public class RegistroAlunoRepository : BaseRepository<RegistroAluno>, IRegistroAlunoRepository
    {
        public RegistroAlunoRepository(DbContext context) : base(context)
        {
        }
    }
}
