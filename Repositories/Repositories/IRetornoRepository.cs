using Entities.Entities;
using Entities.Filters;
using Repositories.Base;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface IRetornoRepository : IBaseRepository<Retorno>
    {
        IEnumerable<Retorno> FiltrarRetornos(IPageFilter filter, bool paginar = false);
    }
}
