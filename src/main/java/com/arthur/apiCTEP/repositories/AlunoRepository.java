package com.arthur.apiCTEP.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.arthur.apiCTEP.entities.Aluno;

@Repository
public interface AlunoRepository extends JpaRepository<Aluno, String> {

}
