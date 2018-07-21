package com.arthur.apiCTEP.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.arthur.apiCTEP.entities.Aluno;
import com.arthur.apiCTEP.repositories.AlunoRepository;

@Service
public class AlunoService extends ServiceGenerico<Aluno,String>{

	@Autowired
	public AlunoService(AlunoRepository repository) {
		super(repository);
	}
}
