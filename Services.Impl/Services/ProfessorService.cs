using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Exceptions;
using Entities.Filters;
using log4net;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl.Services
{
    public class ProfessorService : BaseService<Professor>, IProfessorService
    {
        private readonly IProfessorRepository professorRepository;

        private static readonly ILog log = LogManager.GetLogger(typeof(AlunoService));

        public ProfessorService(IProfessorRepository professorRepository) : base(professorRepository)
        {
            this.professorRepository = professorRepository;
        }

        public override BaseDTO<Professor> GetById(int id)
        {
            var professor = professorRepository.GetById(id);
            return new ProfessorDTO(professor);
        }

        public IEnumerable<ProfessorDTO> ListarProfessores()
        {
            var professores = professorRepository.All();
            return professores.Select(x => new ProfessorDTO(x));
        }

        public IEnumerable<ProfessorDTO> ListarProfessoresAtivos()
        {
            var professores = professorRepository.ListarProfessoresAtivos();
            return professores.Select(x => new ProfessorDTO(x));
        }

        public bool ExcluirProfessor(int id)
        {
            var professor = professorRepository.GetById(id);
            professor.FlagExclusao = true;
            professorRepository.SaveChanges();
            return true;
        }

        public ProfessorDTO SalvarProfessor(ProfessorDTO professorDTO)
        {
            var transaction = professorRepository.GetTransaction();
            try
            {
                Professor professor;
                if (professorDTO.Id.HasValue)
                {
                    professor = professorRepository.GetById(professorDTO.Id.Value);
                    professor.Nome = professorDTO.Nome;
                    professor.RG = professorDTO.RG;
                    professor.CPF = professorDTO.CPF;
                    professor.Endereco = professorDTO.Endereco;
                    professor.CEP = professorDTO.CEP;
                    professor.Bairro = professorDTO.Bairro;
                    professor.Cidade = professorDTO.Cidade;
                    professor.Complemento = professorDTO.Complemento;
                    professor.Telefone = professorDTO.Telefone;
                    professor.Celular = professorDTO.Celular;
                    professor.Email = professorDTO.Email;
                    professor.Formacao = professorDTO.Formacao;
                    professor.FlagExclusao = professorDTO.FlagExclusao;
                }
                else
                {
                    professor = professorDTO.ToEntity();
                    professor.FlagExclusao = false;
                    professor.TurmasProfessor = new List<TurmaProfessor>();
                    professorRepository.Add(professor);
                }
                professorRepository.SaveChanges();

                transaction.Commit();
                transaction.Dispose();

                return new ProfessorDTO(professorRepository.GetById(professor.Id));
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                transaction.Dispose();
                if (ex.InnerException.Message.Contains("cpf_UNIQUE"))
                {
                    throw new BusinessException("Já existe um professor com o CPF cadastrado.");
                }
                log.Error("Erro ao salvar professor.", ex);
                throw new BusinessException("Erro desconhecido ao salvar professor.");
            }
        }

        public IEnumerable<ProfessorDTO> FiltrarProfessores(ProfessorFilter filter)
        {
            var professores = professorRepository.FiltrarProfessores(filter);
            return professores.Select(x => new ProfessorDTO(x));
        }
    }
}
