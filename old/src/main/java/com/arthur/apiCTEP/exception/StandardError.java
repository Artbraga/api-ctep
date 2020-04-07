package com.arthur.apiCTEP.exception;

import java.io.Serializable;

public class StandardError implements Serializable{
    private Integer status;
    private String mensagem;
    private Long timestamp;

    public Integer getStatus() {
        return status;
    }

    public void setStatus(Integer status) {
        this.status = status;
    }

    public String getMensagem() {
        return mensagem;
    }

    public void setMensagem(String mensagem) {
        this.mensagem = mensagem;
    }

    public Long getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(Long timestamp) {
        this.timestamp = timestamp;
    }

    public StandardError(Integer status, String mensagem, Long timestamp) {

        this.status = status;
        this.mensagem = mensagem;
        this.timestamp = timestamp;
    }
}
