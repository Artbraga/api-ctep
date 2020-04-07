package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.ModalidadeEstagio;
import com.arthur.apiCTEP.repositories.ModalidadeEstagioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ModalidadeEstagioService extends ServiceGenerico<ModalidadeEstagio,Integer>{

    @Autowired
    public ModalidadeEstagioService(ModalidadeEstagioRepository repository) {
        super(repository);
    }
}
