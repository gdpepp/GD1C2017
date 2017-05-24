IF (OBJECT_ID ('FSOCIETY.sp_alta_cliente') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_alta_cliente

CREATE PROCEDURE FSOCIETY.sp_alta_cliente (@nombre NVARCHAR(255),
                                        @apellido NVARCHAR(255),
                                        @dni NUMERIC(18, 0),
										@mail NVARCHAR(50),
                                        @telefono NVARCHAR(255),
                                        @fecha_nacimiento DATETIME,
                                        @direccion NVARCHAR(255),
                                        @localidad NVARCHAR(255),
                                        @codigo_postal NVARCHAR(50)) 
AS BEGIN
  BEGIN TRY
    BEGIN TRANSACTION
    DECLARE @codigo_persona INT
    EXEC @codigo_persona = FSOCIETY.sp_alta_persona @nombre, @apellido, @dni, @direccion, @fecha_nacimiento,  

    IF @codigo_usuario = -1
      RAISERROR('El usuario ya existe', 16, 1)  -- Que salte directamente al CATCH

    DECLARE @codigo_contacto INT
    EXEC @codigo_contacto = FSOCIETY.sp_alta_persona @nombre, @apellido, @dni, @fecha_nacimiento

    INSERT INTO HARDCOR.Cliente (cod_us, cod_contacto, cli_nombre, cli_apellido, cli_num_doc, cli_fecha_Nac, cli_tipo_doc)
    VALUES (@codigo_usuario, @codigo_contacto, @nombre, @apellido, @dni, @fecha_nacimiento, @tipo_doc)

    COMMIT TRANSACTION
	SELECT @codigo_usuario
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
	SELECT -1
  END CATCH
END
GO