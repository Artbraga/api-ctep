package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Usuario;
import com.arthur.apiCTEP.repositories.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UsuarioService extends ServiceGenerico<Usuario,Integer>{

    @Autowired
    public UsuarioService(UsuarioRepository repository) {
        super(repository);
    }
}
