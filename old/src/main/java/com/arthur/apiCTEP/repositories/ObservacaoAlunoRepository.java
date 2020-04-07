package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.ObservacaoAluno;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ObservacaoAlunoRepository extends JpaRepository<ObservacaoAluno, Long> {
}
