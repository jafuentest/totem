/*=================================================Procedimientos de la tabla ACTOR=====================================================*/
begin transaction;
go
/*Insertar Actor*/
CREATE PROCEDURE INSERTAR_ACTOR 
	@nombre [varchar] (100),
	@descripcion [varchar] (500),
	@idproyecto int
AS
	BEGIN
		-- Activo la funcion para saber si la  Base de Datos fue alterada
		SET NOCOUNT OFF

		--Inserto el Actor
		INSERT INTO ACTOR (act_nombre,act_descripcion,PROYECTO_pro_id) VALUES (@nombre,@descripcion,@idproyecto)
		
	END
GO

/*Leer actor(es)*/
CREATE PROCEDURE LEER_ACTOR 
	@idproyecto int
AS
	BEGIN
		--Leo todos los Actores asociados al proyecto
		SELECT A.act_nombre NOMBRE, A.act_descripcion DESCRIPCION, A.act_id ID FROM ACTOR A WHERE A.PROYECTO_pro_id=@idproyecto; 
	END
GO

/*Modificar Actor*/
CREATE PROCEDURE MODIFICAR_ACTOR 
	@nombre [varchar] (100),
	@descripcion [varchar] (500),
	@idproyecto int,
	@idactor int
AS
	BEGIN
		--Modifico los datos de un Actor en especifico del proyecto en especifico
		UPDATE ACTOR SET act_nombre = @nombre, act_descripcion = @descripcion 
		WHERE (PROYECTO_pro_id = @idproyecto) AND (act_id = @idactor);
		
		
	END
GO


/*Eliminar Actor*/
CREATE PROCEDURE ELIMINAR_ACTOR 
	@idactor int,
	@idproyecto int
AS
	BEGIN
		DELETE FROM ACTOR WHERE PROYECTO_pro_id= @idproyecto AND act_id=@idactor;
	END

GO

/* Leer casos de uso por actor */
CREATE PROCEDURE LEER_CU_POR_ACTOR 
	@nombreActor [varchar] (100),
	@idproyecto int
AS
	BEGIN
		SELECT C.cu_identificador ,C.cu_titulo, C.cu_condexito, C.cu_condfallo, cu_disparador 
		FROM CASO_USO C, CU_ACTOR R, ACTOR A 
		WHERE (A.act_nombre=@nombreActor AND A.PROYECTO_pro_id= @idproyecto) AND (R.CASO_USO_cu_id=C.cu_id AND R.ACTOR_act_id=A.act_id);
	END
GO

/*==========================================================================================================================*/

/*======================================Procedimientos de la tabla Caso de Uso==============================================*/




/*=====================================Procesos para crear la información de los Casos de Uso===============================*/

/*Insertar datos basicos del Caso de Uso*/
CREATE PROCEDURE INSERTAR_CU 
	@identificador [varchar] (20),
	@titulo [varchar] (50),
	@condexito [varchar] (200),
	@condfallo [varchar] (200),
	@disparador [varchar] (200)
AS
	BEGIN
		
		--Inserto el caso de uso
		INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador) VALUES (@identificador,@titulo,@condexito,@condfallo,@disparador);
	END
GO

/*Asociar requerimientos al CU*/
CREATE PROCEDURE ASOCIAR_REQUERIMIENTO 
	@idrequerimiento int
AS
	BEGIN
		--Busco el ultimo Caso de Uso que cree
		DECLARE @idcasouso INTEGER;
		set @idcasouso = (SELECT MAX(cu_id) from CASO_USO);

		--Inserto en la entidad interseccion
		INSERT INTO CU_REQUERIMIENTO VALUES (@idrequerimiento, @idcasouso);
	END
GO

/*Asociar Actor al CU*/
CREATE PROCEDURE ASOCIAR_ACTOR 
	@idactor int
AS
	BEGIN
		--Busco el ultimo Caso de Uso que cree
		DECLARE @idcasouso INTEGER;
		set @idcasouso = (SELECT MAX(cu_id) from CASO_USO);

		--Inserto en la entidad interseccion
		INSERT INTO CU_ACTOR VALUES (@idcasouso, @idactor);
		
	END
GO

/*Insertar precondicion del Caso de Uso*/
CREATE PROCEDURE INSERTAR_PRECONDICION 
	@descripcion [varchar] (500)
