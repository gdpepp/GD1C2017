USE [GD1C2017]
GO

/* DROP TABLES*/

IF OBJECT_ID('FSOCIETY.Roles','U') IS NOT NULL
    DROP TABLE FSOCIETY.Roles;

IF OBJECT_ID('FSOCIETY.Funcionalidades','U') IS NOT NULL
    DROP TABLE FSOCIETY.Funcionalidades;

IF OBJECT_ID('FSOCIETY.RolFuncionalidades','U') IS NOT NULL
    DROP TABLE FSOCIETY.RolFuncionalidades;

IF OBJECT_ID('FSOCIETY.Direccion','U') IS NOT NULL
    DROP TABLE FSOCIETY.Direccion;

IF OBJECT_ID('FSOCIETY.Direccion','U') IS NOT NULL
    DROP TABLE FSOCIETY.Direccion;

IF OBJECT_ID('FSOCIETY.Personas','U') IS NOT NULL
    DROP TABLE FSOCIETY.Personas;

IF OBJECT_ID('FSOCIETY.Usuarios','U') IS NOT NULL
    DROP TABLE FSOCIETY.Usuarios;

IF OBJECT_ID('FSOCIETY.UsuariosRoles','U') IS NOT NULL
    DROP TABLE FSOCIETY.UsuariosRoles;

IF OBJECT_ID('FSOCIETY.Chofer','U') IS NOT NULL
    DROP TABLE FSOCIETY.Chofer;

IF OBJECT_ID('FSOCIETY.Modelo','U') IS NOT NULL
    DROP TABLE FSOCIETY.Modelo;

IF OBJECT_ID('FSOCIETY.Marcas','U') IS NOT NULL
    DROP TABLE FSOCIETY.Marcas;

IF OBJECT_ID('FSOCIETY.Turnos','U') IS NOT NULL
    DROP TABLE FSOCIETY.Turnos;

IF OBJECT_ID('FSOCIETY.Autos','U') IS NOT NULL
    DROP TABLE FSOCIETY.Autos;

IF OBJECT_ID('FSOCIETY.Cliente','U') IS NOT NULL
    DROP TABLE FSOCIETY.Cliente;

IF OBJECT_ID('FSOCIETY.Viaje','U') IS NOT NULL
    DROP TABLE FSOCIETY.Viaje;

IF OBJECT_ID('FSOCIETY.Facturacion','U') IS NOT NULL
    DROP TABLE FSOCIETY.Facturacion;

IF OBJECT_ID('FSOCIETY.Rendicion','U') IS NOT NULL
    DROP TABLE FSOCIETY.Rendicion;

IF OBJECT_ID('FSOCIETY.Login','U') IS NOT NULL
    DROP TABLE FSOCIETY.Login;

/* DROP SCHEMA*/

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'FSOCIETY')
    DROP SCHEMA FSOCIETY
GO

/* SCHEMA CREATION */

CREATE SCHEMA FSOCIETY
GO

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
--Direccion
----------------------------------------
CREATE TABLE [FSOCIETY].[Direccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Calle] [varchar](100) NOT NULL,
	[Altura] [varchar](10) NOT NULL,
	[Piso] [nchar](10) NULL,
	[Dpto] [nchar](10) NULL,
	[Localidad] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


----------------------------------------
--Personas
----------------------------------------
CREATE TABLE [FSOCIETY].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
	[IdDireccion] [int] NOT NULL,
	[Fecha de Nacimiento] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Direccion] FOREIGN KEY([IdDireccion])
REFERENCES [FSOCIETY].[Direccion] ([Id])
GO

ALTER TABLE [FSOCIETY].[Personas] CHECK CONSTRAINT [FK_Persona_Direccion]
GO

----------------------------------------
--Usuarios
----------------------------------------
CREATE TABLE [FSOCIETY].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Password] [varbinary](50) NOT NULL,
	[IdPersona] [int] NOT NULL,
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
--Login
----------------------------------------
CREATE TABLE [FSOCIETY].[Login](
	[Idusuario] [int] NOT NULL,
	[Reintentos] [smallint] NULL,
	[Fecha] [date] NOT NULL,
	[Logeoexitoso] [nchar](2) NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Login] WITH CHECK ADD  CONSTRAINT [FK_Login_Usuario] FOREIGN KEY([Idusuario])
