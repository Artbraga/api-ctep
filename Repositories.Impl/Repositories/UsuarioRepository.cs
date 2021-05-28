using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System.Collections.Generic;
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
            var query = IncludeCompleto();
            
            query = query.Where(x => x.Login == login && x.Senha == senha);

            return query.ToList().FirstOrDefault();
        }

        public override Usuario GetById(int id)
        {
            var query = IncludeCompleto();
            return query.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Usuario> ListarUsuarios()
        {
            var query = Query().Include(x => x.Perfil);

            return query.ToList();
        }

        public bool VerificaLoginUnico(string login)
        {
            var query = Query();
            return query.Any(x => x.Login.ToLower().Equals(login.ToLower()));
        }

        private IQueryable<Usuario> IncludeCompleto()
        {
            var query = Query();
            query = query
                .Include(x => x.Perfil).ThenInclude(y => y.PerfisPermissao).ThenInclude(x => x.Permissao)
                .Include(x => x.Perfil).ThenInclude(y => y.Usuarios.Where((z) => false))
                .Include(x => x.Aluno)
                .Include(x => x.Professor)
                .AsQueryable();
            return query;
        }
    }
}
