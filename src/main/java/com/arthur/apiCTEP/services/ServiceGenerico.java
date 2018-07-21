package com.arthur.apiCTEP.services;

import java.util.List;

public interface ServiceGenerico<T, K> {
	T buscar(K key);
	
	List<T> listar();

}
