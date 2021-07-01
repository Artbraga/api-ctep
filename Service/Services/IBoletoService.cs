using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Filters;
using Services.Base;

namespace Services.Services
{
    public interface IBoletoService : IBaseService<Boleto>
    {
        FilterResultDTO<BoletoDTO> FiltrarBoletos(BoletoFilter filtro);
        bool AlterarStatusBoleto(BoletoDTO boleto);
    }
}
