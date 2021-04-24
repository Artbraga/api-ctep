using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Impl.Repositories
{
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(DbContext context) : base(context)
        {
        }
        
        public IEnumerable<Perfil> BuscarPerfisComUsuarios()
        {
            var query = Query();
            query = query.Include(x => x.Usuarios)
                        .Include(x => x.PerfisPermissao).ThenInclude(y => y.Permissao);
            

            return query;
        }
    }
}
