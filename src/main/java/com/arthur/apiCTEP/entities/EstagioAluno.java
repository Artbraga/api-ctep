package com.arthur.apiCTEP.entities;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name = "ESTAGIO_ALUNO")
public class EstagioAluno {
    private Long id;
    private Date data;
    private String horaEntrada;
    private String horaSaida;
    private String totalDia;

    private Hospital hospital;
    private ModalidadeEstagio modalidadeEstagio;
    private Aluno aluno;

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ID")
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    @Column(name = "DATA")
    public Date getData() {
        return data;
    }

    public void setData(Date data) {
        this.data = data;
    }

    @Column(name = "HORA_ENTRADA")
    public String getHoraEntrada() {
        return horaEntrada;
    }

    public void setHoraEntrada(String horaEntrada) {
        this.horaEntrada = horaEntrada;
    }

    @Column(name = "HORA_SAIDA")
    public String getHoraSaida() {
        return horaSaida;
    }

    public void setHoraSaida(String horaSaida) {
        this.horaSaida = horaSaida;
    }

    @Column(name = "TOTAL_DIA")
    public String getTotalDia() {
        return totalDia;
    }

    public void setTotalDia(String totalDia) {
        this.totalDia = totalDia;
    }

    public EstagioAluno() {
    }

    public EstagioAluno(Date data, String horaEntrada, String horaSaida, String totalDia, Hospital hospital, ModalidadeEstagio modalidade, Aluno aluno){
        this.data = data;
        this.horaEntrada = horaEntrada;
        this.horaSaida = horaSaida;
        this.totalDia = totalDia;
        this.hospital = hospital;
        this.modalidadeEstagio = modalidade;
        this.aluno = aluno;
    }

// ********* M�todos para Associa��es *********

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "HOSPITAL_ID")
    public Hospital getHospital() {
        return hospital;
    }

    public void setHospital(Hospital hospital) {
        this.hospital = hospital;
    }

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "MODALIDADE_ESTAGIO_ID")
    public ModalidadeEstagio getModalidadeEstagio() {
        return modalidadeEstagio;
    }

    public void setModalidadeEstagio(ModalidadeEstagio modalidadeEstagio) {
        this.modalidadeEstagio = modalidadeEstagio;
    }

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "ALUNO_MATRICULA")
    public Aluno getAluno() {
        return aluno;
    }

    public void setAluno(Aluno aluno) {
        this.aluno = aluno;
    }
}
