package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Disciplina;
import com.arthur.apiCTEP.repositories.DisciplinaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class DisciplinaService extends ServiceGenerico<Disciplina,Integer>{

    @Autowired
    public DisciplinaService(DisciplinaRepository repository) {
        super(repository);
    }
}
