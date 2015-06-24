CREATE PROCEDURE validarlogin
	@Username varchar(60),
	@Clave varchar(MAX)
	 AS

	Select 	Usu_nombre, Usu_apellido, Usu_rol, Usu_correo, car_nombre
	from Usuario, cargo
	where usu_username = @Username and usu_clave = @Clave and CARGO_car_id = car_id;

	RETURN
	GO

CREATE PROCEDURE VALIDAR_PREGUNTA_SEGURIDAD
	@Correo varchar(60)
	AS

	Select Usu_respseguridad
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE OBTENER_PREGUNTA_SEGURIDAD
	@Correo varchar(60)
	AS
	Select Usu_pregseguridad
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE VALIDAR_CORREO
	@Correo varchar(60)
	AS

	Select usu_correo
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE CAMBIAR_CLAVE
	@Correo varchar(60),
	@Clave varchar(MAX)
	AS
	begin
    SET NOCOUNT ON 
	UPDATE USUARIO SET
	   usu_clave = @Clave
    WHERE usu_correo = @Correo;
end