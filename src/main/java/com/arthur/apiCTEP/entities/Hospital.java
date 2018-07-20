package com.arthur.apiCTEP.entities;

import javax.persistence.*;
import java.util.List;

@NamedQueries({
        @NamedQuery(
                name = "Hospital.recuperaHospitais",
                query = "select h from Hospital h order by h.nome"
        ),
})

@Entity
@Table(name = "HOSPITAL")
public class Hospital {
    private Integer id;
    private String nome;

    List<EstagioAluno> estagios;

    @Column(name = "ID")
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
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

    // ********* Construtor *********


    public Hospital(String nome) {
        this.nome = nome;
    }

    public Hospital() {

    }

    // ********* M�todos para Associa��es *********
    @OneToMany(mappedBy= "hospital")
    @OrderBy
    public List<EstagioAluno> getEstagios() {
        return estagios;
    }

    public void setEstagios(List<EstagioAluno> estagios) {
        this.estagios = estagios;
    }
}
