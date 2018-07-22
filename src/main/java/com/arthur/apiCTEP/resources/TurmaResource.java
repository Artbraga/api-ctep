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

@RestController
@RequestMapping(value="/turmas")
public class TurmaResource extends ResourceGenerico<Turma, String>{

    private TurmaService turmaService;
    @Autowired
    public TurmaResource(TurmaService turmaService) {
        super(turmaService);
        this.turmaService = (TurmaService) this.service;
    }

    @RequestMapping(value="/listarTurmasDropdown", method= RequestMethod.GET)
    public ResponseEntity<?> listarTurmasDropdown() {
        List<Turma> turmas = turmaService.listarTurmasAtivas();
        return ResponseEntity.ok(turmas);
    }

}
