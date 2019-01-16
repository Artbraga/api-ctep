package com.arthur.apiCTEP.entities.enums;

public enum CodigoMovimentoRetorno {
    ImpressaoConfirmada(1, "Solicitação de Impressão de Títulos Confirmada"),
    EntradaConfirmada(2, "Entrada Confirmada"),
    EntradaRejeitada(3, "Entrada Rejeitada"),
    TransferenciaEntrada(4, "Transferência de Carteira/Entrada"),
    TransferenciaBaixa(5, "Transferência de Carteira/Baixa"),
    Liquidacao(6, "Liquidação"),
    ConfirmacaoDesconto(7, "Confirmação do Recebimento da Instrução de Desconto"),
    CancelamentoDesconto(8, "Confirmação do Recebimento do Cancelamento do Desconto"),
    Baixa(9, "Baixa"),
    ConfirmacaoAbatimento(12, "Confirmação Recebimento Instrução de Abatimento"),
    CancelamentoAbatimento(13, "Confirmação Recebimento Instrução de Cancelamento Abatimento"),
    AlteracaoVencimento(14, "Confirmação Recebimento Instrução Alteração de Vencimento"),
    InstrucaoProtesto(19, "Confirmação Recebimento Instrução de Protesto"),
    InstrucaoCancelamentoProtesto(20, "Confirmação Recebimento Instrução de Sustação/Cancelamento de Protesto"),
    RemessaCartorio(23, "Remessa a Cartório"),
    RetiradaCartorio(24, "Retirada de Cartório"),
    ProtestadoEBaixado(25, "Protestado e Baixado (Baixa por Ter Sido Protestado)"),
    InstrucaoRejeitada(26, "Instrução Rejeitada"),
    AlteracaoOutrosDados(27, "Confirmação do Pedido de Alteração de Outros Dados"),
    DebitoTarifas(28, "Débito de Tarifas/Custas"),
    AlteracaoDadosRejeitada(30, "Alteração de Dados Rejeitada"),
    InclusaoBancoPagador(35, "Confirmação de Inclusão Banco de Pagador"),
    AlteracaoBancoPagador(36, "Confirmação de Alteração Banco de Pagador"),
    ExclusaoBancoPagador(37, "Confirmação de Exclusão Banco de Pagador"),
    EmissaoBoletosBancoPagador(38, "Emissão de Boletos de Banco de Pagador"),
    ManutencaoPagadorRejeitada(39, "Manutenção de Pagador Rejeitada"),
    EntradaTituloBancoRejeitada(40, "Entrada de Título via Banco de Pagador Rejeitada"),
    ManutencaoBancoRejeitada(41, "Manutenção de Banco de Pagador Rejeitada"),
    EstornoBaixaLiquidacao(44, "Estorno de Baixa / Liquidação"),
    AlteracaoDados(45, "Alteração de Dados"),
    LiquidacaoOnline(46, "Liquidação On-line"),
    EstornoLiquidacaoOnline(47, "Estorno de Liquidação On-line"),
    TituloDDAReconhecido(51, "Título DDA reconhecido pelo pagador"),
    TituloDDANaoReconhecido(52, "Título DDA não reconhecido pelo pagador"),
    TituloDDARecusado(53, "Título DDA recusado pela CIP"),
    AlteracaoValorNominal(61, "Confirmação de alteração do valor nominal do título"),
    AlteracaoValorPercentual(62, "Confirmação de alteração do valor/percentual mínimo/máximo");

    public int valor;
    public String mensagem;

    CodigoMovimentoRetorno(int valor, String mensagem){
        this.valor = valor;
        this.mensagem = mensagem;
    }

    public static CodigoMovimentoRetorno getCodigoMovimentoRetorno(Integer valor){
        if(valor == null) return null;
        CodigoMovimentoRetorno[] values = CodigoMovimentoRetorno.values();
        for (CodigoMovimentoRetorno codigo : values){
            if(codigo.valor == valor)
                return codigo;
        }
        return null;
    }

    public static CodigoMovimentoRetorno getCodigoMovimentoRetorno(String valor){
        if(valor == null) return null;
        CodigoMovimentoRetorno[] values = CodigoMovimentoRetorno.values();
        for (CodigoMovimentoRetorno codigo : values){
            if(codigo.valor == Integer.valueOf(valor))
                return codigo;
        }
        return null;
    }
}
