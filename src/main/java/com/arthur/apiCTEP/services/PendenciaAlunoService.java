package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.PendenciaAluno;
import com.arthur.apiCTEP.repositories.PendenciaAlunoRepository;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;

public class PendenciaAlunoService extends ServiceGenerico<PendenciaAluno, Integer>{

    PendenciaAlunoRepository pendenciaAlunoRepository;

    @Autowired
    public PendenciaAlunoService(PendenciaAlunoRepository repository){
        super(repository);
        pendenciaAlunoRepository = (PendenciaAlunoRepository) this.repository;
    }

    public List<PendenciaAluno> recuperaPendenciasDeUmAluno(String matricula){
        return pendenciaAlunoRepository.recuperaPendenciasDeUmAluno(matricula);
    }
}