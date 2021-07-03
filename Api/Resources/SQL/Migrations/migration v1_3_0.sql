CREATE TABLE IF NOT EXISTS `tb_cursolivre` (
  `id_cursolivre` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `carga_horaria` INT NOT NULL,
  PRIMARY KEY (`id_cursolivre`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `tb_turma_cursolivre` (
  `id_turma_cursolivre` INT NOT NULL AUTO_INCREMENT,
  `data` DATETIME NOT NULL,
  `hora_inicio` TIME NOT NULL,
  `hora_fim` TIME NOT NULL,
  `id_cursolivre` INT NOT NULL,
  INDEX `fk_tb_turma_cursolivre_tb_cursolivre1_idx` (`id_cursolivre` ASC),
  PRIMARY KEY (`id_turma_cursolivre`),
  CONSTRAINT `fk_tb_turma_cursolivre_tb_cursolivre1`
    FOREIGN KEY (`id_cursolivre`)
    REFERENCES `ctep01`.`tb_cursolivre` (`id_cursolivre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `tb_aluno_cursolivre` (
  `id_aluno_cursolivre` INT NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  `cpf` VARCHAR(14) NOT NULL,
  `rg` VARCHAR(20) NULL,
  `orgao_emissor` VARCHAR(10) NULL,
  `endereco` VARCHAR(100) NULL,
  `celular` VARCHAR(12) NULL,
  PRIMARY KEY (`id_aluno_cursolivre`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `tb_participacao_cursolivre` (
  `id_participacao_cursolivre` INT NOT NULL AUTO_INCREMENT,
  `id_aluno_cursolivre` INT NOT NULL,
  `id_turma_cursolivre` INT NOT NULL,
  PRIMARY KEY (`id_participacao_cursolivre`),
  INDEX `fk_tb_participacao_cursolivre_tb_aluno_cursolivre1_idx` (`id_aluno_cursolivre` ASC),
  INDEX `fk_tb_participacao_cursolivre_tb_turma_cursolivre1_idx` (`id_turma_cursolivre` ASC),
  CONSTRAINT `fk_tb_participacao_cursolivre_tb_aluno_cursolivre1`
    FOREIGN KEY (`id_aluno_cursolivre`)
    REFERENCES `ctep01`.`tb_aluno_cursolivre` (`id_aluno_cursolivre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_participacao_cursolivre_tb_turma_cursolivre1`
    FOREIGN KEY (`id_turma_cursolivre`)
    REFERENCES `ctep01`.`tb_turma_cursolivre` (`id_turma_cursolivre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_tpstatus_boleto` (
  `id_tpstatus_boleto` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id_tpstatus_boleto`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_boleto` (
  `id_boleto` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `seu_numero` VARCHAR(15) NOT NULL,
  `nosso_numero` VARCHAR(20) NOT NULL,
  `data_vencimento` DATE NOT NULL,
  `valor` FLOAT NOT NULL,
  `data_emissao` DATE NULL,
  `data_pagamento` DATE NULL,
  `valor_pago` FLOAT NULL,
  `valor_juros` FLOAT NULL,
  `percent_multa` FLOAT NULL,
  `id_aluno` INT NOT NULL,
  `id_tpstatus_boleto` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id_boleto`),
  INDEX `fk_tb_boleto_tb_aluno1_idx` (`id_aluno` ASC),
  INDEX `fk_tb_boleto_tb_tpstatus_boleto1_idx` (`id_tpstatus_boleto` ASC),
  CONSTRAINT `fk_tb_boleto_tb_aluno1`
    FOREIGN KEY (`id_aluno`)
    REFERENCES `ctep01`.`tb_aluno` (`id_aluno`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_boleto_tb_tpstatus_boleto1`
    FOREIGN KEY (`id_tpstatus_boleto`)
    REFERENCES `ctep01`.`tb_tpstatus_boleto` (`id_tpstatus_boleto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_retorno` (
  `id_retorno` INT NOT NULL,
  `numero` VARCHAR(6) NOT NULL,
  `data_referencia` DATETIME NOT NULL,
  `data_leitura` DATETIME NOT NULL,
  PRIMARY KEY (`id_retorno`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_registro_retorno` (
  `id_retorno` INT NOT NULL,
  `registro` VARCHAR(200) NOT NULL,
  `tb_retorno_id_retorno` INT NOT NULL,
  PRIMARY KEY (`id_registro_retorno`),
  INDEX `fk_tb_registro_retorno_tb_retorno1_idx` (`tb_retorno_id_retorno` ASC),
  CONSTRAINT `fk_tb_registro_retorno_tb_retorno1`
    FOREIGN KEY (`tb_retorno_id_retorno`)
    REFERENCES `ctep01`.`tb_retorno` (`id_retorno`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;