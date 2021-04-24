USE ctep;

INSERT INTO tb_tpstatus_turma (id_tpstatus_turma, nome) VALUES
    (1, 'Em Andamento'), (2, 'Concluída');

INSERT INTO tb_tpstatus_aluno (id_tpstatus_aluno, nome) VALUES
    (1, 'Ativo'), (2, 'Concluído'), (3, 'Trancado'), (4, 'Abandono');

INSERT INTO tb_usuario (nome, login, senha, telefone, id_perfil) VALUES
  ('Administrador', 'admin', MD5('admin'), 00000000, 1),
  ('User', 'user', MD5('1234'), 11111111, 1);

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

INSERT INTO tb_permissao (id_permissao, nome) VALUES
  (1, 'Consultar Alunos'),
  (2, 'Manter Alunos'),
  (3, 'Manter Notas'),
  (4, 'Consultar Turmas'),
  (5, 'Manter Turmas'),
  (6, 'Acesso Desktop'),
  (7, 'Acesso Portal'),
  (8, 'Consultar Usuários'),
  (9, 'Manter Usuários'),
  (10, 'Consultar Professores'),
  (11, 'Manter Professores');

INSERT INTO tb_perfil (id_perfil, nome) VALUES
  (1, 'Direção'),
  (2, 'Secretaria'),
  (3, 'Professor'),
  (4, 'Aluno');

INSERT INTO tb_perfil_permissao (id_perfil, id_permissao) VALUES
  (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7), (1, 8), (1, 9), (1, 10), (1, 11),
  (2, 1), (2, 2), (2, 3), (2, 4), (2, 5), (2, 6), (2, 10),
  (3, 1), (3, 3), (3, 4), (3, 6), (3, 7), 
  (4, 7);