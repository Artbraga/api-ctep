package com.arthur.apiCTEP.resources;

import com.arthur.apiCTEP.entities.Curso;
import com.arthur.apiCTEP.services.CursoService;
import com.arthur.apiCTEP.services.ServiceGenerico;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(value="/cursos")
public class CursoResource extends ResourceGenerico<Curso, Integer>{

	@Autowired
	public CursoResource(CursoService service) {
		super(service);
	}
}
