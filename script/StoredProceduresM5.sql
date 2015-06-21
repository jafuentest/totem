-- ========================================================================= --
-- Agregar requerimiento
-- ========================================================================= --

CREATE PROCEDURE M5_AgregarRequerimiento

	@req_codigo			[varchar] (15),
	@req_descripcion	[varchar] (500),
	@req_tipo			[varchar] (25),
	@req_prioridad		[varchar] (10),
	@req_estatus		[varchar] (50),
	@PROYECTO_pro_id	[int]

AS 
	BEGIN
		INSERT INTO REQUERIMIENTO(
			req_id,
			req_codigo,
			req_descripcion,
			req_tipo,
			req_prioridad,
			req_estatus,
			PROYECTO_pro_id
		)
		VALUES(
			NEXT VALUE FOR secuenciaRequerimiento,
			@req_codigo,
			@req_descripcion,
			@req_tipo,
			@req_prioridad,
			@req_estatus,
			@PROYECTO_pro_id
		)
	END
GO

-- ========================================================================= --
-- Modificar requerimiento
-- ========================================================================= --

CREATE PROCEDURE M5_ModificarRequerimiento

	@req_id				[int],
	@req_codigo			[varchar] (15),
	@req_descripcion	[varchar] (500),
	@req_tipo			[varchar] (25),
	@req_prioridad		[varchar] (10),
	@req_estatus		[varchar] (50)

AS 
	BEGIN
		UPDATE REQUERIMIENTO
		SET
			req_codigo		=	@req_codigo,
			req_descripcion	=	@req_descripcion,
			req_tipo		=	@req_tipo,
			req_prioridad	=	@req_prioridad,
			req_estatus		=	@req_estatus
		WHERE
			req_id			=	@req_id;
	END
GO

-- ========================================================================= --
-- Eliminar requerimiento
-- ========================================================================= --

CREATE PROCEDURE M5_EliminarRequerimiento

  @req_codigo       [varchar] (15)

AS
  BEGIN
    DECLARE @idrequerimiento int;
    SELECT @idrequerimiento = req_id
    FROM REQUERIMIENTO 
    WHERE req_codigo = @req_codigo;

    DELETE FROM CU_REQUERIMIENTO
    WHERE REQUERIMIENTO_req_id = @idrequerimiento;

    DELETE FROM REQUERIMIENTO
    WHERE req_codigo = @req_codigo;
  END
GO

-- ========================================================================= --
-- Retornar id según el código del proyecto
-- ========================================================================= --

CREATE PROCEDURE M5_RetornarIdPorCodigoProyecto

	@pro_codigo 		[varchar] (6),
	@pro_id				[int]			OUTPUT

AS
	BEGIN
		SELECT @pro_id = P.pro_id
		FROM PROYECTO P
		WHERE ( LOWER(P.pro_codigo) = LOWER(@pro_codigo) );
	END
GO

-- ========================================================================= --
-- Consultar requerimientos por proyecto (Todos)
-- ========================================================================= --

CREATE PROCEDURE M5_ConsultarRequerimientosPorProyecto

	@pro_id			[int]

AS
	BEGIN
		SELECT	req_id, req_codigo, req_descripcion,
				req_tipo, req_prioridad, req_estatus
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = @pro_id )
	END
GO

-- ========================================================================= --
-- Consultar requerimientos por proyecto (Tipo)
-- ========================================================================= --

CREATE PROCEDURE M5_ConsultarRequerimientosPorTipo

	@pro_id				[int],
	@req_tipo			[varchar] (25)

AS
	BEGIN
		SELECT	req_id, req_codigo, req_descripcion,
				req_tipo, req_prioridad, req_estatus
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = @pro_id
				and LOWER(R.req_tipo) = LOWER(@req_tipo) )
	END
GO

-- ========================================================================= --
-- Consultar requerimientos por proyecto (Tipo y Prioridad)
-- ========================================================================= --

CREATE PROCEDURE M5_ConsultarRequerimientosPorTipoPrioridad

	@pro_id				[int],
	@req_tipo			[varchar] (25),
	@req_prioridad		[varchar] (10)

AS
	BEGIN
		SELECT	req_id, req_codigo, req_descripcion,
				req_tipo, req_prioridad, req_estatus
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = @pro_id
				and LOWER(R.req_tipo) = LOWER(@req_tipo)
				and LOWER(R.req_prioridad) = LOWER(@req_prioridad) )
	END
GO

-- ========================================================================= --
-- Obtener id del proyecto dado el codigo de requerimiento
-- ========================================================================= --

CREATE PROCEDURE M5_RetornarIdPorCodigoRequerimiento
  @req_codigo varchar (25),
  @pro_id int OUTPUT

  As
    BEGIN
      SELECT DISTINCT @pro_id = PROYECTO_pro_id
      FROM Requerimiento
      WHERE req_codigo = @req_codigo
    END
  GO

-- ========================================================================= --
-- Obtener el requerimiento dado su codigo
-- ========================================================================= --
CREATE PROCEDURE M5_ConsultarRequerimientosPorCodigo

	@req_codigo				[varchar] (25),
	@req_id 	int OUTPUT,
	@req_codigo_out	varchar(25) OUTPUT,
	@req_descripcion	varchar(500)	OUTPUT,
	@req_tipo	varchar(25)	OUTPUT,
	@req_prioridad	varchar(10)	OUTPUT,
	@req_estatus	varchar(50)	OUTPUT
AS
	BEGIN
		SELECT	@req_id = req_id, @req_codigo_out = req_codigo, 
		@req_descripcion = req_descripcion, @req_tipo = req_tipo, 
		@req_prioridad = req_prioridad, @req_estatus = req_estatus
		FROM  REQUERIMIENTO R
		WHERE req_codigo = @req_codigo
	END
GO