package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Retorno;
import com.arthur.apiCTEP.repositories.RetornoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class RetornoService extends ServiceGenerico<Retorno, Integer> {

    private RetornoRepository retornoRepository;
    @Autowired
    public RetornoService(RetornoRepository repository) {
        super(repository);
        this.retornoRepository = repository;
    }
}
