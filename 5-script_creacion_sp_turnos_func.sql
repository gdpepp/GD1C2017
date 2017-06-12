IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_crear_turno')
DROP PROCEDURE FSOCIETY.sp_crear_turno
GO

CREATE PROCEDURE [FSOCIETY].[sp_crear_turno](@Descripcion varchar(100),@horainicio int, @horafin int, @valorkm smallmoney, @preciobase smallmoney, @habilitado bit)
AS
BEGIN TRANSACTION T1
	insert into FSOCIETY.Turnos (Descripcion, Hora_De_Inicio, Hora_De_Finalizacion,Valor_Km,Precio_Base,Habilitado)
	values(@Descripcion, @horainicio, @horafin, @valorkm, @preciobase,@habilitado)

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	else COMMIT TRANSACTION T1
GO


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_delete_rel_autoTurno')
DROP PROCEDURE FSOCIETY.sp_delete_rel_autoTurno
GO

CREATE PROCEDURE [FSOCIETY].[sp_delete_rel_autoTurno](@id int)
AS
BEGIN TRANSACTION T1
	
	DELETE FSOCIETY.AutosTurnos 
	WHERE IdTurno = @id

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	else COMMIT TRANSACTION T1
GO


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_update_turno')
DROP PROCEDURE FSOCIETY.sp_update_turno
GO

CREATE PROCEDURE [FSOCIETY].[sp_update_turno](@id int, @Descripcion varchar(100),@horainicio int, @horafin int, @valorkm smallmoney, @preciobase smallmoney, @habilitado bit)
AS
BEGIN TRANSACTION T1

	declare @estadoprevio int = (select tur.Habilitado from FSOCIETY.Turnos tur where tur.Id = @id)

	update FSOCIETY.Turnos 
	set Descripcion= @Descripcion, 
	Hora_De_Inicio = @horainicio, 
	Hora_De_Finalizacion = @horafin,
	Valor_Km = @valorkm,
	Precio_Base = @preciobase,
	Habilitado= @habilitado
	where Id = @id

	if (@estadoPrevio = 1 and @estadoPrevio != @habilitado)
		execute FSOCIETY.sp_delete_rel_autoTurno @id;

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	else COMMIT TRANSACTION T1
GO