package com.arthur.apiCTEP.entities;

import javax.persistence.*;
import java.util.List;

@NamedQueries({
        @NamedQuery(
                name = "ModalidadeEstagio.recuperaModalidadesEstagio",
                query = "select m from ModalidadeEstagio m order by m.modalidade"
        ),
        @NamedQuery(
                name = "ModalidadeEstagio.recuperaModalidadesDeUmCurso",
                query = "select m from ModalidadeEstagio m where m.curso.id=?1 order by m.modalidade"
        )

})

@Entity
@Table(name = "MODALIDADE_ESTAGIO")
public class ModalidadeEstagio {
    private Integer id;
    private String modalidade;

    private Curso curso;

    private List<EstagioAluno> estagioAlunos;

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ID")
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(name = "MODALIDADE")
    public String getModalidade() {
        return modalidade;
    }

    public void setModalidade(String modalidade) {
        this.modalidade = modalidade;
    }

    // ********* Construtor *********

    public ModalidadeEstagio(String modalidade, Curso curso) {
        this.modalidade = modalidade;
        this.curso = curso;
    }

    public ModalidadeEstagio() {
    }

    // ********* M�todos para Associa��es *********
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "CURSO_ID")
    public Curso getCurso() {
        return curso;
    }

    public void setCurso(Curso curso) {
        this.curso = curso;
    }

    @OneToMany(mappedBy = "modalidadeEstagio")
    @OrderBy
    public List<EstagioAluno> getEstagioAlunos() {
        return estagioAlunos;
    }

    public void setEstagioAlunos(List<EstagioAluno> estagioAlunos) {
        this.estagioAlunos = estagioAlunos;
    }
}
