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


------------------ Procedimientos para consultar------------------------------


------------------ Procedimiento para verificar existencia de un proyecto ----------------------
CREATE PROCEDURE Procedure_ExisteProyecto
 
		@pro_codigo[varchar] (6)
AS 
BEGIN
    IF EXISTS (SELECT * FROM PROYECTO P WHERE pro_codigo = @pro_codigo)
        SELECT 1
    ELSE
        SELECT 0  
END
------------------ Procedimiento para consultar un Proyecto----------------------

CREATE PROCEDURE Procedure_ConsultarProyecto
	
	@pro_codigo [varchar] (6)
	   
AS
 BEGIN
	
	SELECT pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_JURIDICO_cj_id,CLIENTE_NATURAL_cn_id
	FROM PROYECTO P
	WHERE (P.pro_codigo=@pro_codigo) 
 END
GO