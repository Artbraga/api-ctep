package com.arthur.apiCTEP.entities;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToMany;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.OrderBy;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@NamedQueries({
        @NamedQuery(
                name = "Professor.recuperaUmProfessorPeloNome",
                query = "select p from Professor p where p.nome = ?1"
        ),
        @NamedQuery(
                name = "Professor.recuperaProfessores",
                query = "select p from Professor p order by p.id"
        ),
        @NamedQuery(
                name = "Professor.recuperaUmProfessorERecibos",
                query = "select p from Professor p left outer join fetch p.recibos where p.id = ?1"
        ),
        @NamedQuery(
                name = "Professor.recuperaProfessoresPeloNome",
                query = "select p from Professor p where lower(p.nome) like lower(concat('%', ?1,'%'))"
        )
})

@Entity
@Table(name = "PROFESSOR")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
public class Professor implements Serializable{

	private static final long serialVersionUID = 1L;
	
    private String nome;
    private Long id;
    private String cpf;
    private String rg;
    private String endereco;

    private String email;
    private String telefone;
    private String celular;

    private Date dataNascimento;

    private List<ReciboProfessor> recibos;
    private List<Turma> turmas;

    @Id
    @GeneratedValue(strategy=GenerationType.AUTO)
    @Column(name = "ID")
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    @Column(name = "CPF")

    public String getCpf() {
        return cpf;
    }

    public void setCpf(String cpf) {
        this.cpf = cpf;
    }

    @Column(name = "RG")
    public String getRg() {
        return rg;
    }

    public void setRg(String rg) {
        this.rg = rg;
    }

    @Column(name = "NOME")
    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    @Column(name = "ENDERECO")
    public String getEndereco() {
        return endereco;
    }

    public void setEndereco(String endereco) {
        this.endereco = endereco;
    }

    @Column(name = "EMAIL")
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Column(name = "TELEFONE")
    public String getTelefone() {
        return telefone;
    }

    public void setTelefone(String telefone) {
        this.telefone = telefone;
    }

    @Column(name = "CELULAR")
    public String getCelular() {
        return celular;
    }

    public void setCelular(String celular) {
        this.celular = celular;
    }

    @Column(name = "DATA_NASCIMENTO")
    public Date getDataNascimento() {
        return dataNascimento;
    }

    public void setDataNascimento(Date dataNascimento) {
        this.dataNascimento = dataNascimento;
    }

    ///// CONSTRUTORES /////
    public Professor(){
    }

    public Professor(String nome, String cpf, String rg, String endereco, String email, String telefone, String celular, Date dataNascimento) {
        this.nome = nome;
        this.cpf = cpf;
        this.rg = rg;
        this.endereco = endereco;
        this.email = email;
        this.telefone = telefone;
        this.celular = celular;
        this.dataNascimento = dataNascimento;
    }

    // ********* M�todos para Associa��es *********

    /*
     * Com o atributo mappedBy. Sem ele a  JPA ir� procurar  pela
     * tabela PRODUTO_LANCE. Com ele, ao se  tentar recuperar  um
     * produto  e  todos  os  seus  lances, o  join de PRODUTO  e
     * LANCE ir� acontecer atrav�s da chave estrangeira existente
     * em  LANCE.  Sem  ele  a  JPA  ir�  procurar  pela   tabela
     * PRODUTO_LANCE.
     */
    @OneToMany(mappedBy = "professor")
    @OrderBy
    @JsonIgnore
    public List<ReciboProfessor> getRecibos() {
        return recibos;
    }

    public void setRecibos(List<ReciboProfessor> recibos) {
        this.recibos = recibos;
    }

    @ManyToMany(mappedBy = "professores")
    @JsonIgnore
    public List<Turma> getTurmas() {
        return turmas;
    }

    public void setTurmas(List<Turma> turmas) {
        this.turmas = turmas;
    }

    // ********* Util *********
    @Override
    public String toString() {
        return this.id + " - " + this.nome;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Professor professor = (Professor) o;

        if (nome != null ? !nome.equals(professor.nome) : professor.nome != null) return false;
        if (id != null ? !id.equals(professor.id) : professor.id != null) return false;
        if (cpf != null ? !cpf.equals(professor.cpf) : professor.cpf != null) return false;
        if (rg != null ? !rg.equals(professor.rg) : professor.rg != null) return false;
        if (endereco != null ? !endereco.equals(professor.endereco) : professor.endereco != null) return false;
        if (email != null ? !email.equals(professor.email) : professor.email != null) return false;
        if (telefone != null ? !telefone.equals(professor.telefone) : professor.telefone != null) return false;
        if (celular != null ? !celular.equals(professor.celular) : professor.celular != null) return false;
        if (dataNascimento != null ? !dataNascimento.equals(professor.dataNascimento) : professor.dataNascimento != null)
            return false;
        return true;
    }

    @Override
    public int hashCode() {
        int result = nome != null ? nome.hashCode() : 0;
        result = 31 * result + (id != null ? id.hashCode() : 0);
        result = 31 * result + (cpf != null ? cpf.hashCode() : 0);
        result = 31 * result + (rg != null ? rg.hashCode() : 0);
        result = 31 * result + (endereco != null ? endereco.hashCode() : 0);
        result = 31 * result + (email != null ? email.hashCode() : 0);
        result = 31 * result + (telefone != null ? telefone.hashCode() : 0);
        result = 31 * result + (celular != null ? celular.hashCode() : 0);
        result = 31 * result + (dataNascimento != null ? dataNascimento.hashCode() : 0);
        result = 31 * result + (recibos != null ? recibos.hashCode() : 0);
        result = 31 * result + (turmas != null ? turmas.hashCode() : 0);
        return result;
    }
}
