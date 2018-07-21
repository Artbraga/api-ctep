package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.ObservacaoTurma;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ObservacaoTurmaRepository extends JpaRepository<ObservacaoTurma, Long> {
}
