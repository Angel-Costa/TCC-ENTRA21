DROP TABLE IF EXISTS logins, clientes, avaliacoes, hoteis, comodidades;
CREATE TABLE logins(
	id INT PRIMARY KEY IDENTITY(1,1),
	email VARCHAR(100),
	senha VARCHAR(100),
	registro_ativo BIT
);

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
	nome VARCHAR(100),
	tipo VARCHAR(100),
	valor_hospedagem DECIMAL(8,2),
	data_entrada DATETIME,
	data_saida DATETIME,
	quantidade_quartos INT PRIMARY KEY IDENTITY(1,1),
	enderecos VARCHAR(100),

	id_avaliacao INT
	FOREIGN KEY(id_avaliacao) REFERENCES avaliacoes(id),

	registro_ativo BIT
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

CREATE TABLE clientes_logins (
	id INT PRIMARY KEY IDENTITY(1,1),

	id_cliente INT,
	FOREIGN KEY(id_cliente) REFERENCES clientes(id),

	id_login INT,
	FOREIGN KEY (id_login) REFERENCES logins(id),
	registro_ativo BIT
);