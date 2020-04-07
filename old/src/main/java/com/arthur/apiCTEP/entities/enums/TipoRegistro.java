package com.arthur.apiCTEP.entities.enums;

public enum TipoRegistro {
    HeaderArquivo(0),
    HeaderLote(1),
    Detalhe(3),
    TrailerLote(5),
    TrailerArquivo(9);

    public int valor;

    TipoRegistro(int valor) {
        this.valor = valor;
    }

    public static TipoRegistro getTipoRegistro(Integer valor){
        if(valor == null) return null;
        TipoRegistro[] values = TipoRegistro.values();
        for (TipoRegistro tipo : values){
            if(tipo.valor == valor)
                return tipo;
        }
        return null;
    }

    public static TipoRegistro getTipoRegistro(String valor){
        if(valor == null) return null;
        TipoRegistro[] values = TipoRegistro.values();
        for (TipoRegistro tipo : values){
            if(tipo.valor == Integer.valueOf(valor))
                return tipo;
        }
        return null;
    }
}
