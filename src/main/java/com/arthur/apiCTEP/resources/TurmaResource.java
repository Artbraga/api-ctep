package com.arthur.apiCTEP.resources;

import com.arthur.apiCTEP.services.TurmaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.arthur.apiCTEP.entities.Turma;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping(value="/turmas")
public class TurmaResource extends ResourceGenerico<Turma, String>{

    private TurmaService turmaService;
    @Autowired
    public TurmaResource(TurmaService turmaService) {
        super(turmaService);
        this.turmaService = (TurmaService) this.service;
    }

    @RequestMapping(value= { "/filtrarTurmasDropdown/", "/filtrarTurmasDropdown/{codigo}" }, method= RequestMethod.GET)
    public ResponseEntity<?> listarTurmasDropdown(@PathVariable Optional<String> codigo) {
        String c = codigo.orElse("");
        List<Turma> turmas = turmaService.filtrarTurmasAtivas(c);
        return ResponseEntity.ok(turmas);
    }

}
