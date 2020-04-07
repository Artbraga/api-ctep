package com.arthur.apiCTEP.entities;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.OrderBy;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@NamedQueries({
        @NamedQuery(
                name = "Hospital.recuperaHospitais",
                query = "select h from Hospital h order by h.nome"
        ),
})

@Entity
@Table(name = "HOSPITAL")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
public class Hospital implements Serializable{

	private static final long serialVersionUID = 1L;
	
    private Integer id;
    private String nome;

    List<EstagioAluno> estagios;

    @Column(name = "ID")
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
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
    @JsonIgnore	
    public List<EstagioAluno> getEstagios() {
        return estagios;
    }

    public void setEstagios(List<EstagioAluno> estagios) {
        this.estagios = estagios;
    }
}
