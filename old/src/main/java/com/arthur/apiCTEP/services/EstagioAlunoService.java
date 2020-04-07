package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.EstagioAluno;
import com.arthur.apiCTEP.repositories.EstagioAlunoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class EstagioAlunoService extends ServiceGenerico<EstagioAluno,Long>{

    @Autowired
    public EstagioAlunoService(EstagioAlunoRepository repository) {
        super(repository);
    }
}
