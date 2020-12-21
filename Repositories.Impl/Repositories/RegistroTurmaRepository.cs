using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
namespace Repositories.Impl.Repositories
{
    public class RegistroTurmaRepository : BaseRepository<RegistroTurma>, IRegistroTurmaRepository
    {
        public RegistroTurmaRepository(DbContext context) : base(context)
        {
        }
    }
}
