USE ctep;

CREATE TABLE PROFESSOR (
  ID              INT(5)       NOT NULL AUTO_INCREMENT,
  CPF             VARCHAR(12)  NOT NULL,
  RG              VARCHAR(12),
  NOME            VARCHAR(50)  NOT NULL,
  ENDERECO        VARCHAR(100) NOT NULL,
  EMAIL           VARCHAR(20),
  TELEFONE        VARCHAR(10),
  CELULAR         VARCHAR(10),
  DATA_NASCIMENTO DATE,

  CONSTRAINT PK_PROFESSOR_ID PRIMARY KEY (ID),
  CONSTRAINT UNIQUE_PROFESSOR_CPF UNIQUE (CPF)
);
CREATE INDEX INDEX_PROFESSOR_NOME
  ON PROFESSOR (NOME);

CREATE TABLE RECIBO_PROFESSOR (
  ID           INT(5)  NOT NULL AUTO_INCREMENT,
  VALOR        DECIMAL NOT NULL,
  DATA_RECIBO  DATE    NOT NULL,
  PROFESSOR_ID INT(5)  NOT NULL,
  DESCRICAO    VARCHAR(200),

  CONSTRAINT PK_RECIBO_PROFESSOR_ID PRIMARY KEY (ID),
  CONSTRAINT FK_PROFESSOR_ID FOREIGN KEY (PROFESSOR_ID) REFERENCES PROFESSOR (ID),
  INDEX (PROFESSOR_ID)
);

CREATE TABLE CURSO (
  ID              INT(3)      NOT NULL AUTO_INCREMENT,
  NOME            VARCHAR(50) NOT NULL,
  SIGLA           VARCHAR(3)  NOT NULL,
  SIGLA_TURMA     VARCHAR(4)  NOT NULL,
  ESPECIALIZACAO  BOOLEAN,
  CURSO_VINCULADO INT(3),

  CONSTRAINT PK_CURSO_ID PRIMARY KEY (ID),
  CONSTRAINT UNIQUE_CURSO_SIGLA UNIQUE (SIGLA),
  CONSTRAINT FK_CURSO_VINCULADO FOREIGN KEY (CURSO_VINCULADO) REFERENCES CURSO (ID)
);