AS
	BEGIN
		--Busco el ID del caso de uso
		DECLARE @idcasouso INTEGER;
		set @idcasouso = (SELECT MAX(cu_id) from CASO_USO);
		
		--Busco cuantas precondiciones tiene actualmente para agregar una mas
		DECLARE @numero INTEGER;
		set @numero = (SELECT MAX(P.pre_id) from PRECONDICION P WHERE P.CASO_USO_cu_id=@idcasouso);
		
		--Inserto la precondicion
		if (@numero != null)
			INSERT INTO PRECONDICION VALUES (@numero+1,@descripcion,@idcasouso);
		else
			INSERT INTO PRECONDICION VALUES (1,@descripcion,@idcasouso);
	END
GO

/*Insertar paso (escenario principal de exito) del Caso de Uso*/
CREATE PROCEDURE INSERTAR_PASO 
	@numeropaso [varchar] (30), 
	@paso [varchar] (300)
AS
	BEGIN
		--Busco el ID del caso de uso
		DECLARE @idcasouso INTEGER;
		set @idcasouso = (SELECT MAX(cu_id) from CASO_USO);

		--Busco cuantos pasos tiene actualmente para agregar uno mas
		DECLARE @numero INTEGER;
		set @numero = (SELECT MAX(P.pas_id) FROM PASO P WHERE P.CASO_USO_cu_id=@idcasouso);

		--Inserto el paso
		if (@numero != null)
			INSERT INTO PASO VALUES (@numero+1,@numeropaso,@paso,@idcasouso);
		else
			INSERT INTO PASO VALUES (1,@numeropaso,@paso,@idcasouso);
		
	END
GO

/*Insertar extension (bifurcacion) del Caso de Uso*/
CREATE PROCEDURE INSERTAR_EXTENSION 
	@descripcion [varchar] (500)
AS
	BEGIN
		--Busco el ID del caso de uso
		DECLARE @idcasouso INTEGER;
		set @idcasouso = (SELECT MAX(cu_id) from CASO_USO);

		--Busco el ID del paso
		DECLARE @idpaso INTEGER;
		set @idpaso = (SELECT MAX(P.pas_id) FROM PASO P WHERE P.CASO_USO_cu_id=@idcasouso);
		
		--Busco cuantas extensiones tiene actualmente para agregar uno mas
		DECLARE @numero INTEGER
		set @numero = (SELECT MAX(E.ext_id) 
		FROM EXTENSION E WHERE (E.PASO_pas_id = @idpaso) AND (E.PASO_CASO_USO_cu_id = @idcasouso));


		--Inserto la extension
		if (@numero != null)
			INSERT INTO EXTENSION VALUES (@numero+1,@descripcion,@idpaso,@idcasouso);
		else
			INSERT INTO EXTENSION VALUES (1,@descripcion,@idpaso,@idcasouso);
		
	END
GO

/*Insertar paso de la extension del Caso de Uso*/
CREATE PROCEDURE INSERTAR_PASO_EXTENSION 
	@descripcion [varchar] (300)
AS
	BEGIN
		--Busco el ID del caso de uso
		DECLARE @idcasouso INTEGER;
		set @idcasouso = (SELECT MAX(cu_id) from CASO_USO);

		--Busco el ID del paso
		DECLARE @idpaso INTEGER;
		set @idpaso = (SELECT MAX(P.pas_id) FROM PASO P WHERE P.CASO_USO_cu_id=@idcasouso);

		--Busco el ID de la extension
		DECLARE @idextension INTEGER
		set @idextension = (SELECT MAX(E.ext_id) 
		FROM EXTENSION E WHERE (E.PASO_pas_id = @idpaso) AND (E.PASO_CASO_USO_cu_id = @idcasouso));

		--Busco cuantos pasos tiene la extension para agregar uno mas
		DECLARE @numero INTEGER
		set @numero = (SELECT MAX(P.pe_id) 
		FROM PASO_EXTENSION P 
		WHERE (P.EXTENSION_ext_id=@idextension) AND (P.EXTENSION_PASO_pas_id=@idpaso) AND (P.EXTENSION_PASO_CASO_USO_cu_id=@idcasouso));

		--Inserto el paso de la extension
		if (@numero != null)
			INSERT INTO PASO_EXTENSION VALUES (@numero+1,@descripcion,@idextension,@idpaso,@idcasouso);
		else
			INSERT INTO PASO_EXTENSION VALUES (1,@descripcion,@idextension,@idpaso,@idcasouso);
	END
GO



/*=====================================Procesos para leer la información de los Casos de Uso===============================*/

