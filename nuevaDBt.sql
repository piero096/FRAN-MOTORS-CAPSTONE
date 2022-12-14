USE [franmotors]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 27/10/2022 18:09:37 ******/
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
/****** Object:  Table [dbo].[Historial]    Script Date: 27/10/2022 18:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMoto] [int] NULL,
	[Fecha] [datetime] NULL,
	[Detalle] [nvarchar](500) NULL,
	[Precio] [decimal](18, 2) NULL,
	[Tipo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Historial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motocicleta]    Script Date: 27/10/2022 18:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motocicleta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [nvarchar](50) NULL,
	[Marca] [nvarchar](50) NULL,
	[NumSerie] [nvarchar](50) NULL,
	[Cilindrada] [nvarchar](50) NULL,
	[Año] [datetime] NULL,
	[ImgTarjeta] [nvarchar](500) NULL,
	[ImgMoto] [nvarchar](500) NULL,
	[IdCliente] [int] NULL,
	[EstadoMoto] [nvarchar](50) NULL,
 CONSTRAINT [PK_Motocicleta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/10/2022 18:09:37 ******/
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

INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Dni], [ImageDni], [Correo], [Telefono], [IdMecanico]) VALUES (1, N'Ratousky', N'Eslavousky', N'78954785', N'/files/nasa-logo-web-rgb.png', N'lavypiero096@gmail.com', N'478526369', 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Historial] ON 

INSERT [dbo].[Historial] ([Id], [IdMoto], [Fecha], [Detalle], [Precio], [Tipo]) VALUES (41, 1, CAST(N'2022-10-27T10:58:47.013' AS DateTime), N'cambio de aceite', CAST(120.00 AS Decimal(18, 2)), N'Mecanico')
INSERT [dbo].[Historial] ([Id], [IdMoto], [Fecha], [Detalle], [Precio], [Tipo]) VALUES (42, 1, CAST(N'2022-10-27T14:41:40.547' AS DateTime), N'cambio de aceite', CAST(0.00 AS Decimal(18, 2)), N'Cliente')
INSERT [dbo].[Historial] ([Id], [IdMoto], [Fecha], [Detalle], [Precio], [Tipo]) VALUES (43, 1, CAST(N'2022-10-27T14:43:34.397' AS DateTime), N'cambio de aceite', CAST(12234.00 AS Decimal(18, 2)), N'Mecanico')
INSERT [dbo].[Historial] ([Id], [IdMoto], [Fecha], [Detalle], [Precio], [Tipo]) VALUES (44, 1, CAST(N'2022-10-27T15:30:39.617' AS DateTime), N'cambo de moto', CAST(0.00 AS Decimal(18, 2)), N'Cliente')
INSERT [dbo].[Historial] ([Id], [IdMoto], [Fecha], [Detalle], [Precio], [Tipo]) VALUES (45, 2, CAST(N'2022-10-27T15:30:57.740' AS DateTime), N'cambio de aceite', CAST(20.00 AS Decimal(18, 2)), N'Mecanico')
SET IDENTITY_INSERT [dbo].[Historial] OFF
GO
SET IDENTITY_INSERT [dbo].[Motocicleta] ON 

INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (1, N'M1034', N'awdawd', N'awdawd', N'awdawd', CAST(N'2022-10-21T00:00:00.000' AS DateTime), N'/files/nasa-logo-web-rgb.png', N'/files/nasa-logo-web-rgb.png', 1, N'En Ingreso')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (2, N'M1034123123123123123', N'awdawd', N'awdawd', N'awdawd', CAST(N'2022-10-21T00:00:00.000' AS DateTime), N'/files/nasa-logo-web-rgb.png', N'/files/nasa-logo-web-rgb.png', 1, N'En Ingreso')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (3, N'P402', N'awdawd', N'awdawd', N'awdawd', CAST(N'2022-10-21T00:00:00.000' AS DateTime), N'/files/nasa-logo-web-rgb.png', N'/files/nasa-logo-web-rgb.png', 1, N'En Ingreso')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (4, N'awdawda', N'wdawdawd', N'awdawd', N'awdawdawd', CAST(N'2022-10-21T00:00:00.000' AS DateTime), N'/files/nasa-logo-web-rgb.png', N'/files/nasa-logo-web-rgb.png', 1, N'En Ingreso')
INSERT [dbo].[Motocicleta] ([Id], [Placa], [Marca], [NumSerie], [Cilindrada], [Año], [ImgTarjeta], [ImgMoto], [IdCliente], [EstadoMoto]) VALUES (5, N'M1034a', N'awd', N'awdaw', N'awdawd', CAST(N'2022-10-21T00:00:00.000' AS DateTime), N'/files/nasa-logo-web-rgb.png', N'/files/nasa-logo-web-rgb.png', 1, N'En Ingreso')
SET IDENTITY_INSERT [dbo].[Motocicleta] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Nombre], [Apellidos], [Dni], [Correo], [Telefono], [Tipo], [Username], [Password], [Estado]) VALUES (1, N'Angel', N'Rios', N'1234567', N'angel@gmail.com', N'12345678', N'Mecanico', N'angel', N'SF9Nyo+Dq7wIM1eoM7P0lD7ij//iLkAmvo4LLUX995aVfJUguZ9w3PytCikQGqGownfU7xKx50aP48/j0EGDjw==', 1)
INSERT [dbo].[User] ([Id], [Nombre], [Apellidos], [Dni], [Correo], [Telefono], [Tipo], [Username], [Password], [Estado]) VALUES (4, N'Piero', N'Lavy', N'12345678', N'Piero@gmail.com', N'598745632', N'Admin', N'Piero', N'LKJtgPlnP6crDrCT5OuexMsA6ntRTMVsrV1Ug9kQRD8tY3LaVeqxoeRXwrw1E94LlPic0pCtc+oe95C/0XIenQ==', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_User] FOREIGN KEY([IdMecanico])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_User]
GO
