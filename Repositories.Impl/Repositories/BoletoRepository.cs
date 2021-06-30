using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Impl.Repositories
{
    public class BoletoRepository : BaseRepository<Boleto>, IBoletoRepository
    {
        public BoletoRepository(DbContext context) : base(context)
        {
        }
    }
}
