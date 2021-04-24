using Entities.Entities;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public interface IPerfilRepository : IBaseRepository<Perfil>
    {
        IEnumerable<Perfil> BuscarPerfisComUsuarios();
    }
}
