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
	    VALUES(@pro_codigo,@pro_nombre,@pro_estado,@pro_descripcion,@pro_costo,@pro_moneda,(SELECT cj_id FROM CLIENTE_JURIDICO WHERE CLIENTE_JURIDICO.cj_rif = @CLIENTE_JURIDICO_cj_id))
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
		INSERT INTO PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_NATURAL_cn_id)
	    VALUES(@pro_codigo,@pro_nombre,@pro_estado,@pro_descripcion,@pro_costo,@pro_moneda, (SELECT cn_id FROM CLIENTE_NATURAL WHERE CLIENTE_NATURAL.cn_cedula = @CLIENTE_NATURAL_cn_id))
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

go

--Procedimiento para verificar que tipo de cliente tiene un proyecto ----------------------
CREATE PROCEDURE Procedure_ObtenerTipoClienteProyecto
 
		@pro_codigo[varchar] (6),
		@resultado int OUTPUT
AS 
BEGIN
    IF (SELECT CLIENTE_JURIDICO_cj_id FROM PROYECTO WHERE pro_codigo = @pro_codigo) IS NOT NULL
        SELECT @resultado = 1
    ELSE
		IF(SELECT CLIENTE_NATURAL_cn_id FROM PROYECTO WHERE pro_codigo = @pro_codigo) IS NOT NULL
        SELECT @resultado = 0
	RETURN
END


-- Procedimiento para consultar un Proyecto----------------------
go 
CREATE PROCEDURE Procedure_ConsultarProyecto
	
	@pro_codigo [varchar] (6) ,
	@pro_codigo2 [varchar] (6) OUTPUT,
	@pro_nombre [varchar] (60) OUTPUT,
	@pro_estado [bit] OUTPUT,
	@pro_descripcion [varchar] (600)OUTPUT,
	@pro_costo       [int] OUTPUT,
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
 
	@usu_username[varchar] (60)
AS 
BEGIN
    SELECT pro_codigo as codigo, pro_nombre as nombre , pro_estado as estado, pro_descripcion as descripcion, pro_costo as costo, pro_moneda as moneda
	 from USUARIO U , INVOLUCRADOS_USUARIOS IU,PROYECTO P 
	 where usu_username=@usu_username AND U.usu_id=IU.USUARIO_usu_id AND P.pro_id=IU.PROYECTO_pro_id

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

-- Procedimiento para buscar un Proyecto----------------------

CREATE PROCEDURE Procedure_BuscarProyecto
	
	@parametro [varchar] (60) 
	   
AS
 BEGIN
	
	SELECT pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda
	FROM PROYECTO 
	WHERE (pro_codigo LIKE '%@parametro%') OR (pro_nombre LIKE '%@parametro%')
	RETURN
 END
 GO
 -- Procedimiento para buscar un Proyecto inactivo----------------------

CREATE PROCEDURE Procedure_BuscarProyectoInactivo
	
	@parametro [varchar] (60) 
	   
AS
 BEGIN
	
	SELECT pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda
	FROM PROYECTO 
	WHERE (pro_codigo LIKE '%@parametro%') OR (pro_nombre LIKE '%@parametro%') AND (pro_estado = 0)
	RETURN
 END
 GO
 -- Procedimiento para buscar un Proyecto activo----------------------

CREATE PROCEDURE Procedure_BuscarProyectoActivo
	
	@parametro [varchar] (60) 
	   
AS
 BEGIN
	
	SELECT pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda
	FROM PROYECTO 
	WHERE (pro_codigo LIKE '%@parametro%') OR (pro_nombre LIKE '%@parametro%') AND (pro_estado = 1)
	RETURN
 END
 GO

 
 
 
CREATE PROCEDURE M5_ContarRequerimientosFinalizadosPorProyecto

	@pro_codigo			[varchar] (6),
	@resultado int OUTPUT

AS
	BEGIN
		SELECT	count(*)
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO  WHERE pro_codigo = @pro_codigo) and req_estatus='Finalizado' )
	END
GO



CREATE PROCEDURE M5_ContarRequerimientosPorProyecto

	@pro_codigo			[varchar] (6),
	@resultado int OUTPUT

AS
	BEGIN
		SELECT	count(*)
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO  WHERE pro_codigo = @pro_codigo) )
	END
GO


-- ========================================================================= --
-- Consultar requerimientos por proyecto para la generacion de documentos(Todos)
-- ========================================================================= --

CREATE PROCEDURE M5_ConsultarRequerimientosFinalizadosPorProyecto

	
	@pro_codigo			[varchar] (6)

AS
	BEGIN
		SELECT	req_id, req_codigo, req_descripcion,
				req_tipo, req_prioridad,req_estatus
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO  WHERE pro_codigo = @pro_codigo) AND req_estatus='Finalizado' )
	END
GO

CREATE PROCEDURE M5_ConsultarRequerimientosFuncionalesPorProyecto

	
	@pro_codigo			[varchar] (6)

AS
	BEGIN
		SELECT	req_id, req_codigo, req_descripcion,
				req_tipo, req_prioridad,req_estatus
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO  WHERE pro_codigo = @pro_codigo)AND req_tipo='Funcional')
	END
GO


CREATE PROCEDURE M5_ConsultarRequerimientosNoFuncionalesPorProyecto

	
	@pro_codigo			[varchar] (6)

AS
	BEGIN
		SELECT	req_id, req_codigo, req_descripcion,
				req_tipo, req_prioridad,req_estatus
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO  WHERE pro_codigo = @pro_codigo) AND req_tipo='No Funcional')
	END
GO

