using Entities.Entities;
using Repositories.Base;

namespace Repositories.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario BuscarUsuarioPorLoginESenha(string login, string senha);
    }
}
