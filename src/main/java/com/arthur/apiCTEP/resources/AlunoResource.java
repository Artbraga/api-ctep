package com.arthur.apiCTEP.resources;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.arthur.apiCTEP.entities.Aluno;
import com.arthur.apiCTEP.services.AlunoService;

@RestController
@RequestMapping(value="/alunos")
public class AlunoResource extends ResourceGenerico<Aluno, String>{

	private AlunoService alunoService;
	@Autowired
	public AlunoResource(AlunoService alunoService) {
		super(alunoService);
		this.alunoService = (AlunoService) this.service;
	}

}
