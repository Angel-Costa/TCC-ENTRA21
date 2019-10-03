DROP TABLE IF EXISTS administradores, comodidades, hoteis , avaliacoes, clientes, sugestoes, contatos;

DROP TABLE IF EXISTS hoteis;

CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),

	imagem VARCHAR (50),
	celular VARCHAR(15),
	estado VARCHAR(100),
	cidade VARCHAR(100),
	cep VARCHAR(10),
	login VARCHAR(100),
	bairro VARCHAR(100),
	numero VARCHAR(20),
	rua VARCHAR(100),
	complemento VARCHAR(100),
	nome VARCHAR(100),
	cpf VARCHAR(15),
	rg VARCHAR(15),
	senha VARCHAR(100),
	registro_ativo BIT
);

CREATE TABLE avaliacoes(
	id INT PRIMARY KEY IDENTITY(1,1),


	id_cliente INT 
	FOREIGN KEY(id_cliente) REFERENCES clientes(id),
	nota DECIMAL(8,2),

	comentario VARCHAR(100),
	feedback VARCHAR(100),
	registro_ativo BIT
);


CREATE TABLE hoteis(

	imagem VARCHAR (50),
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR (50),
	descricao VARCHAR (200),
	valor_noite DECIMAL (9,2),
	estado VARCHAR (17),
	cidade VARCHAR (50),
	cep VARCHAR (10),
	bairro VARCHAR (50),
	numero VARCHAR (15),
	rua VARCHAR (50),
	complemento VARCHAR (50),
	registro_ativo BIT
);

CREATE TABLE comodidades(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_hotel INT
	FOREIGN KEY(id_hotel) REFERENCES hoteis(id),

	nome VARCHAR(100),
	registro_ativo BIT
);

CREATE TABLE administradores (
	id INT PRIMARY KEY IDENTITY(1,1),

	imagem VARCHAR (50),
	nome VARCHAR (50),
	cpf VARCHAR (15),
	login VARCHAR (50),
	senha VARCHAR(100),
	
	privilegio VARCHAR(20),
	registro_ativo BIT
);

CREATE TABLE sugestoes(
	
	imagem VARCHAR (50),
	id INT PRIMARY KEY IDENTITY(1,1),
	local VARCHAR(100),	
	nome VARCHAR(100),
	descricao VARCHAR(100),
	ponto_turistico VARCHAR(100),
	cidade VARCHAR(100),
	endereco VARCHAR(100),
	registro_ativo BIT

);

CREATE TABLE contatos(
	id int PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	email VARCHAR(100),
	celular VARCHAR(15),
	mensagem VARCHAR(100),
	registro_ativo BIT

);

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Filipinas','QUEM NÃO GOSTA DE UMA VISTA INCRÍVEL PARA A PRAIA? COM UM CONFORTO E UM LOCAL FORA DE SÉRIE.',250.0,'Santa Catarina', 'Florianopolis','33658-445','Meia Praia','321','Builin 63','Final da praia', 1 );

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Fransisco','Uma ótima hospedagem com um preço bom, ótima experiencias para se passar aqui.',70.0,'Santa Catarina', 'São Francisco','65589-712','Fernandão','3664','Fransisco','Geral', 1 );

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('New','PARA PASSAR COM A FAMÍLIA, UM LUGAR TRANQUILO LONGE DE QUALQUER ESTRESSE DO DIA-DIA.',120.0,'Santa Catarina', 'Nova Trento','65487-321','Trento','985','Nova','Fazenda', 1 );

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Amon',' UM ÓTIMO HOTEL PARA PASSAR COM SUA COMPANHEIRA (O) UM LUGAR PERFEITO PARA RELAXAR E CONSTRUIR MEMÓRIAS.',150.0,'Santa Catarina', 'Balneário Camboriú','89110-456','Stande 65','654','Palmeiras ','interior', 1 );

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Dallas','PERFEITO PARA PASSAR SUAS FÉRIAS, PARA TOMAR UM ÓTIMO BANHO DE PISCINA COM ACOMODAÇÕES PERFEITAS PARA O CONFORTO.',200.0,'Santa Catarina', 'Blumenau','89884-562','Pioneiros','963','Regular','Geral', 1 );

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Garou',' UM LUGAR PERFEITO PARA FICAR COM OS AMIGOS E CONSTRUIR HISTÓRIAS INCRÍVEIS!',200.0,'Santa Catarina', 'Garopaba','65423-165','Synai','654','piexes','Perto da costa', 1 );

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Toomy','PARA QUEM NÃO GOSTA DE PASSAR AS FÉRIAS SOZINHO, AQUI É UM ÓTIMO LUGAR PARA SE HOSPEDAR COM QUEM DESEJAR!',90.0,'Santa Catarina', 'Porto Belo','78862-465','Belo','1112','Porto','Ao lado de um porto', 1 );



