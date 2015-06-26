CREATE PROCEDURE CambiarCargoUsuario
	 @usu_id [int],
	 @usu_idnuevorol [int]
AS 
begin
    SET NOCOUNT OFF 
    UPDATE USUARIO 
	SET CARGO_car_id = @usu_idnuevorol 
	WHERE usu_id = @usu_id;
end
go
CREATE PROCEDURE ConsultarClave
     @usu_username [varchar] (60),
	 @usu_clave [varchar](max) OUTPUT
AS 
	SELECT @usu_clave = usu_clave
	FROM USUARIO
	WHERE usu_username = @usu_username
RETURN
go

CREATE PROCEDURE ConsultarUsuario
     @usu_id [int]
AS 
begin
    SET NOCOUNT OFF 
	SELECT usu_id,car_nombre,usu_username,usu_clave,usu_nombre,usu_apellido,usu_rol,usu_correo,usu_pregseguridad,usu_respseguridad
	FROM USUARIO,CARGO
	WHERE usu_id = @usu_id AND CARGO_car_id = car_id;
	
end
go

CREATE PROCEDURE ConsultarUsuarioSegunCargo
	 @usu_cargo [varchar](60)
AS 
begin
    SET NOCOUNT OFF 
    SELECT usu_id,usu_username,usu_clave,usu_nombre,usu_apellido,usu_rol,usu_correo,usu_pregseguridad,usu_respseguridad 
    FROM USUARIO 
	WHERE CARGO_car_id=(SELECT car_id FROM CARGO WHERE car_nombre=@usu_cargo)
end
go

CREATE PROCEDURE CorreoUnico
	 @usu_correo varchar(60),
	 @usu_resultado varchar(60) OUTPUT
AS 
    SELECT @usu_resultado = usu_correo FROM USUARIO WHERE usu_correo = @usu_correo
RETURN
go

CREATE PROCEDURE CrearCargo
	 @car_nombre [varchar](60)
AS 
begin
    SET NOCOUNT OFF 
    INSERT INTO CARGO VALUES(
	       NEXT VALUE FOR secuenciaIdCargo,
	       @car_nombre
	)
end
go

CREATE PROCEDURE EliminarCargo
     @car_id [int]
AS 
begin
    SET NOCOUNT OFF 
    DELETE FROM CARGO
	WHERE car_id = @car_id;
end
go


CREATE PROCEDURE EliminarUsuario
     @usu_username [varchar](60) 
AS 
begin
    SET NOCOUNT OFF 
	DELETE FROM INVOLUCRADOS_USUARIOS
	WHERE USUARIO_usu_id=(SELECT usu_id FROM USUARIO WHERE usu_username=@usu_username);
    DELETE FROM USUARIO
	WHERE usu_username = @usu_username;
end
go
CREATE PROCEDURE InsertarUsuario
     @usu_username [varchar](60),
     @usu_clave [varchar](max),
     @usu_nombre [varchar](60),
     @usu_apellido [varchar](60),
     @usu_rol [varchar](60),
     @usu_correo [varchar](60),
     @usupreguntaseguridad [varchar](60),
     @usurespuestaseguridad [varchar](60),
     @usu_car_nombre [varchar](60)
AS
begin
    INSERT INTO USUARIO VALUES(
           NEXT VALUE FOR secuenciaIdUsuario,
           @usu_username,
           @usu_clave,
           @usu_nombre,
           @usu_apellido,
           @usu_rol,
           @usu_correo,
           @usupreguntaseguridad,
           @usurespuestaseguridad,
           (SELECT car_id FROM CARGO WHERE  car_nombre = @usu_car_nombre)
    )
end
go


CREATE PROCEDURE ModificarUsuario
	 @usu_username [varchar](60),
	 @usu_clave [varchar](max),
	 @usu_nombre [varchar](60),
	 @usu_apellido [varchar](60),
	 @usu_rol [varchar](60),
	 @usu_correo [varchar](60),
	 @usupreguntaseguridad [varchar](60),
	 @usurespuestaseguridad [varchar](60),
	 @usu_car_nombre [varchar](60)

AS 
begin
	UPDATE USUARIO SET
	   usu_username = @usu_username,
	   usu_clave = @usu_clave,
	   usu_nombre = @usu_nombre,
	   usu_apellido = @usu_apellido,
	   usu_rol = @usu_rol,
	   usu_correo = @usu_correo,
	   usu_pregseguridad = @usupreguntaseguridad,
	   usu_respseguridad = @usurespuestaseguridad,
	   CARGO_car_id = (SELECT car_id FROM CARGO WHERE  car_nombre = @usu_car_nombre)
    WHERE usu_username = @usu_username;
end
go

	CREATE PROCEDURE ObtenerDatosUsuario
	@usu_username varchar(60),
	@usu_clave varchar(60) OUTPUT,
	@usu_nombre varchar(60) OUTPUT,
	@usu_apellido varchar(60) OUTPUT,
	@usu_rol varchar(60) OUTPUT,
	@Usu_correo varchar(60) OUTPUT,
    @usupreguntaseguridad varchar(60) OUTPUT,
	@usurespuestaseguridad varchar(60) OUTPUT,
	@usu_car_nombre varchar(60) OUTPUT
	 AS
	Select 	@usu_clave = usu_clave,@usu_nombre = Usu_nombre, @usu_apellido = Usu_apellido , @usu_rol = Usu_rol, @usu_correo = Usu_correo,@usupreguntaseguridad=usu_pregseguridad,@usurespuestaseguridad=usu_respseguridad, @usu_car_nombre = car_nombre
	from Usuario, cargo
	where usu_username = @usu_username AND CARGO_car_id = car_id;
	RETURN
	go
	
CREATE PROCEDURE UserNameUnico
     @usu_username varchar(60),
     @usu_resultado varchar(60) OUTPUT
AS 
    SELECT @usu_resultado = usu_username FROM USUARIO WHERE usu_username = @usu_username
RETURN
go

CREATE PROCEDURE ConsultarUsuarioSegunCargo
	 @usu_cargo [varchar](60)
AS 
begin
    SET NOCOUNT OFF 
    SELECT usu_id,usu_username,usu_clave,usu_nombre,usu_apellido,usu_rol,usu_correo,usu_pregseguridad,usu_respseguridad 
    FROM USUARIO 
	WHERE CARGO_car_id=(SELECT car_id FROM CARGO WHERE car_nombre=@usu_cargo)
end
GO



CREATE PROCEDURE ListarUsuario
AS
	Select 	usu_username as NombreUsuario,usu_nombre as Nombre, usu_apellido as Apellido,  car_nombre as CargoNombre
	from Usuario, cargo
	where  CARGO_car_id = car_id;
RETURN
go
CREATE PROCEDURE ListarProyectoUsuario
	@usu_username[varchar](60)
AS
   
   SELECT pro_codigo AS CodigoProyecto,pro_nombre AS NombreProyecto,pro_descripcion AS DescripcionProyecto,pro_costo AS CostoProyecto
   FROM USUARIO,INVOLUCRADOS_USUARIOS,PROYECTO
   WHERE usu_username=@usu_username AND usu_id=USUARIO_usu_id AND PROYECTO_pro_id=pro_id
RETURN
GO

/*
CREATE procedure seleccionarCargos
AS
BEGIN
SELECT DISTINCT CAR_NOMBRE as nombreCargo FROM CARGO, USUARIO WHERE CARGO_car_id=car_id
END
GO*/