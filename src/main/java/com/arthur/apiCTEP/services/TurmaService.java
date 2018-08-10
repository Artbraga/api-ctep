package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Curso;
import com.arthur.apiCTEP.entities.Turma;
import com.arthur.apiCTEP.repositories.CursoRepository;
import com.arthur.apiCTEP.repositories.TurmaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.Year;
import java.util.List;

@Service
public class TurmaService extends ServiceGenerico<Turma,String>{

    private TurmaRepository turmaRepository;

    @Autowired
    private CursoRepository cursoRepository;

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

    public String gerarCodigo(int cursoId, int ano){
        Curso curso = cursoRepository.getOne(cursoId);
        String anoInicio = Integer.toString(ano % 100);
        int numero = turmaRepository.recuperaNumeroDeTurmasNoAno(ano, cursoId);

        return curso.getSiglaTurma() + anoInicio + String.format("%02d", numero + 1);
    }

    public List<Turma> filtrarTurmasAtivasDeUmCurso(String codigo, int cursoId){
        return this.turmaRepository.filtrarTurmasAtivasDeUmCurso(codigo, cursoId);
    }
}
