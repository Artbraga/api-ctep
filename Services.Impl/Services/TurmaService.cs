using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Enums;
using Entities.Exceptions;
using Entities.Filters;
using log4net;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Services.Impl.Services
{
    public class TurmaService : BaseService<Turma>, ITurmaService
    {
        private readonly ITurmaRepository turmaRepository;
        private readonly ICursoRepository cursoRepository;
        private readonly IRegistroTurmaRepository registroTurmaRepository;
        private readonly ITurmaProfessorRepository turmaProfessorRepository;
        private static readonly ILog log = LogManager.GetLogger(typeof(TurmaService));

        public TurmaService(ITurmaRepository TurmaRepository, 
            ICursoRepository CursoRepository, 
            IRegistroTurmaRepository RegistroTurmaRepository,
            ITurmaProfessorRepository TurmaProfessorRepository) : base(TurmaRepository)
        {
            this.turmaRepository = TurmaRepository;
            this.cursoRepository = CursoRepository;
            this.registroTurmaRepository = RegistroTurmaRepository;
            this.turmaProfessorRepository = TurmaProfessorRepository;
        }

        public IEnumerable<TurmaDTO> ListarTurmas()
        {
            return turmaRepository.All().Select(x => new TurmaDTO(x));
        }

        public IEnumerable<TurmaDTO> ListarTurmasDeUmCurso(int cursoId)
        {
            return turmaRepository.ListarTurmasDeUmCurso(cursoId).Select(x => new TurmaDTO(x));
        }

        public string GerarCodigoDaTurma(int cursoId, int anoTurma)
        {
            var curso = cursoRepository.GetById(cursoId);
            var trecho = $"{curso.SiglaTurma}{anoTurma % 100}";
            var numero = turmaRepository.BuscarCodigoDaTurma(trecho);
            string codigo;
            do
            {
                numero += 1;
                codigo = $"{trecho}{numero.ToString("D2")}";
            } while (turmaRepository.ExisteCodigo(codigo));


            return codigo;
        }

        public TurmaDTO SalvarTurma(TurmaDTO turmaDto)
        {
            var transaction = this.turmaRepository.GetTransaction();
            try
            {
                Turma turma;
                if (turmaDto.Id.HasValue)
                {
                    turma = EditarTurma(turmaDto);
                }
                else
                {
                    if (turmaRepository.ExisteCodigo(turmaDto.Codigo))
                    {
                        throw new BusinessException("Já existe uma turma com o código informado.");
                    }
                    turma = turmaDto.ToEntity();
                    turma.TipoStatusTurmaId = (int)TipoStatusTurmaEnum.EmAndamento;
                    turmaRepository.Add(turma);
                }
                turmaRepository.SaveChanges();
                transaction.Commit();
                transaction.Dispose();

                return (TurmaDTO)GetById(turma.Id);
            }
            catch(Exception e)
            {
                transaction.Rollback();
                transaction.Dispose();
                log.Error("Erro ao salvar turma.", e);
                throw;
            }
        }

        public bool FinalizarTurma(TurmaDTO turmaDto)
        {
            var transaction = this.turmaRepository.GetTransaction();
            try
            {
                Turma turma = EditarTurma(turmaDto);
                turma.TipoStatusTurmaId = (int)TipoStatusTurmaEnum.Concluida;
                turmaRepository.SaveChanges();
                transaction.Commit();
                transaction.Dispose();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                transaction.Dispose();
                log.Error("Erro ao filanizar turma.", e);
                throw;
            }

        }

        public IEnumerable<TurmaDTO> ListarTurmasAtivas()
        {
            var turmas = turmaRepository.ListarTurmasAtivas();
            return turmas.Select(x => new TurmaDTO(x));
        }

        public override BaseDTO<Turma> GetById(int id)
        {
            var turma = turmaRepository.GetById(id);

            return new TurmaDTO(turma);
        }

        public IEnumerable<TurmaDTO> BuscarTurmasPorCodigoECurso(string codigo, int? cursoId)
        {
            var turmas = turmaRepository.BuscarTurmasPorCodigoECurso(codigo, cursoId);
            return turmas.Select(x => new TurmaDTO(x));
        }

        public IEnumerable<TurmaDTO> FiltrarTurmas(TurmaFilter filter)
        {
            IEnumerable<Turma> turmas = turmaRepository.FiltrarTurmas(filter);
            return turmas.Select(x => new TurmaDTO(x));
        }

        #region RegistroTurma
        public bool AdicionarRegistro(RegistroTurmaDTO registro)
        {
            var transaction = this.registroTurmaRepository.GetTransaction();
            try
            {
                var reg = registro.ToEntity();
                registroTurmaRepository.Add(reg);
                registroTurmaRepository.SaveChanges();
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
            registroTurmaRepository.Delete(id);
            return true;
        }
        #endregion

        #region TurmaProfessor
        public bool AdicionarProfessor(TurmaProfessorDTO turmaProfessor)
        {
            var transaction = this.turmaProfessorRepository.GetTransaction();
            try
            {
                var turma = this.turmaRepository.GetById(turmaProfessor.TurmaId);
                if (turma.TurmasProfessor.Any(x => x.ProfessorId == turmaProfessor.Professor.Id))
                {
                    throw new BusinessException("O professor já está vinculado na turma.");
                }
                var tp = turmaProfessor.ToEntity();
                turmaProfessorRepository.Add(tp);
                turmaProfessorRepository.SaveChanges();
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

        public bool ExcluirProfessor(int id)
        {
            turmaProfessorRepository.Delete(id);
            return true;
        }

        public IEnumerable<TurmaProfessorDTO> BuscarProfessoresDeUmaTurma(int turmaId)
        {
            IEnumerable<TurmaProfessor> turmas = turmaProfessorRepository.BuscarProfessoresDeUmaTurma(turmaId);
            return turmas.Select(x => new TurmaProfessorDTO(x));
        }
        #endregion

        #region Métodos Privados
        private Turma EditarTurma(TurmaDTO turmaDto)
        {
            Turma turma = turmaRepository.GetById(turmaDto.Id.Value);
            turma.Codigo = turmaDto.Codigo;
            turma.DiasDaSemana = turmaDto.DiasDaSemana;
            turma.HoraInicio = TimeSpan.Parse(turmaDto.HoraInicio, CultureInfo.InvariantCulture);
            turma.HoraFim = TimeSpan.Parse(turmaDto.HoraFim, CultureInfo.InvariantCulture);
            turma.DataInicio = turmaDto.DataInicio;
            turma.DataFim = turmaDto.DataFim;
            return turma;
        }
        #endregion
    }
}
