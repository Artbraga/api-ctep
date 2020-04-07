package com.arthur.apiCTEP.entities.enums;

public enum Permissao {

    Administrador(0), Avancado(1), Basico(2), Consulta(3);

    public int valor;

    Permissao(int valor){
        this.valor = valor;
    }

    public static Permissao getPermissao(Integer valor){

        return valor == null ? null : Permissao.values()[valor-1];
    }
}
