package com.arthur.apiCTEP.resources;

import java.util.List;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import com.arthur.apiCTEP.services.ServiceGenerico;

public abstract class ResourceGenerico<T, K> {
	
	ServiceGenerico<T, K> service;
	public ResourceGenerico(ServiceGenerico<T, K> service) {
		this.service = service;
	}

	@RequestMapping(value="/{key}", method=RequestMethod.GET)
	public ResponseEntity<?> find(@PathVariable K key) {
		T entity = service.buscar(key);
		return ResponseEntity.ok(entity);
	}
	
	@RequestMapping(method=RequestMethod.GET)
	public ResponseEntity<?> list() {
		List<T> entities = service.listar();
		return ResponseEntity.ok(entities);
	}

	@RequestMapping(value="/salvar", method = RequestMethod.POST)
	public ResponseEntity<?> save(@RequestBody T entity){
	    entity = service.save(entity);
	    return ResponseEntity.ok("true");
    }
}
