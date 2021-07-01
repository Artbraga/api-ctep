using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Util;
using Entities.Enums;
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
using Entities.Exceptions;

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

        public bool AlterarStatusBoleto(BoletoDTO boleto)
        {
            log.Info($"Alteração de status do boleto nº {boleto.SeuNumero}");
            var boletoSalvo = boletoRepository.BuscarBoletoPorNumero(boleto.SeuNumero);
            if (boletoSalvo != null)
            {
                if (boleto.Status == TipoStatusBoletoEnum.Liquidado.GetDescription())
                {
                    if (!boleto.ValorPago.HasValue)
                    {
                        log.Error("Para liquidação de boleto o valor pago é obrigatório.");
                        throw new BusinessException("Para liquidação de boleto o valor pago é obrigatório.");
                    }
                    if (!boleto.DataPagamento.HasValue)
                    {
                        log.Error("Para liquidação de boleto a data do pagamento é obrigatória.");
                        throw new BusinessException("Para liquidação de boleto a data do pagamento é obrigatória.");
                    }
                    boletoSalvo.TipoStatusBoletoId = (int)TipoStatusBoletoEnum.Liquidado;
                    boletoSalvo.DataPagamento = boleto.DataPagamento;
                    boletoSalvo.ValorPago = boleto.ValorPago;
                }
                else if (boleto.Status == TipoStatusBoletoEnum.Baixado.GetDescription())
                {
                    if (boletoSalvo.TipoStatusBoletoId == (int)TipoStatusBoletoEnum.Liquidado)
                    {
                        log.Info("O boleto já possui o status Liquidado, não será alterado.");
                        return false;
                    }
                    boletoSalvo.TipoStatusBoletoId = (int)TipoStatusBoletoEnum.Baixado;
                    boletoSalvo.DataPagamento = boleto.DataPagamento;
                }
                else if (boleto.Status == TipoStatusBoletoEnum.Negativado.GetDescription())
                {
                    if (boletoSalvo.TipoStatusBoletoId == (int)TipoStatusBoletoEnum.Liquidado)
                    {
                        log.Info("O boleto já possui o status Liquidado, não será alterado.");
                        return false;
                    }
                    boletoSalvo.TipoStatusBoletoId = (int)TipoStatusBoletoEnum.Negativado;
                    boletoSalvo.DataPagamento = null;
                }
                boletoRepository.SaveChanges();
                return true;
            }
            else
            {
                log.Info($"Boleto nº {boleto.SeuNumero} não encontrado.");
                return false;
            }
        }

        public override BaseDTO<Boleto> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
