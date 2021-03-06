using Aspose.Cells;
using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Enums;
using Entities.Exceptions;
using Entities.Filters;
using Entities.Util;
using log4net;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
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
        private readonly IConfiguration configuration;

        private static readonly ILog log = LogManager.GetLogger(typeof(AlunoService));

        public AlunoService(IAlunoRepository alunoRepository,
                            IRegistroAlunoRepository registroAlunoRepository,
                            ICursoRepository cursoRepository,
                            ITurmaAlunoRepository turmaAlunoRepository,
                            IConfiguration configuration) 
        : base(alunoRepository)
        {
            this.alunoRepository = alunoRepository;
            this.registroAlunoRepository = registroAlunoRepository;
            this.cursoRepository = cursoRepository;
            this.turmaAlunoRepository = turmaAlunoRepository;
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
                throw new BusinessException("Erro desconhecido ao salvar aluno.");
            }
        }

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


        public IEnumerable<AlunoDTO> FiltrarAlunos(AlunoFilter filter)
        {
            IEnumerable<Aluno> alunos = alunoRepository.FiltrarAlunos(filter);
            var retorno = alunos.Select(x => new AlunoDTO(x));
            return retorno;
        }

        public byte[] ExportarPesquisa(AlunoFilter filter)
        {
            var alunos = FiltrarAlunos(filter).ToList();
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
            Style styleDia = conteudoExcel.CreateStyle();
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

            //descomentar para testar localmente
            #region teste local salvar arquivo
            //MemoryStream stream = new MemoryStream();
            //string path = @"C:\Users\exportacao_completa.xlsx";
            //conteudoExcel.Save(stream, SaveFormat.Xlsx);
            //stream.Seek(0, SeekOrigin.Begin);
            //using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            //{
            //    stream.WriteTo(fs);
            //}
            #endregion

            MemoryStream stream = new MemoryStream();
            conteudoExcel.Save(stream, SaveFormat.Xlsx);
            stream.Seek(0, SeekOrigin.Begin);
            return stream.ToArray();

            void GravarValor(Row row, object dado, int indice, Style style = null)
            {
                if (dado == null) dado = "";
                row[indice].PutValue(dado);
                if (style != null)
                {
                    row[indice].SetStyle(style);
                }
            }
        }


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
