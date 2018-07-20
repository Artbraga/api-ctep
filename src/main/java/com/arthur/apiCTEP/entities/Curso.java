package com.arthur.apiCTEP.entities;

import javax.persistence.*;

import java.io.Serializable;
import java.util.List;

@NamedQueries({
        @NamedQuery(
                name = "Curso.recuperaCursos",
                query = "select c from Curso c order by c.nome"
        ),
        @NamedQuery(
                name = "Curso.recuperaCursosDeEspecializacao",
                query = "select c from Curso c where c.especializacao=TRUE and c.cursoVinculado.id=?1"
        ),
        @NamedQuery(
                name = "Curso.recuperaCursosTecnicos",
                query = "select c from Curso c where c.especializacao=FALSE order by c.nome"
        )

})
@Entity
@Table(name = "CURSO")
public class Curso implements Serializable{

	private static final long serialVersionUID = 1L;
	
	private Integer id;
    private String nome;
    private String sigla;
    private String siglaTurma;
    private boolean especializacao;
    private Curso cursoVinculado;

    private List<Disciplina> disciplinas;
    private List<Turma> turmas;
    private List<Aluno> alunos;
    private List<Curso> especializacoes;

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "ID")
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(name = "NOME")
    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    @Column(name = "SIGLA")
    public String getSigla() {
        return sigla;
    }

    public void setSigla(String sigla) {
        this.sigla = sigla;
    }

    @Column(name = "SIGLA_TURMA")
    public String getSiglaTurma() {
        return siglaTurma;
    }

    public void setSiglaTurma(String siglaTurma) {
        this.siglaTurma = siglaTurma;
    }

    @Column(name = "ESPECIALIZACAO")
    public boolean getEspecializacao() {
        return especializacao;
    }

    public void setEspecializacao(boolean especializacao) {
        this.especializacao = especializacao;
    }

    @ManyToOne(cascade={CascadeType.ALL})
    @JoinColumn(name = "CURSO_VINCULADO")
    public Curso getCursoVinculado() {
        return cursoVinculado;
    }

    public void setCursoVinculado(Curso cursoVinculado) {
        this.cursoVinculado = cursoVinculado;
    }

    public Curso() {
    }

    public Curso(String nome, String sigla, String siglaTurma, boolean especializacao){
        this.nome = nome;
        this.sigla = sigla;
        this.siglaTurma = siglaTurma;
        this.especializacao = especializacao;
    }

    public Curso(String nome, String sigla, List<Disciplina> disciplinas) {
        this.nome = nome;
        this.sigla = sigla;
        this.disciplinas = disciplinas;
    }

    // ********* M�todos para Associa��es *********
    @OneToMany(mappedBy = "curso")
    @OrderBy
    public List<Disciplina> getDisciplinas() {
        return disciplinas;
    }

    public void setDisciplinas(List<Disciplina> disciplinas) {
        this.disciplinas = disciplinas;
    }

    @OneToMany(mappedBy= "curso")
    @OrderBy
    public List<Turma> getTurmas() {
        return turmas;
    }

    public void setTurmas(List<Turma> turmas) {
        this.turmas = turmas;
    }

    @OneToMany(mappedBy= "curso")
    @OrderBy
    public List<Aluno> getAlunos() {
        return alunos;
    }

    public void setAlunos(List<Aluno> alunos) {
        this.alunos = alunos;
    }

    @OneToMany(mappedBy = "id")
    public List<Curso> getEspecializacoes() {
        return especializacoes;
    }

    public void setEspecializacoes(List<Curso> especializacoes) {
        this.especializacoes = especializacoes;
    }

    @Override
    public String toString() {
        return id + " - " + nome;
    }
}
