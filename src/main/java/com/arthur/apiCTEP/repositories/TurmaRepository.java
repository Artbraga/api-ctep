package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.Turma;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface TurmaRepository extends JpaRepository<Turma, String> {
}
