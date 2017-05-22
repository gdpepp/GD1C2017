USE [GD1C2017]
GO

/*Set schema*/
DECLARE @schemaName as nvarchar(100)
DECLARE @schemaId as int

SET @schemaName = 'FSOCIETY'
SET @schemaId = (select schema_id from sys.schemas where name = @schemaName)

/*Drop constraints*/
DECLARE @query AS nvarchar(400)
DECLARE foreingkeys CURSOR FOR SELECT 
    'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) +
    '].[' + OBJECT_NAME(parent_object_id) + 
    '] DROP CONSTRAINT [' + name + ']'
FROM sys.foreign_keys
WHERE schema_id=@schemaId

OPEN foreingkeys

FETCH NEXT FROM foreingkeys INTO @query

WHILE @@fetch_status = 0

BEGIN
    --PRINT @query
	exec (@query)
    FETCH NEXT FROM foreingkeys INTO @query
END
CLOSE foreingkeys
DEALLOCATE foreingkeys

/*Drop tables*/
DECLARE @queryDrop AS nvarchar(400)
DECLARE tables CURSOR FOR select 
	'DROP TABLE [' + s.name +
	'].[' + t.name + ']'
from sys.tables t
inner join sys.schemas s on t.schema_id = s.schema_id
where t.schema_id=@schemaId

OPEN tables

FETCH NEXT FROM tables INTO @queryDrop

WHILE @@fetch_status = 0

BEGIN
    --PRINT @queryDrop
	exec (@queryDrop)
    FETCH NEXT FROM tables INTO @queryDrop
END
CLOSE tables
DEALLOCATE tables

GO

/* DROP SCHEMA*/
/*
IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'FSOCIETY')
    DROP SCHEMA FSOCIETY
GO
*/
/* SCHEMA CREATION */

