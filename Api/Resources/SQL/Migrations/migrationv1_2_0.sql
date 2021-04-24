-- -----------------------------------------------------
-- Table `ctep01`.`tb_permissao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ctep01`.`tb_permissao` (
  `id_permissao` INT NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id_permissao`))
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `ctep01`.`tb_perfil`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ctep01`.`tb_perfil` (
  `id_perfil` INT NOT NULL,
  `nome` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`id_perfil`))
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `ctep01`.`tb_perfil_permissao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ctep01`.`tb_perfil_permissao` (
  `id_perfil_permissao` INT NOT NULL AUTO_INCREMENT,
  `id_perfil` INT NOT NULL,
  `id_permissao` INT NOT NULL,
  PRIMARY KEY (`id_perfil_permissao`),
  INDEX `fk_tb_perfil_permissao_tb_perfil1_idx` (`id_perfil` ASC),
  INDEX `fk_tb_perfil_permissao_tb_permissao1_idx` (`id_permissao` ASC),
  CONSTRAINT `fk_tb_perfil_permissao_tb_perfil1`
    FOREIGN KEY (`id_perfil`)
    REFERENCES `ctep01`.`tb_perfil` (`id_perfil`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_perfil_permissao_tb_permissao1`
    FOREIGN KEY (`id_permissao`)
    REFERENCES `ctep01`.`tb_permissao` (`id_permissao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

ALTER TABLE tb_usuario ADD COLUMN id_perfil INT NOT NULL;
UPDATE tb_usuario SET id_perfil = 1;
ALTER TABLE tb_usuario ADD FOREIGN KEY (id_perfil) REFERENCES tb_perfil(id_perfil);
ALTER TABLE tb_usuario ADD CONSTRAINT fk_tb_usuario_tb_perfil1 FOREIGN KEY (id_perfil) REFERENCES tb_perfil(id_perfil);