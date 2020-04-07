package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.EstagioAluno;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface EstagioAlunoRepository extends JpaRepository<EstagioAluno, Long> {
}
