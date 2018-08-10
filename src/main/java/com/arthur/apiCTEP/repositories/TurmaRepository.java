package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.Turma;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface TurmaRepository extends JpaRepository<Turma, String> {

    public List<Turma> listarTurmasAtivas();

    List<Turma> filtrarPeloCodigo(String codigo);

    List<Turma> filtrarTurmasAtivas(String codigo);

    int recuperaNumeroDeTurmasNoAno(int ano, int cursoId);

    List<Turma> filtrarTurmasAtivasDeUmCurso(String codigo, int cursoId);
}
