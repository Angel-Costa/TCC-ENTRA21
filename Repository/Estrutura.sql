DROP TABLE IF EXISTS administradores, comodidades, hoteis , avaliacoes, clientes, sugestoes;

DROP TABLE IF EXISTS hoteis;

CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),

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
	senha VARCHAR(50),
	
	privilegio VARCHAR(20),
	registro_ativo BIT
);

CREATE TABLE sugestoes(
	id INT PRIMARY KEY IDENTITY(1,1),
	local VARCHAR(100),	
	nome VARCHAR(100),
	descricao VARCHAR(100),
	ponto_turistico VARCHAR(100),
	cidade VARCHAR(100),
	endereco VARCHAR(100),
	registro_ativo BIT

);

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Dallas','Profissional',120.0,'Santa Catarina', 'Blumenau','88215-971','Itoupava Central','654','Por do sol','Próximo a associação da weg', 1 );

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Romance', 'Profissional', 200.0, 'Santa Catarina', 'Bombinhas', '88215-970', 'Centro','32', 'Avenida Falcão 1001', 'Próximo a Romulo terraplanagem', 2);

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Bela Vista', 'Profissional', 250.0, 'Santa Catarina', 'Florianópolis', '88215-970', 'Campeche','3652', 'Alex Robe', 'Próximo a Moura car', 3);

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
('Rafael', '12345678910' , 'rafael@gmail.com', 'rafa123', 'cliente', 1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('Jorel', '356871545454' , 'Jorel@gmail.com', 'Jojo6987', 'cliente', 1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('geovana', '32195461416' , 'geovana@gmail.com', 'ge024', 'cliente', 1);

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

INSERT INTO clientes(nome, celular, estado, cidade, cep, login, senha, bairro, numero, rua, complemento, cpf,rg) VALUES
('Matheus','997965820', 'SC', 'Blumenau','00.208-325','matheus@gmail.com', '0504879', 'Vila Itoupava', '456','Rua Alwin Wachholz', 'Proximo ao Hospital Misericórdia', '803.484.620-18', '20.939.373-7');

INSERT INTO clientes(nome, celular, estado, cidade, cep, login, senha, bairro, numero, rua, complemento, cpf,rg) VALUES
('Camilly','324584321', 'SC', 'Balneário Camboriú','88336-015','camy@gmail.com', 'milly123', 'Nova Esperança', '397','Rua Belmiro Diogo Cordeiro', 'proximo a praia', '101.251.560-57', '24.608.995-7');

SELECT * FROM hoteis;
SELECT * FROM comodidades;	
SELECT * FROM administradores;
SELECT * FROM avaliacoes;
SELECT * FROM sugestoes;
SELECT * FROM clientes;
