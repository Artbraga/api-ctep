using Entities.Entities;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        IEnumerable<Usuario> ListarUsuarios();
        Usuario BuscarUsuarioPorLoginESenha(string login, string senha);
        bool VerificaLoginUnico(string login);
    }
}
