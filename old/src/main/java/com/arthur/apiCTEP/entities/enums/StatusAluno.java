package com.arthur.apiCTEP.entities.enums;

public enum StatusAluno {
    Ativo(1), Trancado(2), Reprovado(3), Concluido(4);

    public int valor;

    StatusAluno(int valor) {
        this.valor = valor;
    }

    public static StatusAluno getStatusAluno(Integer valor){

        return valor == null ? null : StatusAluno.values()[valor-1];
    }
}
