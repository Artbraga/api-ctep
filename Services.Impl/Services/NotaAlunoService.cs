using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Exceptions;
using log4net;
using Newtonsoft.Json;
using Repositories.Repositories;
using Services.Impl.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl.Services
{
    public class NotaAlunoService : BaseService<NotaAluno>, INotaAlunoService
    {
        private readonly INotaAlunoRepository notaAlunoRepository;
        private static readonly ILog log = LogManager.GetLogger(typeof(NotaAlunoService));
        public NotaAlunoService(INotaAlunoRepository notaAlunoRepository) : base(notaAlunoRepository)
        {
            this.notaAlunoRepository = notaAlunoRepository;
        }

        public override BaseDTO<NotaAluno> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SalvarNotas(IEnumerable<NotaAlunoDTO> notas)
        {
            var transaction = this.notaAlunoRepository.GetTransaction();
            foreach (var nota in notas)
            {
                log.Info($"Salvando nota: {JsonConvert.SerializeObject(nota)}");
                if (nota.Id.HasValue) // alteração de nota
                {
                    var n = notaAlunoRepository.GetById(nota.Id.Value);
                    n.ValorNota = float.Parse(nota.ValorNota.Replace('.', ','));
                }
                else // criação de nota
                {
                    if (!string.IsNullOrEmpty(nota.ValorNota))
                    {
                        var n = nota.ToEntity();
                        n.ValorNota = float.Parse(nota.ValorNota.Replace('.', ','));
                        notaAlunoRepository.Add(n);
                    }
                }
            }
            try
            {
                notaAlunoRepository.SaveChanges();
                transaction.Commit();
                transaction.Dispose();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                transaction.Dispose();
                log.Error("Erro ao salvar notas.", ex);
                log.Error(JsonConvert.SerializeObject(notas));
                throw new BusinessException("Erro desconhecido ao salvar notas.");
            }
        }

        public IEnumerable<NotaAlunoDTO> ListarNotasDeUmAluno(int alunoId)
        {
            var notas = notaAlunoRepository.ListarNotasDeUmAluno(alunoId);
            return notas.Select(x => new NotaAlunoDTO(x));
        }
    }
}
