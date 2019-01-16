package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Retorno;
import com.arthur.apiCTEP.entities.Titulo;
import com.arthur.apiCTEP.entities.enums.TipoRegistro;
import com.arthur.apiCTEP.exception.RemessaRetornoException;
import com.arthur.apiCTEP.repositories.RetornoRepository;
import com.arthur.apiCTEP.repositories.TituloRepository;
import org.apache.logging.log4j.Level;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.*;
import java.util.Arrays;
import java.util.Date;

@Service
public class TituloService extends ServiceGenerico<Titulo, Long> {

    @Autowired
    private RetornoRepository retornoRepository;
    private TituloRepository tituloRepository;

    private String linha;
    private boolean codigoRemessaRetorno;
    private Date dataArquivo;
    private String situacaoArquivo;
    private int numArquivo;
    private Retorno retorno;

    @Autowired
    public TituloService(TituloRepository repository) {
        super(repository);
        this.tituloRepository = repository;
    }

    public void lerArquivos(){
        try {
            File pasta = new File(prop.getProperty("pasta_retorno"));
            File[] arquivos = pasta.listFiles();
            for (File arq : arquivos) {
                BufferedReader buf = new BufferedReader(new FileReader(arq));
                while ((linha = buf.readLine()) != null) {
                    String aux = remover(7);
                    String tipoRegistro = remover(1);
                    switch (TipoRegistro.getTipoRegistro(tipoRegistro)) {
                        case HeaderArquivo:
                            lerHeaderArquivo();
                            break;
                        case HeaderLote:
                            lerHeaderLote();
                            break;
                        case Detalhe:
                            lerDelathe();
                            break;
                        case TrailerLote:
                            lerTrailerLote();
                            break;
                        case TrailerArquivo:
                            lerTrailerArquivo();
                            break;

                    }
                }
                logger.info("Arquivo " + arq.getName() + " lido com sucesso!");
            }
        }
        catch (RemessaRetornoException e){
            logger.error(e.getMessage());
        }
        catch (Exception e){
            e.printStackTrace();
        }
    }

    private void lerHeaderArquivo() throws RemessaRetornoException {
        String aux = remover(9);
        aux = remover(1);
        if(!aux.equals("2"))
            throw new RemessaRetornoException("Inscrição diferente de Pessoa Jurídica.");
        aux = remover(14);
        if(!prop.getProperty("cnpj").equals(aux))
            throw new RemessaRetornoException("CNPJ inválido: " + aux);
        remover(20);
        aux = remover(6);
        if(Integer.valueOf(prop.getProperty("conta")).intValue() != Integer.valueOf(aux).intValue())
            throw new RemessaRetornoException("Conta corrente inválida " + aux);
        aux = remover(6);
        if(Integer.valueOf(prop.getProperty("cod_cedente")).intValue() != Integer.valueOf(aux).intValue())
            throw new RemessaRetornoException("Conta corrente inválida " + aux);
        remover(8);
        aux = remover(30);
        if(Arrays.asList(prop.getProperty("nome_empresa").split(",")).contains(aux.trim()))
            throw new RemessaRetornoException("Nome da empresa inválido " + aux);
        remover(30);
        remover(10);
        aux = remover(1);
        codigoRemessaRetorno = Integer.valueOf(aux) == 2;
        aux = remover(8);
        dataArquivo = stringToDate(aux);
        remover(6);
        numArquivo = Integer.valueOf(remover(6));
        remover(3);
        remover(5);
        remover(20);
        situacaoArquivo = remover(20).trim();
        remover(14);
        remover(3);
        remover(12);


        this.retorno = new Retorno(dataArquivo, numArquivo);
        this.retorno = retornoRepository.save(retorno);
    }

    private void lerHeaderLote(){
        String aux = remover(8);
        aux = remover(1);
        if(aux.equals("R")){

        }
    }

    private void lerDelathe(){

    }

    private void lerTrailerLote(){

    }

    private void lerTrailerArquivo(){
        String aux = remover(9);
        remover(6);
        aux = remover(6);
        this.retorno.setNumRegistros(Integer.valueOf(aux));
        remover(211);
    }

    private String remover(int tamanho){
        String trecho = linha.substring(0, tamanho);
        this.linha = this.linha.substring(tamanho);
        return trecho;
    }

    private Date stringToDate(String data){
        int dia = Integer.valueOf(data.substring(0, 2));
        int mes = Integer.valueOf(data.substring(2, 4));
        int ano = Integer.valueOf(data.substring(4));
        return new Date(ano, mes, dia);
    }
}
