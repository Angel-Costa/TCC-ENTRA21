DROP TABLE IF EXISTS logins, clientes, avaliacoes, hoteis, comodidades;
CREATE TABLE logins(
	id INT PRIMARY KEY IDENTITY(1,1),
	email VARCHAR(100),
	senha VARCHAR(100),
	registro_ativo BIT
);

CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),

	celular VARCHAR(100),
	estado VARCHAR(100),
	cidade VARCHAR(100),
	cep VARCHAR(100),
	bairro VARCHAR(100),
	numero VARCHAR(100),
	rua VARCHAR(100),
	complemento VARCHAR(100),
	nome VARCHAR(100),
	cpf VARCHAR(100),
	rg VARCHAR(100),
	celular VARCHAR(100),
	login VARCHAR(100),
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
	descricao VARCHAR (50),
	valor_noite DECIMAL (9,2),
	estado VARCHAR (50),
	cidade VARCHAR (50),
	cep VARCHAR (13),
	bairro VARCHAR (50),
	numero VARCHAR (10),
	rua VARCHAR (50),
	complemento VARCHAR (50)
);

CREATE TABLE comodidades(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_hotel INT
	FOREIGN KEY(id_hotel) REFERENCES hoteis(id),

	nome VARCHAR(100)
);

CREATE TABLE Usuarios (
	id INT PRIMARY KEY IDENTITY(1,1),

	nome VARCHAR (50),
	cpf VARCHAR (11),
	login VARCHAR (50),
	senha VARCHAR (50),
	
	registro_ativo BIT
);

INSERT INTO comodidades (nome) VALUES
('PLAYGROUND');