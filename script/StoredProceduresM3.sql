-----------------------PROCEDIMIENTO PARA CONTAR TUPLAS EN INVOLUCRADOS_CONTACTOS---------------------------
CREATE PROCEDURE Contar_TuplasInvContacto(
	@filas int OUTPUT
)
AS
	BEGIN
		SELECT @filas = count(*) from INVOLUCRADOS_CLIENTES
	END
GO
-----------------------PROCEDIMIENTO PARA CONTAR TUPLAS EN INVOLUCRADOS_USUARIOS---------------------------
CREATE PROCEDURE Contar_TuplasInvUsuario(
	@filas int OUTPUT
)
AS
	BEGIN
		SELECT @filas = count(*) from INVOLUCRADOS_USUARIOS
	END
GO
-----------------------PROCEDIMIENTO PARA CONSULTAR INVOLUCRADOS_CLIENTE---------------------------
CREATE PROCEDURE Procedure_consultarInvCliente
	@proyecto_codigo [varchar](6)
AS
 BEGIN
	SELECT co.con_id as contactoID, co.con_nombre as contactoNombre, co.con_apellido as contactoApellido,
		   ca.car_nombre as cargoNombre, cn.cn_nombre as clienteNatNombre, cj.cj_nombre as clienteJurNombre,
		   cj.cj_id as clienteJurID, cn.cn_id as clienteNatID 
	FROM INVOLUCRADOS_CLIENTES ic, CONTACTO co,  CLIENTE_JURIDICO cj, CLIENTE_NATURAL cn, CARGO ca
	WHERE ic.PROYECTO_pro_id = (select pro_id from PROYECTO where pro_codigo = @proyecto_codigo) and
		  ic.CONTACTO_con_id = co.con_id  and co.CARGO_car_id = ca.car_id and cj.cj_id = co.CLIENTE_JURIDICO_cj_id
		  and co.CLIENTE_NATURAL_cn_id = cn.cn_id
 END
GO
-----------------------PROCEDIMIENTO PARA CONSULTAR INVOLUCRADOS_USUARIOS---------------------------
CREATE PROCEDURE Procedure_consultarInvUsuario
	@proyecto_codigo [varchar](6)
AS
 BEGIN
	SELECT u.usu_id as usuarioID, u.usu_nombre as usuarioNombre, u.usu_apellido as usuarioApellido, c.car_nombre as cargoNombre, u.usu_username as usarioUsername
	FROM INVOLUCRADOS_USUARIOS iu, USUARIO u, CARGO c
	WHERE iu.PROYECTO_pro_id = (select pro_id from PROYECTO where pro_codigo = @proyecto_codigo)
		  AND iu.USUARIO_usu_id = u.usu_id
		  AND c.car_id = u.CARGO_car_id
 END
GO
-----------------------PROCEDIMIENTO PARA ELIMINAR INVOLUCRADOS_CLIENTES---------------------------
CREATE PROCEDURE Procedure_eliminarInvCliente
(
	@contacto_id int,
	@proyecto_codigo [varchar](6)
)   
AS
 BEGIN
	BEGIN TRANSACTION
	DELETE FROM INVOLUCRADOS_CLIENTES WHERE
		CONTACTO_con_id = @contacto_id and
		PROYECTO_pro_id = (select pro_id from PROYECTO where pro_codigo = @proyecto_codigo)
	commit;
 END
GO
-----------------------PROCEDIMIENTO PARA ELIMINAR INVOLUCRADOS_USUARIOS---------------------------
CREATE PROCEDURE Procedure_eliminarInvUsuario
(
	@usuario			  [varchar] (60),
	@proyecto_codigo	  [varchar] (6)
)   
AS
 BEGIN
	BEGIN TRANSACTION
	DELETE FROM INVOLUCRADOS_USUARIOS WHERE
		USUARIO_usu_id = (select usu_id from USUARIO where usu_username = @usuario) and 
		PROYECTO_pro_id = (select pro_id from PROYECTO where pro_codigo = @proyecto_codigo)
	commit;
 END
GO
-----------------------PROCEDIMIENTO PARA INSERTAR INVOLUCRADOS_CLIENTES---------------------------
CREATE PROCEDURE Procedure_InsertarInvCliente
(
	@contacto_id         int,
	@proyecto_codigo     [varchar](6)
)  
AS
 BEGIN
	BEGIN TRANSACTION
		INSERT INTO INVOLUCRADOS_CLIENTES (CONTACTO_con_id, PROYECTO_pro_id) 
			VALUES (@contacto_id,
			(select pro_id from PROYECTO where pro_codigo = @proyecto_codigo));
	COMMIT;
 END
GO
-----------------------PROCEDIMIENTO PARA INSERTAR INVOLUCRADOS_USUARIOS---------------------------
CREATE PROCEDURE Procedure_InsertarInvUsuario
(
	@usuario			 [varchar](60),
	@proyecto_codigo	 [varchar](6)
)
AS
 BEGIN
	BEGIN TRANSACTION
		INSERT INTO INVOLUCRADOS_USUARIOS(USUARIO_usu_id,PROYECTO_pro_id)
			VALUES(
			(select usu_id from USUARIO where usu_username = @usuario),
			(select pro_id from PROYECTO where pro_codigo  = @proyecto_codigo));
	COMMIT;
 END
GO
CREATE PROCEDURE Procedure_consultarDatosUsuarioUsername
	@Username varchar(60),
	@Usu_nombre varchar(60) OUTPUT,
	@Usu_apellido varchar(60) OUTPUT,
	@Usu_cargo varchar(60) OUTPUT
AS
BEGIN
	SELECT @Usu_nombre = usu_nombre, @Usu_apellido = usu_apellido, @Usu_cargo = car_nombre
	from USUARIO, CARGO
	where
		usu_username = @Username and CARGO_car_id = car_id
END
GO
CREATE procedure seleccionarCargosUsuarios
AS
BEGIN
SELECT DISTINCT CAR_NOMBRE as nombreCargo FROM CARGO, USUARIO WHERE CARGO_car_id=car_id
END
GO
CREATE PROCEDURE ListarUsuariosPorCargo
	@cargo varchar(60)

AS
BEGIN
	Select u.usu_id as usuarioID, u.usu_nombre as usuarioNombre, u.usu_apellido as usuarioApellido,
	u.usu_username as usuarioUsername, c.car_nombre as cargoNombre 
	 from USUARIO u, CARGO c
	where
	c.car_nombre = @cargo and c.car_id = u.CARGO_car_id
END
GO

