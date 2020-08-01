using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System.Linq;

namespace Repositories.Impl.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {

        }
        public Usuario BuscarUsuarioPorLoginESenha(string login, string senha)
        {
            var query = Query();
            
            return query.Where(x => x.Login == login && x.Senha == senha).FirstOrDefault();
        }
    }
}
