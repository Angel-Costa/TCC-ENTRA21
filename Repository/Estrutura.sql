DROP TABLE IF EXISTS clientes, avaliacoes, hoteis, comodidades;

CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_login INT
	FOREIGN KEY(id_login) REFERENCES logins(id),

	nome VARCHAR(100),
	cpf VARCHAR(100),
	rg VARCHAR(100),
	celular VARCHAR(100),
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

	wifi BIT,
	tv BIT,
	ar_condicionado BIT,
	basico BIT,
	microondas BIT,
	refrigerador BIT,
	forno BIT,
	lareira_interna BIT,
	registro_ativo BIT
);

CREATE TABLE Usuarios (
	id INT PRIMARY KEY IDENTITY(1,1),

	nome VARCHAR (50),
	cpf VARCHAR (11),
	login VARCHAR (50),
	senha VARCHAR (50),
	
	registro_ativo BIT
);



