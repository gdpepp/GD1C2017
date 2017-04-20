USE [GD1C2017]
GO

/****** Object:  Table [dbo].[FSOCIETY.Roles]    Script Date: 4/19/2017 7:01:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [gd_esquema].[FSOCIETY.Roles](
	[ID] [int] NOT NULL PRIMARY KEY,
	[Descripcion] [varchar](50) NOT NULL UNIQUE,
	[Habilitado] [Bit] NOT NULL DEFAULT 1,
) ON [PRIMARY]

GO
CREATE TABLE [gd_esquema].[FSOCIETY.Funcionalidades](
	[ID] [int] NOT NULL PRIMARY KEY,
	[Descripcion] [varchar](50) NOT NULL UNIQUE,
) ON [PRIMARY]

GO

CREATE TABLE [gd_esquema].[FSOCIETY.RolFuncionalidades](
	[IDRol] [int] NOT NULL FOREIGN KEY REFERENCES [gd_esquema].[FSOCIETY.Roles](ID), 
	[IDFuncionalidad] [int] NOT NULL FOREIGN KEY REFERENCES [gd_esquema].[FSOCIETY.Funcionalidades](ID)
) ON [PRIMARY]

GO

/**
ALTER TABLE [gd_esquema].[FSOCIETY.RolFuncionalidades] 
ADD FOREIGN KEY(IDRol) REFERENCES [gd_esquema].[FSOCIETY.Roles](ID)
GO

ALTER TABLE [gd_esquema].[FSOCIETY.RolFuncionalidades] 
ADD FOREIGN KEY(IDFuncionalidad) REFERENCES [gd_esquema].[FSOCIETY.Funcionalidades](ID)
GO
**/

SET ANSI_PADDING OFF
GO


