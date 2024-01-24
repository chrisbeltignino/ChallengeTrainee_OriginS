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

-- Agregar 5 clientes
INSERT INTO Clientes (ID_Cliente, Nombre, Apellido, DNI, Localidad, Telefono)
VALUES
  (1, 'Diego', 'Gonzales', 12345678, 'Localidad1', '123-456-7890'),
  (2, 'Bruno', 'De Paiva', 23456789, 'Localidad2', '234-567-8901'),
  (3, 'Luis', 'Barraza', 34567890, 'Localidad3', '345-678-9012'),
  (4, 'Santiago', 'Sanchez', 45678901, 'Localidad4', '456-789-0123'),
  (5, 'Lautaro', 'Peron', 56789012, 'Localidad5', '567-890-1234');

-- Agregar 5 tarjetas asociadas a los clientes
INSERT INTO Tarjetas (ID_Tarjeta, ID_Cliente, Numero_Tarjeta, PIN, Bloqueada, Saldo, Fecha_Vencimiento)
VALUES
  (1, 1, '1111111111111111', '1234', 0, 1000.00, '2024-12-31'),
  (2, 2, '2222222222222222', '2345', 0, 2000.00, '2025-02-28'),
  (3, 3, '3333333333333333', '3456', 1, 3000.00, '2025-12-31'),
  (4, 4, '4444444444444444', '4567', 0, 4000.00, '2021-03-31'),
  (5, 5, '5555555555555555', '5678', 1, 5000.00, '2025-08-31');