REFERENCES [FSOCIETY].[Usuarios] ([Id])
GO

INSERT INTO FSOCIETY.Roles (Id, Descripcion, Habilitado)
VALUES (1, 'Administrador', 1),
       (2, 'Chofer', 1),
       (3, 'Cliente', 1);
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_get_modif_roles')
DROP PROCEDURE FSOCIETY.sp_get_modif_roles
GO

CREATE PROCEDURE FSOCIETY.sp_get_modif_roles(@username VARCHAR(50)) 
AS
BEGIN TRANSACTION T1
  /* obtiene roles para admin y todos los roles <> admin para quien no lo sea */
  SELECT * FROM FSOCIETY.Roles
  WHERE (ID <> 1) 
  OR 1 = (SELECT ID
			FROM FSOCIETY.Usuarios u, FSOCIETY.UsuariosRoles r
            WHERE u.Username = @username
            AND r.IdRol = u.IdPersona);
COMMIT TRANSACTION T1
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_delete_usuarios_roles')
DROP PROCEDURE FSOCIETY.sp_delete_usuarios_roles
GO

CREATE PROCEDURE FSOCIETY.sp_delete_usuarios_roles(@id int) AS 
BEGIN TRANSACTION T1
	DELETE FSOCIETY.Usuarios where Id = @id 
COMMIT TRANSACTION T1
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_update_roles')
DROP PROCEDURE FSOCIETY.sp_get_modif_roles
GO

CREATE PROCEDURE FSOCIETY.sp_update_roles (@id INT, @nombre VARCHAR(50), @habilitado BIT) 
AS 
BEGIN TRANSACTION T1
	UPDATE FSOCIETY.Roles 
	SET Descripcion = @nombre,
        Habilitado = @habilitado
    WHERE Id = @id;
	IF @habilitado = 0
	BEGIN
		EXECUTE FSOCIETY.sp_delete_usuarios_roles @id;
	END
COMMIT TRANSACTION T1;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_insert_rol')
DROP PROCEDURE FSOCIETY.sp_insert_rol
GO

CREATE PROCEDURE FSOCIETY.sp_insert_rol (@nombre VARCHAR(50), @habilitado BIT) AS 
BEGIN TRANSACTION T1
	INSERT INTO FSOCIETY.Roles (Id, Descripcion, Habilitado)
	VALUES (NEXT VALUE FOR Id, @nombre, @habilitado)
COMMIT TRANSACTION T1
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_get_rol_funcionalidades')
DROP PROCEDURE FSOCIETY.sp_get_rol_funcionalidades
GO

CREATE PROCEDURE FSOCIETY.sp_get_rol_funcionalidades(@idrol INT) AS BEGIN
  /* Lista las funcionalidades que tiene asignado un rol */
BEGIN TRANSACTION T1
  SELECT func.Id, func.Descripcion
    FROM FSOCIETY.Funcionalidades func, FSOCIETY.RolFuncionalidades rolfunc, FSOCIETY.Roles rol
	WHERE rolfunc.IdRol = @idrol
     AND func.Id = rolfunc.IdFuncionalidad
     AND rol.Id = @idrol
END 
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_insert_funcionalidad')
DROP PROCEDURE FSOCIETY.sp_insert_funcionalidad
GO

CREATE PROCEDURE FSOCIETY.sp_insert_funcionalidad (@idrol INT, @idfun INT) AS 
BEGIN TRANSACTION T1
  /* agrego funcionalidad si es que no lo tenia asignado previamente */
    INSERT INTO FSOCIETY.RolFuncionalidades (idRol, IdFuncionalidad)
    VALUES (@idrol, @idfun)
COMMIT TRANSACTION T1
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_delete_funcionalidad')
DROP PROCEDURE FSOCIETY.sp_delete_funcionalidad
GO

CREATE PROCEDURE FSOCIETY.sp_delete_funcionalidad (@idrol INT, @idfun INT) AS 
BEGIN TRANSACTION T1
  DELETE FROM FSOCIETY.RolFuncionalidades
   WHERE IdRol = @idrol
     AND IdFuncionalidad = @idfun
COMMIT TRANSACTION T1
GO

SET ANSI_PADDING OFF
GO
