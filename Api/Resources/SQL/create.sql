-- MySQL Script generated by MySQL Workbench
-- Fri Apr 23 00:02:45 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema ctep01
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ctep01
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ctep01` DEFAULT CHARACTER SET utf8 ;
USE `ctep01` ;

-- -----------------------------------------------------
-- Table `ctep01`.`tb_aluno`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_aluno` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_aluno` (
  `id_aluno` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cpf` VARCHAR(14) NOT NULL,
  `rg` VARCHAR(20) NULL,
  `orgao_emissor` VARCHAR(10) NULL,
  `sexo` CHAR NULL,
  `endereco` VARCHAR(100) NOT NULL,
  `cep` VARCHAR(10) NOT NULL,
  `complemento` VARCHAR(50) NULL,
  `bairro` VARCHAR(50) NULL,
  `cidade` VARCHAR(30) NULL,
  `email` VARCHAR(50) NULL,
  `telefone` VARCHAR(12) NULL,
  `celular` VARCHAR(12) NULL,
  `nome_pai` VARCHAR(50) NULL,
  `nome_mae` VARCHAR(50) NULL,
  `data_matricula` DATE NOT NULL,
  `data_nascimento` DATE NOT NULL,
  `data_validade` DATE NULL,
  `curso_anterior` VARCHAR(50) NULL,
  `nota_fiscal` TINYINT NULL,
  PRIMARY KEY (`id_aluno`),
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_professor`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_professor` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_professor` (
  `id_professor` INT NOT NULL AUTO_INCREMENT,
  `cpf` VARCHAR(14) NOT NULL,
  `rg` VARCHAR(20) NULL,
  `nome` VARCHAR(50) NOT NULL,
  `endereco` VARCHAR(100) NOT NULL,
  `cep` VARCHAR(8) NOT NULL,
  `complemento` VARCHAR(20) NULL,
  `bairro` VARCHAR(20) NULL,
  `cidade` VARCHAR(20) NULL,
  `email` VARCHAR(40) NULL,
  `telefone` VARCHAR(12) NULL,
  `celular` VARCHAR(12) NULL,
  `formacao` VARCHAR(30) NULL,
  `flag_exclusao` BIT NULL,
  PRIMARY KEY (`id_professor`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_usuario` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_usuario` (
  `id_usuario` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `login` VARCHAR(20) NOT NULL,
  `senha` VARCHAR(32) NOT NULL,
  `telefone` VARCHAR(10) NOT NULL,
  `id_aluno` INT NULL,
  `id_professor` INT NULL,
  PRIMARY KEY (`id_usuario`),
  INDEX `fk_tb_usuario_ALUNO1_idx` (`id_aluno` ASC),
  INDEX `fk_tb_usuario_tb_professor1_idx` (`id_professor` ASC),
  CONSTRAINT `fk_tb_usuario_ALUNO1`
    FOREIGN KEY (`id_aluno`)
    REFERENCES `ctep01`.`tb_aluno` (`id_aluno`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_usuario_tb_professor1`
    FOREIGN KEY (`id_professor`)
    REFERENCES `ctep01`.`tb_professor` (`id_professor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_curso`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_curso` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_curso` (
  `id_curso` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `sigla` VARCHAR(3) NOT NULL,
  `sigla_turma` VARCHAR(4) NOT NULL,
  `flg_especializacao` TINYINT(1) NOT NULL DEFAULT 0,
  `id_curso_vinculado` INT NULL,
  PRIMARY KEY (`id_curso`),
  INDEX `fk_CURSO_CURSO1_idx` (`id_curso_vinculado` ASC),
  CONSTRAINT `fk_CURSO_CURSO1`
    FOREIGN KEY (`id_curso_vinculado`)
    REFERENCES `ctep01`.`tb_curso` (`id_curso`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_tpstatus_turma`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_tpstatus_turma` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_tpstatus_turma` (
  `id_tpstatus_turma` INT NOT NULL,
  `nome` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id_tpstatus_turma`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_turma`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_turma` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_turma` (
  `id_turma` INT NOT NULL AUTO_INCREMENT,
  `codigo` VARCHAR(8) NOT NULL,
  `dias_semana` VARCHAR(30) NOT NULL,
  `hora_inicio` TIME NULL,
  `hora_fim` TIME NULL,
  `data_inicio` DATE NOT NULL,
  `data_fim` DATE NULL,
  `id_curso` INT NOT NULL,
  `id_tpstatus_turma` INT NOT NULL,
  PRIMARY KEY (`id_turma`),
  INDEX `fk_TURMA_CURSO1_idx` (`id_curso` ASC),
  INDEX `fk_TURMA_TPSTATUS_TURMA1_idx` (`id_tpstatus_turma` ASC),
  CONSTRAINT `fk_TURMA_CURSO1`
    FOREIGN KEY (`id_curso`)
    REFERENCES `ctep01`.`tb_curso` (`id_curso`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TURMA_TPSTATUS_TURMA1`
    FOREIGN KEY (`id_tpstatus_turma`)
    REFERENCES `ctep01`.`tb_tpstatus_turma` (`id_tpstatus_turma`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_tpstatus_aluno`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_tpstatus_aluno` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_tpstatus_aluno` (
  `id_tpstatus_aluno` INT NOT NULL,
  `nome` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id_tpstatus_aluno`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_turma_aluno`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_turma_aluno` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_turma_aluno` (
  `id_turma_aluno` INT NOT NULL AUTO_INCREMENT,
  `matricula_aluno` VARCHAR(8) NOT NULL,
  `data_conclusao` DATE NULL,
  `codigo_conclusaosistec` VARCHAR(30) NULL,
  `id_aluno` INT NOT NULL,
  `id_turma` INT NOT NULL,
  `id_tpstatus_aluno` INT NOT NULL,
  PRIMARY KEY (`id_turma_aluno`),
  INDEX `fk_ALUNO_has_TURMA_TURMA1_idx` (`id_turma` ASC),
  INDEX `fk_ALUNO_has_TURMA_ALUNO1_idx` (`id_aluno` ASC),
  UNIQUE INDEX `matricula_aluno_UNIQUE` (`matricula_aluno` ASC),
  INDEX `fk_tb_turma_aluno_tb_tpstatus_aluno1_idx` (`id_tpstatus_aluno` ASC),
  CONSTRAINT `fk_ALUNO_has_TURMA_ALUNO1`
    FOREIGN KEY (`id_aluno`)
    REFERENCES `ctep01`.`tb_aluno` (`id_aluno`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ALUNO_has_TURMA_TURMA1`
    FOREIGN KEY (`id_turma`)
    REFERENCES `ctep01`.`tb_turma` (`id_turma`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_turma_aluno_tb_tpstatus_aluno1`
    FOREIGN KEY (`id_tpstatus_aluno`)
    REFERENCES `ctep01`.`tb_tpstatus_aluno` (`id_tpstatus_aluno`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_registro_aluno`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_registro_aluno` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_registro_aluno` (
  `id_registro_aluno` INT NOT NULL AUTO_INCREMENT,
  `data` DATE NOT NULL,
  `registro` VARCHAR(5000) NOT NULL,
  `id_aluno` INT NOT NULL,
  PRIMARY KEY (`id_registro_aluno`),
  INDEX `fk_tb_observacaoaluno_tb_aluno1_idx` (`id_aluno` ASC),
  CONSTRAINT `fk_registroaluno_aluno`
    FOREIGN KEY (`id_aluno`)
    REFERENCES `ctep01`.`tb_aluno` (`id_aluno`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_registro_turma`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_registro_turma` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_registro_turma` (
  `id_registro_turma` INT NOT NULL AUTO_INCREMENT,
  `data` DATE NOT NULL,
  `registro` VARCHAR(5000) NOT NULL,
  `id_turma` INT NOT NULL,
  INDEX `fk_OBSERVACAO_TURMA_TURMA1_idx` (`id_turma` ASC),
  PRIMARY KEY (`id_registro_turma`),
  CONSTRAINT `fk_registroturma_turma`
    FOREIGN KEY (`id_turma`)
    REFERENCES `ctep01`.`tb_turma` (`id_turma`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_turma_professor`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_turma_professor` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_turma_professor` (
  `id_turma_professor` INT NOT NULL AUTO_INCREMENT,
  `id_turma` INT NOT NULL,
  `id_professor` INT NOT NULL,
  PRIMARY KEY (`id_turma_professor`),
  INDEX `fk_TURMA_has_PROFESSOR_PROFESSOR1_idx` (`id_professor` ASC),
  INDEX `fk_TURMA_has_PROFESSOR_TURMA1_idx` (`id_turma` ASC),
  CONSTRAINT `fk_TURMA_has_PROFESSOR_TURMA1`
    FOREIGN KEY (`id_turma`)
    REFERENCES `ctep01`.`tb_turma` (`id_turma`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TURMA_has_PROFESSOR_PROFESSOR1`
    FOREIGN KEY (`id_professor`)
    REFERENCES `ctep01`.`tb_professor` (`id_professor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_disciplina`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_disciplina` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_disciplina` (
  `id_disciplina` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `id_curso` INT NOT NULL,
  PRIMARY KEY (`id_disciplina`),
  INDEX `fk_DISCIPLINA_CURSO1_idx` (`id_curso` ASC),
  CONSTRAINT `fk_DISCIPLINA_CURSO1`
    FOREIGN KEY (`id_curso`)
    REFERENCES `ctep01`.`tb_curso` (`id_curso`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ctep01`.`tb_nota_aluno`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ctep01`.`tb_nota_aluno` ;

CREATE TABLE IF NOT EXISTS `ctep01`.`tb_nota_aluno` (
  `id_nota_aluno` INT NOT NULL AUTO_INCREMENT,
  `valor_nota` FLOAT NOT NULL,
  `id_disciplina` INT NOT NULL,
  `id_aluno` INT NOT NULL,
  `id_professor` INT NULL,
  PRIMARY KEY (`id_nota_aluno`),
  INDEX `fk_tb_nota_aluno_tb_disciplina1_idx` (`id_disciplina` ASC),
  INDEX `fk_tb_nota_aluno_tb_aluno1_idx` (`id_aluno` ASC),
  INDEX `fk_tb_nota_aluno_tb_professor1_idx` (`id_professor` ASC),
  CONSTRAINT `fk_tb_nota_aluno_tb_disciplina1`
    FOREIGN KEY (`id_disciplina`)
    REFERENCES `ctep01`.`tb_disciplina` (`id_disciplina`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_nota_aluno_tb_aluno1`
    FOREIGN KEY (`id_aluno`)
    REFERENCES `ctep01`.`tb_aluno` (`id_aluno`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_nota_aluno_tb_professor1`
    FOREIGN KEY (`id_professor`)
    REFERENCES `ctep01`.`tb_professor` (`id_professor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
