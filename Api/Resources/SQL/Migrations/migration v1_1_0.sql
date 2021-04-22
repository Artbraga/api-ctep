
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

ALTER TABLE tb_disciplina MODIFY COLUMN nome varchar(100);