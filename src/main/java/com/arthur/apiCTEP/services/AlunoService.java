package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Curso;
import com.arthur.apiCTEP.repositories.CursoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.arthur.apiCTEP.entities.Aluno;
import com.arthur.apiCTEP.repositories.AlunoRepository;

import java.util.List;

@Service
public class AlunoService extends ServiceGenerico<Aluno,String>{

    private AlunoRepository alunoRepository;

    @Autowired
    private CursoRepository cursoRepository;

	@Autowired
	public AlunoService(AlunoRepository repository) {
		super(repository);
		this.alunoRepository = (AlunoRepository) this.repository;
	}

    public String gerarMatricula(int ano, int cursoId){
	    String anoMatricula = Integer.toString(ano);
        List<String> matriculas = this.alunoRepository.recuperaNumeroDeAlunosParaMatricula(ano, cursoId);
        int numero;
        if (!matriculas.isEmpty())
            numero = Integer.parseInt(matriculas.get(matriculas.size() - 1).substring(6)) + 1;
        else numero = 1;

        Curso curso = cursoRepository.getOne(cursoId);

        return curso.getSigla() + anoMatricula + String.format("%03d", numero);
    }

    public List<Aluno> filtrarPelaMatricula(String matricula){
        return alunoRepository.filtrarPelaMatricula(matricula);
    }

    public List<Aluno> filtrarPelaTurma(String codigoTurma){
        return alunoRepository.filtrarPelaTurma(codigoTurma);
    }

    public List<Aluno> filtrarPeloNome(String nome){
        return alunoRepository.filtrarPeloNome(nome);
    }
}
