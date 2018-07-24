package com.arthur.apiCTEP.entities;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.OrderBy;
import javax.persistence.Table;

import com.arthur.apiCTEP.entities.enums.StatusAluno;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@NamedQueries({
        @NamedQuery(
                name = "Aluno.recuperaUmAlunoPeloNome",
                query = "select a from Aluno a where a.nome = ?1"
        ),
        @NamedQuery(
                name = "Aluno.recuperaAlunos",
                query = "select a from Aluno a order by a.nome"
        ),
        @NamedQuery(
                name = "Aluno.recuperaAlunosDeUmaTurma",
                query = "select a from Aluno a where a.turma.codigo=?1  order by a.nome"
        ),
        @NamedQuery(
                name = "Aluno.recuperaAlunosDeUmCurso",
                query = "select a from Aluno a where a.curso.id=?1  order by a.nome"
        ),
        @NamedQuery(
                name = "Aluno.recuperaNumeroDeAlunosParaMatricula",
                query = "select a.matricula from Aluno a where (a.anoMatricula=?1 and a.curso.id=?2) order by a.matricula"
        ),
        @NamedQuery(
                name = "Aluno.filtrarPelaMatricula",
                query = "select a from Aluno a where lower(a.matricula) like lower(concat('%', ?1,'%'))"
        ),
        @NamedQuery(
                name = "Aluno.filtrarPeloNome",
                query = "select a from Aluno a where lower(a.nome) like lower(concat('%', ?1,'%'))"
        )
})


@Entity
@Table(name = "ALUNO")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
public class Aluno implements Serializable{
	private static final long serialVersionUID = 1L;
	
	private String matricula;
    private String nome;
    private String cpf;
    private String rg;

    private String endereco;
    private String cep;
    private String complemento;
    private String bairro;
    private String cidade;
    private String email;
    private String telefone;
    private String celular;

    private String nomePai;
    private String nomeMae;

    private boolean notaFiscal;

    private Date dataMatricula;
    private Date dataNascimento;
    private Date dataValidade;
    private String cursoAnterior;
    private int anoMatricula;

    private Integer status;

    private Turma turma;
    private Turma turmaEspecializacao;

    private Curso curso;

    private List<ObservacaoAluno> observacoes;
    private List<EstagioAluno> estagios;

    @Id
    @Column(name = "MATRICULA")
    public String getMatricula() {
        return matricula;
    }

    public void setMatricula(String matricula) {
        this.matricula = matricula;
    }

    @Column(name = "NOME")
    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    @Column(name = "CPF")
    public String getCpf() {
        return cpf;
    }

    public void setCpf(String cpf) {
        this.cpf = cpf;
    }

    @Column(name = "RG")
    public String getRg() {
        return rg;
    }

    public void setRg(String rg) {
        this.rg = rg;
    }

    @Column(name = "ENDERECO")
    public String getEndereco() {
        return endereco;
    }

    public void setEndereco(String endereco) {
        this.endereco = endereco;
    }

    @Column(name = "CEP")
    public String getCep() {
        return cep;
    }

    public void setCep(String cep) {
        this.cep = cep;
    }

    @Column(name = "COMPLEMENTO")
    public String getComplemento() {
        return complemento;
    }

    public void setComplemento(String complemento) {
        this.complemento = complemento;
    }

    @Column(name = "BAIRRO")
    public String getBairro() {
        return bairro;
    }

    public void setBairro(String bairro) {
        this.bairro = bairro;
    }

    @Column(name = "CIDADE")
    public String getCidade() {
        return cidade;
    }

    public void setCidade(String cidade) {
        this.cidade = cidade;
    }

    @Column(name = "EMAIL")
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Column(name = "TELEFONE")
    public String getTelefone() {
        return telefone;
    }

    public void setTelefone(String telefone) {
        this.telefone = telefone;
    }

    @Column(name = "CELULAR")
    public String getCelular() {
        return celular;
    }

    public void setCelular(String celular) {
        this.celular = celular;
    }

    @Column(name = "NOME_PAI")
    public String getNomePai() {
        return nomePai;
    }

