package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.ObservacaoTurma;
import com.arthur.apiCTEP.repositories.ObservacaoTurmaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ObservacaoTurmaService extends ServiceGenerico<ObservacaoTurma,Long>{

    @Autowired
    public ObservacaoTurmaService(ObservacaoTurmaRepository repository) {
        super(repository);
    }
}
