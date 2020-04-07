package com.arthur.apiCTEP.entities.enums;

public enum StatusTurma {
    Teoria(1), Estágio(2), Ambos(3), Concluído(4);

    public int valor;

    StatusTurma(int valor) {
        this.valor = valor;
    }

    public static StatusTurma getStatusTurma(Integer valor){

        return valor == null ? null : StatusTurma.values()[valor-1];
    }
}
