package com.arthur.apiCTEP.resources;

import com.arthur.apiCTEP.entities.Curso;
import com.arthur.apiCTEP.services.CursoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping(value="/cursos")
public class CursoResource extends ResourceGenerico<Curso, Integer>{

	private CursoService cursoService;

	@Autowired
	public CursoResource(CursoService service) {
		super(service);
		this.cursoService = (CursoService) this.service;
	}

	@RequestMapping(value="/listarCursosDeEspecializacao/{id}", method= RequestMethod.GET)
	public ResponseEntity<?> listarCursosDeEspecializacao(@PathVariable int id) {
		List<Curso> cursos = cursoService.listarCursosDeEspecializacao(id);
		return ResponseEntity.ok(cursos);
	}

	@RequestMapping(value="/listarCursosTecnicos", method= RequestMethod.GET)
	public ResponseEntity<?> listarCursosTecnicos() {
		List<Curso> cursos = cursoService.listarCursosTecnicos();
		return ResponseEntity.ok(cursos);
	}

    @RequestMapping(value= {"/filtrar/{nome}", "/filtrar/"}, method= RequestMethod.GET)
    public ResponseEntity<?> listarCursosTecnicos(@PathVariable Optional<String> nome) {
		String n = nome.orElse("");
        List<Curso> cursos = cursoService.filtrar(n);
        return ResponseEntity.ok(cursos);
    }
}
