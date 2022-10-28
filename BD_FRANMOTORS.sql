USE [franmotors]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 9/10/2022 11:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NULL,
	[Apellido] [nvarchar](500) NULL,
	[Dni] [nvarchar](50) NULL,
	[ImageDni] [nvarchar](500) NULL,
	[Correo] [varchar](50) NULL,
	[Telefono] [nvarchar](50) NULL,
	[IdMecanico] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoMoto]    Script Date: 9/10/2022 11:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoMoto](
	[Id] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[IdMoto] [nchar](10) NULL,
 CONSTRAINT [PK_EstadoMoto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historial]    Script Date: 9/10/2022 11:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Detalle] [nvarchar](200) NULL,
	[IdMoto] [int] NULL,
 CONSTRAINT [PK_Historial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motocicleta]    Script Date: 9/10/2022 11:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motocicleta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [nvarchar](50) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
	[NumSerie] [nvarchar](50) NOT NULL,
	[Cilindrada] [nvarchar](50) NOT NULL,
	[Año] [datetime] NOT NULL,
	[ImgTarjeta] [nvarchar](500) NULL,
	[ImgMoto] [nvarchar](500) NULL,
	[IdCliente] [int] NULL,
	[EstadoMoto] [nvarchar](500) NULL,
 CONSTRAINT [PK_Motocicleta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/10/2022 11:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NULL,
	[Apellidos] [nvarchar](500) NULL,
	[Dni] [nvarchar](50) NULL,
	[Correo] [nvarchar](500) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Tipo] [nvarchar](50) NULL,
	[Username] [nvarchar](500) NULL,
	[Password] [nvarchar](500) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni], [ImageDni], [Correo], [Telefono], [IdMecanico]) VALUES (3, N'Juan', N'Perez', N'123123123', N'/files/DNI.png', N'riosan575@gmail.com', N'123', 1)
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni], [ImageDni], [Correo], [Telefono], [IdMecanico]) VALUES (6, N'Benja', N'Rios', N'12345678', N'/files/DNI.png', N'lavypiero096@gmail.com', N'34561', 1)
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni], [ImageDni], [Correo], [Telefono], [IdMecanico]) VALUES (7, N'awdaw', N'awdawd', N'12312', N'/files/DNI.png', N'an_99_ben@hotmail.com', N'978398181', 1)
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni], [ImageDni], [Correo], [Telefono], [IdMecanico]) VALUES (8, N'piero', N'Lavy', N'123454', N'/files/DNI.png', N'N00026011@upn.pe', N'123123', 1)
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni], [ImageDni], [Correo], [Telefono], [IdMecanico]) VALUES (9, N'Angel', N'Rios', N'45678912', N'/files/DNI.png', N'Ivan@gmail.com', N'978398181', 1)
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni], [ImageDni], [Correo], [Telefono], [IdMecanico]) VALUES (10, N'Luffy', N'Monkey', N'45678912', N'/files/DNI.png', N'cdlb5000@gmail.com', N'123245678', 1)
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni], [ImageDni], [Correo], [Telefono], [IdMecanico]) VALUES (14, N'awdawdawd', N'Eslavousky', N'78954785', N'/files/DNI.png', N'aw@gmail.com', N'478526369', 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Historial] ON 

INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (1, CAST(N'2021-11-11T00:00:00.000' AS DateTime), N'hoaladadadadawdawdawdawd', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (2, CAST(N'2021-11-11T00:00:00.000' AS DateTime), N'Buena moto en buen estado', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (3, CAST(N'2021-11-11T00:00:00.000' AS DateTime), N'Buena moto en buen estado', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (4, CAST(N'2021-11-11T00:00:00.000' AS DateTime), N'Mal estado de moto', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (5, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'awdawdawd', 3)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (6, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'awdawdawd', 3)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (7, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'se cambiaron los aceites', 4)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (8, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'se hizo cambio de bugia', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (9, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'yeah', 2)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (10, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'awdawdawdawdawjdkqwjqjejqwejqiowjeiqjwe', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (11, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'el piero es gil', 18)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (12, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'Aprende Bitcoin, BlockChain, seguridad informática ( RSA, 2FA, etc ), negocio cripto-fiat (exchanges, bots, etc) en 2020', 18)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (13, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'hola mundo', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (14, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'uju', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (15, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'awdawdawdawdawdaw', 3)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (16, CAST(N'2022-01-17T00:00:00.000' AS DateTime), N'hola mundo', 3)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (17, CAST(N'2022-01-22T00:00:00.000' AS DateTime), N'Aprende Bitcoin, BlockChain, seguridad informática ( RSA, 2FA, etc ), negocio cripto-fiat (exchanges, bots, etc) en 2020', 20)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (18, CAST(N'2022-01-22T00:00:00.000' AS DateTime), N'dawd', 3)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (19, CAST(N'2022-01-23T00:00:00.000' AS DateTime), N'Aprende Bitcoin, BlockChain, seguridad informática ( RSA, 2FA, etc ), negocio cripto-fiat (exchanges, bots, etc) en 2020', 20)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (20, CAST(N'2022-01-23T00:00:00.000' AS DateTime), N'jajajajja', 20)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (21, CAST(N'2022-01-23T00:00:00.000' AS DateTime), N'Aprende Bitcoin, BlockChain, seguridad informática ( RSA, 2FA, etc ), negocio cripto-fiat (exchanges, bots, etc) en 2020', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (22, CAST(N'2022-01-23T00:00:00.000' AS DateTime), N'awdawd', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (23, CAST(N'2022-01-23T00:00:00.000' AS DateTime), N'Como utilizar los grupos de Facebook, los foros de nichos específicos, y vídeos de YouTube', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (24, CAST(N'2022-01-23T00:00:00.000' AS DateTime), N'El lenguaje de programación más popular y amado por la mayoría de los programadores. Aprende Javascript gratis', 1)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (25, CAST(N'2022-01-23T00:00:00.000' AS DateTime), N'esta moto esta en ingreso para reparar motor', 21)
INSERT [dbo].[Historial] ([Id], [Fecha], [Detalle], [IdMoto]) VALUES (26, CAST(N'2022-01-23T00:00:00.000' AS DateTime), N'esta moto será vendida', 21)
SET IDENTITY_INSERT [dbo].[Historial] OFF
GO
SET IDENTITY_INSERT [dbo].[Motocicleta] ON 

INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (1, N'M102', N'Honda', N'124', N'2 cilindros', CAST(N'2021-11-27T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 6, N'Para Entrega')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (2, N'M103', N'Kawasaki', N'1242', N'4 cilindros', CAST(N'2021-11-27T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 6, N'En Reparación')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (3, N'M1034', N'Honda', N'124', N'2 cilindros', CAST(N'2021-11-27T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 3, N'En Ingreso')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (4, N'M500', N'RTM', N'123123123', N'20 cilindros', CAST(N'2022-01-17T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 3, N'En Reparación')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (15, N'jajajajajajajaj', N'jajajajajjjajajajja', N'123', N'jajajajja', CAST(N'2022-01-17T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 3, N'En Reparación')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (16, N'piero', N'piero', N'123', N'piero', CAST(N'2022-01-17T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 3, N'En Reparación')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (18, N'jajajajjajajajajajajajjajajajjajajajajajajaj', N'jajajajjajajajajajajajjajajajjajajajajajajaj', N'123123', N'jajajajjajajajajaj', CAST(N'2022-01-12T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 6, N'En Reparación')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (19, N'jajajajjajajajajajajajjajajajjajajajajajajaj', N'jajajajjajajajajajajajjajajajjajajajajajajaj', N'123', N'2 cilindros', CAST(N'2022-01-14T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 7, N'Para Entrega')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (20, N'M102', N'Honda', N'124', N'2 cilindros', CAST(N'2022-01-22T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 9, N'En Ingreso')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (21, N'jajajajjajajajajajajajjajajajjajajajajajajaj', N'jajajajjajajajajajajajjajajajjajajajajajajaj', N'124', N'2 cilindros', CAST(N'2022-01-23T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 10, N'Para Entrega')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (22, N'M', N'aw', N'awd', N'awd', CAST(N'2022-09-26T00:00:00.000' AS DateTime), NULL, N'/files/DNI.png', 8, N'En Ingreso')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (23, N'M1034', N'aw', N'awd', N'awd', CAST(N'2022-10-09T00:00:00.000' AS DateTime), N'/files/084208_1220264.png', N'/files/DNI.png', 3, N'En Ingreso')
SET IDENTITY_INSERT [dbo].[Motocicleta] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Nombre], [Apellidos], [Dni], [Correo], [Telefono], [Tipo], [Username], [Password], [Estado]) VALUES (1, N'Angel', N'Rios', N'1234567', N'angel@gmail.com', N'12345678', N'Mecanico', N'angel', N'angel', 1)
INSERT [dbo].[User] ([Id], [Nombre], [Apellidos], [Dni], [Correo], [Telefono], [Tipo], [Username], [Password], [Estado]) VALUES (4, N'Piero', N'Lavy', N'12345678', N'Piero@gmail.com', N'598745632', N'Admin', N'Piero', N'piero', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_User] FOREIGN KEY([IdMecanico])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_User]
GO
ALTER TABLE [dbo].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_Motocicleta] FOREIGN KEY([IdMoto])
REFERENCES [dbo].[Motocicleta] ([Id])
GO
ALTER TABLE [dbo].[Historial] CHECK CONSTRAINT [FK_Historial_Motocicleta]
GO
ALTER TABLE [dbo].[Motocicleta]  WITH CHECK ADD  CONSTRAINT [FK_Motocicleta_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Motocicleta] CHECK CONSTRAINT [FK_Motocicleta_Cliente]
GO
