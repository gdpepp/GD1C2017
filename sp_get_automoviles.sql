IF (OBJECT_ID ('FSOCIETY.sp_crear_auto') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_crear_auto
GO

CREATE PROCEDURE FSOCIETY.sp_crear_auto(@idMarca INT, @modelo NVARCHAR(255), @patente NVARCHAR(255), @idTurno INT, @idChofer INT, @habilitado BIT)

AS BEGIN

DECLARE @idModelo INT

    BEGIN TRANSACTION T1

	INSERT INTO FSOCIETY.Modelos(IdMarca, Description)
	VALUES (@idMarca, @modelo)

	SELECT @idModelo = MODELOS.Id FROM FSOCIETY.Modelos MODELOS WHERE MODELOS.Description = @modelo
	INSERT INTO FSOCIETY.Autos(Patente, IdModelo, IdTurno, IdChofer, Habilitado)
	VALUES (@patente, @idModelo, @idTurno, @idChofer, @habilitado)

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
END
GO