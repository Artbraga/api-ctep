using CTEP.Repositories.Impl.Context;
using Entities.DTOs;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using TinyCsvParser;

namespace AssistantOperations.Boletos
{
    public class BoletoExtractor
    {
        public static void Run()
        {
            DbContext context = new CtepContext(ConfigurationManager.AppSettings["connectionString"]);
            AlunoRepository alunoRepository = new AlunoRepository(context);
            BoletoRepository boletoRepository = new BoletoRepository(context);

            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ';');
            var csvParser = new CsvParser<BoletoDTO>(csvParserOptions, new CsvBoletoMapping());

            var linhas = csvParser.ReadFromFile(ConfigurationManager.AppSettings["planilhaBoletos"], Encoding.UTF8);

            var boletos = linhas.Select(x => x.Result).ToList();
            Console.WriteLine($"{boletos.Count} extraídos.");

            var alunos = alunoRepository.All().ToList().Select(x => new 
            {
                Nome = RemoveDiacritics(x.Nome),
                Aluno = x
            });

            using (var transaction = boletoRepository.GetTransaction())
            {
                var boletosSalvos = boletoRepository.All().ToList();
                var boletosAgrupados = boletos.GroupBy(x => x.NomeAluno);
                boletosAgrupados.ToList().ForEach(x =>
                {
                    var aluno = alunos.FirstOrDefault(a => a.Nome.ToUpper().Normalize(NormalizationForm.FormD) == x.Key.ToUpper().Normalize(NormalizationForm.FormD));
                    if (aluno != null)
                    {
                        Console.WriteLine($"Boletos do aluno {aluno.Aluno.Nome} encontrados ({x.ToList().Count}).");
                        var boletosParaInserir = x.ToList().Where(x => !boletosSalvos.Any(y => y.SeuNumero == x.SeuNumero)).Select(x =>
                        {
                            var b = x.ToEntity();
                            b.AlunoId = aluno.Aluno.Id;
                            b.TipoStatusBoletoId = (int)GetStatusBoleto(x.Status);
                            if (b.TipoStatusBoletoId != (int)TipoStatusBoletoEnum.Liquidado)
                            {
                                b.ValorPago = null;
                            }
                            b.PercentualMulta = 5;
                            return b;
                        });

                        boletoRepository.BulkAdd(boletosParaInserir);
                        boletoRepository.SaveChanges();
                        Console.WriteLine($"{boletosParaInserir.Count()} boletos inseridos.");
                    }
                });
                transaction.Commit();
                transaction.Dispose();
            }
        }

        private static TipoStatusBoletoEnum GetStatusBoleto(string status)
        {
            switch (status)
            {
                case "Registrado (em ser)": return TipoStatusBoletoEnum.EmAberto;
                case "Baixado": return TipoStatusBoletoEnum.Baixado;
                case "Liquidado": return TipoStatusBoletoEnum.Liquidado;
                default: return TipoStatusBoletoEnum.Outro;
            }
        }

        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
