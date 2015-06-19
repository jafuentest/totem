CREATE PROCEDURE validar_login
	@Username varchar(60),
	@Clave varchar(MAX),
	@Usu_nombre varchar(60) OUTPUT,
	@Usu_apellido varchar(60) OUTPUT,
	@Usu_rol varchar(60) OUTPUT,
	@Usu_correo varchar(60) OUTPUT,
	@Usu_cargo varchar(60) OUTPUT
	 AS

	Select 	@Usu_nombre = usu_nombre, @Usu_apellido = usu_apellido , @Usu_rol = usu_rol, @Usu_correo = usu_correo, @Usu_cargo = car_nombre
	from USUARIO, CARGO
	where usu_username = @Username and usu_clave = @Clave and CARGO_car_id = car_id;

	RETURN
	GO

CREATE PROCEDURE obtener_pregunta_seguridad
	@Correo varchar(60),
	@Usu_pregseguridad varchar(60) OUTPUT
	AS

	Select @Usu_pregseguridad =  Usu_pregseguridad
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE validar_pregunta_seguridad
	@Correo varchar(60),
	@Usu_respseguridad varchar(100) OUTPUT
	AS

	Select @Usu_respseguridad = Usu_respseguridad
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE validar_correo
	@Correo varchar(60),
	@usu_correo varchar(60) OUTPUT
	AS

	Select @Usu_correo = usu_correo
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE cambiar_clave
	@Correo varchar(60),
	@Clave varchar(MAX)
	AS
	begin
    SET NOCOUNT ON 
	UPDATE USUARIO SET
	   usu_clave = @Clave
    WHERE usu_correo = @Correo;
end