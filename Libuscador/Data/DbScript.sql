USE master

DROP database DBLIbros_MarianoRamborger

CREATE DATABASE DBLIbros_MarianoRamborger
GO

USE DBLIbros_MarianoRamborger
GO

CREATE TABLE LIBROS
(
Lib_Id int primary key identity(1,1),
ISBN varchar (15) not null,
Titulo varchar(100) not null,

CONSTRAINT UQ_ISBN UNIQUE (ISBN),
CONSTRAINT IS_ISBN CHECK  (Len(ISBN) >= 4)

);


-------------------------------------

-- Tabla Editoriales
CREATE TABLE EDITORIALES
(
Ed_Id INT PRIMARY KEY IDENTITY(1,1),
Nombre_editorial Varchar(40),
Pagina_web VARCHAR(70) not null,
Pais Varchar(30) not null,

CONSTRAINT UQ_EDI UNIQUE (Nombre_editorial),
CONSTRAINT UQ_WEB UNIQUE (Pagina_web),
CONSTRAINT IS_WEB CHECK (Pagina_web LIKE 'www.%' OR Pagina_web LIKE 'https://%' OR Pagina_web LIKE 'http://%' ))
;




-------------------------------------

-- Tabla Autores -----------------
CREATE TABLE AUTORES
(
Aut_Id INT  PRIMARY KEY IDENTITY(1,1),
Aut_Nombre varchar(80) not null,
Pais varchar(40) not null,

CONSTRAINT UQ_AUT UNIQUE (Aut_Nombre),
);

----------------------------------------
-- Tabla Generos

CREATE TABLE GENEROS
(
Gen_Id INT PRIMARY KEY IDENTITY(1,1),
Genero Varchar(20) not null,
Descripcion Varchar(100) not null,

CONSTRAINT Gen_UQ UNIQUE (GENERO)

)
--------------------------------------


-- TABLA de relacion Libro/Generos => Permite poner mas de un genero por libro.
CREATE TABLE LibrosxGenero
(
GendeLibId INT PRIMARY KEY IDENTITY (1,1),
Libro_Id int not null,
Genero_Id int not null

CONSTRAINT UQ_Ids_GeneroYLibro UNIQUE (Libro_Id, Genero_Id)
CONSTRAINT FK_GenLibIDs FOREIGN KEY (Libro_Id) REFERENCES LIBROS(Lib_Id) ON DELETE CASCADE,
CONSTRAINT FK_GenIds FOREIGN KEY (Genero_Id) REFERENCES GENEROS(Gen_Id) ON DELETE CASCADE,
)

--------------------------------------------------------------------------------

--Tabla de relación Libro/Autor => Permite poner mas de un autor por libro.
CREATE TABLE LibrosxAutor (  
Id INT PRIMARY KEY IDENTITY(1,1),
Libro_Id int not null,
Autor_Id int not null,

CONSTRAINT UQ_IDs_AutorYLibro UNIQUE (Libro_Id, Autor_Id),
CONSTRAINT FK_AutLibIds FOREIGN KEY (Libro_Id) REFERENCES LIBROS(Lib_Id) ON DELETE CASCADE,
CONSTRAINT FK_AutIds FOREIGN KEY (Autor_Id) REFERENCES AUTORES(Aut_Id) ON DELETE CASCADE,
)

--------------------------------------------------------------------------------

--Tabla de relación Libro/Editoriales => Permite poner mas de una editorial por libro.
CREATE TABLE LibrosxEditorial
(
Id INT PRIMARY KEY IDENTITY(1,1),
Libro_Id INT not null,
Editorial_Id INT not null,

CONSTRAINT UQ_Ids_EditorialYLibro UNIQUE ( Libro_Id, Editorial_Id) ,
CONSTRAINT FK_EDLibIds FOREIGN KEY (Libro_Id) REFERENCES LIBROS(Lib_Id) ON DELETE CASCADE,
CONSTRAINT FK_EDIIds FOREIGN KEY (Editorial_Id) REFERENCES EDITORIALES(Ed_Id) ON DELETE CASCADE,

)
--------------------------------------------------------------------------------





INSERT INTO LIBROS
(Titulo, ISBN)
VALUES
('1984', '9780141036144'),
('The Fault in Our Stars', '0525478817'),
('Pride and Prejudice', '9780679783268'),
('Harry Potter Collection', '9780439827607'),
('A Game of Thrones', ' 0553588486')



select * from autores
INSERT INTO AUTORES
(Aut_Nombre, Pais)
VALUES
('George Orwell', 'Reino Unido'),
('John Green', 'Estados Unidos'),
('Jane Austen', 'Reino Unido'),
('J.K. Rowling', 'Reino Unido'),
('George R.R. Martin', 'Estados Unidos')
;

Select * from editoriales;


INSERT into EDITORIALES
(Nombre_editorial, Pagina_web, Pais)
VALUES
('Penguin Books', 'https://www.penguin.com/', 'Reino Unido'),
('Dutton Books', 'http://www.penguin.com/publishers/dutton/', 'Estados Unidos'),
('Modern Library', 'http://www.modernlibrary.com/', 'Estados Unidos'),
('Scholastic', 'https://la.scholastic.com/en', 'Estados Unidos'),
('Bantam', 'http://www.randomhousebooks.com', 'Estados Unidos');
;

SELECT * from generos
Insert into GENEROS
(Genero, Descripcion)
VALUES
('Ficción Politica', 'Libros dedicadas a explorar temáticas politicas mediante su narrativa'),
('Romance', 'Libros dedicados a explorar relaciones o ideas de tipo romantico'),
('Fantasía', 'Libros que incorporan el elementos fantásticos a la trama');

select * from LibrosxGenero
Insert INTO LibrosxGenero
(Libro_id, Genero_id)
VALUES (1, 1), (2, 2), (3, 2), (4,3), (5,3)

Insert INTO LibrosxEditorial
(Libro_id, Editorial_Id)
VALUES
(1, 1), (2,2), (3,3), (4,4), (5,5)


Insert INTO LibrosxAutor
(Libro_id, Autor_Id)
VALUES
(1, 1), (2,2), (3,3), (4,4), (5,5)


----- LATER INSERTIONS


INSERT INTO LIBROS
(ISBN, Titulo)
VALUES
('0452284236','1984');

INSERT INTO EDITORIALES
(Nombre_editorial, Pagina_web, Pais)
VALUES
('Plume', 'https://www.penguin.com/publishers/plume/', 'Estados Unidos');

INSERT INTO LibrosxAutor (Autor_Id, Libro_Id) VALUES (1, 6)
INSERT INTO LibrosxGenero (Libro_Id, Genero_Id) VALUES (6, 1);
INSERT INTO LibrosxEditorial (Libro_Id, Editorial_Id) Values (6, 7)

select * from LibrosxAutor