IF (OBJECT_ID ('FSOCIETY.sp_crear_persona') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_crear_persona
GO

CREATE PROCEDURE FSOCIETY.sp_crear_persona (@nombre NVARCHAR(255),
                                        @apellido NVARCHAR(255),
                                        @dni NUMERIC(18, 0),
										@direccion NVARCHAR(255),
                                        @fecha_nacimiento DATETIME,
										@id INT OUTPUT)
AS BEGIN
    BEGIN TRANSACTION T1

	set @id = (SELECT MAX(id)+1 from FSOCIETY.Personas);

	insert into FSOCIETY.Personas (id, Nombre, Apellido, DNI, Direccion, [Fecha de Nacimiento])
	values (@id, @nombre, @apellido, @dni, @direccion, @fecha_nacimiento)

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_crear_cliente') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_crear_cliente
GO

CREATE PROCEDURE FSOCIETY.sp_crear_cliente (@telefono varchar(50), 
											@mail varchar(50),
											@codigoPostal varchar(10),
											@idCliente int OUTPUT)
AS BEGIN
    BEGIN TRANSACTION T1

	set @idCliente = (SELECT MAX(id)+1 from FSOCIETY.Cliente);

	insert into FSOCIETY.Cliente(id, Telefono, Email, Codigo_Postal, Habilitado)
	values (@idCliente, @telefono, @mail, @codigoPostal, 1);
	
	execute FSOCIETY.sp_set_rol_cliente @idCliente;

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
	
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_set_rol_cliente') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_set_rol_cliente
GO

CREATE PROCEDURE FSOCIETY.sp_set_rol_cliente (@idCliente int)
AS BEGIN
BEGIN TRANSACTION
	INSERT INTO FSOCIETY.UsuariosRoles (IdUsuario, IdRol)
	values(@idCliente, 3)

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
COMMIT TRANSACTION
END
GO