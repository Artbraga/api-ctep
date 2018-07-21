package com.arthur.apiCTEP.services;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public abstract class ServiceGenerico<T, K> {

	private JpaRepository<T, K> repository;

    ServiceGenerico(JpaRepository<T, K> repository) {
        this.repository = repository;
    }

	public T buscar(K key) {
		Optional<T> entity = this.repository.findById(key);
		return entity.orElse(null);
	}

	public List<T> listar(){
		return this.repository.findAll();
	}

}
