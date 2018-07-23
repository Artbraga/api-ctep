package com.arthur.apiCTEP.repositories;

import com.arthur.apiCTEP.entities.Curso;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface CursoRepository extends JpaRepository<Curso, Integer> {

    List<Curso> listarCursosDeEspecializacao(int id);

    List<Curso> listarCursosTecnicos();

    List<Curso> filtrar(String nome);
}
