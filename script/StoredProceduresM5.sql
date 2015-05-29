

---Procedimiento para agregar un Requerimiento a un Proyecto--------------

CREATE PROCEDURE Procedure_AgregarRequerimiento

        @req_codigo [varchar] (15),
        @req_descripcion [varchar] (500),
		@req_tipo [varchar] (25),
		@req_prioridad [varchar] (10),
		@req_estatus [varchar] (50),	
		@PROYECTO_pro_id [int]

AS 
BEGIN
		INSERT INTO REQUERIMIENTO(req_codigo, req_descripcion, req_tipo, req_prioridad, req_estatus, PROYECTO_pro_id)
	    VALUES(@req_codigo,@req_descripcion,@req_tipo,@req_prioridad,@req_estatus,@PROYECTO_pro_id)
END;
GO

---Procedimiento para Modificar un Requerimiento a un Proyecto--------------

CREATE PROCEDURE Procedure_ModificarRequerimiento

        @req_id [int],
        @req_codigo [varchar] (15),
        @req_descripcion [varchar] (500),
		@req_tipo [varchar] (25),
		@req_prioridad [varchar] (10),
		@req_estatus [varchar] (50)

AS 
BEGIN
 	UPDATE REQUERMIENTO
 	SET
 		req_codigo = @req_codigo,
 		req_descripcion = @req_descripcion,
 		req_tipo = @req_tipo,
 		req_prioridad = @req_prioridad,
 		req_estatus =@req_estatus
 	WHERE
 		req_id = @req_id;		
END		 	
GO


---Procedimiento para Eliminar un Requerimiento a un Proyecto--------------

CREATE PROCEDURE Procedure_EliminarRequerimiento

        @req_id [int]

AS 
BEGIN
 	DELETE FROM REQUERMIENTO
 	WHERE req_id = @req_id;	
END		 	
GO








----Procedimiento para consultar TODOS los Requerimientos de un Proyecto----------------

CREATE PROCEDURE Procedure_ConsultarTodosRequerimiento
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT req_codigo, req_descripcion, req_tipo, req_prioridad, req_estatus
	FROM  REQUERMIENTO R
	WHERE (R.PROYECTO_pro_id=@pro_codigo) 
 END
GO


----Procedimiento para consultar  los Requerimientos Funcionales de un Proyecto----------------

CREATE PROCEDURE Procedure_ConsultarRequerimientoFuncional
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT req_codigo, req_descripcion, req_prioridad, req_estatus
	FROM  REQUERMIENTO R
	WHERE (R.PROYECTO_pro_id=@pro_codigo and R.req_tipo= "Funcional") 
 END
GO

----Procedimiento para consultar los Requerimientos NO Funcionales de un Proyecto----------------

CREATE PROCEDURE Procedure_ConsultarRequerimientoNoFuncional
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT req_codigo, req_descripcion, req_prioridad, req_estatus
	FROM  REQUERMIENTO R
	WHERE (R.PROYECTO_pro_id=@pro_codigo and R.req_tipo= "No Funcional") 
 END
GO


----Procedimiento para listar los Requerimientos Funcionales  por maxima prioridad de un Proyecto----------------

CREATE PROCEDURE Procedure_ConsultarRequerimientoFuncionalMax
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT req_codigo, req_descripcion, req_estatus
	FROM  REQUERMIENTO R
	WHERE (R.PROYECTO_pro_id=@pro_codigo and R.req_prioridad = "Alta" and R.req_descripcion="Funcional") 
 END
GO

----Procedimiento para listar los Requerimientos Funcionales  por media prioridad de un Proyecto----------------

CREATE PROCEDURE Procedure_ConsultarRequerimientoFuncionalMed
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT req_codigo, req_descripcion, req_estatus
	FROM  REQUERMIENTO R
	WHERE (R.PROYECTO_pro_id=@pro_codigo and R.req_prioridad= "Media" and R.req_descripcion="Funcional") 
 END
GO


----Procedimiento para listar los Requerimientos Funcionales  por baja prioridad de un Proyecto----------------

CREATE PROCEDURE Procedure_ConsultarRequerimientoFuncionalBaja
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT req_codigo, req_descripcion, req_estatus
	FROM  REQUERMIENTO R
	WHERE (R.PROYECTO_pro_id=@pro_codigo and R.req_prioridad= "Baja" and R.req_descripcion="Funcional") 
 END
GO

----Procedimiento para listar los Requerimientos No Funcionales  por maxima prioridad de un Proyecto----------------

CREATE PROCEDURE Procedure_ConsultarRequerimientoNoFuncionalMax
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT req_codigo, req_descripcion, req_estatus
	FROM  REQUERMIENTO R
	WHERE (R.PROYECTO_pro_id=@pro_codigo and R.req_prioridad = "Alta" and R.req_descripcion="No Funcional") 
 END
GO

----Procedimiento para listar los Requerimientos No Funcionales por media prioridad de un Proyecto----------------

CREATE PROCEDURE Procedure_ConsultarRequerimientoNoFuncionalMed
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT req_codigo, req_descripcion, req_estatus
	FROM  REQUERMIENTO R
	WHERE (R.PROYECTO_pro_id=@pro_codigo and R.req_prioridad= "Media" and R.req_descripcion="No Funcional") 
 END
GO


----Procedimiento para listar los Requerimientos No Funcionales por baja prioridad de un Proyecto----------------

CREATE PROCEDURE Procedure_ConsultarRequerimientoNoFuncionalBaja
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT req_codigo, req_descripcion, req_estatus
	FROM  REQUERMIENTO R
	WHERE (R.PROYECTO_pro_id=@pro_codigo and R.req_prioridad= "Baja" and R.req_descripcion="No Funcional") 
 END
GO





