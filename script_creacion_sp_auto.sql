IF (OBJECT_ID ('FSOCIETY.sp_crear_auto') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_crear_auto
GO

CREATE PROCEDURE FSOCIETY.sp_crear_auto(@marca INT, @modelo NVARCHAR(255), @patente NVARCHAR(255), @turno INT, @chofer INT, @habilitado BIT, @id INT, @idmodelo INT)

AS BEGIN
    BEGIN TRANSACTION T1

	SET @idmodelo = (SELECT MAX(id)+1 from FSOCIETY.Modelos);
	INSERT INTO FSOCIETY.Modelos(IdMarca, Description)
	VALUES (@marca, @modelo)

	SET @id = (SELECT MAX(id)+1 from FSOCIETY.Autos);
	INSERT INTO FSOCIETY.Autos(Patente, IdModelo, IdTurno, IdChofer, Habilitado)
	VALUES (@patente, @idmodelo, @turno, @chofer, @habilitado)

  	EXECUTE FSOCIETY.sp_create_user @id

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_modificar_auto') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_modificar_auto
GO

CREATE PROCEDURE FSOCIETY.sp_modificar_auto (@marca INT, @modelo NVARCHAR(255), @patente NVARCHAR(255), @turno INT, @chofer INT, @habilitado BIT, @id INT, @idmodelo INT)
AS BEGIN
    BEGIN TRANSACTION T1

	UPDATE FSOCIETY.Modelos
	SET IdMarca = @marca, Description = @modelo WHERE Id = @idmodelo

	UPDATE FSOCIETY.Autos
	SET Patente = @patente, IdTurno = @turno, IdChofer = @chofer, Habilitado = @habilitado WHERE Id = @id

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
END
GO