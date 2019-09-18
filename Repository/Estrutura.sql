DROP TABLE IF EXISTS administradores, comodidades, hoteis , avaliacoes, clientes, sugestoes;

CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),

	celular VARCHAR(12),
	estado VARCHAR(100),
	cidade VARCHAR(100),
	cep VARCHAR(10),
	logim VARCHAR(100),
	bairro VARCHAR(100),
	numero VARCHAR(20),
	rua VARCHAR(100),
	complemento VARCHAR(100),
	nome VARCHAR(100),
	cpf VARCHAR(14),
	rg VARCHAR(12),
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
	valor_noite DECIMAL (8,2),
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

	nome VARCHAR (50),
	cpf VARCHAR (14),
	logim VARCHAR (50),
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
('Dallas','profissional',120.0,'Santa Catarina', 'Blumenau','65.454-132','Centro','654','por do sol','perto do shopping', 1 );

INSERT INTO hoteis(nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Romance', 'proficional', 200.0, 'Santa Catarina', 'Bombinhas', '85.654-328', 'Ponta Aguda','32', 'Frederico Jensen', 'Perto do aeroporto regional', 2);

INSERT INTO hoteis(nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Bela Vista', 'proficional', 250.0, 'Santa Catarina', 'Florienopolis', '85.654-055', 'Itoupava Seca','3652', 'Alex Robe', 'Perto da escola leoberto leal', 3);


INSERT INTO comodidades (id_hotel, nome, registro_ativo) VALUES
(1,'PLAYGROUND', 1),
(1, 'refrigerador', 1);

INSERT INTO comodidades (id_hotel, nome, registro_ativo) VALUES
(2,'Piscina', 2),
(2, 'Lanchonete', 2);

INSERT INTO comodidades (id_hotel, nome, registro_ativo) VALUES
(2,'Frigobar', 2),
(2, 'Karaoke', 2);

INSERT INTO administradores(nome, cpf, logim, senha, privilegio, registro_ativo) VALUES
('Rafael', '12345678910' , 'rafael@gmail.com', 'rafa123', 'cliente', 1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('Manoela', '16546135465' , 'Manoela@gmail.com', 'Manu5645', 'cliente', 1);

INSERT INTO administradores(nome, cpf, login, senha, privilegio, registro_ativo) VALUES
('geovana', '32195461416' , 'geovana@gmail.com', 'ge024', 'cliente', 1);

INSERT INTO avaliacoes(nota, comentario, feedback) VALUES
(10, 'Muito bom!', 'qualidade');

INSERT INTO avaliacoes(nota, comentario, feedback) VALUES
(10, 'Muito bom!', 'qualidade');

INSERT INTO avaliacoes(nota, comentario, feedback) VALUES
(10, 'Muito bom!', 'qualidade');

INSERT INTO sugestoes(nome, local, descricao, ponto_turistico, cidade, endereco) VALUES
('Morada do mar', 'em beira mar', 'piscina exclusiva para clientes, ideal para viajem em dupla', 'praia da lagoinha', 'bombinhas', 'Avenida Leopoldo Zarling, 1221, Bombinhas, CEP 88215-000, Brasil');

INSERT INTO clientes(nome, celular, estado, cidade, cep, login, senha, bairro, numero, rua, complemento, cpf,rg) VALUES
('Jose','997857239', 'SC', 'Blumenau','67.130-170','josefreitas@gmail.com', 'jose123', 'itoupava central', '201','alex borchardt', 'proximo a weg', '123.456.789-10', '12.345.678-9');

SELECT * FROM hoteis;
SELECT * FROM comodidades;	
SELECT * FROM administradores;
SELECT * FROM avaliacoes;
SELECT * FROM sugestoes;
SELECT * FROM clientes;
