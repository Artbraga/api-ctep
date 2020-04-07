package com.arthur.apiCTEP.entities;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@NamedQueries({
    @NamedQuery(
            name = "NotaAluno.recuperaNotasDeUmAluno",
            query = "select n from NotaAluno n where n.aluno.matricula=?1"
    ),
})

@Entity
@Table(name = "NOTA_ALUNO")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
public class NotaAluno implements Serializable{

	private static final long serialVersionUID = 1L;
	
    private Long id;
    private Aluno aluno;
    private Disciplina disciplina;
    private Float nota;

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "ID")
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "ALUNO_MATRICULA")
    public Aluno getAluno() {
        return aluno;
    }

    public void setAluno(Aluno aluno) {
        this.aluno = aluno;
    }
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "DISCIPLINA_ID")
    public Disciplina getDisciplina() {
        return disciplina;
    }

    public void setDisciplina(Disciplina disciplina) {
        this.disciplina = disciplina;
    }

    @Column(name = "NOTA")
    public Float getNota() {
        return nota;
    }

    public void setNota(Float nota) {
        this.nota = nota;
    }

    public NotaAluno(Aluno aluno, Disciplina disciplina, Float nota) {
        this.aluno = aluno;
        this.disciplina = disciplina;
        this.nota = nota;
    }

    public NotaAluno() {
    }
}
