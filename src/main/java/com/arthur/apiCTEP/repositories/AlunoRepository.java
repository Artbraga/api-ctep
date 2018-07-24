package com.arthur.apiCTEP.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.arthur.apiCTEP.entities.Aluno;

import java.util.List;

@Repository
public interface AlunoRepository extends JpaRepository<Aluno, String> {

    List<Aluno> filtrarPeloNome(String nome);

    List<Aluno> filtrarPelaMatricula(String matricula);

    List<String> recuperaNumeroDeAlunosParaMatricula(int ano, int cursoId);
}
