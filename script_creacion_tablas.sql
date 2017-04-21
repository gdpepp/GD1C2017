USE [GD1C2017]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE SEQUENCE [gd_esquema].[FSOCIETY.RolesIDSeq]
	START WITH 1
	INCREMENT BY 1
	NO CACHE
	;
GO

CREATE TABLE [gd_esquema].[FSOCIETY.Roles](
	[ID] [int] NOT NULL PRIMARY KEY DEFAULT (NEXT VALUE FOR [gd_esquema].[FSOCIETY.RolesIDSeq]),
	[Descripcion] [varchar](50) NOT NULL UNIQUE,
	[Habilitado] [Bit] NOT NULL DEFAULT 1,
) ON [PRIMARY]

GO

CREATE SEQUENCE [gd_esquema].[FSOCIETY.FuncionalidadesIDSeq]
	START WITH 1
	INCREMENT BY 1
	NO CACHE
	;
GO

CREATE TABLE [gd_esquema].[FSOCIETY.Funcionalidades](
	[ID] [int] NOT NULL PRIMARY KEY DEFAULT (NEXT VALUE FOR [gd_esquema].[FSOCIETY.FuncionalidadesIDSeq]),
	[Descripcion] [varchar](50) NOT NULL UNIQUE,
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[FSOCIETY.RolFuncionalidades](
	[IDRol] [int] NOT NULL FOREIGN KEY REFERENCES [gd_esquema].[FSOCIETY.Roles](ID), 
	[IDFuncionalidad] [int] NOT NULL FOREIGN KEY REFERENCES [gd_esquema].[FSOCIETY.Funcionalidades](ID),
	PRIMARY KEY ([IDRol], [IDFuncionalidad])
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[FSOCIETY.UruarioRoles](
	[IDUsuario] [int] NOT NULL FOREIGN KEY REFERENCES [gd_esquema].[FSOCIETY.Usuarios](ID), 
	[IDRol] [int] NOT NULL FOREIGN KEY REFERENCES [gd_esquema].[FSOCIETY.Roles](ID),
) ON [PRIMARY]

/****** Object:  Table [gd_esquema].[FSOCIETY.Clientes]    Script Date: 4/20/2017 10:05:17 PM ******/
CREATE TABLE [gd_esquema].[FSOCIETY.Clientes](
	[ID] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[DNI] [int] NOT NULL,
	[Mail] [varchar](50) NULL,
	[Telefono] [int] NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[CodigoPostal] [int] NOT NULL,
	[FechaDeNacimiento] [smalldatetime] NOT NULL,
	[Inhabilitado] [bit] NOT NULL,
 CONSTRAINT [PK_FSOCIETY.Clientes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [gd_esquema].[FSOCIETY.Facturacion]    Script Date: 4/20/2017 10:05:28 PM ******/
CREATE TABLE [gd_esquema].[FSOCIETY.Facturacion](
	[ID] [int] NOT NULL,
	[IDClientes] [int] NOT NULL,
	[IDViaje] [int] NOT NULL,
	[FechaInicio] [smalldatetime] NOT NULL,
	[FechaFin] [smalldatetime] NOT NULL,
	[Importe] [int] NOT NULL,
 CONSTRAINT [PK_FSOCIETY.Facturacion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [gd_esquema].[FSOCIETY.Rendicion]    Script Date: 4/20/2017 11:24:58 PM ******/
CREATE TABLE [gd_esquema].[FSOCIETY.Rendicion](
	[ID] [int] NOT NULL,
	[IDChofer] [int] NOT NULL,
	[IDTurno] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[ImporteTotal] [int] NOT NULL,
 CONSTRAINT [PK_FSOCIETY.Rendicion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [gd_esquema].[FSOCIETY.Login](
	[Idusuario] [nchar](10) NOT NULL,
	[Reintentos] [smallint] NULL,
	[Fecha] [date] NOT NULL,
	[Logeoexitoso] [nchar](2) NOT NULL
) ON [PRIMARY]

GO
CREATE TABLE [gd_esquema].[FSOCIETY.Usuarios](
	[Idusuario] [int] NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Password] [varbinary](50) NOT NULL,
  PRIMARY KEY ([Idusuario])
 )ON [PRIMARY]

 GO

SET ANSI_PADDING OFF
GO
