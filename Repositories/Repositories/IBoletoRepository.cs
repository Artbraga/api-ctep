using Entities.Entities;
using Entities.Filters;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public interface IBoletoRepository : IBaseRepository<Boleto>
    {
        IEnumerable<Boleto> FiltrarBoletos(BoletoFilter filter, bool paginar = false);
    }
}
