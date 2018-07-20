package com.arthur.apiCTEP.entities;

import javax.persistence.*;
import java.util.Date;

@NamedQueries({
        @NamedQuery(
                name = "ObservacaoTurma.recuperaObservacoesDeTurma",
                query = "select o from ObservacaoTurma o where o.turma.codigo=?1 order by o.id"
        )

})

@Entity
@Table(name = "OBSERVACAO_TURMA")
public class ObservacaoTurma {
    private Long id;
    private String obs;
    private Date data;
    private Turma turma;

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "ID")
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

    public ObservacaoTurma(String obs, Date data) {
        this.obs = obs;
        this.data = data;
    }

    public ObservacaoTurma(){

    }

    public ObservacaoTurma(String obs, Date data, Turma turma) {
        this.obs = obs;
        this.data = data;
        this.turma = turma;
    }

    // ********* M�todos para Associa��es *********
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "CODIGO_TURMA")
    public Turma getTurma() {
        return turma;
    }

    public void setTurma(Turma turma) {
        this.turma = turma;
    }

    @Override
    public String toString() {
        return data + " - " + obs;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        ObservacaoTurma that = (ObservacaoTurma) o;

        if (id != null ? !id.equals(that.id) : that.id != null) return false;
        return obs != null ? obs.equals(that.obs) : that.obs == null;
    }

    @Override
    public int hashCode() {
        int result = id != null ? id.hashCode() : 0;
        result = 31 * result + (obs != null ? obs.hashCode() : 0);
        result = 31 * result + (data != null ? data.hashCode() : 0);
        result = 31 * result + (turma != null ? turma.hashCode() : 0);
        return result;
    }
}
