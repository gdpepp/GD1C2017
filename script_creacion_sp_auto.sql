IF (OBJECT_ID ('FSOCIETY.sp_crear_auto') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_crear_auto
GO

CREATE PROCEDURE [FSOCIETY].[sp_crear_auto](@idMarca INT, @modelo NVARCHAR(255), @patente NVARCHAR(255), @idTurno INT, @idChofer INT, @habilitado BIT)

AS BEGIN

DECLARE @idModelo INT
DECLARE @idAuto INT

    BEGIN TRANSACTION T1

	INSERT INTO FSOCIETY.Modelos(IdMarca, Description)
	VALUES (@idMarca, @modelo)

	SELECT @idModelo = MODELOS.Id FROM FSOCIETY.Modelos MODELOS WHERE MODELOS.Description = @modelo
	INSERT INTO FSOCIETY.Autos(Patente, IdModelo, IdChofer, Habilitado)
	VALUES (@patente, @idModelo, @idChofer, @habilitado)

	SELECT @idAuto = AUTOS.Id FROM FSOCIETY.Autos AUTOS WHERE AUTOS.Patente = @patente
	INSERT INTO FSOCIETY.AutosTurnos(IdAuto, IdTurno)
	VALUES (@idAuto, @idTurno)
	
	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_eliminar_auto') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_eliminar_auto
GO

CREATE PROCEDURE FSOCIETY.sp_eliminar_auto(@idAuto INT, @idModelo INT, @idTurno INT)

AS BEGIN

	BEGIN TRANSACTION T1

	IF EXISTS (SELECT * FROM FSOCIETY.AutosTurnos WHERE IdAuto = @idAuto AND IdTurno = @idTurno)
		DELETE FSOCIETY.AutosTurnos
		WHERE IdAuto = @idAuto AND IdTurno = @idTurno

	IF NOT EXISTS (SELECT * FROM FSOCIETY.Autos AUTOS WHERE AUTOS.IdModelo = @idModelo)
		DELETE FSOCIETY.Modelos
		WHERE Id = @idModelo

	IF NOT EXISTS (SELECT * FROM FSOCIETY.AutosTurnos AUTOSTURNOS WHERE AUTOSTURNOS.IdAuto = @idAuto)
		DELETE FSOCIETY.Autos
		WHERE Id = @idAuto

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;

END
GO


IF (OBJECT_ID ('FSOCIETY.sp_agregar_turno') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_agregar_turno
GO

CREATE PROCEDURE FSOCIETY.sp_agregar_turno(@idAuto INT, @idTurno INT)

AS BEGIN

	BEGIN TRANSACTION T1

	INSERT INTO FSOCIETY.AutosTurnos(IdAuto, IdTurno)
	VALUES (@idAuto, @idTurno)

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;

END
GO

IF (OBJECT_ID ('FSOCIETY.sp_actualizar_auto') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_actualizar_auto
GO

CREATE PROCEDURE FSOCIETY.sp_actualizar_auto(@idAuto INT, @idModelo INT, @patente NVARCHAR(255), @modelo NVARCHAR(255), @idChofer INT, @idMarca INT,   @idTurno INT,  @habilitado BIT, @idTurnoViejo INT)

AS BEGIN

    BEGIN TRANSACTION T1

	UPDATE FSOCIETY.Modelos
	SET Description = @modelo
	WHERE Id = @idModelo

	UPDATE FSOCIETY.Autos
	SET Patente = @patente, IdChofer = @idChofer, Habilitado = @habilitado
	WHERE Id = @idAuto

	IF EXISTS (SELECT * FROM FSOCIETY.AutosTurnos WHERE IdAuto = @idAuto AND IdTurno = @idTurnoViejo)
		UPDATE FSOCIETY.AutosTurnos
		SET IdTurno = @idTurno
		WHERE IdAuto = @idAuto AND IdTurno = @idTurnoViejo
	
	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
END
GO