package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.NotaAluno;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface NotaAlunoRepository extends JpaRepository<NotaAluno, Long> {
}