/*Leer datos basicos del Caso de Uso*/
CREATE PROCEDURE LEER_CU 
	@idproyecto int
AS
	BEGIN
		--Leo todos los casos de uso asociados al requerimiento
		SELECT C.cu_id, C.cu_identificador ,C.cu_titulo, C.cu_condexito, C.cu_condfallo, C.cu_disparador 
		FROM CASO_USO C 
		WHERE C.PROYECTO_pro_id=@idproyecto;
	END
GO

/*Leer precondicion(es) del Caso de Uso*/
CREATE PROCEDURE LEER_PRECONDICION 
	@idcasouso int
AS
	BEGIN
		--Leo todas las precondiciones asociadas al Caso de Uso
		SELECT P.pre_descripcion 
		FROM PRECONDICION P 
		WHERE (P.CASO_USO_cu_id=@idcasouso); 
	END
GO

/*Leer escenario principal de exito (pasos) del Caso de Uso*/
CREATE PROCEDURE LEER_PASO 
	@idcasouso int
AS
	BEGIN
		--Leo todos los pasos asociados al Caso de Uso
		SELECT P.pas_id, P.pas_paso 
		FROM PASO P 
		WHERE (P.CASO_USO_cu_id=@idcasouso); 
	END
GO

/*Leer extension(es) (Bifurcaciones) del Caso de Uso*/
CREATE PROCEDURE LEER_EXTENSION 
	@idpaso int,
	@idcasouso int
AS
	BEGIN
		--Leo todas las extensiones asociadas al paso en especifico del Caso de Uso
		SELECT E.ext_id, E.ext_descripcion 
		FROM EXTENSION E 
		WHERE (E.PASO_pas_id=@idpaso) AND (E.PASO_CASO_USO_cu_id=@idcasouso); 
	END
GO

/*Leer paso(s) de las extension(es) del Caso de Uso*/
CREATE PROCEDURE LEER_PASO_EXTENSION 
	@idpaso int,
	@idcasouso int,
	@idextension int
AS
	BEGIN
		--Leo todos los pasos de las extension asociados a una extension especifico y de un paso en especifico del Caso de Uso 
		SELECT P.pe_paso 
		FROM PASO_EXTENSION P 
		WHERE (P.EXTENSION_ext_id=@idextension) AND (P.EXTENSION_PASO_pas_id=@idpaso) AND (P.EXTENSION_PASO_CASO_USO_cu_id=@idcasouso); 
	END
GO

/*Leer actor(es) del Caso de Uso*/
CREATE PROCEDURE LEER_ACTOR_DEL_CU 
	@idcasouso int
AS
	BEGIN
		SELECT A.act_nombre NOMBRE, A.act_descripcion DESCRIPCION 
		FROM ACTOR A, CU_ACTOR R, CASO_USO C 
		WHERE (C.cu_id=@idcasouso) AND (C.cu_id=R.CASO_USO_cu_id) AND (R.ACTOR_act_id=A.act_id);
	END
GO

/*Leer requerimiento(s) del Caso de Uso*/
CREATE PROCEDURE LEER_REQUERIMIENTO_DEL_CU 
	@idcasouso int
AS
	BEGIN
		SELECT R.req_descripcion DESCRIPCION 
		FROM REQUERIMIENTO R, CU_REQUERIMIENTO O, CASO_USO C 
		WHERE (C.cu_id=@idcasouso) AND (C.cu_id=O.CASO_USO_cu_id) AND (R.req_id=O.REQUERIMIENTO_req_id);
	END
GO


/*=====================================Procesos para modificar la información de los Casos de Uso===============================*/

/*Modificar datos basicos del Caso de Uso*/
CREATE PROCEDURE MODIFICAR_CU 
	@idcasouso int,
	@identificador [varchar] (20),
	@titulo [varchar] (50),
	@condexito [varchar] (200),
	@condfallo [varchar] (200),
	@disparador [varchar] (200)
AS
	BEGIN
		--Modifico los datos de un Caso de Uso en especifico
		UPDATE CASO_USO 
		SET cu_identificador=@identificador, cu_titulo=@titulo, cu_condexito=@condexito, cu_condfallo=@condfallo, cu_disparador=@disparador
		WHERE (cu_id=@idcasouso);	
	END
GO

/*Modificar precondicion del Caso de Uso*/
CREATE PROCEDURE MODIFICAR_PRECONDICION 
	@idprecondicion int,
	@idcasouso int,
	@descripcion [varchar] (500)
