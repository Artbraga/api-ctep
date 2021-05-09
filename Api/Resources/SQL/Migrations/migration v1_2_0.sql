ALTER TABLE tb_professor add column formacao VARCHAR(50);
ALTER TABLE tb_professor add column flag_exclusao BOOLEAN;
ALTER TABLE tb_professor modify column cep VARCHAR(10);

ALTER TABLE tb_aluno add column naturalidade VARCHAR(50);