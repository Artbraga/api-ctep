package com.arthur.apiCTEP.entities;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import javax.persistence.*;
import java.io.Serializable;
import java.util.Date;
import java.util.Objects;

@Entity
@Table(name = "BOLETO")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
public class Titulo implements Serializable {

    private static final long serialVersionUID = 1L;

    private Long id;

    private String seuNumero;
    private Long nossoNumero;
    private Date dataVencimento;
    private Float valor;
    private Float custo;

    private Aluno aluno;

    private Retorno retorno;

    @Id
    @Column(name = "ID")
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    @Column(name = "SEU_NUMERO")
    public String getSeuNumero() {
        return seuNumero;
    }

    public void setSeuNumero(String seuNumero) {
        this.seuNumero = seuNumero;
    }

    @Column(name = "NOSSO_NUMERO")
    public Long getNossoNumero() {
        return nossoNumero;
    }

    public void setNossoNumero(Long nossoNumero) {
        this.nossoNumero = nossoNumero;
    }

    @Column(name = "DATA_VENCIMENTO")
    public Date getDataVencimento() {
        return dataVencimento;
    }

    public void setDataVencimento(Date dataVencimento) {
        this.dataVencimento = dataVencimento;
    }

    @Column(name = "VALOR")
    public Float getValor() {
        return valor;
    }

    public void setValor(Float valor) {
        this.valor = valor;
    }

    @Column(name = "CUSTO")
    public Float getCusto() {
        return custo;
    }

    public void setCusto(Float custo) {
        this.custo = custo;
    }

    ///// CONSTRUTORES /////
    public Titulo() {
    }

    public Titulo(String seuNumero, Long nossoNumero, Date dataVencimento, Float valor, Float custo, Aluno aluno, Retorno retorno) {
        this.seuNumero = seuNumero;
        this.nossoNumero = nossoNumero;
        this.dataVencimento = dataVencimento;
        this.valor = valor;
        this.custo = custo;
        this.aluno = aluno;
        this.retorno = retorno;
    }

    ///// MÉTODOS PARA ASSOCIAÇÕES /////
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "ALUNO_MATRICULA")
    public Aluno getAluno() {
        return aluno;
    }

    public void setAluno(Aluno aluno) {
        this.aluno = aluno;
    }

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "RETORNO_ID")
    public Retorno getRetorno() {
        return retorno;
    }

    public void setRetorno(Retorno retorno) {
        this.retorno = retorno;
    }

    ///// UTIL /////
    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Titulo titulo = (Titulo) o;
        return Objects.equals(seuNumero, titulo.seuNumero) &&
                Objects.equals(nossoNumero, titulo.nossoNumero) &&
                Objects.equals(aluno, titulo.aluno);
    }

    @Override
    public int hashCode() {
        return Objects.hash(seuNumero, nossoNumero, aluno);
    }
}