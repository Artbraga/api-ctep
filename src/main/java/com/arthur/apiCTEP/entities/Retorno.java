package com.arthur.apiCTEP.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;

import javax.persistence.*;
import java.io.Serializable;
import java.util.Date;
import java.util.List;

@Entity
@Table(name = "RETORNO")
public class Retorno implements Serializable {

    private static final long serialVersionUID = 1L;

    private Integer id;
    private Date data;
    private Integer numeroSequencia;
    private Integer numRegistros;

    private List<Titulo> titulos;

    @Id
    @Column(name = "ID")
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(name = "DATA")
    public Date getData() {
        return data;
    }

    public void setData(Date data) {
        this.data = data;
    }

    @Column(name = "NUMERO")
    public Integer getNumeroSequencia() {
        return numeroSequencia;
    }

    public void setNumeroSequencia(Integer numeroSequencia) {
        this.numeroSequencia = numeroSequencia;
    }

    @Column(name = "NUM_REGISTROS")
    public Integer getNumRegistros() {
        return numRegistros;
    }

    public void setNumRegistros(Integer numRegistros) {
        this.numRegistros = numRegistros;
    }

    ///// CONSTRUTORES /////
    public Retorno() {
    }

    public Retorno(Date data, Integer numeroSequencia) {
        this.data = data;
        this.numeroSequencia = numeroSequencia;
    }

    ///// MÉTODOS PARA ASSOCIAÇÕES /////
    @OneToMany(mappedBy = "retorno")
    @OrderBy
    @JsonIgnore
    public List<Titulo> getTitulos() {
        return titulos;
    }

    public void setTitulos(List<Titulo> titulos) {
        this.titulos = titulos;
    }
}
