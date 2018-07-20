package com.arthur.apiCTEP.entities;

import javax.persistence.*;
import java.util.Date;

@NamedQueries({
        @NamedQuery(
                name = "ObservacaoAluno.recuperaObservacoesDeUmAluno",
                query = "select o from ObservacaoAluno o where o.aluno.matricula=?1 order by o.id"
        )

})

@Entity
@Table(name = "OBSERVACAO_ALUNO")
public class ObservacaoAluno {
    private Long id;
    private String obs;
    private Aluno aluno;
    private Date data;

    @Id
    @Column(name = "ID")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
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
    @ManyToOne(fetch = FetchType.EAGER)
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
