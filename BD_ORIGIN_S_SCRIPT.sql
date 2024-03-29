USE [master]
GO
/****** Object:  Database [BD_ORIGIN_S]    Script Date: 26/1/2024 01:31:00 ******/
CREATE DATABASE [BD_ORIGIN_S]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_ORIGIN_S', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BD_ORIGIN_S.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_ORIGIN_S_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BD_ORIGIN_S_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BD_ORIGIN_S] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_ORIGIN_S].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_ORIGIN_S] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_ORIGIN_S] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_ORIGIN_S] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BD_ORIGIN_S] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_ORIGIN_S] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET RECOVERY FULL 
GO
ALTER DATABASE [BD_ORIGIN_S] SET  MULTI_USER 
GO
ALTER DATABASE [BD_ORIGIN_S] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_ORIGIN_S] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_ORIGIN_S] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_ORIGIN_S] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_ORIGIN_S] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_ORIGIN_S] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD_ORIGIN_S', N'ON'
GO
ALTER DATABASE [BD_ORIGIN_S] SET QUERY_STORE = ON
GO
ALTER DATABASE [BD_ORIGIN_S] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BD_ORIGIN_S]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 26/1/2024 01:31:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ID_Cliente] [int] NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[DNI] [int] NULL,
	[Localidad] [nvarchar](100) NULL,
	[Telefono] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operaciones]    Script Date: 26/1/2024 01:31:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operaciones](
	[ID_Operacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Tarjeta] [int] NULL,
	[Fecha_Operacion] [datetime] NULL,
	[Codigo_Operacion] [nvarchar](50) NULL,
	[Cantidad_Retirada] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Operacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjetas]    Script Date: 26/1/2024 01:31:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjetas](
	[ID_Tarjeta] [int] NOT NULL,
	[ID_Cliente] [int] NULL,
	[Numero_Tarjeta] [nvarchar](16) NULL,
	[PIN] [nvarchar](4) NULL,
	[Bloqueada] [bit] NULL,
	[Saldo] [decimal](18, 2) NULL,
	[Fecha_Vencimiento] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clientes] ([ID_Cliente], [Nombre], [Apellido], [DNI], [Localidad], [Telefono]) VALUES (1, N'Diego', N'Gonzales', 12345678, N'Localidad1', N'123-456-7890')
INSERT [dbo].[Clientes] ([ID_Cliente], [Nombre], [Apellido], [DNI], [Localidad], [Telefono]) VALUES (2, N'Bruno', N'De Paiva', 23456789, N'Localidad2', N'234-567-8901')
INSERT [dbo].[Clientes] ([ID_Cliente], [Nombre], [Apellido], [DNI], [Localidad], [Telefono]) VALUES (3, N'Luis', N'Barraza', 34567890, N'Localidad3', N'345-678-9012')
INSERT [dbo].[Clientes] ([ID_Cliente], [Nombre], [Apellido], [DNI], [Localidad], [Telefono]) VALUES (4, N'Santiago', N'Sanchez', 45678901, N'Localidad4', N'456-789-0123')
INSERT [dbo].[Clientes] ([ID_Cliente], [Nombre], [Apellido], [DNI], [Localidad], [Telefono]) VALUES (5, N'Lautaro', N'Peron', 56789012, N'Localidad5', N'567-890-1234')
GO
SET IDENTITY_INSERT [dbo].[Operaciones] ON 

INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (1, 1, CAST(N'2024-01-23T11:40:31.200' AS DateTime), N'Retiro', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (2, 1, CAST(N'2024-01-23T11:40:31.310' AS DateTime), N'Retiro', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (3, 1, CAST(N'2024-01-23T11:45:38.723' AS DateTime), N'Retiro', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (4, 1, CAST(N'2024-01-23T11:45:38.823' AS DateTime), N'Retiro', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (5, 1, CAST(N'2024-01-23T20:49:49.050' AS DateTime), N'Retiro', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (6, 1, CAST(N'2024-01-23T20:49:49.177' AS DateTime), N'Retiro', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (7, 1, CAST(N'2024-01-23T20:52:35.387' AS DateTime), N'Retiro', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (8, 1, CAST(N'2024-01-23T20:52:35.517' AS DateTime), N'Retiro', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (9, 1, CAST(N'2024-01-24T16:59:56.087' AS DateTime), N'Balance', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (10, 1, CAST(N'2024-01-24T17:04:35.890' AS DateTime), N'Balance', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (11, 1, CAST(N'2024-01-24T17:14:39.703' AS DateTime), N'Balance', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (12, 1, CAST(N'2024-01-24T18:39:40.397' AS DateTime), N'Balance', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (13, 1, CAST(N'2024-01-24T18:41:18.467' AS DateTime), N'Retiro', CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (14, 2, CAST(N'2024-01-24T18:48:08.850' AS DateTime), N'Balance', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (15, 2, CAST(N'2024-01-24T18:48:40.727' AS DateTime), N'Retiro', CAST(2000.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (16, 1, CAST(N'2024-01-25T23:42:06.563' AS DateTime), N'Balance', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (17, 1, CAST(N'2024-01-26T01:20:48.177' AS DateTime), N'Retiro', CAST(125.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (18, 1, CAST(N'2024-01-26T01:20:59.870' AS DateTime), N'Retiro', CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[Operaciones] ([ID_Operacion], [ID_Tarjeta], [Fecha_Operacion], [Codigo_Operacion], [Cantidad_Retirada]) VALUES (19, 1, CAST(N'2024-01-26T01:21:03.307' AS DateTime), N'Balance', CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Operaciones] OFF
GO
INSERT [dbo].[Tarjetas] ([ID_Tarjeta], [ID_Cliente], [Numero_Tarjeta], [PIN], [Bloqueada], [Saldo], [Fecha_Vencimiento]) VALUES (1, 1, N'1111111111111111', N'1234', 0, CAST(170.00 AS Decimal(18, 2)), CAST(N'2024-12-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Tarjetas] ([ID_Tarjeta], [ID_Cliente], [Numero_Tarjeta], [PIN], [Bloqueada], [Saldo], [Fecha_Vencimiento]) VALUES (2, 2, N'2222222222222222', N'2345', 0, CAST(0.00 AS Decimal(18, 2)), CAST(N'2025-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Tarjetas] ([ID_Tarjeta], [ID_Cliente], [Numero_Tarjeta], [PIN], [Bloqueada], [Saldo], [Fecha_Vencimiento]) VALUES (3, 3, N'3333333333333333', N'3456', 1, CAST(3000.00 AS Decimal(18, 2)), CAST(N'2025-12-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Tarjetas] ([ID_Tarjeta], [ID_Cliente], [Numero_Tarjeta], [PIN], [Bloqueada], [Saldo], [Fecha_Vencimiento]) VALUES (4, 4, N'4444444444444444', N'4567', 0, CAST(4000.00 AS Decimal(18, 2)), CAST(N'2021-03-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Tarjetas] ([ID_Tarjeta], [ID_Cliente], [Numero_Tarjeta], [PIN], [Bloqueada], [Saldo], [Fecha_Vencimiento]) VALUES (5, 5, N'5555555555555555', N'5678', 1, CAST(5000.00 AS Decimal(18, 2)), CAST(N'2025-08-31T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD FOREIGN KEY([ID_Tarjeta])
REFERENCES [dbo].[Tarjetas] ([ID_Tarjeta])
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Clientes] ([ID_Cliente])
GO
USE [master]
GO
ALTER DATABASE [BD_ORIGIN_S] SET  READ_WRITE 
GO
