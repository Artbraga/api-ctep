using Entities.Base;
using Entities.DTOs;
using Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class FinanceiroController : Controller
    {
        private readonly IBoletoService boletoService;

        public FinanceiroController(IBoletoService boletoService)
        {
            this.boletoService = boletoService;
        }

        [HttpPost]
        public FilterResultDTO<BoletoDTO> FiltrarBoletos(BoletoFilter filter)
        {
            return boletoService.FiltrarBoletos(filter);
        }
    }
}
