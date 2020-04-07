package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.NotaAluno;
import com.arthur.apiCTEP.repositories.NotaAlunoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class NotaAlunoService extends ServiceGenerico<NotaAluno,Long>{

    @Autowired
    public NotaAlunoService(NotaAlunoRepository repository) {
        super(repository);
    }
}
