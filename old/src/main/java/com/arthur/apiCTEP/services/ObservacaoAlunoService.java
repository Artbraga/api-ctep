package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.ObservacaoAluno;
import com.arthur.apiCTEP.repositories.ObservacaoAlunoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ObservacaoAlunoService extends ServiceGenerico<ObservacaoAluno,Long>{

    @Autowired
    public ObservacaoAlunoService(ObservacaoAlunoRepository repository) {
        super(repository);
    }
}
