﻿using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.Replacing;
using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Enums;
using Entities.Exceptions;
using Entities.Filters;
using Entities.Util;
using log4net;
using Microsoft.Extensions.Configuration;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Services.Impl.Services
{
    public class AlunoService : BaseService<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository alunoRepository;
        private readonly IRegistroAlunoRepository registroAlunoRepository;
        private readonly ICursoRepository cursoRepository;
        private readonly ITurmaAlunoRepository turmaAlunoRepository;
        private readonly IDisciplinaRepository disciplinaRepository;
        private readonly INotaAlunoRepository notaAlunoRepository;
        private readonly IConfiguration configuration;

        private static readonly ILog log = LogManager.GetLogger(typeof(AlunoService));

        public AlunoService(IAlunoRepository alunoRepository,
                            IRegistroAlunoRepository registroAlunoRepository,
                            ICursoRepository cursoRepository,
                            ITurmaAlunoRepository turmaAlunoRepository,
                            IDisciplinaRepository disciplinaRepository,
                            INotaAlunoRepository notaAlunoRepository,
                            IConfiguration configuration) 
        : base(alunoRepository)
        {
            this.alunoRepository = alunoRepository;
            this.registroAlunoRepository = registroAlunoRepository;
            this.cursoRepository = cursoRepository;
            this.turmaAlunoRepository = turmaAlunoRepository;
            this.disciplinaRepository = disciplinaRepository;
            this.notaAlunoRepository = notaAlunoRepository;
            this.configuration = configuration;
        }

        public string GerarNumeroDeMatricula(int cursoId, int anoMatricula)
        {
            var curso = cursoRepository.GetById(cursoId);
            var trecho = $"{curso.Sigla}{anoMatricula % 100}";
            var numero = alunoRepository.BuscarNumeroDeMatriculasPorTrecho(trecho);
            string codigo;
            do
            {
                numero += 1;
                codigo = $"{trecho}{numero.ToString("D3")}";
            } while (alunoRepository.ExisteMatricula(codigo));

            return codigo;
        }

        public IEnumerable<AlunoNotasDTO> BuscarAlunosENotasDeTurma(int turmaId)
        {
            var alunosNotas = new List<AlunoNotasDTO>();
            var alunos = alunoRepository.BuscarAlunosENotasDeTurma(turmaId).ToList();
            alunos.ForEach(x =>
            {
                var turmaAluno = x.TurmasAluno.First(x => x.TurmaId == turmaId);
                var alN = new AlunoNotasDTO();
                alN.AlunoId = x.Id;
                alN.NomeAluno = x.Nome;
                alN.Matricula = turmaAluno.Matricula;
                alN.Notas = x.NotasAluno.Where(x => x.Disciplina.CursoId == turmaAluno.Turma.CursoId).Select(y => new NotaAlunoDTO(y));
                alunosNotas.Add(alN);
            });
            return alunosNotas;
        }

        public AlunoDTO SalvarAluno(AlunoDTO alunoDto)
        {
            var transaction = this.alunoRepository.GetTransaction();
            try
            {
                Aluno aluno;
                if (alunoDto.Id.HasValue)
                {
                    aluno = alunoRepository.GetById(alunoDto.Id.Value);
                    aluno.Nome = alunoDto.Nome;
                    aluno.RG = alunoDto.RG;
                    aluno.CPF = alunoDto.CPF;
                    aluno.OrgaoEmissor = alunoDto.OrgaoEmissor;
                    aluno.Sexo = alunoDto.Sexo;
                    aluno.Naturalidade = alunoDto.Naturalidade;
                    aluno.Naturalidade = alunoDto.Naturalidade;
                    aluno.NomePai = alunoDto.NomePai;
                    aluno.NomeMae = alunoDto.NomeMae;
                    aluno.Endereco = alunoDto.Endereco;
                    aluno.CEP = alunoDto.CEP;
                    aluno.Bairro = alunoDto.Bairro;
                    aluno.Cidade = alunoDto.Cidade;
                    aluno.Complemento = alunoDto.Complemento;
                    aluno.DataMatricula = alunoDto.DataMatricula;
                    aluno.DataNascimento = alunoDto.DataNascimento;
                    aluno.DataValidade = alunoDto.DataValidade;
                    aluno.Telefone = alunoDto.Telefone;
                    aluno.Celular = alunoDto.Celular;
                    aluno.Email = alunoDto.Email;
                    aluno.CursoAnterior = alunoDto.CursoAnterior;
                }
                else
                {
                    aluno = alunoDto.ToEntity();
                    aluno.TurmasAluno = new List<TurmaAluno>();
                    alunoRepository.Add(aluno);
                }
                alunoRepository.SaveChanges();

                transaction.Commit();
                transaction.Dispose();

                return new AlunoDTO(alunoRepository.GetById(aluno.Id));
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                transaction.Dispose();
                if (ex.InnerException.Message.Contains("cpf_UNIQUE"))
                {
                    throw new BusinessException("Já existe um aluno com o CPF cadastrado.");
                }
                log.Error("Erro ao salvar aluno.", ex);
                throw new BusinessException("Erro desconhecido ao salvar aluno.");
            }
        }

        public override BaseDTO<Aluno> GetById(int id)
        {
            var aluno = this.alunoRepository.GetById(id);

            return new AlunoDTO(aluno);
        }

        public bool ExcluirAluno(int id)
        {
            var aluno = this.alunoRepository.GetById(id);
            if (aluno.TurmasAluno.Any())
            {
                throw new BusinessException("Não é possível excluir um aluno vinculado em uma turma.");
            }
            alunoRepository.Delete(id);
            return true;
        }

        public FilterResultDTO<AlunoDTO> FiltrarAlunos(AlunoFilter filter)
        {
            try
            {
                IEnumerable<Aluno> alunos = alunoRepository.FiltrarAlunos(filter, true);
                var retorno = new FilterResultDTO<AlunoDTO>
                {
                    Total = filter.Total,
                    Pagina = filter.Pagina,
                    TamanhoPagina = filter.TamanhoPagina,
                    Lista = alunos.Select(x => new AlunoDTO(x))
                };
                return retorno;
            }
            catch(Exception e)
            {
                log.Error("Erro ao buscar alunos.", e);
                throw new Exception("Erro ao buscar alunos.");
            }
        }

        public FilterResultDTO<AlunoDTO> ListarAlunosPorVencimento(IPageFilter filter)
        {
            try
            {
                IEnumerable<Aluno> alunos = alunoRepository.ListarAlunosPorVencimento(filter);
                var retorno = new FilterResultDTO<AlunoDTO>
                {
                    Total = filter.Total,
                    Pagina = filter.Pagina,
                    TamanhoPagina = filter.TamanhoPagina,
                    Lista = alunos.Select(x => new AlunoDTO(x))
                };
                return retorno;
            }
            catch (Exception e)
            {
                log.Error("Erro ao buscar alunos por vencimento.", e);
                throw new Exception("Erro ao buscar alunos por vencimento.");
            }
        }

        #region Arquivos
        public byte[] ExportarPesquisa(AlunoFilter filter)
        {
            List<AlunoDTO> alunos = alunoRepository.FiltrarAlunos(filter).Select(x => new AlunoDTO(x)).ToList();
            #region Criação da tabela
            Workbook conteudoExcel = new Workbook
            {
                FileName = "exportação.xlsx"
            };
            conteudoExcel.Worksheets.RemoveAt(0);
            Worksheet sheet = conteudoExcel.Worksheets.Add("Alunos");
            string[] propertyNames =
            {
                /* 00 */ "Nome",
                /* 01 */ "CPF",
                /* 02 */ "Telefone",
                /* 03 */ "Celular",
                /* 04 */ "Matrículas",
                /* 05 */ "Turmas",
                /* 06 */ "Validade",
                /* 07 */ "Situação"
            };
            Aspose.Cells.Style styleDia = conteudoExcel.CreateStyle();
            styleDia.Custom = "dd/mm/yyyy";
            #endregion

            #region Preenchimento da tabela
            var contador = 1;
            alunos.ForEach(a =>
            {
                try
                {
                    var row = sheet.Cells.Rows[contador];
                    GravarValor(row, a.Nome, 0);
                    GravarValor(row, a.CPF, 1);
                    GravarValor(row, a.Telefone, 2);
                    GravarValor(row, a.Celular, 3);
                    GravarValor(row, string.Join(", ", a.TurmasAluno.Select(ta => ta.Matricula)), 4);
                    GravarValor(row, string.Join(", ", a.TurmasAluno.Select(ta => ta.Turma.Codigo)), 5);
                    GravarValor(row, a.DataValidade, 6, styleDia);
                    GravarValor(row, a.TipoStatusAluno, 7);
                    contador++;
                }
                catch (Exception e)
                {
                    log.Error($"Erro exportar pesquisa.", e);
                }

            });
            sheet.ListObjects.Add(0, 0, contador - 1, propertyNames.Length - 1, true);
            var header = sheet.Cells.Rows[0];
            for (int i = 0; i < propertyNames.Length; i++)
            {
                header[i].PutValue(propertyNames[i]);
            }
            sheet.AutoFitColumns();
            sheet.AutoFitRows();
            #endregion

            MemoryStream stream = new MemoryStream();
            conteudoExcel.Save(stream, Aspose.Cells.SaveFormat.Xlsx);
            stream.Seek(0, SeekOrigin.Begin);
            return stream.ToArray();

            void GravarValor(Row row, object dado, int indice, Aspose.Cells.Style style = null)
            {
                if (dado == null) dado = "";
                row[indice].PutValue(dado);
                if (style != null)
                {
                    row[indice].SetStyle(style);
                }
            }
        }

        public byte[] GerarCracha(int idTurmaAluno)
        {
            var turmaAluno = turmaAlunoRepository.GetById(idTurmaAluno);
            var aluno = alunoRepository.GetById(turmaAluno.AlunoId);
            Document doc = new Document(Path.Combine(ApplicationConstants.PastaDocumentos, ApplicationConstants.ArquivoCracha));
            turmaAluno = aluno.TurmasAluno.First(x => x.TurmaId == turmaAluno.TurmaId);
            try
            {
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
                string data = DateTime.Now.Day.ToString("00") + " de " + mes + " de " + DateTime.Now.Year;

                Dictionary<string, string> stringsToReplace = new Dictionary<string, string>()
                {
                    { ApplicationConstants.CursoReplace, turmaAluno.Turma.Curso.Nome },
                    { ApplicationConstants.NomeReplace, aluno.Nome },
                    { ApplicationConstants.CPFReplace, aluno.CPF },
                    { ApplicationConstants.MatriculaReplace, turmaAluno.Matricula },
                    { ApplicationConstants.TurmaReplace, turmaAluno.Turma.Codigo },
                    { ApplicationConstants.ValidadeReplace, aluno.DataValidade.Value.ToString(ApplicationConstants.MonthYearFormat, culture) },
                    { ApplicationConstants.DataGeracaoReplace, data }
                };
                ReplaceString(doc, stringsToReplace);
            }
            catch(Exception ex)
            {
                log.Error("Erro ao gerar crachá.", ex);
                throw new BusinessException("Erro ao gerar crachá.");
            }

            MemoryStream stream = new MemoryStream();
            doc.Save(stream, Aspose.Words.SaveFormat.Pdf);
            stream.Seek(0, SeekOrigin.Begin);
            return stream.ToArray();
        }

        public byte[] GerarHistorico(int idTurmaAluno)
        {
            var turmaAluno = turmaAlunoRepository.GetById(idTurmaAluno);
            var aluno = alunoRepository.GetById(turmaAluno.AlunoId);
            turmaAluno = aluno.TurmasAluno.First(x => x.TurmaId == turmaAluno.TurmaId);
            Document doc = new Document(Path.Combine(ApplicationConstants.PastaDocumentos, turmaAluno.Turma.CursoId.ToString(), ApplicationConstants.ArquivoHistorico));
            try
            {
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
                string dataGeracao = DateTime.Now.Day.ToString("00") + " de " + mes + " de " + DateTime.Now.Year;

                Dictionary<string, string> stringsToReplace = new Dictionary<string, string>()
                {
                    { ApplicationConstants.NomeReplace, aluno.Nome },
                    { ApplicationConstants.DataNascimentoReplace, aluno.DataNascimento.ToString(ApplicationConstants.DateFormat) },
                    { ApplicationConstants.RGReplace, aluno.RG },
                    { ApplicationConstants.OrgaoEmissorReplace, aluno.OrgaoEmissor },
                    { ApplicationConstants.CPFReplace, aluno.CPF },
                    { ApplicationConstants.DataInicioReplace, MaxDate(aluno.DataMatricula, turmaAluno.Turma.DataInicio).ToString(ApplicationConstants.DateFormat) },
                    { ApplicationConstants.DataTerminoReplace, turmaAluno.DataConclusao.HasValue ? turmaAluno.DataConclusao.Value.ToString(ApplicationConstants.DateFormat) : "" },
                    { ApplicationConstants.ValidadeReplace, aluno.DataValidade.Value.ToString(ApplicationConstants.MonthYearFormat, culture) },
                    { ApplicationConstants.DataGeracaoReplace, dataGeracao }
                };
                var disciplinas = disciplinaRepository.ListarDisciplinasDeUmCurso(turmaAluno.Turma.CursoId);
                var notas = notaAlunoRepository.ListarNotasDeUmAluno(aluno.Id);
                disciplinas.ToList().ForEach(d =>
                {
                    var notaReplace = ApplicationConstants.NotaReplace;
                    notaReplace = notaReplace.Replace("%d", d.Id.ToString());
                    var nota = notas.FirstOrDefault(x => x.DisciplinaId == d.Id);
                    var valor = string.Empty;
                    if (nota != null) valor = nota.ValorNota.ToString("0.0");
                    stringsToReplace.Add(notaReplace, valor);
                });
                ReplaceString(doc, stringsToReplace);
            }
            catch (Exception ex)
            {
                log.Error("Erro ao gerar histórico.", ex);
                throw new BusinessException("Erro ao gerar histórico.");
            }

            MemoryStream stream = new MemoryStream();
            doc.Save(stream, Aspose.Words.SaveFormat.Docx);
            stream.Seek(0, SeekOrigin.Begin);
            return stream.ToArray();
        }

        private DateTime MinDate(DateTime? date1, DateTime? date2)
        {
            if (date1.HasValue && !date2.HasValue) return date1.Value;
            else if (!date1.HasValue && date2.HasValue) return date2.Value;
            else return date1.Value < date2.Value ? date1.Value : date2.Value;
        }

        private DateTime MaxDate(DateTime? date1, DateTime? date2)
        {
            if (date1.HasValue && !date2.HasValue) return date1.Value;
            else if (!date1.HasValue && date2.HasValue) return date2.Value;
            else return date1.Value > date2.Value ? date1.Value : date2.Value;
        }


        private void ReplaceString(Document doc, Dictionary<string, string> stringsToReplace)
        {
            var options = new FindReplaceOptions
            {
                MatchCase = false,
                FindWholeWordsOnly = true,
                Direction = FindReplaceDirection.Forward
            };
            foreach (KeyValuePair<string, string> entry in stringsToReplace)
            {
                doc.Range.Replace(entry.Key, entry.Value, options);
            }
        }
        #endregion

        #region Turma Aluno 

        public bool VincularAlunoTurma(TurmaAlunoDTO turmaAlunoDTO)
        {
            // Vincular
            if (!turmaAlunoDTO.Id.HasValue)
            {
                var turmasSalvas = turmaAlunoRepository.ListarTurmasDeUmAluno(turmaAlunoDTO.AlunoId);
                if (turmasSalvas.Any(x => x.Turma.CursoId == turmaAlunoDTO.Turma.Curso.Id))
                {
                    throw new BusinessException("O aluno já está vinculado a uma turma desse curso.");
                }
                if (alunoRepository.ExisteMatricula(turmaAlunoDTO.Matricula))
                {
                    throw new BusinessException("Já existe um aluno com a matrícula informada.");
                }
                var turmaAluno = turmaAlunoDTO.ToEntity();
                turmaAluno.Id = 0;
                turmaAluno.AlunoId = turmaAlunoDTO.AlunoId;
                turmaAluno.TurmaId = turmaAlunoDTO.Turma.Id.Value;
                turmaAluno.TipoStatusAlunoId = (int)TipoStatusAlunoEnum.Ativo;

                turmaAlunoRepository.Add(turmaAluno);
                turmaAlunoRepository.SaveChanges();

                AdicionarRegistro(new RegistroAlunoDTO
                {
                    AlunoId = turmaAluno.AlunoId,
                    Data = DateTime.Today,
                    Registro = $"Aluno registrado na turma {turmaAlunoDTO.Turma.Codigo}."
                });
            }
            // Transferir
            else
            {
                var turmasSalvas = turmaAlunoRepository.ListarTurmasDeUmAluno(turmaAlunoDTO.AlunoId);
                var turmaAluno = turmasSalvas.First(x => x.Id == turmaAlunoDTO.Id.Value);
                var mensagem = $"Aluno transferido da turma {turmaAluno.Turma.Codigo} para a turma {turmaAlunoDTO.Turma.Codigo}.";
                turmaAluno.TurmaId = turmaAlunoDTO.Turma.Id.Value;
                turmaAlunoRepository.SaveChanges();

                AdicionarRegistro(new RegistroAlunoDTO
                {
                    AlunoId = turmaAluno.AlunoId,
                    Data = DateTime.Today,
                    Registro = mensagem
                });

            }
            return true;
        }

        public bool AlterarSituacao(MudancaSituacaoDTO mudancaSituacao)
        {
            var aluno = alunoRepository.GetById(mudancaSituacao.AlunoId);
            var turmaAluno = aluno.TurmasAluno.First(t => t.TurmaId == mudancaSituacao.TurmaId);
            turmaAluno.TipoStatusAlunoId = mudancaSituacao.SituacaoId;
            if (mudancaSituacao.SituacaoId == (int)TipoStatusAlunoEnum.Concluido)
            {
                turmaAluno.DataConclusao = mudancaSituacao.DataConclusao;
                turmaAluno.CodigoConlusaoSistec = mudancaSituacao.CodigoSistec;
            }
            alunoRepository.SaveChanges();
            if (!string.IsNullOrEmpty(mudancaSituacao.Registro))
            {
                AdicionarRegistro(new RegistroAlunoDTO
                {
                    AlunoId = turmaAluno.AlunoId,
                    Data = DateTime.Today,
                    Registro = mudancaSituacao.Registro
                });
            }
            return true;
        }
        #endregion

        #region Registro Aluno
        public bool AdicionarRegistro(RegistroAlunoDTO registro)
        {
            var transaction = this.registroAlunoRepository.GetTransaction();
            try
            {
                var reg = registro.ToEntity();
                registroAlunoRepository.Add(reg);
                registroAlunoRepository.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public bool ExcluirRegistro(int id)
        {
            registroAlunoRepository.Delete(id);
            return true;
        }

        #endregion

        #region Arquivos
        public bool SalvarImagemAluno(int idAluno, byte[] imagem)
        {
            Aluno aluno = alunoRepository.GetById(idAluno);
            string cpf = aluno.CPF.Replace(".", "").Replace("-", "");
            if (imagem != null && imagem.Length > 0)
            {
                return SalvarArquivo(cpf, ApplicationConstants.NomeArquivoFotoPerfil, imagem);
            }
            else
            {
                return ExcluirArquivo(cpf, ApplicationConstants.NomeArquivoFotoPerfil);
            }
        }


        public byte[] BuscarImagemAluno(int idAluno)
        {
            Aluno aluno = alunoRepository.GetById(idAluno);
            string cpf = aluno.CPF.Replace(".", "").Replace("-", "");
            return BuscarArquivo(cpf, ApplicationConstants.NomeArquivoFotoPerfil);
        }
        #endregion

        #region Métodos Privados
        private bool SalvarArquivo(string cpf, string nomeArquivo, byte[] arquivo)
        {
            try
            {
                string folder = configuration.GetSection("AssetsFolder").Value;
                string path = Path.Combine(folder, cpf);
                Directory.CreateDirectory(path);
                path = Path.Combine(path, nomeArquivo);
                File.WriteAllBytes(path, arquivo);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private byte[] BuscarArquivo(string cpf, string nomeArquivo)
        {
            try
            {
                string folder = configuration.GetSection("AssetsFolder").Value;
                string path = Path.Combine(folder, cpf);
                path = Path.Combine(path, nomeArquivo);
                return File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private bool ExcluirArquivo(string cpf, string nomeArquivo)
        {
            try
            {
                string folder = configuration.GetSection("AssetsFolder").Value;
                string path = Path.Combine(folder, cpf);
                path = Path.Combine(path, nomeArquivo);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        #endregion
    }
}
