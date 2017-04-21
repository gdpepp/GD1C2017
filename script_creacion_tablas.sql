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
