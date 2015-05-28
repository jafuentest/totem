/*                  Procedimientos del Módulo 4                      */



-------------------Procedimiento para Agregar un proyecto con Cliente Juridico----------------------
CREATE PROCEDURE Procedure_AgregarProyectoClienteJuridico
		 
		
		@pro_codigo[varchar] (6),
		@pro_nombre [varchar] (60),
		@pro_estado [bit],
		@pro_descripcion [varchar] (600),
		@pro_costo       [int],
		@pro_moneda      [varchar] (3),
		@CLIENTE_JURIDICO_cj_id [int]
AS 
BEGIN
		INSERT INTO PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_JURIDICO_cj_id)
	    VALUES(@pro_codigo,@pro_nombre,@pro_estado,@pro_descripcion,@pro_costo,@pro_moneda,@CLIENTE_JURIDICO_cj_id)
END;
GO

-------------------Procedimiento para Agregar un proyecto con Cliente Natural----------------------
CREATE PROCEDURE Procedure_AgregarProyectoClienteNatural
		 
		
		@pro_codigo[varchar] (6),
		@pro_nombre [varchar] (60),
		@pro_estado [bit],
		@pro_descripcion [varchar] (600),
		@pro_costo       [int],
		@pro_moneda      [varchar] (3),
		@CLIENTE_NATURAL_cn_id [int]
AS 
BEGIN
		INSERT INTO PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_JURIDICO_cj_id)
	    VALUES(@pro_codigo,@pro_nombre,@pro_estado,@pro_descripcion,@pro_costo,@pro_moneda,@CLIENTE_NATURAL_cn_id)
END;
GO




-------------------Procedimiento para Agregar un proyecto sin cliente (solo para pruebas del modulo 4)----------------------
CREATE PROCEDURE Procedure_AgregarProyecto
		 
		
		@pro_codigo[varchar] (6),
		@pro_nombre [varchar] (60),
		@pro_estado [bit],
		@pro_descripcion [varchar] (600),
		@pro_costo       [int],
		@pro_moneda      [varchar] (3)
AS 
BEGIN
		INSERT INTO PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda)
	    VALUES(@pro_codigo,@pro_nombre,@pro_estado,@pro_descripcion,@pro_costo,@pro_moneda)
END;
GO

------------------ Procedimientos para Modificar-------------------------------------------------------------------------------
CREATE PROCEDURE Procedure_ModificarProyecto
		 
		
		@pro_codigo[varchar] (6) ,
		@pro_nombre [varchar] (60),
		@pro_estado [bit],
		@pro_descripcion [varchar] (600),
		@pro_costo       [int],
		@pro_moneda      [varchar] (3),
		@codigo_anterior [varchar] (6)
AS 
BEGIN
		UPDATE PROYECTO SET pro_codigo = @pro_codigo, pro_nombre = @pro_nombre, pro_estado = @pro_estado, pro_descripcion = @pro_descripcion, pro_costo = @pro_costo, pro_moneda = @pro_moneda
		WHERE pro_codigo = @codigo_anterior
END;
GO



------------------ Procedimientos para consultar-------------------------------------------------------------------------------


--Procedimiento para verificar existencia de un proyecto ----------------------
CREATE PROCEDURE Procedure_ExisteProyecto
 
		@pro_codigo[varchar] (6),
		@resultado int OUTPUT
AS 
BEGIN
    IF EXISTS (SELECT * FROM PROYECTO P WHERE pro_codigo = @pro_codigo)
        SELECT @resultado = 1
    ELSE
        SELECT @resultado = 0
	RETURN
END
-- Procedimiento para consultar un Proyecto----------------------

CREATE PROCEDURE Procedure_ConsultarProyecto
	
	@pro_codigo [varchar] (6) ,
	@pro_codigo2 [varchar] (6) OUTPUT,
	@pro_nombre [varchar] (60) OUTPUT,
	@pro_estado [bit] OUTPUT,
	@pro_descripcion [varchar] (600)OUTPUT,
	@pro_costo       [int] OUTPUT,
	@pro_moneda      [varchar] (3)OUTPUT
	@pro_moneda      [varchar] (3)OUTPUT
	
	
	   
AS
 BEGIN
	
	SELECT @pro_codigo2=pro_codigo, @pro_nombre= pro_nombre, @pro_estado=pro_estado,@pro_descripcion =pro_descripcion,@pro_costo=pro_costo,@pro_moneda  =pro_moneda
	FROM PROYECTO P
	WHERE (P.pro_codigo=@pro_codigo) 
	RETURN
 END
GO

-- Procedimiento para consultar los Proyectos asociados a un usuario----------------------

CREATE PROCEDURE Procedure_ProyectosDeUsuario
 
	@usu_username[varchar] (6),
	@pro_codigo [varchar] (6)OUTPUT ,
	@pro_nombre [varchar] (60) OUTPUT,
	@pro_estado [bit] OUTPUT,
	@pro_descripcion [varchar] (600)OUTPUT,
	@pro_costo       [int] OUTPUT,
	@pro_moneda      [varchar] (3)OUTPUT
AS 
BEGIN
    SELECT @pro_codigo=pro_codigo, @pro_nombre=pro_nombre, @pro_estado=pro_estado, @pro_descripcion=pro_descripcion, @pro_costo=pro_costo, @pro_moneda=pro_moneda FROM PROYECTO INNER JOIN INVOLUCRADOS_USUARIOS ON PROYECTO.pro_id = INVOLUCRADOS_USUARIOS.PROYECTO_pro_id
	WHERE (SELECT usu_id FROM USUARIO WHERE USUARIO.usu_username = @usu_username) = INVOLUCRADOS_USUARIOS.USUARIO_usu_id
	RETURN
END
GO


-- Procedimiento para Eliminar un Proyecto (solo para pruebas)---------------------

CREATE PROCEDURE Procedure_EliminarProyecto
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	DELETE FROM PROYECTO WHERE (pro_codigo=@pro_codigo)
 END
GO