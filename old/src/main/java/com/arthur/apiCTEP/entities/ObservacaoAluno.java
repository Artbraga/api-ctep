package com.arthur.apiCTEP.entities;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@NamedQueries({
        @NamedQuery(
                name = "ObservacaoAluno.recuperaObservacoesDeUmAluno",
                query = "select o from ObservacaoAluno o where o.aluno.matricula=?1 order by o.id"
        )

})

@Entity
@Table(name = "OBSERVACAO_ALUNO")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
public class ObservacaoAluno implements Serializable{

	private static final long serialVersionUID = 1L;
	
    private Long id;
    private String obs;
    private Aluno aluno;
    private Date data;

    @Id
    @Column(name = "ID")
    @GeneratedValue(strategy = GenerationType.AUTO)
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    @Column(name = "OBS")
    public String getObs() {
        return obs;
    }

    public void setObs(String obs) {
        this.obs = obs;
    }

    @Column(name = "DATA")
    public Date getData() {
        return data;
    }

    public void setData(Date data) {
        this.data = data;
    }

    public ObservacaoAluno() {
    }

    public ObservacaoAluno(String obs, Date data) {
        this.obs = obs;
        this.data = data;
    }

    // ********* M�todos para Associa��es *********
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "ALUNO_MATRICULA")
    public Aluno getAluno() {
        return aluno;
    }

    public void setAluno(Aluno aluno) {
        this.aluno = aluno;
    }

    @Override
    public String toString() {
        return data + " - " +obs;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        ObservacaoAluno that = (ObservacaoAluno) o;

        if (id != null ? !id.equals(that.id) : that.id != null) return false;
        return obs != null ? obs.equals(that.obs) : that.obs == null;
    }

    @Override
    public int hashCode() {
        int result = id != null ? id.hashCode() : 0;
        result = 31 * result + (obs != null ? obs.hashCode() : 0);
        result = 31 * result + (data != null ? data.hashCode() : 0);
        result = 31 * result + (aluno != null ? aluno.hashCode() : 0);
        return result;
    }
}
