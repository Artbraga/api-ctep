using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Enums;
using Entities.Exceptions;
using Entities.Filters;
using Entities.Util;
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
        private readonly ICursoRepository cursoRepository;
        private readonly ITurmaAlunoRepository turmaAlunoRepository;
        private readonly IConfiguration configuration;
        public AlunoService(IAlunoRepository alunoRepository, 
                            ICursoRepository cursoRepository,
                            ITurmaAlunoRepository turmaAlunoRepository,
                            IConfiguration configuration) 
        : base(alunoRepository)
        {
            this.alunoRepository = alunoRepository;
            this.cursoRepository = cursoRepository;
            this.turmaAlunoRepository = turmaAlunoRepository;
            this.configuration = configuration;
        }

        public string GerarNumeroDeMatricula(int cursoId, int anoMatricula)
        {
            var curso = cursoRepository.GetById(cursoId);
            var trecho = $"{curso.Sigla}{anoMatricula % 100}";
            var numero = alunoRepository.BuscarCodigoParaMatricula(trecho);
            return $"{trecho}{(numero + 1).ToString("D3")}";
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
                    aluno.NotaFiscal = alunoDto.NotaFiscal;
                }
                else
                {
                    aluno = alunoDto.ToEntity();
                    aluno.TipoStatusAlunoId = (int)TipoStatusAlunoEnum.Ativo;
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
            var turmasSalvas = turmaAlunoRepository.ListarTurmasDeUmAluno(turmaAlunoDTO.AlunoId);
            if (turmasSalvas.Any(x => x.Turma.CursoId == turmaAlunoDTO.Turma.Curso.Id))
            {
                throw new BusinessException("O aluno já está vinculado a uma turma desse curso.");
            }
            var turmaAluno = turmaAlunoDTO.ToEntity();
            turmaAluno.Id = 0;
            turmaAluno.AlunoId = turmaAlunoDTO.AlunoId;
            turmaAluno.TurmaId = turmaAlunoDTO.Turma.Id.Value;

            turmaAlunoRepository.Add(turmaAluno);
            turmaAlunoRepository.SaveChanges();
            return true;
        }

        public override BaseDTO<Aluno> GetById(int id)
        {
            var aluno = this.alunoRepository.GetById(id);

            return new AlunoDTO(aluno);
        }

        public IEnumerable<AlunoDTO> FiltrarAlunos(AlunoFilter filter)
        {
            IEnumerable<Aluno> alunos = alunoRepository.FiltrarAlunos(filter);
            return alunos.Select(x => new AlunoDTO(x));
        }

        public bool SalvarImagemAluno(int idAluno, byte[] imagem)
        {
            Aluno aluno = alunoRepository.GetById(idAluno);
            string cpf = aluno.CPF.Replace(".", "").Replace("-", "");
            return SalvarArquivo(cpf, ApplicationConstants.NomeArquivoFotoPerfil, imagem);
        }


        public byte[] BuscarImagemAluno(int idAluno)
        {
            Aluno aluno = alunoRepository.GetById(idAluno);
            string cpf = aluno.CPF.Replace(".", "").Replace("-", "");
            return BuscarArquivo(cpf, ApplicationConstants.NomeArquivoFotoPerfil);
        }

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
        #endregion
    }
}
