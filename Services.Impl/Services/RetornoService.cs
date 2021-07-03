using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Enums;
using Entities.Filters;
using Entities.Util;
using log4net;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.Impl.Services
{
    public class RetornoService : BaseService<Retorno>, IRetornoService
    {
        private readonly IRetornoRepository retornoRepository;

        private static readonly ILog log = LogManager.GetLogger(typeof(RetornoService));
        public RetornoService(IRetornoRepository retornoRepository) : base(retornoRepository)
        {
            this.retornoRepository = retornoRepository;
        }

        public FilterResultDTO<RetornoDTO> FiltrarRetornos(IPageFilter filter)
        {
            try
            {
                IEnumerable<Retorno> retornos = retornoRepository.FiltrarRetornos(filter, true);
                var retorno = new FilterResultDTO<RetornoDTO>
                {
                    Total = filter.Total,
                    Pagina = filter.Pagina,
                    TamanhoPagina = filter.TamanhoPagina,
                    Lista = retornos.Select(x => new RetornoDTO(x))
                };
                return retorno;
            }
            catch (Exception e)
            {
                log.Error("Erro ao buscar retornos.", e);
                throw new Exception("Erro ao buscar retornos.");
            }
        }

        public RetornoDTO LerArquivo(Stream arquivo)
        {
            var boletos = new List<BoletoDTO>();
            RetornoDTO retorno;
            try
            {
                using (StreamReader arquivoRetorno = new StreamReader(arquivo, System.Text.Encoding.UTF8))
                {
                    var registro = arquivoRetorno.ReadLine();
                    var tipoArquivo = registro.Substring(142, 1);
                    if (tipoArquivo == "1") // Remessa
                    {
                        //REGISTRO HEADER DO ARQUIVO RETORNO
                        retorno = LerHeaderRemessa(registro);
                        registro = arquivoRetorno.ReadLine();
                        retorno.Numero = registro.Substring(185, 6);
                    }
                    else // Retorno
                    {
                        retorno = LerHeaderRetorno(registro);
                    }
                    while (!arquivoRetorno.EndOfStream)
                    {
                        registro = arquivoRetorno.ReadLine();
                        var tipoRegistro = registro.Substring(7, 1);

                        if (tipoRegistro == "3")
                        {
                            var tipoSegmento = registro.Substring(13, 1);
                            if (tipoSegmento == "T")
                            {
                                var boleto = LerDetalheSegmentoT(registro);
                                boletos.Add(boleto);
                            }
                            else if (tipoSegmento == "U")
                            {
                                var boleto = boletos.LastOrDefault();
                                LerDetalheSegmentoU(ref boleto, registro);
                            }
                            else if (tipoSegmento == "P")
                            {
                                var boleto = LerDetalheSegmentoP(registro);
                                if (boleto != null) boletos.Add(boleto);
                            }
                            else if (tipoSegmento == "Q")
                            {
                                var boleto = boletos.LastOrDefault();
                                LerDetalheSegmentoU(ref boleto, registro);
                            }
                            else if (tipoSegmento == "R")
                            {
                                var boleto = boletos.LastOrDefault();
                                LerDetalheSegmentoU(ref boleto, registro);
                            }
                        }
                    }
                }
                retorno.Movimentacoes = boletos;
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler arquivo.", ex);
            }
        }

        #region Leitura do arquivo 
        public RetornoDTO LerHeaderRetorno(string registro)
        {
            var retorno = new RetornoDTO();
            retorno.DataLeitura = DateTime.Now;
            retorno.DataReferencia = LerData(registro.Substring(143, 8));
            retorno.Numero = registro.Substring(157, 6);
            retorno.Tipo = "Retorno";
            return retorno;
        }

        public RetornoDTO LerHeaderRemessa(string registro)
        {
            var retorno = new RetornoDTO();
            retorno.DataLeitura = DateTime.Now;
            retorno.DataReferencia = LerData(registro.Substring(143, 8));
            retorno.Tipo = "Remessa";
            return retorno;
        }
        public BoletoDTO LerDetalheSegmentoP(string registro)
        {
            try
            {
                var boleto = new BoletoDTO();
                boleto.NossoNumero = registro.Substring(37, 20).Trim();
                var ocorrencia = registro.Substring(15, 2);
                switch (ocorrencia)
                {
                    case "01": // Criação 
                        boleto.Status = TipoStatusBoletoEnum.EmAberto.GetDescription();
                        break;
                    default:
                        log.Info("Tipo de movimentação desconhecido.");
                        return null;
                }

                boleto.NossoNumero = registro.Substring(37, 20).Trim();
                boleto.SeuNumero = registro.Substring(62, 15).Trim();
                boleto.DataVencimento = LerData(registro.Substring(77, 8));
                boleto.Valor = Convert.ToSingle(registro.Substring(85, 13)) / 100;
                boleto.DataEmissao = LerData(registro.Substring(109, 8));
                boleto.ValorJuros = Convert.ToSingle(registro.Substring(126, 13)) / 100;

                return boleto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler detalhe do arquivo de RETORNO / CNAB 240 / P.", ex);
            }
        }

        public void LerDetalheSegmentoQ(ref BoletoDTO boleto, string registro)
        {
            boleto.NomeAluno = registro.Substring(33, 40).Trim();
        }

        public void LerDetalheSegmentoR(ref BoletoDTO boleto, string registro)
        {
            boleto.PercentualMulta = Convert.ToSingle(registro.Substring(74, 13)) / 100;
        }

        public BoletoDTO LerDetalheSegmentoT(string registro)
        {
            try
            {
                var boleto = new BoletoDTO();
                boleto.SeuNumero = registro.Substring(58, 15).Trim();

                return boleto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler detalhe do arquivo de RETORNO / CNAB 240 / T.", ex);
            }
        }

        public void LerDetalheSegmentoU(ref BoletoDTO boleto, string registro)
        {
            try
            {
                var ocorrencia = registro.Substring(15, 2);
                switch (ocorrencia)
                {
                    case "06": // Liquidação 
                        boleto.ValorPago = Convert.ToSingle(registro.Substring(77, 15)) / 100;
                        boleto.DataPagamento = LerData(registro.Substring(137, 8));
                        boleto.Status = TipoStatusBoletoEnum.Liquidado.GetDescription();
                        break;
                    case "09": // Baixa 
                        boleto.DataPagamento = LerData(registro.Substring(137, 8));
                        boleto.Status = TipoStatusBoletoEnum.Baixado.GetDescription();
                        break;
                    default:
                        log.Info("Tipo de movimentação desconhecido.");
                        return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler detalhe do arquivo de RETORNO / CNAB 240 / U.", ex);
            }
        }

        private DateTime LerData(string s)
        {
            return new DateTime(int.Parse(s.Substring(4, 4)), int.Parse(s.Substring(2, 2)), int.Parse(s.Substring(0, 2)));
        }
        #endregion

        public override BaseDTO<Retorno> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
