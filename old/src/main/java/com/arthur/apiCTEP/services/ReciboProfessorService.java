package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.ReciboProfessor;
import com.arthur.apiCTEP.repositories.ReciboProfessorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ReciboProfessorService extends ServiceGenerico<ReciboProfessor,Long>{

    @Autowired
    public ReciboProfessorService(ReciboProfessorRepository repository) {
        super(repository);
    }
}
