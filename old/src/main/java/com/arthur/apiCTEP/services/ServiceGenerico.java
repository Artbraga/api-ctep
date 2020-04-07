package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.exception.ObjetoNaoEncontradoException;
import org.springframework.data.jpa.repository.JpaRepository;

import java.lang.reflect.ParameterizedType;
import java.util.List;
import java.util.Optional;

public abstract class ServiceGenerico<T, K> {

	JpaRepository<T, K> repository;
	private Class<T> tipo;

	@SuppressWarnings("unchecked")
    ServiceGenerico(JpaRepository<T, K> repository) {
        this.repository = repository;
        final ParameterizedType type = (ParameterizedType) getClass().getGenericSuperclass();
        tipo = (Class<T>) (type).getActualTypeArguments()[0];
    }

	public T buscar(K key) {
		Optional<T> entity = this.repository.findById(key);
		return entity.orElseThrow(() -> new ObjetoNaoEncontradoException("Objeto não encontrado! Id: " + key + ", Tipo: " + tipo.getSimpleName()));
	}

	public List<T> listar(){
		return this.repository.findAll();
	}

	public T save(T entity){
	    return repository.save(entity);
    }

    public String delete(K key){
	    try{
            Optional<T> entity = this.repository.findById(key);
            repository.delete(entity.orElseThrow(() -> new ObjetoNaoEncontradoException(tipo.getSimpleName() +" não encontrado!")));
            return "true";
        } catch (Exception e){
	        return e.getMessage();
        }
    }
}
