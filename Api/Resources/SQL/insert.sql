USE ctep;

INSERT INTO tb_tpstatus_turma (id_tpstatus_turma, nome) VALUES
    (1, 'Em Andamento'), (2, 'Concluída');

INSERT INTO tb_tpstatus_aluno (id_tpstatus_aluno, nome) VALUES
    (1, 'Ativo'), (2, 'Concluído'), (3, 'Trancado'), (4, 'Abandono');

INSERT INTO tb_usuario (nome, login, senha, telefone) VALUES
  ('Administrador', 'admin', MD5('admin'), 00000000),
  ('User', 'user', MD5('1234'), 11111111);

INSERT INTO tb_curso (nome, sigla, sigla_turma, flg_especializacao, id_curso_vinculado) VALUES 
	('Técnico de Enfermagem', 'ENF', 'TENF', FALSE, NULL), 
	('Especialização em Instrumentação Cirúrgica', 'EIC', 'ETIC', TRUE, 1);

INSERT INTO tb_disciplina (nome, id_curso) VALUES
  ('Anatomia', 1),
  ('Ética', 1),
  ('Assistência de Enfermagem à Criança e Adolescente', 1),
  ('Assistência de Enfermagem à Saúde da Mulher e Maternidade', 1),
  ('Saúde Mental', 1),
  ('Saúde Coletiva', 1),
  ('Saúde Pública', 1),
  ('Biossegurança das Ações de Enfermagem', 1),
  ('Ações de Enfermagem Para Segurança do Paciente', 1),
  ('Enfermagem Cirúrgica', 1),
  ('Epidemiologia', 1),
  ('Fundamentos de Enfermagem', 1),
  ('Enfermagem Clínica', 1),
  ('Urgência e Emergência', 1);

INSERT INTO tb_disciplina (nome, id_curso) VALUES
  ('Prova Módulo 1', 2),
  ('Prova Módulo 2', 2),
  ('Escovação e Paramentação', 2),
  ('Mesa de Mayo', 2);