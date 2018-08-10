package com.arthur.apiCTEP.resources;

import com.arthur.apiCTEP.services.TurmaService;
import net.minidev.json.JSONObject;
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

    @RequestMapping(value="/gerarCodigo/{ano}&{cursoId}", method= RequestMethod.GET)
    public ResponseEntity<?> listarCursosDeEspecializacao(@PathVariable int ano, @PathVariable int cursoId) {
        String codigo = turmaService.gerarCodigo(cursoId, ano);
        JSONObject json = new JSONObject();

        json.put("data", codigo);

        return ResponseEntity.ok(json);
    }

    @RequestMapping(value="/filtrarTurmasDeUmCurso/{codigo}&{cursoId}", method= RequestMethod.GET)
    public ResponseEntity<?> filtrarTurmasDeUmCurso(@PathVariable String codigo, @PathVariable int cursoId) {
        List<Turma> turmas = turmaService.filtrarTurmasAtivasDeUmCurso(codigo, cursoId);

        return ResponseEntity.ok(turmas);
    }
}
