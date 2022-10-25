CREATE DATABASE chapter;

USE chapter;

CREATE TABLE livros
(
	Id INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(150) NOT NULL,
	QuantidadePaginas INT,
	Disponivel BIT
);

INSERT INTO livros (Titulo, quantidadePaginas, Disponivel)
VALUES ('Titulo A',120, 1);

INSERT INTO livros (Titulo, quantidadePaginas, Disponivel)
VALUES ('Titulo B',220, 0);

INSERT INTO livros (Titulo, quantidadePaginas, Disponivel)
VALUES ('Titulo C',225, 1);

SELECT * FROM livros;