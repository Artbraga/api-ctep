package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Turma;
import com.arthur.apiCTEP.repositories.TurmaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TurmaService extends ServiceGenerico<Turma,String>{

    private TurmaRepository turmaRepository;

    @Autowired
    public TurmaService(TurmaRepository repository) {
        super(repository);
        turmaRepository = (TurmaRepository) this.repository;
    }

    public List<Turma> listarTurmasAtivas(){
        return this.turmaRepository.listarTurmasAtivas();
    }


    public List<Turma> filtrarTurmasAtivas(String codigo){
        return this.turmaRepository.filtrarTurmasAtivas(codigo);
    }


}
