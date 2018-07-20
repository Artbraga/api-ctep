package com.arthur.apiCTEP.services;

import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.arthur.apiCTEP.entities.Aluno;
import com.arthur.apiCTEP.repositories.AlunoRepository;

@Service
public class AlunoService {
	
	@Autowired
	private AlunoRepository alunoRepository;
	
	public Aluno buscar(String matricula) {
		Optional<Aluno> aluno = this.alunoRepository.findById(matricula);
		return aluno.orElse(null);
	}
}
