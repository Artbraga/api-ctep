using Entities.Base;
using Entities.DTOs;
using Entities.Entities;
using Entities.Filters;
using Services.Base;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IAlunoService : IBaseService<Aluno>
    {
        string GerarNumeroDeMatricula(int cursoId, int anoMatricula);
        AlunoDTO SalvarAluno(AlunoDTO alunoDto);
        bool VincularAlunoTurma(TurmaAlunoDTO turmaAlunoDTO);
        FilterResultDTO<AlunoDTO> FiltrarAlunos(AlunoFilter filter);
        byte[] ExportarPesquisa(AlunoFilter filter);
        bool ExcluirAluno(int id);
        bool ExcluirRegistro(int id);
        bool AdicionarRegistro(RegistroAlunoDTO registro);
        bool SalvarImagemAluno(int idAluno, byte[] imagem);
        byte[] BuscarImagemAluno(int idAluno);
        byte[] GerarCracha(int idTurmaAluno);
        byte[] GerarHistorico(int idTurmaAluno);
        bool AlterarSituacao(MudancaSituacaoDTO mudancaSituacao);
        IEnumerable<AlunoNotasDTO> BuscarAlunosENotasDeTurma(int turmaId);
    }
}
