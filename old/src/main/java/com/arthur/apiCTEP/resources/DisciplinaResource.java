package com.arthur.apiCTEP.resources;

import com.arthur.apiCTEP.entities.Disciplina;
import com.arthur.apiCTEP.services.DisciplinaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping(value="/disciplinas")
public class DisciplinaResource extends ResourceGenerico<Disciplina, Integer>{

	private DisciplinaService disciplinaService;
	@Autowired
	public DisciplinaResource(DisciplinaService disciplinaService) {
		super(disciplinaService);
		this.disciplinaService = (DisciplinaService) this.service;
	}

	@RequestMapping(value="/listarDisciplinasDeUmCurso/{cursoId}", method= RequestMethod.GET)
	public ResponseEntity<?> listarCursosDeEspecializacao(@PathVariable int cursoId) {
		List<Disciplina> disciplinas = disciplinaService.recuperaDisciplinasDeUmCurso(cursoId);
        return ResponseEntity.ok(disciplinas);
	}
}
