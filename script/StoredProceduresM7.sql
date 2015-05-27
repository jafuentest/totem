CREATE PROCEDURE CambiarCargoUsuario
	 @usu_id [int],
	 @usu_idnuevorol [int]
AS 
begin
    SET NOCOUNT ON 
    UPDATE USUARIO 
	SET CARGO_car_id = @usu_idnuevorol 
	WHERE usu_id = @usu_id;
end

CREATE PROCEDURE ConsultarUsuario
     @usu_id [int]
AS 
begin
    SET NOCOUNT ON 
	SELECT usu_id,car_nombre,usu_username,usu_clave,usu_nombre,usu_apellido,usu_rol,usu_correo,usu_pregseguridad,usu_respseguridad
	FROM USUARIO,CARGO
	WHERE usu_id = @usu_id AND CARGO_car_id = car_id;
	
end

CREATE PROCEDURE CrearCargo
	 @car_nombre [varchar](60)
AS 
begin
    SET NOCOUNT ON 
    INSERT INTO CARGO VALUES(
	       NEXT VALUE FOR secuenciaIdCargo,
	       @car_nombre
	)
end

CREATE PROCEDURE EliminarCargo
     @car_id [int]
AS 
begin
    SET NOCOUNT ON 
    DELETE FROM CARGO
	WHERE car_id = @car_id;
end

CREATE PROCEDURE EliminarUsuario
     @usu_id [int] 
AS 
begin
    SET NOCOUNT ON 
    DELETE FROM USUARIO
	WHERE usu_id = @usu_id;
end

CREATE PROCEDURE InsertarUsuario
     @usu_username [varchar](60),
     @usu_clave [varchar](60),
     @usu_nombre [varchar](60),
     @usu_apellido [varchar](60),
     @usu_rol [varchar](60),
     @usu_correo [varchar](60),
     @usupreguntaseguridad [varchar](60),
     @usurespuestaseguridad [varchar](60),
     @usu_car_nombre [varchar](60)

AS
begin
    SET NOCOUNT ON
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

CREATE PROCEDURE ModificarUsuario
	 @usu_username [varchar](60),
	 @usu_clave [varchar](60),
	 @usu_nombre [varchar](60),
	 @usu_apellido [varchar](60),
	 @usu_rol [varchar](60),
	 @usu_correo [varchar](60),
	 @usupreguntaseguridad [varchar](60),
	 @usurespuestaseguridad [varchar](60),
	 @usu_car_nombre [varchar](60)

AS 
begin
    SET NOCOUNT ON 
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