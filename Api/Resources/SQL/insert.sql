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

INSERT INTO tb_turma (codigo, dias_semana, hora_inicio, hora_fim, data_inicio, data_fim, id_curso, id_tpstatus_turma) VALUES
  ('ETIC2001', 'Sábados', '08:00', '12:00', '2020-01-01', NULL, 2, 1),
  ('TENF2001', 'Terças e Quintas', '18:00', '21:00', '2020-03-12', '2022-05-21', 1, 1),
  ('ETIC2002', 'Quartas', '13:00', '17:00', '2020-02-23', '2020-11-01', 2, 1),
  ('ETIC2003', 'Quintas', '09:00', '13:00', '2020-04-21', NULL, 2,2);

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
  ('Urgência e Emergência', 1)
;

INSERT INTO tb_disciplina (nome, id_curso) VALUES
  ('Prova Módulo 1', 2),
  ('Prova Módulo 2', 2),
  ('Escovação e Paramentação', 2),
  ('Mesa de Mayo', 2);

INSERT INTO HOSPITAL (NOME) VALUES
  ('Hospital Municipal Jesus'),
  ('Hospital Municipal Piedade'),
  ('Hospital Municipal de Iraja');

INSERT INTO MODALIDADE_ESTAGIO (MODALIDADE, CURSO_ID) VALUES
  ('Instrumentação', '2'),
  ('Maternidade', '1'),
  ('CME', '1'),
  ('Clinica Médica', '1');