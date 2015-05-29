CREATE PROCEDURE VALIDARLOGIN 
	@Username varchar(60),
	@Clave varchar(MAX),
	@Usu_nombre varchar(60) OUTPUT,
	@Usu_apellido varchar(60) OUTPUT,
	@Usu_rol varchar(60) OUTPUT,
	@Usu_correo varchar(60) OUTPUT,
	@Usu_cargo varchar(60) OUTPUT
	 AS

	Select 	@Usu_nombre = Usu_nombre, @Usu_apellido = Usu_apellido , @Usu_rol = Usu_rol, @Usu_correo = Usu_correo, @Usu_cargo = car_nombre
	from Usuario, cargo
	where usu_username = @Username and usu_clave = @Clave and CARGO_car_id = car_id;

	RETURN
	GO

CREATE PROCEDURE OBTENER_PREGUNTA_SEGURIDAD
	@Correo varchar(60),
	@Usu_pregseguridad varchar(60) OUTPUT
	AS

	Select @Usu_pregseguridad =  Usu_pregseguridad
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE VALIDAR_PREGUNTA_SEGURIDAD
	@Correo varchar(60),
	@Usu_respseguridad varchar(100) OUTPUT
	AS

	Select @Usu_respseguridad = Usu_respseguridad
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE VALIDAR_CORREO
	@Correo varchar(60),
	@usu_correo varchar(60) OUTPUT
	AS

	Select @Usu_correo = usu_correo
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