AS
	BEGIN
		--Modifico los datos de una precondicion especifica del Caso de Uso
		UPDATE PRECONDICION SET pre_descripcion=@descripcion WHERE (CASO_USO_cu_id=@idcasouso) AND (pre_id=@idprecondicion);	
	END
GO

/*Modificar escenario principal de exito (pasos) del Caso de Uso*/
CREATE PROCEDURE MODIFICAR_PASO 
	@idpaso int,
	@idcasouso int,
	@numpaso [varchar] (30),
	@descripcion [varchar] (300)
AS
	BEGIN
		--Modifico los datos de un paso en especifico del Caso de Uso
		UPDATE PASO SET pas_paso=@descripcion, pas_numpaso=@numpaso WHERE (CASO_USO_cu_id=@idcasouso) AND (pas_id=@idpaso);	
	END
GO

/*Modificar extension (bifurcaciones) del Caso de Uso*/
CREATE PROCEDURE MODIFICAR_EXTENSION 
	@idextension int,
	@idpaso int,
	@idcasouso int,
	@descripcion [varchar] (500)
AS
	BEGIN
		--Modifico los datos de una extension en especifico de un paso en especifico del Caso de Uso
		UPDATE EXTENSION SET ext_descripcion=@descripcion WHERE (PASO_CASO_USO_cu_id=@idcasouso) AND (PASO_pas_id=@idpaso) AND (ext_id=@idextension);
	END
GO

/*Modificar paso de una extension del Caso de Uso*/
CREATE PROCEDURE MODIFICAR_PASO_EXTENSION 
	@idpasoex int,
	@idextension int,
	@idpaso int,
	@idcasouso int,
	@descripcion [varchar] (300)
AS
	BEGIN
		--Modifico los datos de un paso de una extension en especifico de un paso en especifico del Caso de Uso
		UPDATE PASO_EXTENSION SET pe_paso=@descripcion 
		WHERE (EXTENSION_PASO_CASO_USO_cu_id=@idcasouso) AND (EXTENSION_PASO_pas_id=@idpaso) AND (EXTENSION_ext_id=@idextension) AND (pe_id=@idpasoex);
	END
GO



/*=====================================Procesos para eliminar la información de los Casos de Uso===============================*/

--Se crearon al revés para que se puedan eliminar de abajo hacia arriba (de la entidad más pequeña a la más grande)

/*Eliminar pasos de las extensiones*/
CREATE PROCEDURE ELIMINAR_PASO_EXTENSION 
	@idcasouso int
AS
	BEGIN
		DELETE FROM PASO_EXTENSION WHERE (EXTENSION_PASO_CASO_USO_cu_id=@idcasouso);	
	END
GO

/*Eliminar extensiones*/
CREATE PROCEDURE ELIMINAR_EXTENSION 
	@idcasouso int
AS
	BEGIN
		DELETE FROM EXTENSION WHERE (PASO_CASO_USO_cu_id=@idcasouso);	
	END
GO

/*Eliminar escenario principal de exito (pasos)*/
CREATE PROCEDURE ELIMINAR_PASO 
	@idcasouso int
AS
	BEGIN
		DELETE FROM PASO WHERE (CASO_USO_cu_id=@idcasouso);	
	END
GO

/*Eliminar precondiciones*/
CREATE PROCEDURE ELIMINAR_PRECONDICION
	@idcasouso int
AS
	BEGIN
		DELETE FROM PRECONDICION WHERE (CASO_USO_cu_id=@idcasouso);
	END
GO

/*Eliminar Requerimientos del CU*/
CREATE PROCEDURE ELIMINAR_REQUERIMIENTO_DEL_CU 
	@idcasouso int
AS
	BEGIN
		DELETE FROM CU_REQUERIMIENTO WHERE (CASO_USO_cu_id=@idcasouso);
	END
GO

/*Eliminar Actores del CU*/
CREATE PROCEDURE ELIMINAR_ACTOR_DEL_CU 
	@idcasouso int
AS
	BEGIN
		DELETE FROM CU_ACTOR WHERE (CASO_USO_cu_id=@idcasouso);
	END
GO

/*Eliminar Caso de Uso*/
CREATE PROCEDURE ELIMINAR_CU 
	@idcasouso int
AS
	BEGIN
		DELETE FROM CASO_USO WHERE (cu_id=@idcasouso);
	END
GO

/*==========================================================================================================================*/
commit transaction;
go

