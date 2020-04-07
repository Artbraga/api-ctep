package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Professor;
import com.arthur.apiCTEP.repositories.ProfessorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ProfessorService extends ServiceGenerico<Professor,Long>{

    @Autowired
    public ProfessorService(ProfessorRepository repository) {
        super(repository);
    }
}
