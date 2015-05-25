CREATE PROCEDURE VALIDARLOGIN 
	@Username varchar(60),
	@Clave varchar(60),
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