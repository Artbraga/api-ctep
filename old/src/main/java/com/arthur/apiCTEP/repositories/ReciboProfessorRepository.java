package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.ReciboProfessor;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ReciboProfessorRepository extends JpaRepository<ReciboProfessor, Long> {
}
