using Entities.DTOs;
using Entities.Entities;
using Services.Base;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        IEnumerable<UsuarioDTO> ListarUsuarios();
    }
}
