package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Turma;
import com.arthur.apiCTEP.repositories.TurmaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TurmaService extends ServiceGenerico<Turma,String>{

    @Autowired
    public TurmaService(TurmaRepository repository) {
        super(repository);
    }
}