CREATE TABLE TURMA (
  CODIGO         VARCHAR(8)  NOT NULL,
  DIAS_DA_SEMANA VARCHAR(20) NOT NULL,
  HORA_INICIO    VARCHAR(5)  NOT NULL,
  HORA_FIM       VARCHAR(5)  NOT NULL,
  DATA_INICIO    DATE        NOT NULL,
  DATA_FIM       DATE,
  ANO_INICIO     INT(2)      NOT NULL,
  CURSO_ID       INT(3),
  STATUS         INT(2)      NOT NULL,

  CONSTRAINT PK_TURMA_CODIGO PRIMARY KEY (CODIGO),
  CONSTRAINT FK_TURMA_CURSO_ID FOREIGN KEY (CURSO_ID) REFERENCES CURSO (ID)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE ALUNO (
  MATRICULA               VARCHAR(8)   NOT NULL,
  NOME                    VARCHAR(50)  NOT NULL,
  CPF                     VARCHAR(12)  NOT NULL,
  RG                      VARCHAR(12),
  ENDERECO                VARCHAR(100) NOT NULL,
  CEP                     VARCHAR(8)   NOT NULL,
  COMPLEMENTO             VARCHAR(20),
  BAIRRO                  VARCHAR(20),
  CIDADE                  VARCHAR(20),
  EMAIL                   VARCHAR(20),
  TELEFONE                VARCHAR(10),
  CELULAR                 VARCHAR(10),
  NOME_PAI                VARCHAR(50),
  NOME_MAE                VARCHAR(50),
  ANO_MATRICULA           INT(2)       NOT NULL,
  DATA_MATRICULA          DATE         NOT NULL,
  DATA_NASCIMENTO         DATE,
  DATA_VALIDADE           DATE,
  CURSO_ANTERIOR          VARCHAR(20),
  TURMA_ID                VARCHAR(8),
  TURMA_ESPECIALIZACAO_ID VARCHAR(8),
  CURSO_ID                INT(3)       NOT NULL,
  NOTA_FISCAL             BOOLEAN,
  STATUS                  INT(2)       NOT NULL,

  CONSTRAINT PK_ALUNO_MATRICULA PRIMARY KEY (MATRICULA),
  CONSTRAINT FK_ALUNO_TURMA_ID FOREIGN KEY (TURMA_ID) REFERENCES TURMA (CODIGO)
    ON DELETE SET NULL,
  CONSTRAINT FK_ALUNO_TURMA_ESPECIALIZACAO_ID FOREIGN KEY (TURMA_ESPECIALIZACAO_ID) REFERENCES TURMA (CODIGO)
    ON DELETE SET NULL,
  CONSTRAINT FK_ALUNO_CURSO_ID FOREIGN KEY (CURSO_ID) REFERENCES CURSO (ID)
);
CREATE INDEX INDEX_NOME_ALUNO
  ON ALUNO (NOME);

CREATE TABLE OBSERVACAO_ALUNO (
  ID              INT(5)       NOT NULL AUTO_INCREMENT,
  OBS             VARCHAR(200) NOT NULL,
  DATA            DATE         NOT NULL,
  ALUNO_MATRICULA VARCHAR(8)   NOT NULL,

  CONSTRAINT PK_OBERVACAO_ALUNO_ID PRIMARY KEY (ID),
  CONSTRAINT FK_ALUNO_MATRICULA FOREIGN KEY (ALUNO_MATRICULA) REFERENCES ALUNO (MATRICULA)
    ON DELETE CASCADE
);

CREATE TABLE DISCIPLINA (
  ID       INT(3)      NOT NULL AUTO_INCREMENT,
  CURSO_ID INT(3)      NOT NULL,
  NOME     VARCHAR(80) NOT NULL,

  CONSTRAINT PK_DISCIPLINA_ID PRIMARY KEY (ID),
  CONSTRAINT FK_DISCIPLINA_CURSO_ID FOREIGN KEY (CURSO_ID) REFERENCES CURSO (ID)
);

CREATE TABLE OBSERVACAO_TURMA (
  ID           INT(5)       NOT NULL AUTO_INCREMENT,
  OBS          VARCHAR(200) NOT NULL,
  DATA         DATE         NOT NULL,
  CODIGO_TURMA VARCHAR(8)   NOT NULL,

  CONSTRAINT PK_OBERVACAO_TURMA_ID PRIMARY KEY (ID),
  CONSTRAINT FK_CODIGO_TURMA FOREIGN KEY (CODIGO_TURMA) REFERENCES TURMA (CODIGO)
    ON DELETE CASCADE
);

CREATE TABLE USUARIO (
  ID        INT(3)      NOT NULL AUTO_INCREMENT,
  NOME      VARCHAR(50) NOT NULL,
  LOGIN     VARCHAR(10) NOT NULL,
  SENHA     VARCHAR(32) NOT NULL,
  TELEFONE  VARCHAR(10),
  PERMISSAO INT(2)      NOT NULL,

  CONSTRAINT PK_USUARIO_ID PRIMARY KEY (ID),
  CONSTRAINT UNIQUE_LOGIN UNIQUE (LOGIN)
);

CREATE TABLE MODALIDADE_ESTAGIO (
  ID         INT(2)      NOT NULL AUTO_INCREMENT,
  MODALIDADE VARCHAR(15) NOT NULL,
  CURSO_ID   INT(3),

  CONSTRAINT PK_MODALIDADE_ESTAGIO_ID PRIMARY KEY (ID),
  CONSTRAINT FK_MODALIDADE_CURSO_ID FOREIGN KEY (CURSO_ID) REFERENCES CURSO (ID)
);

CREATE TABLE HOSPITAL (
  ID   INT(2)      NOT NULL AUTO_INCREMENT,
  NOME VARCHAR(30) NOT NULL,

  CONSTRAINT PK_HOSPITAL_ID PRIMARY KEY (ID)
);

CREATE TABLE ESTAGIO_ALUNO (
  ID                    INT(6)     NOT NULL AUTO_INCREMENT,
  DATA                  DATE       NOT NULL,
  HORA_ENTRADA          VARCHAR(5) NOT NULL,
  HORA_SAIDA            VARCHAR(5) NOT NULL,
  TOTAL_DIA             VARCHAR(5),
  HOSPITAL_ID           INT(2),
  MODALIDADE_ESTAGIO_ID INT(2)     NOT NULL,
  ALUNO_MATRICULA       VARCHAR(8) NOT NULL,

  CONSTRAINT PK_ESTAGIO_ALUNO_ID PRIMARY KEY (ID),
  CONSTRAINT FK_ESTAGIO_HOSPITAL_ID FOREIGN KEY (HOSPITAL_ID) REFERENCES HOSPITAL (ID),
  CONSTRAINT FK_ESTAGIO_MODALIDADE_ID FOREIGN KEY (MODALIDADE_ESTAGIO_ID) REFERENCES MODALIDADE_ESTAGIO (ID),
  CONSTRAINT FK_ESTAGIO_ALUNO_MATRICULA FOREIGN KEY (ALUNO_MATRICULA) REFERENCES ALUNO (MATRICULA)
);

CREATE TABLE NOTA_ALUNO (
  ID              INT(6)     NOT NULL AUTO_INCREMENT,
  ALUNO_MATRICULA VARCHAR(8) NOT NULL,
  DISCIPLINA_ID   INT(3)     NOT NULL,
  NOTA            FLOAT      NOT NULL,

  CONSTRAINT PK_NOTA_ALUNO_ID PRIMARY KEY (ID),
  CONSTRAINT FK_NOTA_ALUNO_MATRICULA FOREIGN KEY (ALUNO_MATRICULA) REFERENCES ALUNO (MATRICULA),
  CONSTRAINT FK_NOTA_ALUNO_DISCIPLINA_ID FOREIGN KEY (DISCIPLINA_ID) REFERENCES DISCIPLINA (ID)
)