    public void setNomePai(String nomePai) {
        this.nomePai = nomePai;
    }

    @Column(name = "NOME_MAE")
    public String getNomeMae() {
        return nomeMae;
    }

    public void setNomeMae(String nomeMae) {
        this.nomeMae = nomeMae;
    }

    @Column(name = "NOTA_FISCAL")
    public boolean getNotaFiscal() {
        return notaFiscal;
    }

    public void setNotaFiscal(boolean notaFiscal) {
        this.notaFiscal = notaFiscal;
    }

    @Column(name = "DATA_MATRICULA")
    public Date getDataMatricula() {
        return dataMatricula;
    }

    public void setDataMatricula(Date dataMatricula) {
        this.dataMatricula = dataMatricula;
    }

    @Column(name = "DATA_NASCIMENTO")
    public Date getDataNascimento() {
        return dataNascimento;
    }

    public void setDataNascimento(Date dataNascimento) {
        this.dataNascimento = dataNascimento;
    }

    @Column(name = "DATA_VALIDADE")
    public Date getDataValidade() {
        return dataValidade;
    }

    public void setDataValidade(Date dataValidade) {
        this.dataValidade = dataValidade;
    }

    @Column(name = "CURSO_ANTERIOR")
    public String getCursoAnterior() {
        return cursoAnterior;
    }

    public void setCursoAnterior(String cursoAnterior) {
        this.cursoAnterior = cursoAnterior;
    }

    @Column(name = "ANO_MATRICULA")
    public int getAnoMatricula() {
        return anoMatricula;
    }

    public void setAnoMatricula(int anoMatricula) {
        this.anoMatricula = anoMatricula;
    }

    @Column(name = "STATUS")
    public Integer getStatus() {
        return status;
    }

    public void setStatus(Integer status) {
        this.status = status;
    }

    ///// CONSTRUTORES /////
    public Aluno() {
    }

    @SuppressWarnings("deprecation")
	public Aluno(String matricula, String nome, String cpf, String rg, String endereco, String cep, String complemento, String bairro, String cidade, String email, String telefone, String celular, String nomePai, String nomeMae, boolean notaFiscal, Date dataMatricula, Date dataNascimento, Date dataValidade, String cursoAnterior, StatusAluno status, Curso curso, Turma turma) {
        this.matricula = matricula;
        this.nome = nome;
        this.cpf = cpf;
        this.rg = rg;
        this.endereco = endereco;
        this.cep = cep;
        this.complemento = complemento;
        this.bairro = bairro;
        this.cidade = cidade;
        this.email = email;
        this.telefone = telefone;
        this.celular = celular;
        this.nomePai = nomePai;
        this.nomeMae = nomeMae;
        this.notaFiscal = notaFiscal;
        this.dataMatricula = dataMatricula;
        this.dataNascimento = dataNascimento;
        this.dataValidade = dataValidade;
        this.cursoAnterior = cursoAnterior;
        this.anoMatricula = dataMatricula.getYear()%100;
        this.status = status != null ? status.valor : null;
        this.curso = curso;
        this.turma = turma;
    }

    // ********* M�todos para Associa��es *********
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "TURMA_ID")
    public Turma getTurma() {
        return turma;
    }

    public void setTurma(Turma turma) {
        this.turma = turma;
    }

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "TURMA_ESPECIALIZACAO_ID")
    public Turma getTurmaEspecializacao() {
        return turmaEspecializacao;
    }

    public void setTurmaEspecializacao(Turma turmaEspecializacao) {
        this.turmaEspecializacao = turmaEspecializacao;
    }

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "CURSO_ID")
    public Curso getCurso() {
        return curso;
    }

    public void setCurso(Curso curso) {
        this.curso = curso;
    }

    @OneToMany(mappedBy = "aluno")
    @OrderBy
    @JsonIgnore
    public List<ObservacaoAluno> getObservacoes() {
        return observacoes;
    }

    public void setObservacoes(List<ObservacaoAluno> observacoes) {
        this.observacoes = observacoes;
    }

    // ********* Utils *********


    @Override
    public String toString() {
        return matricula + " - " + nome;
    }
}
