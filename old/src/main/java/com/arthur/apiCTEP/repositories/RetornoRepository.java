package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.Retorno;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface RetornoRepository extends JpaRepository<Retorno, Integer> {
}
