USE [GD1C2017]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

/****** Object:  Table [gd_esquema].[FSOCIETY.Roles]    Script Date: 4/19/2017 7:01:31 PM ******/
CREATE TABLE [gd_esquema].[FSOCIETY.Roles](
	[ID] [int] NOT NULL PRIMARY KEY,
	[Descripcion] [varchar](50) NOT NULL UNIQUE,
	[Habilitado] [Bit] NOT NULL DEFAULT 1,
) ON [PRIMARY]

GO

/****** Object:  Table [gd_esquema].[FSOCIETY.Funcionalidades]    Script Date: 4/19/2017 7:01:31 PM ******/
CREATE TABLE [gd_esquema].[FSOCIETY.Funcionalidades](
	[ID] [int] NOT NULL PRIMARY KEY,
	[Descripcion] [varchar](50) NOT NULL UNIQUE,
) ON [PRIMARY]

GO

/****** Object:  Table [gd_esquema].[FSOCIETY.RolFuncionalidades]    Script Date: 4/19/2017 7:01:31 PM ******/
CREATE TABLE [gd_esquema].[FSOCIETY.RolFuncionalidades](
	[IDRol] [int] NOT NULL FOREIGN KEY REFERENCES [gd_esquema].[FSOCIETY.Roles](ID), 
	[IDFuncionalidad] [int] NOT NULL FOREIGN KEY REFERENCES [gd_esquema].[FSOCIETY.Funcionalidades](ID),
	PRIMARY KEY ([IDRol], [IDFuncionalidad])
) ON [PRIMARY]

GO

/****** Object:  Table [gd_esquema].[FSOCIETY.UsuarioRoles]    Script Date: 4/19/2017 7:01:31 PM ******/
--TBD

　
SET ANSI_PADDING OFF
GO

　
　