/*CREATE SCHEMA FSOCIETY
GO
*/
/****** Object:  Table [FSOCIETY].[Autos]    Script Date: 21/04/2017 12:36:03 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

----------------------------------------
--Roles
----------------------------------------

CREATE TABLE [FSOCIETY].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

----------------------------------------
--Funcionalidades
----------------------------------------
CREATE TABLE [FSOCIETY].[Funcionalidades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

----------------------------------------
--RolFuncionalidades
----------------------------------------
CREATE TABLE [FSOCIETY].[RolFuncionalidades](
	[IdRol] [int] NOT NULL,
	[IdFuncionalidad] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[RolFuncionalidades]  WITH CHECK ADD  CONSTRAINT [FK_RolFuncionalidades_Funcionalidades] FOREIGN KEY([IdFuncionalidad])
REFERENCES [FSOCIETY].[Funcionalidades] ([Id])
GO

ALTER TABLE [FSOCIETY].[RolFuncionalidades] CHECK CONSTRAINT [FK_RolFuncionalidades_Funcionalidades]
GO

ALTER TABLE [FSOCIETY].[RolFuncionalidades]  WITH CHECK ADD  CONSTRAINT [FK_RolFuncionalidades_Roles] FOREIGN KEY([IdRol])
REFERENCES [FSOCIETY].[Roles] ([Id])
GO

ALTER TABLE [FSOCIETY].[RolFuncionalidades] CHECK CONSTRAINT [FK_RolFuncionalidades_Roles]
GO

----------------------------------------
--Personas
----------------------------------------
CREATE TABLE [FSOCIETY].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[DNI] [varchar](8) NOT NULL UNIQUE,
	[Direccion] [varchar](250) NOT NULL,
	[Fecha de Nacimiento] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----------------------------------------
--Usuarios
----------------------------------------
CREATE TABLE [FSOCIETY].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Reintentos] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Personas] FOREIGN KEY([IdPersona])
REFERENCES [FSOCIETY].[Personas] ([Id])
GO

ALTER TABLE [FSOCIETY].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Personas]
GO
----------------------------------------
--UsuariosRoles
----------------------------------------
CREATE TABLE [FSOCIETY].[UsuariosRoles](
	[IdUsuario] [int] NOT NULL,
	[IdRol] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[UsuariosRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosRoles_Roles] FOREIGN KEY([IdRol])
REFERENCES [FSOCIETY].[Roles] ([Id])
GO

ALTER TABLE [FSOCIETY].[UsuariosRoles] CHECK CONSTRAINT [FK_UsuariosRoles_Roles]
GO

ALTER TABLE [FSOCIETY].[UsuariosRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosRoles_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [FSOCIETY].[Usuarios] ([Id])
GO

ALTER TABLE [FSOCIETY].[UsuariosRoles] CHECK CONSTRAINT [FK_UsuariosRoles_Usuarios]
GO
----------------------------------------
--Chofer
----------------------------------------
CREATE TABLE [FSOCIETY].[Chofer](
	[Id] [int] NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Chofer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Chofer]  WITH CHECK ADD  CONSTRAINT [FK_Chofer_Usuarios] FOREIGN KEY([Id])
REFERENCES [FSOCIETY].[Usuarios] ([Id])
GO

ALTER TABLE [FSOCIETY].[Chofer] CHECK CONSTRAINT [FK_Chofer_Usuarios]
GO
----------------------------------------
--Marcas
----------------------------------------
CREATE TABLE [FSOCIETY].[Marcas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
----------------------------------------
--Modelo
----------------------------------------
CREATE TABLE [FSOCIETY].[Modelos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Modelos]  WITH CHECK ADD  CONSTRAINT [FK_Modelos_Marcas] FOREIGN KEY([IdMarca])
REFERENCES [FSOCIETY].[Marcas] ([Id])
GO

ALTER TABLE [FSOCIETY].[Modelos] CHECK CONSTRAINT [FK_Modelos_Marcas]
GO
----------------------------------------
--Turnos
----------------------------------------
CREATE TABLE [FSOCIETY].[Turnos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hora_De_Inicio] [time](0) NOT NULL,
	[Hora_De_Finalizacion] [time](0) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Valor_Km] [smallmoney] NOT NULL,
	[Precio_Base] [smallmoney] NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
----------------------------------------
--Autos
----------------------------------------
CREATE TABLE [FSOCIETY].[Autos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Patente] [varchar](8) NOT NULL,
	[IdModelo] [int] NOT NULL,
	[IdTurno] [int] NOT NULL,
	[IdChofer] [int] NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Autos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Chofer] FOREIGN KEY([IdChofer])
REFERENCES [FSOCIETY].[Chofer] ([Id])
GO

ALTER TABLE [FSOCIETY].[Autos] CHECK CONSTRAINT [FK_Autos_Chofer]
GO

ALTER TABLE [FSOCIETY].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Modelos] FOREIGN KEY([IdModelo])
REFERENCES [FSOCIETY].[Modelos] ([Id])
GO

ALTER TABLE [FSOCIETY].[Autos] CHECK CONSTRAINT [FK_Autos_Modelos]
GO

ALTER TABLE [FSOCIETY].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Turnos] FOREIGN KEY([IdTurno])
REFERENCES [FSOCIETY].[Turnos] ([Id])
GO

ALTER TABLE [FSOCIETY].[Autos] CHECK CONSTRAINT [FK_Autos_Turnos]
GO

----------------------------------------
--Cliente
----------------------------------------
CREATE TABLE [FSOCIETY].[Cliente](
	[Id] [int] NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Codigo_Postal] [varchar](10) NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuarios] FOREIGN KEY([Id])
REFERENCES [FSOCIETY].[Usuarios] ([Id])
GO

ALTER TABLE [FSOCIETY].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuarios]
GO

----------------------------------------
--Viajes
----------------------------------------
CREATE TABLE [FSOCIETY].[Viaje](
	[IdChofer] [int] NOT NULL,
	[IdAuto] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdTurno] [int] NOT NULL,
	[CantKm] [int] NOT NULL,
	[FechaHoraInicio] [date] NOT NULL,
	[FechaHoraFin] [date] NOT NULL
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[IdChofer], [IdCliente], [IdTurno]
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Chofer] FOREIGN KEY([IdChofer])
REFERENCES [FSOCIETY].[Chofer] ([Id])
GO

ALTER TABLE [FSOCIETY].[Viaje] CHECK CONSTRAINT [FK_Viaje_Chofer]
GO

ALTER TABLE [FSOCIETY].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Auto] FOREIGN KEY([IdAuto])
REFERENCES [FSOCIETY].[Autos] ([Id])
GO

ALTER TABLE [FSOCIETY].[Viaje] CHECK CONSTRAINT [FK_Viaje_Auto]
GO

ALTER TABLE [FSOCIETY].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [FSOCIETY].[Cliente] ([Id])
GO

ALTER TABLE [FSOCIETY].[Viaje] CHECK CONSTRAINT [FK_Viaje_Cliente]
GO

ALTER TABLE [FSOCIETY].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Turno] FOREIGN KEY([IdTurno])
REFERENCES [FSOCIETY].[Turnos] ([Id])
GO

ALTER TABLE [FSOCIETY].[Viaje] CHECK CONSTRAINT [FK_Viaje_Turno]
GO

----------------------------------------
--Facturacion
----------------------------------------
CREATE TABLE [FSOCIETY].[Facturacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdViaje] [int] NOT NULL,
	[FechaInicio] [smalldatetime] NOT NULL,
	[FechaFin] [smalldatetime] NOT NULL,
	[Importe] [money] NOT NULL,
 CONSTRAINT [PK_Facturacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Facturacion]  WITH CHECK ADD  CONSTRAINT [FK_Facturacion_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [FSOCIETY].[Cliente] ([Id])
GO

ALTER TABLE [FSOCIETY].[Facturacion] CHECK CONSTRAINT [FK_Facturacion_Cliente]
GO

----------------------------------------
--Rendicion
----------------------------------------
CREATE TABLE [FSOCIETY].[Rendicion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdChofer] [int] NOT NULL,
	[IdTurno] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[ImporteTotal] [money] NOT NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_Rendicion_Chofer] FOREIGN KEY([IdChofer])
REFERENCES [FSOCIETY].[Chofer] ([Id])
GO

ALTER TABLE [FSOCIETY].[Rendicion] CHECK CONSTRAINT [FK_Rendicion_Chofer]
GO

ALTER TABLE [FSOCIETY].[Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_Rendicion_Turnos] FOREIGN KEY([IdTurno])
REFERENCES [FSOCIETY].[Turnos] ([Id])
GO

ALTER TABLE [FSOCIETY].[Rendicion] CHECK CONSTRAINT [FK_Rendicion_Turnos]
GO

----------------------------------------
--Creo al admin
----------------------------------------
insert into FSOCIETY.Personas(Nombre,Apellido,DNI,Direccion,[Fecha de Nacimiento])
values('Admin','Admin','35323521','Salvigny 1821','1990/07/25')

GO

insert into FSOCIETY.Usuarios(Username,Password,IdPersona,Reintentos)
values('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',1,0)

GO

INSERT INTO FSOCIETY.Roles (Descripcion, Habilitado)
VALUES ('Administrador', 1),
       ('Chofer', 1),
       ('Cliente', 1);

GO

SET ANSI_PADDING OFF
GO
