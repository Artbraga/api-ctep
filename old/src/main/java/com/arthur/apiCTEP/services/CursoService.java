package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Curso;
import com.arthur.apiCTEP.repositories.CursoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CursoService extends ServiceGenerico<Curso, Integer> {

    private CursoRepository cursoRepository;
    @Autowired
    public CursoService(CursoRepository repository) {
        super(repository);
        this.cursoRepository = (CursoRepository) this.repository;
    }

    public List<Curso> listarCursosDeEspecializacao(int id){
        return cursoRepository.listarCursosDeEspecializacao(id);
    }

    public List<Curso> listarCursosTecnicos(){
        return cursoRepository.listarCursosTecnicos();
    }

    public List<Curso> filtrar(String nome) {
        return cursoRepository.filtrar(nome);
    }
}
