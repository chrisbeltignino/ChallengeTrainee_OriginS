-- Creo la base de datos
CREATE DATABASE BD_ORIGIN_S;
GO

-- Seleccionar la base de datos
USE BD_ORIGIN_S;
GO

-- Crear tabla Clientes
CREATE TABLE Clientes (
    ID_Cliente INT PRIMARY KEY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    DNI INT,
    Localidad NVARCHAR(100),
    Telefono NVARCHAR(20)
);

-- Crear tabla Tarjetas
CREATE TABLE Tarjetas (
    ID_Tarjeta INT PRIMARY KEY,
    ID_Cliente INT FOREIGN KEY REFERENCES Clientes(ID_Cliente),
    Numero_Tarjeta NVARCHAR(16),
    PIN NVARCHAR(4),
    Bloqueada BIT,
    Saldo DECIMAL(18, 2),
    Fecha_Vencimiento DATETIME
);

-- Crear tabla Operaciones
CREATE TABLE Operaciones (
    ID_Operacion INT PRIMARY KEY,
    ID_Tarjeta INT FOREIGN KEY REFERENCES Tarjetas(ID_Tarjeta),
    Fecha_Operacion DATETIME,
    Codigo_Operacion NVARCHAR(50),
    Cantidad_Retirada DECIMAL(18, 2)
);