INSERT INTO comodidades (id_hotel, nome, registro_ativo) VALUES
(1,'PLAYGROUND', 1),
(1, 'refrigerador', 1);

INSERT INTO comodidades (id_hotel, nome, registro_ativo) VALUES
(2,'Piscina', 2),
(2, 'Lanchonete', 2);

INSERT INTO comodidades (id_hotel, nome, registro_ativo) VALUES
(3,'Frigobar', 3),
(3, 'Karaoke', 3);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('Loene', '12345678910' , 'loene@gmail.com', 'loene0504', 1, 1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('Jorel', '356871545454' , 'Jorel@gmail.com', 'Jojo6987', 1, 1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('Angel', '32195461416' , 'angelcosta@gmail.com', 'fimose000', 1, 1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('Paulo','123.123.123-12', 'camargopaulohenrique2@gmail.com', 'paulin', 1, 1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('Loene','323.323.232-44', 'loene@gmail.com', 'loene', 1 , 1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('Naiara', '111.111.111-21', 'naiara@gmail.com','naiara', 1,1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('Nicollas', '555.555.555-45', 'nicollasleeribeiro@gmail.com', 'jhtjht','administrador', 1)

INSERT INTO avaliacoes(nota, comentario, feedback) VALUES
(10, 'Excelente', 'conforto');

INSERT INTO avaliacoes(nota, comentario, feedback) VALUES
(10, 'Surpreendente', 'qualidade');

INSERT INTO avaliacoes(nota, comentario, feedback) VALUES
(10, 'Muito bom!', 'barato e de qualidade');

INSERT INTO sugestoes(nome, local, descricao, ponto_turistico, cidade, endereco) VALUES
('Por do sol', 'Na avenida', 'Piscinas termicas', 'Lagoa da conceição', 'Florianópolis', 'Av. das Rendeiras, 200 - Lagoa da Conceição, Florianópolis - SC, 88062-400');

INSERT INTO sugestoes(nome, local, descricao, ponto_turistico, cidade, endereco) VALUES
('Morada do mar', 'Em beira mar', 'Piscina exclusiva para clientes, ideal para viajem em dupla', 'Praia da lagoinha', 'Bombinhas', 'Avenida Leopoldo Zarling, 1221, Bombinhas, CEP 88215-000, Brasil');

INSERT INTO sugestoes(nome, local, descricao, ponto_turistico, cidade, endereco) VALUES
('Zimbra', 'próximo ao Ramiro Ruediger', 'Vista para o centro de Blumenau', 'Vila Germânica', 'Blumenau', 'Rua Alberto Stein, 199 | Velha, Blumenau, Santa Catarina 89036-900, Brasil');

INSERT INTO clientes(nome, celular, estado, cidade, cep, login, senha, bairro, numero, rua, complemento, cpf,rg) VALUES
('Jose','997857239', 'SC', 'Blumenau','67.130-170','josefreitas@gmail.com', 'jose123', 'itoupava central', '201','alex borchardt', 'proximo a weg', '123.456.789-10', '12.345.678-9');

INSERT INTO clientes(nome, celular, estado, cidade, cep, login, senha, bairro, numero, rua, complemento, cpf,rg, registro_ativo) VALUES
('Matheus','997965820', 'SC', 'Blumenau','00.208-325','matheus@gmail.com', '123', 'Vila Itoupava', '456','Rua Alwin Wachholz', 'Proximo ao Hospital Misericórdia', '803.484.620-18', '20.939.373-7', 1);

INSERT INTO clientes(nome, celular, estado, cidade, cep, login, senha, bairro, numero, rua, complemento, cpf,rg) VALUES
('Camilly','324584321', 'SC', 'Balneário Camboriú','88336-015','camy@gmail.com', 'milly123', 'Nova Esperança', '397','Rua Belmiro Diogo Cordeiro', 'proximo a praia', '101.251.560-57', '24.608.995-7'),
('Jeanderson', '998988989', 'Santa Catarina', 'Blumenau', '87899-123', 'jeanderson@gmail.com', 'ionion', 'Nova Esperança' , '987', 'Rua Alex Borchardt', 'Na frente do posto Petrobras','879.489.189-26','87.589.689-8');

SELECT * FROM hoteis;
SELECT * FROM comodidades;	
SELECT * FROM administradores;
SELECT * FROM avaliacoes;
SELECT * FROM sugestoes;
SELECT * FROM clientes;
SELECT * FROM contatos;
