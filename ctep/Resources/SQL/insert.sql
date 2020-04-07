USE ctep;

INSERT INTO PROFESSOR (NOME, CPF, ENDERECO) VALUES
  ('Isabel Souza', '70835792021', 'Rua ABC'),
  ('Rosemary Moutinho', '46754158069', 'Rua 123'),
  ('Marcia Barreiros', '34273182068', 'Rua teste');

INSERT INTO USUARIO (NOME, LOGIN, SENHA, TELEFONE, PERMISSAO) VALUES
  ('Administrador', 'admin', MD5('admin'), NULL, 0),
  ('User', 'user', MD5('1234'), NULL , 3);

INSERT INTO CURSO (ID, NOME, SIGLA, SIGLA_TURMA, ESPECIALIZACAO, CURSO_VINCULADO) VALUES
  (1, 'Técnico de Enfermagem', 'ENF', 'TENF', FALSE, NULL),
  (2, 'Especialização em Instrumentação Cirúrgica', 'EIC', 'ETIC', TRUE, 1);

INSERT INTO ALUNO (MATRICULA, NOME, CPF, ENDERECO, CEP, ANO_MATRICULA, DATA_MATRICULA, CURSO_ID, NOTA_FISCAL, STATUS) VALUES
  ('EIC17001', 'Arthur Bastos Braga Coelho', '12480014789', 'Rua Embaixador Ramón Carcano 95', '20210030', 17,'2017-12-10', 2, 0, 1),
  ('EIC17002', 'Ana Maria Cardoso Fontes', '82417581035', 'Estrada Cajuzinho 53', '65437834', 17, '2017-02-14', 2, 0, 1),
  ('EIC17003', 'Carolina Pereira Nunes', '32823220038', 'Beco do Bigode 43', '54327538', 17, '2017-04-04', 2, 0, 1),
  ('EIC17004', 'Roberto Cruz da Silva', '05884682077', 'Rua da Villa 34', '64279537', 17, '2017-06-23', 2, 0, 1),
  ('EIC17005', 'Cristina Vasconsellos Villela', '75800520089', 'Rua Embaixador Rubens Barrichelo 445', '32473574', 17, '2017-04-30', 2, 0, 1),
  ('EIC17006', 'Victor Hugo Ferreira Loureiro', '05893601084', 'Rua Gaviao Peixoto 34', '34466732', 17, '2017-11-05', 2, 0, 1),
  ('EIC17007', 'Caroline Cardoso Chads', '97263081008', 'Rua Geraldo Martins 99', '34668324', 17, '2017-11-10', 2, 0, 1),
  ('EIC17008', 'Rafel Nunes Ferreira', '66565962073', 'Rua Doutor Paulo Cesar 47', '34234657', 17, '2017-12-28', 2, 0, 1),
  ('EIC17009', 'Brenda Soares Porto', '94231421099', 'Rua Retiro dos Artistas 29', '34580323', 17, '2017-01-03', 2, 0, 1),
  ('EIC17010', 'Christian Bernard da Silva Loureiro', '97114967047', 'Rua Noronha Torresão 87', '88543254', 17, '2017-02-19', 2, 0, 1),
  ('EIC17011', 'Nicole Kafta Loureiro', '82814558021', 'Estrada do Tindiba 67', '45738936', 17, '2017-07-12', 2, 0, 1),
  ('EIC17012', 'Adriana Bittencourt Silva', '06392790071', 'Rua Tirol 543', '23628437', 17, '2017-09-12', 2, 0, 1),
  ('EIC17013', 'João Victor Domingos Borges', '92081655071', 'Rua Taberna Molhada 54', '67792538', 17, '2017-08-21', 2, 0, 1),
  ('EIC17014', 'Thiago Martins Ventura', '03506849018', 'Rua Tabuão da Serra 69', '81760142', 17, '2017-05-23', 2, 0, 1),
  ('EIC17015', 'Valéria Christina da Silva', '46470737005', 'Rua Sergio Motta 23', '34638536', 17, '2017-03-04', 2, 0, 1),
  ('EIC17016', 'Fátima Bernardes Exbonner', '06927736069', 'Travessa Carilhos Brown 45', '43573285', 17, '2017-10-05', 2, 0, 1),
  ('EIC17017', 'Willian Exbernardes Bonner', '86818315003', 'Rua Mario Bros 42', '32468346', 17, '2017-12-01', 2, 0, 1),
  ('EIC17018', 'Larissa Macedo Machado', '75055676086', 'Rua Major Lazer 100', '43545623', 17, '2017-03-31', 2, 0, 1),
  ('EIC17019', 'Katrlyn Maria Souto', '48976940008', 'Rua Morena do Thcan 42', '45389054', 17, '2017-04-29', 2, 0, 1),
  ('EIC17020', 'Gelson Platutino Junior', '88194187036', 'ladeira do Negão 22', '34354632', 17, '2017-05-17', 2, 0, 1),
  ('EIC17021', 'Felipe Gomes Santiago', '73215062070', 'Rua do Mato 000', '00956005', 17, '2017-02-13', 2, 0, 1),
  ('EIC17022', 'Monica Silva Iozi', '88150919040', 'Rua Video Show 188', '78273245', 17, '2017-06-27', 2, 0, 1),
  ('EIC17023', 'Otaviano Grisalho Costa', '40497003015', 'Rua Video Show - 201', '78273245', 17, '2017-06-27', 2, 0, 1),
  ('EIC17024', 'Sophia Rebelde Abrahão', '10489138055', 'Estrada Rebelde Brasi 01', '35556432', 17, '2017-09-21', 2, 0, 1),
  ('EIC17025', 'Micael Sortudo Borges', '60765217082', 'Rua Contratado da Cantora 32', '23467632', 17, '2017-02-01', 2, 0, 1),

  ('ENF17001', 'Maria do Bairro Silva', '07273439045', 'ladeira de Laranjeira 654', '34584093', 17, '2017-09-12', 1, 0, 1),
  ('ENF17002', 'Floribella Ferreira da Silva', '54459473003', 'Rua das Flores 34', '13345464', 17, '2017-12-22', 1, 0, 1),
  ('ENF17003', 'Raquel Gomes Pereira', '25209206025', 'Praia de Marajós 999', '92874823', 17, '2017-03-24', 1, 0, 1),
  ('ENF17004', 'Agnes Gru Cristine', '90710036043', 'Estrada Malvado Favorito', '23445787', 17, '2017-05-23', 1, 0, 1),
  ('ENF17005', 'Margo Gru Cristine', '58332950090', 'Estrada Malvado Favorito', '23445787', 17, '2017-05-23', 1, 0, 1),
  ('ENF17006', 'Edith Gru Cristine', '85202125062', 'Estrada Malvado Favorito', '23445787', 17, '2017-05-23', 1, 0, 1),
  ('ENF17007', 'Leonardo Casulo Pintor', '17453676088', 'Beco do Esgoto 87', '32434936', 17, '2017-01-28', 1, 0, 1),
  ('ENF17008', 'Raphael Casulo Pintor', '39979330066', 'Beco do Esgoto 87', '32434936', 17, '2017-01-12', 1, 0, 1),
  ('ENF17009', 'Michellangelo Casulo Pintor', '79221892069', 'Beco do Esgoto 87', '32434936', 17, '2017-03-24', 1, 0, 1),
  ('ENF17010', 'Donatello Casulo Pintor', '29713681061', 'Beco do Esgoto 87', '32434936', 17, '2017-07-10', 1, 0, 1),
  ('ENF17011', 'Clover Espíndola Javas', '37913336072', 'Rua Woop 34', '45675329', 17, '2017-06-14', 1, 0, 1),
  ('ENF17012', 'Samantha Coelho Nascimento', '94422689029', 'Rua Woop 109', '45675329', 17, '2017-06-14', 1, 0, 1),
  ('ENF17013', 'Alex da Silva Pereira', '01792784015', 'Rua Woop 14', '45675329', 17, '2017-06-14', 1, 0, 1),
  ('ENF17014', 'Rickin Martin Bernard', '12842841077', 'Rua do Mistério 49', '32467670', 17, '2017-02-28', 1, 0, 1),
  ('ENF17015', 'Aquamarine Fernandes Alento', '99874380080', 'Praia Ariel 768', '35678324', 17, '2017-09-25', 1, 0, 1),
  ('ENF17016', 'Lea Christina Ferratry', '26182795069', 'Rua Bosque dos Equilos 8746', '09887690', 17, '2017-01-07', 1, 0, 1),
  ('ENF17017', 'Isaac Newton Ferratry', '62927863075', 'Rua Bosque dos Esquilos 9380', '09887690', 17, '2017-01-07', 1, 0, 1),
  ('ENF17018', 'Wenny Isa Christina Vasconselos', '08864712062', 'Rua Araticum 234', '32445876', 17, '2017-01-09', 1, 0, 1),
  ('ENF17019', 'Julia Reis Amaral', '84007861064', 'Rua Moreira 76', '34354879', 17, '2017-06-05', 1, 0, 1),
  ('ENF17020', 'Rodrigo Pinto Pimenta', '79646696058', 'Rua Tirulipa 00', '43576334', 17, '2017-06-14', 1, 0, 1),
  ('ENF17021', 'Mario Marcio Alves Junior', '77809095064', 'Rua Professor Livinho', '23452367', 17, '2017-12-23', 1, 0, 1),
  ('ENF17022', 'Gabriel Gouveia Santos', '08324034072', 'Avenida Atlândida 171', '56542344', 17, '2017-09-10', 1, 0, 1),
  ('ENF17023', 'Pablo Pinto Vittar', '97972074046', 'Ladeira do Meu Coração', '35579045', 17, '2017-07-15', 1, 0, 1),
  ('ENF17024', 'Breno Isoldi Cristo', '99024165008', 'Rua Francisco Xavir 85', '74973093', 17, '2017-03-20', 1, 0, 1),
  ('ENF17025', 'Bebecca Passos Lyra', '38282297003', 'Rua Testemunha de Jeojusto 10', '32475653', 17, '2017-03-17', 1, 0, 1),
  ('ENF17026', 'Ruth Gomes Pereira', '83298834009', 'Praia de Marajós 999', '92874823', 17, '2017-03-24', 1, 0, 1),
  ('ENF17027', 'Gabrielli Moreira Cruz', '99212748058', 'Rua Amaral Peixoto 34', '23465320', 17, '2017-01-15', 1, 0, 1);

INSERT INTO TURMA (CODIGO, DIAS_DA_SEMANA, HORA_INICIO, HORA_FIM, DATA_INICIO, DATA_FIM, ANO_INICIO, CURSO_ID, STATUS) VALUES
  ('ETIC1701', 'Sábados', '08:00', '12:00', '2017-01-01', NULL, 17, 2, 1),
  ('TENF1701', 'Terças e Quintas', '18:00', '21:00', '2017-03-12', '2019-05-21', 17, 1, 1),
  ('ETIC1702', 'Quartas', '13:00', '17:00', '2017-02-23', '2017-11-01', 17, 2, 3),
  ('ETIC1703', 'Quintas', '09:00', '13:00', '2017-04-21', NULL, 17, 2,2)
;

INSERT INTO DISCIPLINA (NOME, CURSO_ID) VALUES
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

INSERT INTO DISCIPLINA (NOME, CURSO_ID) VALUES
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