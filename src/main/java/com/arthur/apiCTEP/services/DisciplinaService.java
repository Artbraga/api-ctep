package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Disciplina;
import com.arthur.apiCTEP.repositories.DisciplinaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class DisciplinaService extends ServiceGenerico<Disciplina,Integer>{

    private DisciplinaRepository disciplinaRepository;

    @Autowired
    public DisciplinaService(DisciplinaRepository repository) {
        super(repository);
        this.disciplinaRepository = (DisciplinaRepository) this.repository;
    }

    public List<Disciplina> recuperaDisciplinasDeUmCurso(int cursoId){
        return disciplinaRepository.recuperaDisciplinasDeUmCurso(cursoId);
    }
}
