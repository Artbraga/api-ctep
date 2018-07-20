package com.arthur.apiCTEP.entities;

import javax.persistence.*;

@NamedQueries({
    @NamedQuery(
            name = "NotaAluno.recuperaNotasDeUmAluno",
            query = "select n from NotaAluno n where n.aluno.matricula=?1"
    ),
})

@Entity
@Table(name = "NOTA_ALUNO")
public class NotaAluno {
    private Long id;
    private Aluno aluno;
    private Disciplina disciplina;
    private Float nota;

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
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
