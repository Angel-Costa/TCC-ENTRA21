DROP TABLE IF EXISTS usuarios, comodidades, hoteis , avaliacoes, clientes, sugestao;

CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),

	celular VARCHAR(100),
	estado VARCHAR(100),
	cidade VARCHAR(100),
	cep VARCHAR(9),
	login VARCHAR(100),
	bairro VARCHAR(100),
	numero VARCHAR(20),
	rua VARCHAR(100),
	complemento VARCHAR(100),
	nome VARCHAR(100),
	cpf VARCHAR(14),
	rg VARCHAR(100),
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
	cep VARCHAR (8),
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

CREATE TABLE usuarios (
	id INT PRIMARY KEY IDENTITY(1,1),

	nome VARCHAR (50),
	cpf VARCHAR (11),
	login VARCHAR (50),
	senha VARCHAR(50),
	
	registro_ativo BIT,
	privilegio VARCHAR
);

CREATE TABLE sugestoes(
	id INT PRIMARY KEY IDENTITY(1,1),
	local VARCHAR(100),
	nome VARCHAR(100),
	descricao VARCHAR(100),
	ponto_turistico VARCHAR(100),
	cidade VARCHAR(100),
	endereco VARCHAR(100)

);

INSERT INTO hoteis (nome, descricao , valor_noite , estado, cidade, cep, bairro, numero ,rua, complemento, registro_ativo) VALUES
('Dallas','profissional',12.0,'Santa Catarina', 'Blumenau',654541321,'Centro','654','por do sol','perto do shopping', 1 );

INSERT INTO comodidades (id_hotel,nome, registro_ativo) VALUES
(1,'PLAYGROUND', 1),
(1, 'refrigerador', 1);

SELECT * FROM comodidades ;	


SELECT * FROM usuarios ;	
TRUNCATE TABLE usuarios;
