using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Filters;
using Services.Base;
using System.Collections.Generic;
using System.IO;

namespace Services.Services
{
    public interface IRetornoService : IBaseService<Retorno>
    {
        FilterResultDTO<RetornoDTO> FiltrarRetornos(IPageFilter filter);
        RetornoDTO LerArquivo(Stream arquivo);
    }
}
