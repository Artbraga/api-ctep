using Entities.Base;
using Entities.DTOs;
using Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System.IO;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class FinanceiroController : Controller
    {
        private readonly IBoletoService boletoService;
        private readonly IRetornoService retornoService;

        public FinanceiroController(IBoletoService boletoService, IRetornoService retornoService)
        {
            this.boletoService = boletoService;
            this.retornoService = retornoService;
        }

        [HttpPost]
        public FilterResultDTO<BoletoDTO> FiltrarBoletos(BoletoFilter filter)
        {
            return boletoService.FiltrarBoletos(filter);
        }

        [HttpPost]
        public bool AlterarStatusBoleto(BoletoDTO boleto)
        {
            return boletoService.AlterarStatusBoleto(boleto);
        }

        [HttpPost, DisableRequestSizeLimit]
        public RetornoDTO LerArquivo()
        {
            var ms = new MemoryStream();
            Request.Form.Files[0].CopyTo(ms);
            ms.Flush();
            ms.Position = 0;
            
            var retorno = retornoService.LerArquivo(ms);
            ms.Dispose();
            return retorno;
        }
    }
}
