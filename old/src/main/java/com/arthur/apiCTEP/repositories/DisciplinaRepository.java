package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.Disciplina;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface DisciplinaRepository extends JpaRepository<Disciplina, Integer> {

    List<Disciplina> recuperaDisciplinasDeUmCurso(int cursoId);
}
