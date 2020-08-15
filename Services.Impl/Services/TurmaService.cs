using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Enums;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Services.Impl
{
    public class TurmaService : BaseService<Turma>, ITurmaService
    {
        private readonly ITurmaRepository turmaRepository;
        private readonly ICursoRepository cursoRepository;
        public TurmaService(ITurmaRepository TurmaRepository, ICursoRepository CursoRepository) : base(TurmaRepository)
        {
            this.turmaRepository = TurmaRepository;
            this.cursoRepository = CursoRepository;
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
            return $"{trecho}{(numero + 1).ToString("D2")}";
        }

        public TurmaDTO SalvarTurma(TurmaDTO turmaDto)
        {
            var transaction = this.turmaRepository.GetTransaction();
            try
            {
                Turma turma;
                if (turmaDto.Id.HasValue)
                {
                    turma = turmaRepository.GetById(turmaDto.Id.Value);
                    turma.Codigo = turmaDto.Codigo;
                    turma.DiasDaSemana = turmaDto.DiasDaSemana;
                    turma.HoraInicio = TimeSpan.Parse(turmaDto.HoraInicio, CultureInfo.InvariantCulture);
                    turma.HoraFim = TimeSpan.Parse(turmaDto.HoraFim, CultureInfo.InvariantCulture);
                    turma.DataInicio = turmaDto.DataInicio;
                    turma.DataFim = turmaDto.DataFim;
                }
                else
                {
                    turma = turmaDto.ToEntity();
                    turma.TipoStatusTurmaId = (int)TipoStatusTurmaEnum.EmAndamento;
                }
                turmaRepository.Add(turma);
                turmaRepository.SaveChanges();
                transaction.Commit();
                transaction.Dispose();

                return new TurmaDTO(turmaRepository.GetById(turma.Id));
            }
            catch(Exception e)
            {
                transaction.Rollback();
                transaction.Dispose();
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
    }
}
