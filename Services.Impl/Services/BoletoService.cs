using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Filters;
using log4net;
using Repositories.Base;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Impl.Services
{
    public class BoletoService : BaseService<Boleto>, IBoletoService
    {
        private readonly IBoletoRepository boletoRepository;

        private static readonly ILog log = LogManager.GetLogger(typeof(BoletoService));
        public BoletoService(IBoletoRepository boletoRepository) : base(boletoRepository)
        {
            this.boletoRepository = boletoRepository;
        }

        public FilterResultDTO<BoletoDTO> FiltrarBoletos(BoletoFilter filtro)
        {
            try
            {
                IEnumerable<Boleto> boletos = boletoRepository.FiltrarBoletos(filtro, true);
                var retorno = new FilterResultDTO<BoletoDTO>
                {
                    Total = filtro.Total,
                    Pagina = filtro.Pagina,
                    TamanhoPagina = filtro.TamanhoPagina,
                    Lista = boletos.Select(x => new BoletoDTO(x))
                };
                return retorno;
            }
            catch (Exception e)
            {
                log.Error("Erro ao buscar boletos.", e);
                throw new Exception("Erro ao buscar boletos.");
            }
        }

        public override BaseDTO<Boleto> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
