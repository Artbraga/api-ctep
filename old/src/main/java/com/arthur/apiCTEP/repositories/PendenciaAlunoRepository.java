package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.PendenciaAluno;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface PendenciaAlunoRepository extends JpaRepository<PendenciaAluno, Integer> {

    List<PendenciaAluno> recuperaPendenciasDeUmAluno(String matricula);
}
