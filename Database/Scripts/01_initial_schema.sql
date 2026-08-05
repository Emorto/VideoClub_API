-- database/scripts/01_Initial_Schema.sql

CREATE DATABASE VideoClubDB;
GO
USE VideoClubDB;
GO

-- Tabla: Categorias
CREATE TABLE Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    Activo BIT NOT NULL DEFAULT 1
);

-- Tabla: Peliculas
CREATE TABLE Peliculas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CategoriaId INT NOT NULL,
    Titulo NVARCHAR(200) NOT NULL,
    Director NVARCHAR(100) NOT NULL,
    AnioLanzamiento INT NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Peliculas_Categorias FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);

-- Tabla: Usuarios
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);

-- Tabla: Alquileres
CREATE TABLE Alquileres (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT NOT NULL,
    PeliculaId INT NOT NULL,
    FechaAlquiler DATETIME NOT NULL DEFAULT GETDATE(),
    FechaDevolucion DATETIME NULL,
    Devuelta BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Alquileres_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    CONSTRAINT FK_Alquileres_Peliculas FOREIGN KEY (PeliculaId) REFERENCES Peliculas(Id)
);