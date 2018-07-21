package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Curso;
import com.arthur.apiCTEP.repositories.CursoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CursoService extends ServiceGenerico<Curso, Integer> {

    @Autowired
    public CursoService(CursoRepository repository) {
        super(repository);
    }
}
