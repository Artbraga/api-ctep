package com.arthur.apiCTEP.entities;

import javax.persistence.*;
import java.util.Date;

@NamedQueries({
        @NamedQuery(
                name = "ReciboProfessor.recuperaRecibosProfessor",
                query = "select r from ReciboProfessor r order by r.id"
        ),
        @NamedQuery(
                name = "ReciboProfessor.recuperaUltimoReciboProfessor",
                query = "select r from ReciboProfessor r where r.professor.id = ?1 order by r.id desc"
        ),
        @NamedQuery(
                name = "ReciboProfessor.recuperaRecibosProfessorData",
                query = "select r from ReciboProfessor r where r.dataRecibo > ?1 and r.dataRecibo < ?2  order by r.id"
        ),
        @NamedQuery(
                name = "ReciboProfessor.recuperaRecibosDeUmProfessor",
                query = "select r from ReciboProfessor r where r.professor.id=?1  order by r.id"
        )
})

@Entity
@Table(name = "RECIBO_PROFESSOR")

public class ReciboProfessor {
    private Long id;
    private float valor;
    private Date dataRecibo;
    private String descricao;

    private Professor professor;

    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name = "ID")
    public Long getId() {

        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    @Column(name = "VALOR")
    public float getValor() {
        return valor;
    }

    public void setValor(float valor) {
        this.valor = valor;
    }

    @Column(name = "DATA_RECIBO")
    @Temporal(value = TemporalType.DATE)
    public Date getDataRecibo() {
        return dataRecibo;
    }

    public void setDataRecibo(Date dataRecibo) {
        this.dataRecibo = dataRecibo;
    }

    public String getDescricao() {
        return descricao;
    }

    @Column(name = "DESCRICAO")
    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }


    // ********* M�todos para Associa��es *********

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "PROFESSOR_ID")
    public Professor getProfessor() {
        return professor;
    }

    public void setProfessor(Professor professor) {
        this.professor = professor;
    }

    ///// CONSTRUTORES /////
    public ReciboProfessor(){
    }

    public ReciboProfessor(float valor, Date dataRecibo, String descricao, Professor professor) {
        this.valor = valor;
        this.dataRecibo = dataRecibo;
        this.descricao = descricao;
        this.professor = professor;
    }
}
