package com.arthur.apiCTEP.entities;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import javax.persistence.*;
import java.io.Serializable;

@NamedQueries(
        @NamedQuery(
                name = "PendenciaAluno.recuperaPendenciasDeUmAluno",
                query = "select p from PendenciaAluno p where p.aluno.matricula=?1"
        )
)

@Entity
@Table(name = "PENDENCIA_ALUNO")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
public class PendenciaAluno implements Serializable{

    private static final long serialVersionUID = 1L;

    private Integer id;
    private Aluno aluno;
    private Disciplina disciplina;

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "ID")
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
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

    public PendenciaAluno(Aluno aluno, Disciplina disciplina) {
        this.aluno = aluno;
        this.disciplina = disciplina;
    }

    public PendenciaAluno() {
    }
}
