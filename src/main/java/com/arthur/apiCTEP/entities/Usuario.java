package com.arthur.apiCTEP.entities;

import com.arthur.apiCTEP.entities.enums.Permissao;

import javax.persistence.*;

@NamedQuery(
        name = "Usuario.recuperaUsuarioPeloLogin",
        query = "select u from Usuario u where u.login = ?1"
)

@Entity
@Table(name = "USUARIO")

public class Usuario {
    private Integer id;
    private String nome;
    private String login;
    private String senha;
    private String telefone;
    private int permissao;

    @Id
    @GeneratedValue(strategy=GenerationType.AUTO)
    @Column(name = "ID")
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

    @Column(name = "LOGIN")
    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    @Column(name = "SENHA")
    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    @Column(name = "TELEFONE")
    public String getTelefone() {
        return telefone;
    }

    public void setTelefone(String telefone) {
        this.telefone = telefone;
    }

    @Column(name = "PERMISSAO")
    public int getPermissao() {
        return permissao;
    }

    public void setPermissao(int permissao) {
        this.permissao = permissao;
    }

    public Usuario() {
    }

    public Usuario(String nome, String login, String senha, String telefone, Permissao permissao) {
        this.nome = nome;
        this.login = login;
        this.senha = senha;
        this.telefone = telefone;
        this.permissao = permissao.valor;
    }
}
