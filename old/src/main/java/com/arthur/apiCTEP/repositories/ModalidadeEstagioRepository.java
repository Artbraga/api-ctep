package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.ModalidadeEstagio;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ModalidadeEstagioRepository extends JpaRepository<ModalidadeEstagio, Integer> {
}
