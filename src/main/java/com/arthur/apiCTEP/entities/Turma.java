package com.arthur.apiCTEP.entities;

import com.arthur.apiCTEP.entities.enums.StatusTurma;

import javax.persistence.*;
import java.util.Date;
import java.util.List;

@NamedQueries({
        @NamedQuery(
                name = "Turma.recuperaTurmas",
                query = "select t from Turma t order by t.codigo desc"
        ),
        @NamedQuery(
                name = "Turma.recuperaTurmasDeUmCurso",
                query = "select t from Turma t where t.curso.id = ?1 order by t.codigo desc"
        ),
        @NamedQuery(
                name = "Turma.recuperaNumeroDeTurmasNoAno",
                query = "select t.codigo from Turma t where (t.anoInicio=?1 and t.curso.id=?2) order by t.codigo"
        ),
        @NamedQuery(
                name = "Turma.recuperaTurmasPeloCodigo",
                query = "select t from Turma t where lower(t.codigo) like lower(concat('%', ?1,'%')) "
        ),
        @NamedQuery(
                name = "Turma.recuperaTurmasPeloDiaDaSemana",
                query = "select t from Turma t where lower(t.diasDaSemana) like lower(concat('%', ?1,'%')) "
        ),
        @NamedQuery(
                name = "Turma.recuperaTurmaComProfessores",
                query = "select t from Turma t left join fetch t.professores where t.id = ?1"

        )
})

@Entity
@Table(name = "TURMA")
public class Turma {
    private String codigo;
    private String diasDaSemana;
    private String horaInicio;
    private String horaFim;
    private Date dataInicio;
    private Date dataFim;
    private Integer status;
    private Curso curso;

    private int anoInicio;

    private List<Professor> professores;
    private List<ObservacaoTurma> observacoes;
    private List<Aluno> alunos;

    @Id
    @Column(name = "CODIGO")
    public String getCodigo() {
        return codigo;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    @Column(name = "DIAS_DA_SEMANA")
    public String getDiasDaSemana() {
        return diasDaSemana;
    }

    public void setDiasDaSemana(String diasDaSemana) {
        this.diasDaSemana = diasDaSemana;
    }

    @Column(name = "HORA_INICIO")
    public String getHoraInicio() {
        return horaInicio;
    }

    public void setHoraInicio(String horaInicio) {
        this.horaInicio = horaInicio;
    }

    @Column(name = "HORA_FIM")
    public String getHoraFim() {
        return horaFim;
    }

    public void setHoraFim(String horaFim) {
        this.horaFim = horaFim;
    }

    @Column(name = "DATA_INICIO")
    public Date getDataInicio() {
        return dataInicio;
    }

    public void setDataInicio(Date dataInicio) {
        this.dataInicio = dataInicio;
    }

    @Column(name = "DATA_FIM")
    public Date getDataFim() {
        return dataFim;
    }

    public void setDataFim(Date dataFim) {
        this.dataFim = dataFim;
    }

    @Column(name = "ANO_INICIO")
    public int getAnoInicio() {
        return anoInicio;
    }

    public void setAnoInicio(int anoInicio) {
        this.anoInicio = anoInicio;
    }

    @Column(name = "STATUS")
    public Integer getStatus() {
        return status;
    }

    public void setStatus(Integer status) {
        this.status = status;
    }

    public Turma() {
    }

    @SuppressWarnings("deprecation")
	public Turma(String codigo, String diasDaSemana, String horaInicio, String horaFim, Date dataInicio, Date dataFim, StatusTurma status, Curso curso){
        this.codigo = codigo;
        this.diasDaSemana = diasDaSemana;
        this.horaInicio = horaInicio;
        this.horaFim = horaFim;
        this.dataInicio = dataInicio;
        this.dataFim = dataFim;
        this.status = status.valor;
        this.curso = curso;
        this.anoInicio = dataInicio.getYear()%100;
    }


    // ********* M�todos para Associa��es *********
    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "CURSO_ID")
    public Curso getCurso() {
        return curso;
    }

    public void setCurso(Curso curso) {
        this.curso = curso;
    }

    @ManyToMany(fetch = FetchType.LAZY)
    @JoinTable(name = "PROFESSOR_TURMA", joinColumns = {@JoinColumn(name = "TURMA_CODIGO")}, inverseJoinColumns = {@JoinColumn(name = "PROFESSOR_ID")})
    public List<Professor> getProfessores() {
        return professores;
    }

    public void setProfessores(List<Professor> professores) {
        this.professores = professores;
    }

    @OneToMany(mappedBy = "turma")
    @OrderBy
    public List<ObservacaoTurma> getObservacoes() {
        return observacoes;
    }

    public void setObservacoes(List<ObservacaoTurma> observacoes) {
        this.observacoes = observacoes;
    }

    @OneToMany(mappedBy = "turma")
    @OrderBy
    public List<Aluno> getAlunos() {
        return alunos;
    }

    public void setAlunos(List<Aluno> alunos) {
        this.alunos = alunos;
    }
}
