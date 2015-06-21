--Begin CREATES
CREATE
  TABLE ACTOR
  (
    act_id          INTEGER IDENTITY(1,1) NOT NULL ,
    act_nombre      VARCHAR (100) NOT NULL ,
    act_descripcion VARCHAR (500) NOT NULL ,
    PROYECTO_pro_id INTEGER NOT NULL ,
    CONSTRAINT ACTOR_PK PRIMARY KEY CLUSTERED (act_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE ACUERDO
  (
    acu_id         INTEGER IDENTITY(1,1) NOT NULL ,
    acu_fecha      DATE NOT NULL ,
    acu_desarrollo VARCHAR (300) NOT NULL ,
	MINUTA_min_id  INTEGER NOT NULL ,
    CONSTRAINT ACUERDO_PK PRIMARY KEY CLUSTERED (acu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE ACU_INV
  (
    acu_inv_id INTEGER IDENTITY(1,1) NOT NULL,
	ACUERDO_acu_id INTEGER NOT NULL,
	INVOLUCRADOS_USUARIOS_USUARIO_usu_id  INTEGER,
    INVOLUCRADOS_USUARIOS_PROYECTO_pro_id INTEGER,
	INVOLUCRADOS_CLIENTES_CONTACTO_con_id INTEGER,
	INVOLUCRADOS_CLIENTES_PROYECTO_pro_id INTEGER,
    CONSTRAINT ACU_INV_PK PRIMARY KEY CLUSTERED (acu_inv_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CARGO
  (
    car_id     INTEGER NOT NULL ,
    car_nombre VARCHAR (60) NOT NULL ,
    CONSTRAINT CARGO_PK PRIMARY KEY CLUSTERED (car_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CASO_USO
  (
    cu_id            INTEGER IDENTITY(1,1) NOT NULL ,
    cu_identificador VARCHAR (20) NOT NULL ,
    cu_titulo        VARCHAR (50) NOT NULL ,
    cu_condexito     VARCHAR (200) NOT NULL ,
    cu_condfallo     VARCHAR (200) NOT NULL ,
    cu_disparador    VARCHAR (200) NOT NULL ,
    PROYECTO_pro_id INTEGER NOT NULL ,
    CONSTRAINT CASO_USO_PK PRIMARY KEY CLUSTERED (cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CLIENTE_JURIDICO
  (
    cj_id        INTEGER IDENTITY(1,1) NOT NULL ,
    cj_rif       VARCHAR (20) NOT NULL ,
    cj_nombre    VARCHAR (60) NOT NULL ,
    cj_logo      VARCHAR (60) ,
    LUGAR_lug_id INTEGER NOT NULL ,
    
	CONSTRAINT CLIENTE_JURIDICO_PK PRIMARY KEY CLUSTERED (cj_id)
	
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CLIENTE_NATURAL
  (
    cn_id        INTEGER IDENTITY(1,1) NOT NULL ,
	cn_cedula    VARCHAR (20) NOT NULL ,
    cn_nombre    VARCHAR (60) NOT NULL ,
    cn_apellido  VARCHAR (60) NOT NULL ,
    cn_correo    VARCHAR (60) NOT NULL ,
    LUGAR_lug_id INTEGER NOT NULL ,
	
    CONSTRAINT CLIENTE_NATURAL_PK PRIMARY KEY CLUSTERED (cn_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CONTACTO
  (
    con_id                 INTEGER IDENTITY(1,1) NOT NULL ,
	con_cedula    		   VARCHAR (20) NOT NULL ,
    con_nombre             VARCHAR (100) NOT NULL ,
    con_apellido           VARCHAR (50) NOT NULL ,
    CLIENTE_JURIDICO_cj_id INTEGER,
    CARGO_car_id           INTEGER,
	CLIENTE_NATURAL_cn_id  INTEGER,
    CONSTRAINT CONTACTO_PK PRIMARY KEY CLUSTERED (con_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CU_ACTOR
  (
    CASO_USO_cu_id INTEGER NOT NULL ,
    ACTOR_act_id   INTEGER NOT NULL ,
    CONSTRAINT CU_ACTOR_PK PRIMARY KEY CLUSTERED (CASO_USO_cu_id, ACTOR_act_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CU_REQUERIMIENTO
  (
    REQUERIMIENTO_req_id INTEGER NOT NULL ,
    CASO_USO_cu_id       INTEGER NOT NULL ,
    CONSTRAINT CU_REQUERIMIENTO_PK PRIMARY KEY CLUSTERED (REQUERIMIENTO_req_id,
    CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE EXTENSION
  (
    ext_id              INTEGER NOT NULL ,
    ext_descripcion     VARCHAR (500) NOT NULL ,
    PASO_pas_id         INTEGER NOT NULL ,
    PASO_CASO_USO_cu_id INTEGER NOT NULL ,
    CONSTRAINT EXTENSION_PK PRIMARY KEY CLUSTERED (ext_id, PASO_pas_id,
    PASO_CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE INVOLUCRADOS_CLIENTES
  (
    CONTACTO_con_id INTEGER NOT NULL ,
    PROYECTO_pro_id INTEGER NOT NULL ,
    CONSTRAINT INVOLUCRADOS_CLIENTES_PK PRIMARY KEY CLUSTERED (CONTACTO_con_id,
    PROYECTO_pro_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE INVOLUCRADOS_USUARIOS
  (
    USUARIO_usu_id  INTEGER NOT NULL ,
    PROYECTO_pro_id INTEGER NOT NULL ,
    CONSTRAINT INVOLUCRADOS_USUARIOS_PK PRIMARY KEY CLUSTERED (USUARIO_usu_id,
    PROYECTO_pro_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE LUGAR
  (
    lug_id           INTEGER IDENTITY(1,1) NOT NULL ,
    lug_nombre       VARCHAR (100) NOT NULL ,
    lug_tipo         VARCHAR (40) NOT NULL ,
    lug_codigopostal INTEGER ,
    LUGAR_lug_id     INTEGER ,
    CONSTRAINT LUGAR_PK PRIMARY KEY CLUSTERED (lug_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE MINUTA
  (
    min_id            INTEGER IDENTITY(1,1) NOT NULL ,
    min_fecha         DATETIME NOT NULL ,
    min_motivo        VARCHAR (200) NOT NULL ,
    min_observaciones VARCHAR (500) ,
    CONSTRAINT MINUTA_PK PRIMARY KEY CLUSTERED (min_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE MIN_INV
  (
    min_inv_id INTEGER IDENTITY(1,1) NOT NULL,
    MINUTA_min_id                         INTEGER NOT NULL ,
    INVOLUCRADOS_USUARIOS_USUARIO_usu_id  INTEGER,
    INVOLUCRADOS_USUARIOS_PROYECTO_pro_id INTEGER,
	INVOLUCRADOS_CLIENTES_CONTACTO_con_id INTEGER,
	INVOLUCRADOS_CLIENTES_PROYECTO_pro_id INTEGER,
    CONSTRAINT MIN_INV_PK PRIMARY KEY CLUSTERED (min_inv_id, MINUTA_min_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PASO
  (
    pas_id         INTEGER NOT NULL ,
    pas_numpaso    VARCHAR (30) NOT NULL,
    pas_paso       VARCHAR (300) NOT NULL ,
    CASO_USO_cu_id INTEGER NOT NULL ,
    CONSTRAINT PASO_PK PRIMARY KEY CLUSTERED (pas_id, CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PASO_EXTENSION
  (
    pe_id                        INTEGER NOT NULL ,
    pe_paso                      VARCHAR (300) NOT NULL ,
    EXTENSION_ext_id              INTEGER NOT NULL ,
    EXTENSION_PASO_pas_id         INTEGER NOT NULL ,
    EXTENSION_PASO_CASO_USO_cu_id INTEGER NOT NULL ,
    CONSTRAINT PASO_EXTENSION_PK PRIMARY KEY CLUSTERED (pe_id,
    EXTENSION_ext_id, EXTENSION_PASO_pas_id, EXTENSION_PASO_CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PRECONDICION
  (
    pre_id          INTEGER NOT NULL ,
    pre_descripcion VARCHAR (500) NOT NULL ,
    CASO_USO_cu_id  INTEGER NOT NULL ,
    CONSTRAINT PRECONDICION_PK PRIMARY KEY CLUSTERED (pre_id, CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PROYECTO
  (
    pro_id     INTEGER IDENTITY(1,1) NOT NULL,
    pro_codigo VARCHAR (6)  NOT NULL ,
    pro_nombre VARCHAR (60) NOT NULL ,
    pro_estado BIT NOT NULL ,
    pro_descripcion VARCHAR (600) NOT NULL ,
    pro_costo       INTEGER NOT NULL ,
    pro_moneda      VARCHAR (3) NOT NULL ,
    CLIENTE_JURIDICO_cj_id INTEGER ,
    CLIENTE_NATURAL_cn_id INTEGER,
    CONSTRAINT PROYECTO_PK PRIMARY KEY CLUSTERED (pro_id),
    CONSTRAINT PROYECTO_CODIGO UNIQUE (pro_codigo)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PUNTO
  (
    pun_id         INTEGER IDENTITY(1,1) NOT NULL ,
    pun_titulo     VARCHAR (100) NOT NULL ,
    pun_desarrollo VARCHAR (400),
	MINUTA_min_id  INTEGER  NOT NULL ,
    CONSTRAINT PUNTO_PK PRIMARY KEY CLUSTERED (pun_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE REQUERIMIENTO
  (
    req_id          INTEGER NOT NULL ,
    req_codigo      VARCHAR (15) NOT NULL ,
    req_descripcion VARCHAR (500) NOT NULL ,
    req_tipo        VARCHAR (25) NOT NULL ,
    req_prioridad   VARCHAR (10) NOT NULL ,
    req_estatus     VARCHAR (50) NOT NULL ,
    PROYECTO_pro_id INTEGER NOT NULL ,
    CONSTRAINT REQUERIMIENTO_PK PRIMARY KEY CLUSTERED (req_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TELEFONO
  (
    tel_id                INTEGER IDENTITY(1,1) NOT NULL ,
    tel_codigo            VARCHAR (5)  NOT NULL ,
    tel_numero            VARCHAR (20) NOT NULL ,
    CLIENTE_NATURAL_cn_id INTEGER ,
    CONTACTO_con_id       INTEGER ,
    CONSTRAINT TELEFONO_PK PRIMARY KEY CLUSTERED (tel_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE USUARIO
  (
    usu_id            INTEGER NOT NULL ,
    usu_username      VARCHAR (60) NOT NULL ,
    usu_clave         VARCHAR (MAX) NOT NULL ,
    usu_nombre        VARCHAR (60) NOT NULL ,
    usu_apellido      VARCHAR (60) NOT NULL ,
    usu_rol           VARCHAR (60) NOT NULL ,
    usu_correo        VARCHAR (60) NOT NULL ,
    usu_pregseguridad VARCHAR (80) NOT NULL ,
    usu_respseguridad VARCHAR (80) NOT NULL ,
    CARGO_car_id      INTEGER NOT NULL ,
    CONSTRAINT USUARIO_PK PRIMARY KEY CLUSTERED (usu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

ALTER TABLE ACTOR
ADD CONSTRAINT ACTOR_PROYECTO_FK FOREIGN KEY
(
PROYECTO_pro_id
)
REFERENCES PROYECTO
(
pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ACUERDO
ADD CONSTRAINT ACUERDO_MINUTA_FK FOREIGN KEY
(
MINUTA_min_id
)
REFERENCES MINUTA
(
min_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ACU_INV
ADD CONSTRAINT ACU_INV_ACUERDO_FK FOREIGN KEY
(
ACUERDO_acu_id
)
REFERENCES ACUERDO
(
acu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ACU_INV
ADD CONSTRAINT ACU_INV_USUARIOS_FK FOREIGN KEY
(
INVOLUCRADOS_USUARIOS_USUARIO_usu_id,
INVOLUCRADOS_USUARIOS_PROYECTO_pro_id
)
REFERENCES INVOLUCRADOS_USUARIOS
(
USUARIO_usu_id,
PROYECTO_pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ACU_INV
ADD CONSTRAINT ACU_INV_CLIENTES_FK FOREIGN KEY
(
INVOLUCRADOS_CLIENTES_CONTACTO_con_id,
INVOLUCRADOS_CLIENTES_PROYECTO_pro_id
)
REFERENCES INVOLUCRADOS_CLIENTES
(
CONTACTO_con_id,
PROYECTO_pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CASO_USO
ADD CONSTRAINT CU_PROYECTO_FK FOREIGN KEY
(
PROYECTO_pro_id
)
REFERENCES PROYECTO
(
pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CLIENTE_JURIDICO
ADD CONSTRAINT CLIENTE_JURIDICO_LUGAR_FK FOREIGN KEY
(
LUGAR_lug_id
)
REFERENCES LUGAR
(
lug_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CLIENTE_NATURAL
ADD CONSTRAINT CLIENTE_NATURAL_LUGAR_FK FOREIGN KEY
(
LUGAR_lug_id
)
REFERENCES LUGAR
(
lug_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CONTACTO
ADD CONSTRAINT CONTACTO_CARGO_FK FOREIGN KEY
(
CARGO_car_id
)
REFERENCES CARGO
(
car_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CONTACTO
ADD CONSTRAINT CONTACTO_CLIENTE_JURIDICO_FK FOREIGN KEY
(
CLIENTE_JURIDICO_cj_id
)
REFERENCES CLIENTE_JURIDICO
(
cj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO


ALTER TABLE CONTACTO
ADD CONSTRAINT CONTACTO_CLIENTE_NATURAL_FK FOREIGN KEY
(
CLIENTE_NATURAL_cn_id
)
REFERENCES CLIENTE_NATURAL
(
cn_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CU_ACTOR
ADD CONSTRAINT CU_ACTOR_ACTOR_FK FOREIGN KEY
(
ACTOR_act_id
)
REFERENCES ACTOR
(
act_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CU_ACTOR
ADD CONSTRAINT CU_ACTOR_CASO_USO_FK FOREIGN KEY
(
CASO_USO_cu_id
)
REFERENCES CASO_USO
(
cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CU_REQUERIMIENTO
ADD CONSTRAINT CU_REQUERIMIENTO_CASO_USO_FK FOREIGN KEY
(
CASO_USO_cu_id
)
REFERENCES CASO_USO
(
cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CU_REQUERIMIENTO
ADD CONSTRAINT CU_REQUERIMIENTO_REQUERIMIENTO_FK FOREIGN KEY
(
REQUERIMIENTO_req_id
)
REFERENCES REQUERIMIENTO
(
req_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE EXTENSION
ADD CONSTRAINT EXTENSION_PASO_FK FOREIGN KEY
(
PASO_pas_id,
PASO_CASO_USO_cu_id
)
REFERENCES PASO
(
pas_id ,
CASO_USO_cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVOLUCRADOS_CLIENTES
ADD CONSTRAINT INVOLUCRADOS_CLIENTES_CONTACTO_FK FOREIGN KEY
(
CONTACTO_con_id
)
REFERENCES CONTACTO
(
con_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVOLUCRADOS_CLIENTES
ADD CONSTRAINT INVOLUCRADOS_CLIENTES_PROYECTO_FK FOREIGN KEY
(
PROYECTO_pro_id
)
REFERENCES PROYECTO
(
pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVOLUCRADOS_USUARIOS
ADD CONSTRAINT INVOLUCRADOS_USUARIOS_PROYECTO_FK FOREIGN KEY
(
PROYECTO_pro_id
)
REFERENCES PROYECTO
(
pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVOLUCRADOS_USUARIOS
ADD CONSTRAINT INVOLUCRADOS_USUARIOS_USUARIO_FK FOREIGN KEY
(
USUARIO_usu_id
)
REFERENCES USUARIO
(
usu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE LUGAR
ADD CONSTRAINT LUGAR_LUGAR_FK FOREIGN KEY
(
LUGAR_lug_id
)
REFERENCES LUGAR
(
lug_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE MIN_INV
ADD CONSTRAINT MIN_INV_INVOLUCRADOS_USUARIOS_FK FOREIGN KEY
(
INVOLUCRADOS_USUARIOS_USUARIO_usu_id,
INVOLUCRADOS_USUARIOS_PROYECTO_pro_id
)
REFERENCES INVOLUCRADOS_USUARIOS
(
USUARIO_usu_id ,
PROYECTO_pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE MIN_INV
ADD CONSTRAINT MIN_INV_MINUTA_FK FOREIGN KEY
(
MINUTA_min_id
)
REFERENCES MINUTA
(
min_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE MIN_INV
ADD CONSTRAINT MIN_INV_INVOLUCRADOS_CLIENTES_FK FOREIGN KEY
(
INVOLUCRADOS_CLIENTES_CONTACTO_con_id,
INVOLUCRADOS_CLIENTES_PROYECTO_pro_id
)
REFERENCES INVOLUCRADOS_CLIENTES
(
CONTACTO_con_id ,
PROYECTO_pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PASO
ADD CONSTRAINT PASO_CASO_USO_FK FOREIGN KEY
(
CASO_USO_cu_id
)
REFERENCES CASO_USO
(
cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PASO_EXTENSION
ADD CONSTRAINT PASO_EXTENSION_EXTENSION_FK FOREIGN KEY
(
EXTENSION_ext_id,
EXTENSION_PASO_pas_id,
EXTENSION_PASO_CASO_USO_cu_id
)
REFERENCES EXTENSION
(
ext_id ,
PASO_pas_id ,
PASO_CASO_USO_cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PRECONDICION
ADD CONSTRAINT PRECONDICION_CASO_USO_FK FOREIGN KEY
(
CASO_USO_cu_id
)
REFERENCES CASO_USO
(
cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PUNTO
ADD CONSTRAINT PUNTO_MINUTA_FK FOREIGN KEY
(
MINUTA_min_id
)
REFERENCES MINUTA
(
min_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE REQUERIMIENTO
ADD CONSTRAINT REQUERIMIENTO_PROYECTO_FK FOREIGN KEY
(
PROYECTO_pro_id
)
REFERENCES PROYECTO
(
pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TELEFONO
ADD CONSTRAINT TELEFONO_CLIENTE_NATURAL_FK FOREIGN KEY
(
CLIENTE_NATURAL_cn_id
)
REFERENCES CLIENTE_NATURAL
(
cn_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TELEFONO
ADD CONSTRAINT TELEFONO_CONTACTO_FK FOREIGN KEY
(
CONTACTO_con_id
)
REFERENCES CONTACTO
(
con_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE USUARIO
ADD CONSTRAINT USUARIO_CARGO_FK FOREIGN KEY
(
CARGO_car_id
)
REFERENCES CARGO
(
car_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PROYECTO
ADD CONSTRAINT CLIENTE_JURIDICO_PROYECTO_FK FOREIGN KEY
(
CLIENTE_JURIDICO_cj_id
)
REFERENCES CLIENTE_JURIDICO
(
cj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO


ALTER TABLE PROYECTO
ADD CONSTRAINT CLIENTE_NATURAL_PROYECTO_FK FOREIGN KEY
(
CLIENTE_NATURAL_cn_id
)
REFERENCES CLIENTE_NATURAL
(
cn_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
--END CREATES 
--Begin SP1
CREATE PROCEDURE VALIDARLOGIN 
	@Username varchar(60),
	@Clave varchar(MAX),
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

CREATE PROCEDURE OBTENER_PREGUNTA_SEGURIDAD
	@Correo varchar(60),
	@Usu_pregseguridad varchar(60) OUTPUT
	AS

	Select @Usu_pregseguridad =  Usu_pregseguridad
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE VALIDAR_PREGUNTA_SEGURIDAD
	@Correo varchar(60),
	@Usu_respseguridad varchar(100) OUTPUT
	AS

	Select @Usu_respseguridad = Usu_respseguridad
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE VALIDAR_CORREO
	@Correo varchar(60),
	@usu_correo varchar(60) OUTPUT
	AS

	Select @Usu_correo = usu_correo
	from Usuario
	where usu_correo = @Correo

	RETURN
	GO

CREATE PROCEDURE CAMBIAR_CLAVE
	@Correo varchar(60),
	@Clave varchar(MAX)
	AS
	begin
    SET NOCOUNT ON 
	UPDATE USUARIO SET
	   usu_clave = @Clave
    WHERE usu_correo = @Correo;
end
go
--End SP1

--Begin SP2
------------------------PROCEDURE SELECCIONAR CLIENTE_JURIDICO POR ID----------------------- 
CREATE PROCEDURE M2_ConsultarDatosClienteJur
	@idClienteJur [int]
AS
BEGIN
	select cli.cj_id as clienteJurID, cli.cj_nombre as clienteJurNombre, cli.cj_rif as clienteJurRif,
		   cli.cj_logo as clienteJurLogo, direccion.lug_nombre as clienteJurDir, 
		   direccion.lug_codigopostal as clienteJurCodPost, ciudad.lug_nombre as clienteJurCiudad, 
		   estado.lug_nombre as clienteJurEstado, pais.lug_nombre as clienteJurPais
	from 
		CLIENTE_JURIDICO cli, LUGAR pais, LUGAR estado, LUGAR ciudad, LUGAR direccion 
	where
		cli.LUGAR_lug_id = direccion.lug_id and direccion.LUGAR_lug_id = ciudad.lug_id
		and ciudad.LUGAR_lug_id = estado.lug_id and estado.LUGAR_lug_id = pais.lug_id
		and cli.cj_id = @idClienteJur
END;
go
--------------------------PROCEDURE CONSULTAR CARGOS----------------------------
CREATE PROCEDURE M2_ConsultarListaCargos 
AS
BEGIN
	SELECT DISTINCT CAR_NOMBRE  as nombreCargo
	FROM CARGO 
	WHERE CAR_NOMBRE NOT IN (SELECT DISTINCT CAR_NOMBRE as nombreCargo 
							 FROM CARGO, USUARIO WHERE CARGO_car_id=car_id)
END;
go
--------------------------PROCEDURE CONSULTAR PAISES----------------------------
CREATE PROCEDURE M2_ConsultarPaises
AS
BEGIN
	select lug_nombre
	from LUGAR where lug_tipo = 'Pais';
END;
GO
----------------------PROCEDURE CONSULTAR ESTADOS POR PAIS-----------------------
CREATE PROCEDURE M2_ConsultarEstadosPorPais
	@pais [varchar](60)
AS
BEGIN
	select lug_nombre
	from LUGAR 
	where lug_tipo = 'Estado' and 
		  LUGAR_lug_id = (select lug_id from LUGAR 
					      where lug_nombre = @pais and lug_tipo = 'Pais');
END;
GO
--------------------PROCEDURE CONSULTAR CIUDADES POR ESTADO----------------------
CREATE PROCEDURE M2_ConsultarCiudadesPorEstado
	@estado [varchar](60)
AS
BEGIN
	select lug_nombre
	from LUGAR 
	where lug_tipo = 'Ciudad' and 
		  LUGAR_lug_id = (select lug_id from LUGAR 
					      where lug_nombre = @estado and lug_tipo = 'Estado');
END;
go
------------------------PROCEDURE INSERTAR PAISES--------------------------------
CREATE PROCEDURE M2_InsertarPaises
AS
BEGIN
	DECLARE @nombresarray TABLE(nombres VARCHAR(100));
	DECLARE @i int;
	set @i = 0;
	insert into @nombresarray 
	values ('Aruba'),('Afghanistan'),('Angola'),('Anguilla'),('Albania'),('Andorra'),('Netherlands Antilles'),('United Arab Emirates'),
	('Argentina'),('Armenia'),('American Samoa'),('Antarctica'),('French Southern territories'),('Antigua and Barbuda'),('Australia'),
	('Austria'),('Azerbaijan'),('Burundi'),('Belgium'),('Benin'),('Burkina Faso'),('Bangladesh'),('Bulgaria'),('Bahrain'),('Bahamas'),
	('Bosnia and Herzegovina'),('Belarus'),('Belize'),('Bermuda'),('Bolivia'),('Brazil'),('Barbados'),('Brunei'),('Bhutan'),('Bouvet Island'),
	('Botswana'),('Central African Republic'),('Canada'),('Cocos (Keeling) Islands'),('Switzerland'),('Chile'),('China'),('Côte d’Ivoire'),('Cameroon'),
	('Congo, The Democratic Republic of the'),('Congo'),('Cook Islands'),('Colombia'),('Comoros'),('Cape Verde'),('Costa Rica'),('Cuba'),('Christmas Island'),
	('Cayman Islands'),('Cyprus'),('Czech Republic'),('Germany'),('Djibouti'),('Dominica'),('Denmark'),('Dominican Republic'),('Algeria'),('Ecuador'),('Egypt'),
	('Eritrea'),('Western Sahara'),('Spain'),('Estonia'),('Ethiopia'),('Finland'),('Fiji Islands'),('Falkland Islands'),('France'),('Faroe Islands'),
	('Micronesia, Federated States of'),('Gabon'),('United Kingdom'),('Georgia'),('Ghana'),('Gibraltar'),('Guinea'),('Guadeloupe'),('Gambia'),('Guinea-Bissau'),
	('Equatorial Guinea'),('Greece'),('Grenada'),('Greenland'),('Guatemala'),('French Guiana'),('Guam'),('Guyana'),('Hong Kong'),('Heard Island and McDonald Islands'),
	('Honduras'),('Croatia'),('Haiti'),('Hungary'),('Indonesia'),('India'),('British Indian Ocean Territory'),('Ireland'),('Iran'),('Iraq'),('Iceland'),('Israel'),
	('Italy'),('Jamaica'),('Jordan'),('Japan'),('Kazakstan'),('Kenya'),('Kyrgyzstan'),('Cambodia'),('Kiribati'),('Saint Kitts and Nevis'),('South Korea'),('Kuwait'),
	('Laos'),('Lebanon'),('Liberia'),('Libyan Arab Jamahiriya'),('Saint Lucia'),('Liechtenstein'),('Sri Lanka'),('Lesotho'),('Lithuania'),('Luxembourg'),('Latvia'),
	('Macao'),('Morocco'),('Monaco'),('Moldova'),('Madagascar'),('Maldives'),('Mexico'),('Marshall Islands'),('Macedonia'),('Mali'),('Malta'),('Myanmar'),('Mongolia'),
	('Northern Mariana Islands'),('Mozambique'),('Mauritania'),('Martinique'),('Mauritius'),('Malawi'),('Malaysia'),('Mayotte'),('Namibia'),('New Caledonia'),('Niger'),
	('Norfolk Island'),('Nigeria'),('Nicaragua'),('Niue'),('Netherlands'),('Norway'),('Nepal'),('Nauru'),('New Zealand'),('Oman'),('Pakistan'),('Panama'),('Pitcairn'),
	('Peru'),('Philippines'),('Palau'),('Papua New Guinea'),('Poland'),('Puerto Rico'),('North Korea'),('Portugal'),('Paraguay'),('Palestine'),('French Polynesia'),
	('Qatar'),('Réunion'),('Romania'),('Russian Federation'),('Rwanda'),('Saudi Arabia'),('Sudan'),('Senegal'),('Singapore'),
	('South Georgia and the South Sandwich Islands'),('Saint Helena'),('Svalbard and Jan Mayen'),('Solomon Islands'),('Sierra Leone'),
	('El Salvador'),('San Marino'),('Somalia'),('Saint Pierre and Miquelon'),('Sao Tome and Principe'),('Suriname'),('Slovakia'),('Slovenia'),
	('Sweden'),('Swaziland'),('Seychelles'),('Syria'),('Turks and Caicos Islands'),('Chad'),('Togo'),('Thailand'),('Tajikistan'),('Tokelau'),
	('Turkmenistan'),('East Timor'),('Tonga'),('Trinidad and Tobago'),('Tunisia'),('Turkey'),('Tuvalu'),('Taiwan'),('Tanzania'),('Uganda'),('Ukraine'),
	('United States Minor Outlying Islands'),('Uruguay'),('Estados Unidos'),('Uzbekistan'),('Holy See (Vatican City State)'),('Saint Vincent and the Grenadines'),
	('Venezuela'),('South America'),('Virgin Islands, British'),('Virgin Islands, U.S.'),('Vietnam'),('Vanuatu'),('Wallis and Futuna'),('Samoa'),('Yemen'),('Yugoslavia'),
	('South Africa'),('Zambia'),('Zimbabwe');
	
	while (@i < (select count(*) from @nombresarray))
	begin
		insert into LUGAR (lug_nombre, lug_tipo) 
		values ((
		SELECT a.nombres
		FROM
			(SELECT ROW_NUMBER() OVER (ORDER BY  nombres) AS ROWNUMBERS, * 
			FROM @nombresarray) a
		WHERE a.ROWNUMBERS = @i)
		, 'Pais');
		set @i = @i + 1;
	end	
END;
go
------------------------PROCEDURE AGREGAR CLIENTE_JURIDICO----------------------- 
CREATE PROCEDURE M2_AgregarClienteJur	 
	
--Datos de la empresa
    @cj_rif       [VARCHAR] (20),
    @cj_nombre    [VARCHAR] (60),
    @cj_logo      [VARCHAR] (60),
	
--Direccion de la empresa
	
    @pais         [VARCHAR] (100),
	
    @estado       [VARCHAR] (100),
	
    @ciudad       [VARCHAR] (100), 
	
    @direccion    [VARCHAR] (100),
	
    @codigo_post  [int], 
	
--Datos del contacto
	
    @con_cedula   [VARCHAR] (20),
    @con_nombre   [VARCHAR] (100),
    @con_apellido [VARCHAR] (50),
	
--Nombre del cargo del contacto
	
    @con_cargo    [VARCHAR] (60),
	
--Telefono del contacto
	
    @con_cod_tel  [VARCHAR] (5),
	
    @con_num_tel  [VARCHAR] (20)

AS 

BEGIN
	
DECLARE @num_paises as int;
	
select @num_paises = count(*)
	from LUGAR where lug_nombre = @pais and lug_tipo = 'País';

	
DECLARE @num_estados as int;
	
select @num_estados = count(*)
	from LUGAR where lug_nombre = @estado and lug_tipo = 'Estado';

	
DECLARE @num_ciudades as int;
	
select @num_ciudades = count(*)
	from LUGAR where lug_nombre = @ciudad and lug_tipo = 'Ciudad';

	
DECLARE @num_cargos as int;
	
select @num_cargos = count(*)
	from CARGO where car_nombre = @con_cargo;

	
if @num_paises = 0
		
	INSERT INTO LUGAR (lug_nombre, lug_tipo, LUGAR_lug_id) 
		
	VALUES (@pais, 'País', null);
		
	
if @num_estados = 0
		
	INSERT INTO LUGAR (lug_nombre, lug_tipo, LUGAR_lug_id) 
		
	VALUES (@estado, 'Estado', 
		
	(SELECT l.lug_id FROM LUGAR l WHERE l.lug_nombre = @pais and l.lug_tipo = 'País'));

	
if @num_ciudades = 0
		
	INSERT INTO LUGAR (lug_nombre, lug_tipo, LUGAR_lug_id) 
		
	VALUES (@ciudad, 'Ciudad', 
		
	(SELECT l.lug_id FROM LUGAR l WHERE l.lug_nombre = @estado and l.lug_tipo = 'Estado'));
	
	
	
INSERT INTO LUGAR (lug_nombre, lug_tipo, lug_codigopostal, LUGAR_lug_id)
	
VALUES (@direccion, 'Direccion', @codigo_post, 
	
(SELECT l.lug_id FROM LUGAR l WHERE l.lug_nombre = @ciudad and l.lug_tipo = 'Ciudad'));

	

INSERT INTO CLIENTE_JURIDICO (cj_rif, cj_nombre, cj_logo, LUGAR_lug_id)
	
VALUES (@cj_rif, @cj_nombre, @cj_logo, (SELECT MAX(lug_id) FROM LUGAR));

	

if @num_cargos = 0
		
	INSERT INTO CARGO (car_nombre) VALUES (@con_cargo);

	

INSERT INTO CONTACTO (con_cedula, con_nombre, con_apellido, CLIENTE_JURIDICO_cj_id, CARGO_car_id) 
	
VALUES (@con_cedula, @con_nombre, @con_apellido, 
	(SELECT MAX(cj_id) FROM CLIENTE_JURIDICO), 
	
(SELECT car_id FROM CARGO WHERE car_nombre = @con_cargo));
	
	

INSERT INTO TELEFONO (tel_codigo, tel_numero, CONTACTO_con_id) VALUES (@con_cod_tel, @con_num_tel, 
	
(SELECT con_id FROM CONTACTO WHERE con_cedula = @con_cedula));


END;
GO
------------------------PROCEDURE MODIFICAR CLIENTE_JURIDICO----------------------- 
CREATE PROCEDURE M2_ModificarClienteJur	 
	--Datos de la empresa
	@cj_id		  [int], 
	@cj_rif       [VARCHAR] (20),
    @cj_nombre    [VARCHAR] (60),
    @cj_logo      [VARCHAR] (60),
	--Direccion de la empresa
	@direccion    [VARCHAR] (100),
	@codigo_post  [int]
AS 
BEGIN

	if (@direccion != (select lug_nombre from LUGAR where lug_id = (select LUGAR_lug_id from CLIENTE_JURIDICO where cj_id = @cj_id)))
		UPDATE LUGAR
		SET
			lug_nombre       = @direccion,
			lug_codigopostal = @codigo_post
		WHERE
			lug_id = (select LUGAR_lug_id from CLIENTE_JURIDICO where cj_id = @cj_id);

	UPDATE CLIENTE_JURIDICO
	SET 
		cj_nombre = @cj_nombre,
		cj_logo   = @cj_logo,
		cj_rif    = @cj_logo,
		LUGAR_lug_id = (select lug_id from LUGAR where lug_nombre = @direccion)
	WHERE
		cj_id = @cj_id;
END;
GO
------------------------PROCEDURE SELECCIONAR LISTA DE CLIENTE_JURIDICO----------------------- 
CREATE PROCEDURE M2_ConsultarListaClienteJur
AS
BEGIN
	select cli.cj_id as clienteJurID, cli.cj_nombre as clienteJurNombre, cli.cj_rif as clienteJurRif,
		   cli.cj_logo as clienteJurLogo, direccion.lug_nombre as clienteJurDir, 
		   direccion.lug_codigopostal as clienteJurCodPost, ciudad.lug_nombre as clienteJurCiudad, 
		   estado.lug_nombre as clienteJurEstado, pais.lug_nombre as clienteJurPais
	from 
		CLIENTE_JURIDICO cli, LUGAR pais, LUGAR estado, LUGAR ciudad, LUGAR direccion 
	where
		cli.LUGAR_lug_id = direccion.lug_id and direccion.LUGAR_lug_id = ciudad.lug_id
		and ciudad.LUGAR_lug_id = estado.lug_id and estado.LUGAR_lug_id = pais.lug_id
END;
GO
-------------------PROCEDURE SELECCIONAR LISTA DE CONTACTOS DE JURIDICOS POR ID------------------ 
CREATE PROCEDURE M2_ConsultarListaContactosJurID
(
	@idClienteJur [int]
)
AS
BEGIN
	select con.con_id as contactoID, con.con_cedula as contactoCedula, con.con_nombre as contactoNombre,
		   con.con_apellido as contactoApellido, tel.tel_codigo as COD_TELEFONO, tel.tel_numero NUM_TELEFONO,
		   car.car_nombre as contactoCargo
	from CONTACTO con, CLIENTE_JURIDICO cli, TELEFONO tel, CARGO car
	where
		con.CLIENTE_JURIDICO_cj_id = cli.cj_id and tel.CONTACTO_con_id = con_id and car.car_id = con.CARGO_car_id
END;
GO
-------------------PROCEDURE SELECCIONAR DATOS DE CONTACTO POR ID------------------ 
CREATE PROCEDURE M2_ConsultarDatosContacto
(
	@idContacto [int]
)
AS
BEGIN
	select con.con_id as contactoID, con.con_cedula as contactoCedula, con.con_nombre as contactoNombre,
		   con.con_apellido as contactoApellido, tel.tel_codigo as COD_TELEFONO, tel.tel_numero NUM_TELEFONO,
		   car.car_nombre as contactoCargo
	from CONTACTO con, CLIENTE_JURIDICO cli, TELEFONO tel, CARGO car
	where
		con.con_id = @idContacto and con.CLIENTE_JURIDICO_cj_id = cli.cj_id and 
		tel.CONTACTO_con_id = con_id and car.car_id = con.CARGO_car_id
END;
GO
-------------------PROCEDURE ELIMINAR CLIENTE_JURIDICO------------------ 
CREATE PROCEDURE M2_EliminarClienteJuridico
(
	@idClienteJur [int]
)
AS
BEGIN

	delete from LUGAR 
	where 
		lug_id = (select LUGAR_lug_id 
				  from CLIENTE_JURIDICO
				  where cj_id = @idClienteJur);

	delete from TELEFONO
	where
		CONTACTO_con_id in (select con_id 
						   from CONTACTO 
						   where CLIENTE_JURIDICO_cj_id = @idClienteJur);

	delete from CONTACTO
	where
		CLIENTE_JURIDICO_cj_id = @idClienteJur;

	delete from CLIENTE_JURIDICO
	where
		cj_id = @idClienteJur;
		
	
END;
GO
-------------------PROCEDURE ELIMINAR CONTACTO POR ID------------------ 
CREATE PROCEDURE M2_EliminarContacto
(
	@idContacto [int]
)
AS
BEGIN
	delete from TELEFONO
	where
		CONTACTO_con_id = @idContacto;

	delete from CONTACTO
	where
		con_id = @idContacto;
	
END;
GO
--------------------PROCEDURE AGREGAR CLIENTE_NATURAL--------------
create procedure M2_AgregarClienteNat

    @cn_cedula    [VARCHAR] (20),
    @cn_nombre    [VARCHAR] (60),
    @cn_apellido  [VARCHAR] (60),
    @cn_correo    [VARCHAR] (60),
	---direccion del cliente natural
    @direccion	  [VARCHAR] (100),
	@pais		  [VARCHAR]	(100),
	@estado       [VARCHAR] (100),
	@ciudad	      [VARCHAR] (100),
	---codigo postal de la direccion
	@codigo_post  [INT],
	---telefono del cliente natural
	@codigo_tel [VARCHAR](5) ,
	@numero_tel [VARCHAR] (20)
as
	begin
		declare @num_paises as int;
		select @num_paises = count(*)
		from LUGAR where lug_nombre = @pais and lug_tipo = 'País';

		declare @num_estados as int;
		select @num_estados = count(*)
		from LUGAR where lug_nombre = @estado and lug_tipo = 'Estado';

		declare @num_ciudad as int;
		select @num_ciudad = count(*)
		from LUGAR where lug_nombre = @ciudad and lug_tipo = 'Ciudad';

		if @num_paises = 0 
			insert into LUGAR (lug_nombre, lug_tipo, LUGAR_lug_id) values (@pais,'País', null);

		if @num_estados = 0
			insert into LUGAR (lug_nombre, lug_tipo, LUGAR_lug_id) values (@estado,'Estado', (select lug_id
			from LUGAR where lug_nombre = @pais and lug_tipo = 'País'));
		
		if @num_ciudad = 0
			insert into LUGAR (lug_nombre, lug_tipo, LUGAR_lug_id) values (@ciudad,'Ciudad', (select lug_id
			from LUGAR where lug_nombre = @estado and lug_tipo = 'Estado'));

		insert into LUGAR (lug_nombre, lug_tipo, lug_codigopostal, LUGAR_lug_id)
		values (@direccion, 'Direccion', @codigo_post, (select lug_id from LUGAR
		where lug_nombre = @ciudad and lug_tipo = 'Ciudad'));

		insert into CLIENTE_NATURAL (cn_nombre, cn_apellido, cn_cedula, cn_correo, LUGAR_lug_id)
		values (@cn_nombre, @cn_apellido, @cn_cedula, @cn_correo, (select MAX (lug_id) from LUGAR));

		insert into CONTACTO (con_nombre, con_apellido, con_cedula, CLIENTE_NATURAL_cn_id)
		values (@cn_nombre, @cn_apellido, @cn_cedula, (select MAX(cn_id) from CLIENTE_NATURAL));

	    insert into TELEFONO (tel_codigo, tel_numero, CLIENTE_NATURAL_cn_id, CONTACTO_con_id) values (@codigo_tel, @numero_tel, (select cn_id from
		CLIENTE_NATURAL where cn_cedula = @cn_cedula), (select con_id from CONTACTO where con_cedula = @cn_cedula));

	end;
go
--------------------PROCEDURE MODIFICAR CLIENTE_NATURAL--------------
create procedure M2_ModificarClienteNat
	@idClienteNat		  [int],
    @cn_cedula    [VARCHAR] (20),
    @cn_nombre    [VARCHAR] (60),
    @cn_apellido  [VARCHAR] (60),
    @cn_correo    [VARCHAR] (60),
	---direccion del cliente natural
    @direccion	  [VARCHAR] (100),
	@codigo_postal	  [int],
	---telefono del cliente natural
	@codigo_tel [VARCHAR](5) ,
	@numero_tel [VARCHAR] (20)
as
	begin

		declare @num_direccion as int;
		select @num_direccion = count(*)
		from LUGAR where lug_nombre = @direccion and lug_tipo = 'Direccion';

		update LUGAR
		set lug_nombre = @direccion,
			lug_codigopostal = @codigo_postal
		where lug_id = (select LUGAR_lug_id from CLIENTE_NATURAL where cn_id = @idClienteNat);

		update CLIENTE_NATURAL
		set cn_cedula = @cn_cedula,
			cn_nombre = @cn_nombre,
			cn_apellido = @cn_apellido,
			cn_correo = @cn_correo
		where cn_id = @idClienteNat;

		update CONTACTO
		set con_cedula = @cn_cedula,
			con_nombre = @cn_nombre,
			con_apellido = @cn_apellido
		where con_id = @idClienteNat;
		
		update TELEFONO
		set tel_codigo = @codigo_tel,
			tel_numero = @numero_tel
		where CLIENTE_NATURAL_cn_id = (select cn_id from CLIENTE_NATURAL where cn_id = @idClienteNat);
	end;
go
--------------------PROCEDURE CONSULTAR LISTA CLIENTE_NATURAL--------------
create procedure M2_ConsultarListaClienteNat
as
	begin

	select cn.cn_id as ID_CLIENTENATURAL, cn.cn_nombre as NOMBRE_CLIENTENATURAL, cn.cn_apellido as APELLIDO_CLIENTENATURAL,
						cn.cn_cedula as CEDULA_CLIENTENATURAL, cn.cn_correo as CORREO_CLIENTENATURAL, tel.tel_codigo as COD_TELEFONO,
						tel.tel_numero as NUM_TELEFONO, direccion.lug_nombre as NOMBRE_DIR, direccion.lug_codigopostal as CODPOSTAL_DIR, 
						ciudad.lug_nombre as NOMBRE_CIUDAD, estado.lug_nombre as NOMBRE_ESTADO, pais.lug_nombre as NOMBRE_PAIS 
	from CLIENTE_NATURAL cn, LUGAR pais, LUGAR estado, LUGAR ciudad, LUGAR direccion, TELEFONO tel
	where tel.CLIENTE_NATURAL_cn_id = cn.cn_id and cn.LUGAR_lug_id = direccion.lug_id and direccion.LUGAR_lug_id = ciudad.lug_id and
		  ciudad.LUGAR_lug_id = estado.lug_id and estado.LUGAR_lug_id = pais.lug_id;
	end;
go
--------------------PROCEDURE CONSULTAR DATOS CLIENTE_NATURAL--------------
create procedure M2_ConsultarDatosClienteNat
	@idClienteNat [int]
as
	begin

	select cn.cn_id as ID_CLIENTENATURAL, cn.cn_nombre as NOMBRE_CLIENTENATURAL, cn.cn_apellido as APELLIDO_CLIENTENATURAL,
						cn.cn_cedula as CEDULA_CLIENTENATURAL, cn.cn_correo as CORREO_CLIENTENATURAL, tel.tel_codigo as COD_TELEFONO,
						tel.tel_numero as NUM_TELEFONO, direccion.lug_nombre as NOMBRE_DIR, direccion.lug_codigopostal as CODPOSTAL_DIR, 
						ciudad.lug_nombre as NOMBRE_CIUDAD, estado.lug_nombre as NOMBRE_ESTADO, pais.lug_nombre as NOMBRE_PAIS 
	from CLIENTE_NATURAL cn, LUGAR pais, LUGAR estado, LUGAR ciudad, LUGAR direccion, TELEFONO tel
	where tel.CLIENTE_NATURAL_cn_id = cn.cn_id and cn.LUGAR_lug_id = direccion.lug_id and direccion.LUGAR_lug_id = ciudad.lug_id and
		  ciudad.LUGAR_lug_id = estado.lug_id and estado.LUGAR_lug_id = pais.lug_id and cn.cn_id = @idClienteNat;
	end;
go
--------------------PROCEDURE CONSULTAR DATOS CONTACTO CLIENTE_NATURAL ID--------------
create procedure M2_ConsultarDatosContactoNatID
	@idClienteNat [int]
as
	begin
		
			select con.con_id as contactoID, con.con_cedula as contactoCedula, con.con_nombre contactoNombre,
				   con.con_apellido as contactoApellido
			from CLIENTE_NATURAL cn, CONTACTO con
			where cn.cn_id = con.CLIENTE_NATURAL_cn_id;
	end;
go
--------------------PROCEDURE ELIMINAR CLIENTE_NATURAL -------------
create procedure M2_EliminarClienteNat
	@idClienteNat [int]
as
	begin
		delete 
		from TELEFONO
		where CLIENTE_NATURAL_cn_id = @idClienteNat;

		delete
		from CONTACTO
		where CLIENTE_NATURAL_cn_id = @idClienteNat;

		delete 
		from CLIENTE_NATURAL
		where cn_id = @idClienteNat;
	end;
go

--End SP2

--Begin SP3
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
		   ca.car_nombre as cargoNombre, cj.cj_nombre as clienteNombre,
		   cj.cj_id as clienteID, 1 as valor
	FROM INVOLUCRADOS_CLIENTES ic, CONTACTO co,  CLIENTE_JURIDICO cj, CARGO ca
	WHERE ic.PROYECTO_pro_id = (select pro_id from PROYECTO where pro_codigo = 'TOT') and
		  ic.CONTACTO_con_id = co.con_id  and co.CARGO_car_id = ca.car_id
		  and co.CLIENTE_JURIDICO_cj_id = cj.cj_id
	UNION
	SELECT co.con_id as contactoID, co.con_nombre as contactoNombre, co.con_apellido as contactoApellido,
		   ca.car_nombre as cargoNombre, cn.cn_nombre as clienteNombre,
		   cn.cn_id as clienteID, 2 as valor
	FROM INVOLUCRADOS_CLIENTES ic, CONTACTO co,  CLIENTE_NATURAL cn, CARGO ca
	WHERE ic.PROYECTO_pro_id = (select pro_id from PROYECTO where pro_codigo = 'TOT') and
		  ic.CONTACTO_con_id = co.con_id  and co.CARGO_car_id = ca.car_id
		  and co.CLIENTE_NATURAL_cn_id =  cn_id
 END
 GO
-----------------------PROCEDIMIENTO PARA CONSULTAR INVOLUCRADOS_USUARIOS---------------------------
CREATE PROCEDURE Procedure_consultarInvUsuario
	@proyecto_codigo [varchar](6)
AS
 BEGIN
	SELECT u.usu_id as usuarioID, u.usu_nombre as usuarioNombre, u.usu_apellido as usuarioApellido, c.car_nombre as cargoNombre, u.usu_username as usuarioUsername
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
CREATE PROCEDURE Procedure_consultarDatosContactoID(
	@idContacto int,
	@con_nombre varchar(60) OUTPUT,
	@con_apellido varchar(60) OUTPUT,
	@con_cargo varchar(60) OUTPUT,
	@cj_nombre varchar(60) OUTPUT
	)
AS
BEGIN
	SELECT @con_nombre = con.con_nombre, @con_apellido = con.con_apellido, 
	@con_cargo = car.car_nombre, @cj_nombre = cj.cj_nombre
	from CONTACTO as con, CARGO as car, CLIENTE_JURIDICO as cj
	where
		con_id = @idContacto and CARGO_car_id = car_id
		and con.CLIENTE_JURIDICO_cj_id = cj.cj_id
END
go

--End SP3

--Begin SP4

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
		SELECT	@resultado = COUNT(*)
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO  WHERE pro_codigo = @pro_codigo) and req_estatus='Finalizado' )
	END
GO



CREATE PROCEDURE M5_ContarRequerimientosPorProyecto

	@pro_codigo	[varchar] (6),
	@resultado int OUTPUT

AS
	BEGIN
		SELECT @resultado = COUNT(*)
		FROM  REQUERIMIENTO R
		WHERE ( R.PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO  WHERE pro_codigo = @pro_codigo) )
		RETURN
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

CREATE PROCEDURE Procedimiento_ObtenerIDClienteNatural
	@cedula	[varchar] (20),
	@idClienteNatural int OUTPUT
AS
	BEGIN 
		SELECT @idClienteNatural = cn_id 
		FROM CLIENTE_NATURAL
		WHERE cn_cedula = @cedula
		RETURN
	END
GO


CREATE PROCEDURE Procedimiento_ObtenerIDClienteJuridico
	@rif [varchar] (20),
	@idClienteJuridico int OUTPUT
AS
	BEGIN 
		SELECT @idClienteJuridico = cj_id
		FROM CLIENTE_JURIDICO
		WHERE cj_rif = @rif
		RETURN
	END
GO

--End SP4

--Begin SP5
-- ========================================================================= --
-- Agregar requerimiento
-- ========================================================================= --
CREATE PROCEDURE M5_AgregarRequerimiento

  @req_codigo     [varchar] (15),
  @req_descripcion  [varchar] (500),
  @req_tipo     [varchar] (25),
  @req_prioridad    [varchar] (10),
  @req_estatus    [varchar] (50),
  @PROYECTO_pro_id  [int]

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

	@req_id				[int]

AS
	BEGIN
		DELETE FROM REQUERIMIENTO
		WHERE req_id = @req_id;
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
  
--End SP5

--Begin SP6
/*=================================================Procedimientos de la tabla ACTOR=====================================================*/
begin transaction;
go
/*Insertar Actor*/
CREATE PROCEDURE INSERTAR_ACTOR 
	@nombre [varchar] (100),
	@descripcion [varchar] (500),
	@codigoProyecto varchar(6),
	@afectado int OUTPUT
AS
DECLARE @idProyecto int = 0
	BEGIN
		-- Activo la funcion para saber si la  Base de Datos fue alterada
		SET NOCOUNT OFF

		select @idProyecto=pro_id from proyecto where pro_codigo=@codigoProyecto;
		 

		--Inserto el Actor
		INSERT INTO ACTOR (act_nombre,act_descripcion,PROYECTO_pro_id) VALUES (@nombre,@descripcion,@idproyecto);
		
		select @afectado=count(*) from actor 
				where act_nombre=@nombre 
				and  PROYECTO_pro_id=@idproyecto; 
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

/*Verifica la existencia del actor*/

CREATE PROCEDURE ValidarExitenciaActor
@nombre varchar(30),
@existe int OUTPUT
AS
	SET NOCOUNT OFF;
	SELECT @existe=count(*) from actor where act_nombre =@nombre;
GO

CREATE PROCEDURE LlenarComboActores
@codigoProyecto  varchar(30)
AS
select	a.act_id as idActor,
		a.act_nombre as nombreActor
from actor a, 
	 proyecto p 
where p.pro_id = a.PROYECTO_pro_id
and p.pro_codigo =@codigoProyecto;

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
	@disparador [varchar] (200),
	@proyecto int
AS
	BEGIN
		
		--Inserto el caso de uso
		INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador,PROYECTO_pro_id) VALUES (@identificador,@titulo,@condexito,@condfallo,@disparador,@proyecto);
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

CREATE PROCEDURE LISTAR_CU 
AS
    BEGIN
        --Leo todos los datos de los casos de uso
        SELECT C.cu_id, C.cu_identificador ,C.cu_titulo, C.cu_condexito, C.cu_condfallo, C.cu_disparador 
        FROM CASO_USO C
    END
GO

/*Leer datos basicos del Caso de Uso*/
CREATE PROCEDURE LEER_CU 
	@idproyecto int
AS
	BEGIN
		--Leo todos los datos del casos de uso
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


--End SP6

--Begin SP7
-------SECUENCIA USUARIO
CREATE SEQUENCE secuenciaIdUsuario
AS 
	int
	START WITH 1
	INCREMENT BY 1;
	
go

-------SECUENCIA CARGO---
CREATE SEQUENCE secuenciaIdCargo
AS 
	int
	START WITH 1
	INCREMENT BY 1;
 
go

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
    SET NOCOUNT ON 
	SELECT usu_id,car_nombre,usu_username,usu_clave,usu_nombre,usu_apellido,usu_rol,usu_correo,usu_pregseguridad,usu_respseguridad
	FROM USUARIO,CARGO
	WHERE usu_id = @usu_id AND CARGO_car_id = car_id;
	
end
go

CREATE PROCEDURE ConsultarUsuarioSegunCargo
	 @usu_cargo [varchar](60)
AS 
begin
    SET NOCOUNT ON 
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
    SET NOCOUNT ON 
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
    SET NOCOUNT ON 
    DELETE FROM CARGO
	WHERE car_id = @car_id;
end
go


CREATE PROCEDURE EliminarUsuario
     @usu_username [varchar](60) 
AS 
begin
    SET NOCOUNT ON 
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



CREATE PROCEDURE ListarUsuario
	@usu_username varchar(60) OUTPUT,
	@usu_nombre varchar(60) OUTPUT,
	@usu_apellido varchar(60) OUTPUT,
	@usu_car_nombre varchar(60)OUTPUT
AS
	Select 	@usu_nombre = Usu_nombre, @usu_apellido = Usu_apellido ,  @usu_car_nombre = car_nombre
	from Usuario, cargo
	where  CARGO_car_id = car_id;
RETURN
GO	
--End SP7



--Begin SP8
-------SECUENCIA MINUTA -------
CREATE SEQUENCE secuenciaIdMinuta
AS 
	int
	START WITH 1
	INCREMENT BY 1;
	
go

-------SECUENCIA ACUERDO -------
CREATE SEQUENCE secuenciaIdAcuerdo
AS 
	int
	START WITH 1
	INCREMENT BY 1;
 
go

-------SECUENCIA PUNTO -------
CREATE SEQUENCE secuenciaIdPunto
AS 
	int
	START WITH 1
	INCREMENT BY 1;
 
go

-------SECUENCIA MIN_INV -------
CREATE SEQUENCE secuenciaIdMinInv
AS 
	int
	START WITH 1
	INCREMENT BY 1;
 
go

-------SECUENCIA ACU_INV -------
CREATE SEQUENCE secuenciaIdAcuInv
AS 
	int
	START WITH 1
	INCREMENT BY 1;
 
go
-------SECUENCIA Requerimiento-------
CREATE SEQUENCE secuenciaRequerimiento
AS 
  int
  START WITH 1
  INCREMENT BY 1;
 
go
------------------ Procedimientos del Módulo 8 ------------------------
------------------ Procedimientos para Agregar -----------------------

-------------------Procedimiento para Agregar una Minuta ----------------------
CREATE PROCEDURE Procedure_AgregarMinuta
		 
		@min_fecha   [datetime],
		@min_motivo  [varchar] (200),
		@min_observaciones 	[varchar] (500)
	   
AS 
BEGIN
		INSERT INTO MINUTA(min_fecha, min_motivo, min_observaciones) Output Inserted.min_id
	    VALUES(@min_fecha ,@min_motivo ,@min_observaciones)

END;
GO

-------------------Procedimiento para Agregar un Punto ----------------------

CREATE PROCEDURE Procedure_AgregarPunto
		 
		@pun_titulo   [varchar] (100),
		@pun_desarrollo  [varchar] (400)
AS 
BEGIN
		INSERT INTO PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id)
	    VALUES(@pun_titulo ,@pun_desarrollo ,(SELECT MAX(min_id) FROM MINUTA))
END;
GO

-------------------Procedimiento para Agregar un Acuerdo ----------------------

CREATE PROCEDURE Procedure_AgregarAcuerdo
		 
		 
		@acu_fecha   [date],
		@acu_desarrollo  [varchar] (300)
AS 
BEGIN

		INSERT INTO ACUERDO(acu_fecha, acu_desarrollo, MINUTA_min_id)
	    VALUES(@acu_fecha, @acu_desarrollo,	(SELECT MAX(min_id) FROM MINUTA));

END;
GO


CREATE PROCEDURE Procedure_AgregarResponsablesUsuarioDeAcuerdos

		@usu_id   [int],
		@pro_id   [varchar](6)
AS 
BEGIN

		INSERT INTO ACU_INV(ACUERDO_acu_id,INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id)
	    VALUES((SELECT MAX(acu_id) FROM ACUERDO), @usu_id, (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @pro_id))
END;
GO

CREATE PROCEDURE Procedure_AgregarResponsablesContactoDeAcuerdos
		
		@con_id   [int],
		@pro_id   [varchar](6)
AS 
BEGIN

		INSERT INTO ACU_INV(ACUERDO_acu_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id,INVOLUCRADOS_CLIENTES_PROYECTO_pro_id)
	    VALUES((SELECT MAX(acu_id) FROM ACUERDO), @con_id, (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @pro_id));
END;
GO
-------------------Procedimiento para Agregar un Involucrado Cliente ----------------------

CREATE PROCEDURE Procedure_AgregarInvolucradoCliente
		 
		@con_id          [int],
		@pro_id          [varchar](6)
		
AS 
BEGIN
		INSERT INTO MIN_INV(MINUTA_min_id, INVOLUCRADOS_CLIENTES_CONTACTO_con_id, 
				    INVOLUCRADOS_CLIENTES_PROYECTO_pro_id)
	    VALUES((SELECT MAX(min_id) FROM MINUTA), @con_id, (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @pro_id))
END;
GO

-------------------Procedimiento para Agregar un Involucrado Usuario ----------------------

CREATE PROCEDURE Procedure_AgregarInvolucradoUsuario
		 
		@usu_id          [int],
		@pro_id          [varchar](6)
		
AS 
BEGIN
		INSERT INTO MIN_INV(MINUTA_min_id, INVOLUCRADOS_USUARIOS_USUARIO_usu_id, 
		            INVOLUCRADOS_USUARIOS_PROYECTO_pro_id)
	    VALUES((SELECT MAX(min_id) FROM MINUTA), @usu_id, (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @pro_id))
END;
GO
------------------ Procedimientos para consultar------------------------------

------------------ Procedimiento para consultar las Minutas de un Proyecto----------------------

CREATE PROCEDURE Procedure_ConsultarMinutasProyecto
	
	@min_inv_proy [varchar](6)	
	   
AS
 BEGIN
	
	SELECT Distinct(M.min_id) as min_id, M.min_fecha, M.min_motivo, M.min_observaciones
	FROM MINUTA M, MIN_INV MI
	WHERE (MI.INVOLUCRADOS_USUARIOS_PROYECTO_pro_id= (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @min_inv_proy) or MI.INVOLUCRADOS_CLIENTES_PROYECTO_pro_id =(SELECT pro_id FROM PROYECTO WHERE pro_codigo= @min_inv_proy))
 END
GO

------------------ Procedimiento para consultar una Minuta en especifico----------------------

CREATE PROCEDURE Procedure_ConsultarMinuta
	
	@min_id [int]	
	   
AS
 BEGIN
	
	SELECT M.min_id, M.min_fecha, M.min_motivo, M.min_observaciones
	FROM MINUTA M
	WHERE M.min_id = @min_id
 END
GO

------------------ Procedimiento para consultar los puntos de una minuta----------------------
CREATE PROCEDURE Procedure_ConsultarPuntos
	
	@min_id [int]	
	   
AS
 BEGIN
	
	SELECT P.pun_id, P.pun_titulo, P.pun_desarrollo
	FROM PUNTO P
	WHERE P.MINUTA_min_id = @min_id
 END
GO

------------------ Procedimiento para consultar los Acuerdos de una minuta----------------------
CREATE PROCEDURE Procedure_ConsultarAcuerdos
	
	@min_id [int]	
	   
AS
 BEGIN
	
	SELECT A.acu_id, A.acu_fecha, A.acu_desarrollo
	FROM  ACUERDO A
	WHERE A.MINUTA_min_id = @min_id
 END
GO

CREATE PROCEDURE Procedure_ConsultarInvolucradosUsuarioProyecto

   @pro_id [varchar](6)

AS
 BEGIN
     
	 SELECT I.USUARIO_usu_id as usu_id FROM INVOLUCRADOS_USUARIOS I WHERE I.PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @pro_id);
 END
GO

CREATE PROCEDURE Procedure_ConsultarInvolucradosContactoProyecto

   @pro_id [varchar](6)

AS
 BEGIN
     
	 SELECT I.CONTACTO_con_id as con_id FROM INVOLUCRADOS_CLIENTES I WHERE I.PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @pro_id);
 END
GO
------------------- Procedimiento para consultar los responsables tipo contacto de los Acuerdos de la una Minuta
CREATE PROCEDURE Procedure_ConsultarAcuerdoResponsablesContactoMinuta

	@acu_id [int]
	
AS
 BEGIN 

     SELECT AC.INVOLUCRADOS_CLIENTES_CONTACTO_con_id as idContacto
	 FROM ACU_INV AC
	 WHERE AC.ACUERDO_acu_id = @acu_id and AC.INVOLUCRADOS_CLIENTES_CONTACTO_con_id is not null
END
GO

------------------- Procedimiento para consultar los responsables tipo usuario de los Acuerdos de la una Minuta
CREATE PROCEDURE Procedure_ConsultarAcuerdoResponsablesUsuarioMinuta

	@acu_id [int]
	
AS
 BEGIN 

     SELECT DISTINCT(AC.INVOLUCRADOS_USUARIOS_USUARIO_usu_id) as idUsuario
	 FROM ACU_INV AC
	 WHERE AC.ACUERDO_acu_id = @acu_id and AC.INVOLUCRADOS_USUARIOS_USUARIO_usu_id is not null
END
GO

------------------Procedimiento para consultar Asistentes Usuario en una Minuta----------------
CREATE PROCEDURE Procedure_ConsultarAsistenteUsuarioMinuta
  
  @min_id [int]

AS
 BEGIN
     SELECT M.INVOLUCRADOS_USUARIOS_USUARIO_usu_id as idUsuario FROM MIN_INV M
	 WHERE M.MINUTA_min_id =@min_id and M.INVOLUCRADOS_USUARIOS_USUARIO_usu_id is not null
 END
GO

-----------------Procedimiento para consultar Asistentes Contacto en una Minuta---------------------
CREATE PROCEDURE Procedure_ConsultarAsistenteContactoMinuta
  
  @min_id [int]

AS
 BEGIN
     SELECT M.INVOLUCRADOS_CLIENTES_CONTACTO_con_id as idContacto FROM MIN_INV M
	 WHERE M.INVOLUCRADOS_CLIENTES_CONTACTO_con_id is not NULL AND M.MINUTA_min_id = @min_id
 END
GO


----------------- Procedimiento para consultar algunos datos de Usuario --------------------------------------
CREATE PROCEDURE Procedure_ConsultarUsuarioMinuta

       @acu_id [int],
	   @pro_id [varchar](6)
AS
 BEGIN
	
	SELECT U.usu_id, U.usu_nombre, U.usu_apellido, U.usu_rol
	FROM  USUARIO U , ACU_INV A
	WHERE A.ACUERDO_acu_id = @acu_id and A.INVOLUCRADOS_USUARIOS_PROYECTO_pro_id= (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @pro_id) 
	      and A.INVOLUCRADOS_USUARIOS_USUARIO_usu_id = U.usu_id
 END
GO

----------------- Procedimiento para consutar los datos de un Usuario --------------------------
CREATE PROCEDURE Procedure_ConsultarUsuario

       @usu_id [int]
AS
 BEGIN

    SELECT U.usu_id, U.usu_nombre, U.usu_apellido, U.usu_rol
	FROM  USUARIO U
	WHERE U.usu_id = @usu_id
 END
GO

----------------- Procedimiento para consutar los datos de un Contacto --------------------------
CREATE PROCEDURE Procedure_ConsultarContacto

       @con_id [int]
AS
 BEGIN

    SELECT C.con_id, C.con_nombre, C.con_apellido, CA.car_nombre
	FROM  CONTACTO C, CARGO CA
	WHERE C.con_id =  @con_id AND CA.car_id = C.CARGO_car_id
 END
GO

-----------------Procedimientos para Modificar---------------------------------------------------
----------------- Procedimiento para modificar datos principales de una Minuta-------------------

CREATE PROCEDURE Procedure_ModificarMinuta
    
	@min_id [int],
	@min_fecha [datetime],
	@min_motivo [varchar](200),
	@min_observaciones [varchar](500)

AS
   UPDATE MINUTA
   SET 
       min_fecha = @min_fecha,
       min_motivo = @min_motivo,
	   min_observaciones = @min_observaciones
   WHERE
       min_id = @min_id;
GO

----------------- Procedimiento para modificar puntos

CREATE PROCEDURE Procedure_ModificarPunto

     @min_id [int],
	 @pun_id [int],
	 @pun_titulo [varchar](100),
	 @pun_desarrollo [varchar](400)
AS
BEGIN
   UPDATE PUNTO
   SET 
       pun_titulo = @pun_titulo,
	   pun_desarrollo = @pun_desarrollo
   WHERE
       MINUTA_min_id = @min_id and pun_id= @pun_id;
END
GO

---------------- Procedimiento para modificar un Acuerdo
CREATE PROCEDURE Procedure_ModificarAcuerdo

     @acu_id [int],
	 @acu_fecha [date],
	 @acu_desarrollo [varchar] (300),
	 @MINUTA_min_id [int]
AS
BEGIN
   UPDATE ACUERDO
   SET
       acu_fecha = @acu_fecha, 
	   acu_desarrollo = @acu_desarrollo ,
	   MINUTA_min_id = @MINUTA_min_id
   WHERE
       acu_id = @acu_id
END
GO

----------------- Procedimientos para Eliminar-----------------------
----------------- Procedimiento para Eliminar un Punto---------------

CREATE PROCEDURE Procedure_EliminarPunto

       @min_id [int],
	   @pun_id [int]

AS 
BEGIN
   DELETE FROM PUNTO
	   	WHERE MINUTA_min_id = @min_id and pun_id= @min_id
 
END
GO

CREATE PROCEDURE Procedure_EliminarPuntoMinuta

       @min_id [int]

AS 
BEGIN
   DELETE FROM PUNTO
	   	WHERE MINUTA_min_id = @min_id
 
END
GO

-------------------- Procedimiento Eliminar Acuerdo
CREATE PROCEDURE Procedure_EliminarAcuerdo

       @acu_id [int]
AS
BEGIN
   DELETE FROM ACUERDO
          WHERE acu_id = @acu_id
END
GO

CREATE PROCEDURE Procedure_EliminarAcuerdoMinuta

       @min_id [int]
AS
BEGIN
   DELETE FROM ACUERDO
          WHERE MINUTA_min_id = @min_id
END
GO

---------------- Procedimiento para Eliminar un Responsable Usuario de una Minuta
CREATE PROCEDURE Procedure_EliminarUsuarioAcuerdo

     @acu_id [int],
	 @usu_id [int],
	 @pro_id [varchar](6)

AS
BEGIN
   DELETE FROM ACU_INV 
   WHERE ACUERDO_acu_id = @acu_id and INVOLUCRADOS_USUARIOS_USUARIO_usu_id = @usu_id
   and INVOLUCRADOS_USUARIOS_PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @pro_id)
END
GO

---------------- Procedimiento para Eliminar un Responsable Contacto de una Minuta
CREATE PROCEDURE Procedure_EliminarContactoAcuerdo

     @acu_id [int],
	 @con_id [int],
	 @pro_id [varchar](6)

AS
BEGIN
   DELETE FROM ACU_INV 
   WHERE ACUERDO_acu_id = @acu_id and INVOLUCRADOS_CLIENTES_CONTACTO_con_id = @con_id
   and INVOLUCRADOS_CLIENTES_PROYECTO_pro_id = (SELECT pro_id FROM PROYECTO WHERE pro_codigo= @pro_id)
END
GO

CREATE PROCEDURE Procedure_EliminarTodosInvolucrados

     @min_id [int]

AS
BEGIN
   DELETE FROM MIN_INV 
   WHERE MINUTA_min_id =  @min_id
END
GO

--------------- Procedimiento para Eliminar una minuta 
CREATE PROCEDURE Procedure_EliminarMinuta

     @min_id [int]

AS
BEGIN
   DELETE FROM MINUTA 
   WHERE min_id =  @min_id
END
GO
--------------- Procedimiento para buscar la ultima una minuta 
CREATE PROCEDURE Procedure_BuscarUltimaMinuta
AS
BEGIN
   SELECT MAX(min_id)AS min_id FROM MINUTA
END
GO

--End SP8




--Begin Inserts 7


insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Gerente');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Desarrollador');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Diseñador');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Lider de Proyecto');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Arquitecto de Solucion');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Arquitecto de Base de Datos');



insert into usuario  values (NEXT VALUE FOR secuenciaIdUsuario,'albertods','96-FF-4D-0A-31-9B-D3-BF-0D-E9-AE-A3-44-5C-A2-2F-C8-73-AD-7E-5C-4A-39-BD-E5-DE-40-F7-BA-26-CB-03','Albeto','Da Silva','Administrador','alberto21ds@gmail.com','como se llama mi perro','fifi',(Select car_id from Cargo where car_nombre='Gerente'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'argenis12','B4-81-04-AA-D4-2A-FB-1D-54-80-C3-A8-7B-F7-F2-A0-87-95-CD-B0-0C-4B-54-01-D2-14-77-CA-FC-DC-5D-5C','Argenis','Rodriguez','Administrador','rodarge32@gmail.com','como se llama mi gato','miau',(Select car_id from Cargo where car_nombre='Desarrollador'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'scherylu12','BF-14-DE-68-79-22-23-A5-F8-CD-1D-3A-14-72-96-18-66-3B-3A-20-36-C9-77-FD-AA-D8-A2-A1-A6-E2-AD-74','Scheryl','Palencia','Usuario','scheryluci@gmail.com','mi isla favorita','ibiza',(Select car_id from Cargo where car_nombre='Diseñador'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'carlo125','A1-49-AC-9D-0D-36-BB-02-AD-E1-46-3E-DB-27-7B-F1-38-34-A5-3A-17-BD-7F-82-53-60-91-80-A8-49-24-4A','Carlo','Unda','Usuario','carlos651@gmail.com','como se llama mi tio mayor','juan',(Select car_id from Cargo where car_nombre='Lider de Proyecto'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'santiagop85','AA-C4-CA-81-9C-8A-DD-BD-73-FC-19-17-35-A5-D8-32-4A-A3-4C-35-F4-D8-DF-D8-F2-6D-B2-3E-E6-B0-0A-68','Santiago','Bernal','Usuario','santiagobernal93@gmail.com','cual es mi carro favorito','chevette',(Select car_id from Cargo where car_nombre='Arquitecto de Solucion'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'Maria78la','44-9C-4A-F6-47-56-A6-0E-89-71-D8-CF-D5-71-1D-F6-4A-15-C8-F6-6F-E5-0F-EB-0E-8D-78-E7-E7-89-FE-79','Maria','Vargas','Usuario','mariavargas@gmail.com','como se llama mi perro','dogui',(Select car_id from Cargo where car_nombre='Arquitecto de Solucion'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'Roger1245','1B-4C-4E-12-27-72-6A-21-51-A5-59-2B-B1-5A-BB-A5-67-66-E6-5B-4D-CC-57-46-92-C7-5B-94-B5-F6-66-F9','Roger','Perez','Usuario','rogerperez123@gmail.com','como se llama mi papa','pedro',(Select car_id from Cargo where car_nombre='Arquitecto de Base de Datos'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'Juanfe1422','AA-88-6A-08-BA-65-4D-10-7E-20-40-D7-CB-A5-42-DD-DF-D8-29-3C-26-AF-5E-AC-5D-BC-D6-EB-32-94-28-20','Juan','Fuentes','Usuario','juanfuentes12@gmail.com','cual es mi bebida alcoholica favorita','anis',(Select car_id from Cargo where car_nombre='Gerente'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'eduardo785','8E-CC-8E-D8-D2-E7-54-73-FC-11-96-65-F7-D4-3D-90-E2-C4-F0-66-13-B0-1E-D6-B4-78-E8-08-4F-7F-B3-A2','Eduardo','Palacios','Usuario','eduardo852@gmail.com','cual es mi color favorito','rosado',(Select car_id from Cargo where car_nombre='Desarrollador'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'johan7850','7E-B5-D3-48-1F-5C-C9-4C-C0-A6-B8-7F-23-96-0B-35-47-B0-01-2D-31-F7-C1-D0-D4-82-E9-8C-EF-99-46-E8','Johan','plascensia','Usuario','Johaplas123@gmail.com','cual es mi clave de wifi','nosepreguntaleaotro',(Select car_id from Cargo where car_nombre='Arquitecto de Base de Datos'));

--END Inserts 7

--Begin Inserts 2


/*---------------------------------------LUGAR-----------------------------------------*/
exec dbo.M2_InsertarPaises;
go
INSERT INTO LUGAR VALUES('Distrito Capital','Estado',null, (select lug_id from LUGAR where lug_nombre = 'Venezuela'));
go
INSERT INTO LUGAR VALUES('Miranda','Estado',null,(select lug_id from LUGAR where lug_nombre = 'Venezuela'));
go
INSERT INTO LUGAR VALUES('Caracas','Ciudad',1020,(select lug_id from LUGAR where lug_nombre = 'Distrito Capital'));
go
INSERT INTO LUGAR VALUES('Los Teques','Ciudad',1011,(select lug_id from LUGAR where lug_nombre = 'Miranda'));
go
INSERT INTO LUGAR VALUES('Guarenas','Ciudad',1015,(select lug_id from LUGAR where lug_nombre = 'Miranda'));
go
INSERT INTO LUGAR VALUES('Parroquia Caricuao UD 3, Bloque 6, piso 1, apt 01','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Caracas'));
go
INSERT INTO LUGAR VALUES('Parroquia San Juan, Bloque 16, piso 4, apt 04','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Caracas'));
go
INSERT INTO LUGAR VALUES('Parroquia Altagracia, Edif 3, piso 8, apt 07','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Guarenas'));
go
INSERT INTO LUGAR VALUES('Parroquia Candelaria, edif 8, piso 15, apt 05','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Caracas'));
go
INSERT INTO LUGAR VALUES('Parroquia San pedro, residencia Virgen María, Casa # 3','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Caracas'));
go
INSERT INTO LUGAR VALUES('Zona industrial de Cloris Urb. Terrazas del Este, Primera Etapa, edif 20, apt 3-2','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Los Teques'));
go
INSERT INTO LUGAR VALUES('Parroquia Caricuao, Calle A, Local Q, Coche','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Caracas'));
go
INSERT INTO LUGAR VALUES('Parroquia San Juan, Calle C, Local 34, Santa Rosa de Lima','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Caracas'));
go
INSERT INTO LUGAR VALUES('Parroquia Altagracia, Calle Guaicaipuro, Local 76, Bello Monte','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Guarenas'));
go
INSERT INTO LUGAR VALUES('Parroquia Candelaria, De Tablitas A Sordo, Parcelas 2-5, Los Ruices','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Caracas'));
go
INSERT INTO LUGAR VALUES('Parroquia San Pedro, Avenida Principal de Lomas de Prados del Este, Indialca, Alto Prado','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Caracas'));
go
INSERT INTO LUGAR VALUES('Florida','Estado',null,(select lug_id from LUGAR where lug_nombre = 'Estados Unidos'));
go
INSERT INTO LUGAR VALUES('Georgia','Estado',null,(select lug_id from LUGAR where lug_nombre = 'Estados Unidos'));
go
INSERT INTO LUGAR VALUES('Jacksonville','Ciudad',29320,(select lug_id from LUGAR where lug_nombre = 'Florida'));
go
INSERT INTO LUGAR VALUES('Miami','Ciudad',83921,(select lug_id from LUGAR where lug_nombre = 'Florida'));
go
INSERT INTO LUGAR VALUES('Atlanta','Ciudad',82193,(select lug_id from LUGAR where lug_nombre = 'Georgia' and lug_tipo = 'Estado'));
go
INSERT INTO LUGAR VALUES('Eastport Apartments, The 11701 Palm Lake Drive Jacksonville, FL 32218-3985','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Jacksonville'));
go
INSERT INTO LUGAR VALUES('La Esperanza 3800 University Blvd S Jacksonville, FL 32216-4328','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Jacksonville'));
go
INSERT INTO LUGAR VALUES('1231 PENNSYLVANIA AV 10','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Miami'));
go
INSERT INTO LUGAR VALUES('1250 WEST AV 10D','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Miami'));
go
INSERT INTO LUGAR VALUES('415 Fairburn Rd SW Atlanta, GA 30331-1996','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Atlanta'));
go
INSERT INTO LUGAR VALUES('1800 Windridge Dr Sandy Springs, GA 30350-2873','Direccion',null,(select lug_id from LUGAR where lug_nombre = 'Atlanta'));
go

/*---------------------------------------CLIENTE_JURIDICO-----------------------------------------*/
INSERT INTO CLIENTE_JURIDICO VALUES ('J-11111111-1','Locatel',null,(select lug_id from LUGAR where lug_nombre = 'Parroquia Caricuao UD 3, Bloque 6, piso 1, apt 01'));
go
INSERT INTO CLIENTE_JURIDICO VALUES ('J-22222222-2','Swatch',null,(select lug_id from LUGAR where lug_nombre = 'Parroquia San Juan, Bloque 16, piso 4, apt 04'));
go
INSERT INTO CLIENTE_JURIDICO VALUES ('J-33333333-3','Tealca',null,(select lug_id from LUGAR where lug_nombre = 'Parroquia Altagracia, Edif 3, piso 8, apt 07'));
go
INSERT INTO CLIENTE_JURIDICO VALUES ('J-44444444-4','PaperMate',null,(select lug_id from LUGAR where lug_nombre = 'Parroquia Candelaria, edif 8, piso 15, apt 05'));
go
INSERT INTO CLIENTE_JURIDICO VALUES ('J-55555555-5','Vernet',null,(select lug_id from LUGAR where lug_nombre = 'Parroquia San pedro, residencia Virgen María, Casa # 3'));
go


/*---------------------------------------CLIENTE_NATURAL-----------------------------------------*/
INSERT INTO CLIENTE_NATURAL VALUES(11111111,'Valentina','Scioli','valensciove@hotmail.com',(select lug_id from LUGAR where lug_nombre = 'Zona industrial de Cloris Urb. Terrazas del Este, Primera Etapa, edif 20, apt 3-2'));
go
INSERT INTO CLIENTE_NATURAL VALUES(22222222,'Guillermo','Gonzalez','guillegonzale@gmail.com',(select lug_id from LUGAR where lug_nombre = 'Parroquia Caricuao, Calle A, Local Q, Coche'));
go
INSERT INTO CLIENTE_NATURAL VALUES(33333333,'Francisco','Torres','franctorre@hotmail.com',(select lug_id from LUGAR where lug_nombre = 'Parroquia San Juan, Calle C, Local 34, Santa Rosa de Lima'));
go
INSERT INTO CLIENTE_NATURAL VALUES(44444444,'Pedro','De Jesus','pedrdejesus@gmail.com',(select lug_id from LUGAR where lug_nombre = 'Parroquia Altagracia, Calle Guaicaipuro, Local 76, Bello Monte'));
go
INSERT INTO CLIENTE_NATURAL VALUES(55555555,'Jessica','De Torres','jesidetorres@gmail.com',(select lug_id from LUGAR where lug_nombre = 'Parroquia Candelaria, De Tablitas A Sordo, Parcelas 2-5, Los Ruices'));
go

/*---------------------------------------CARGO-----------------------------------------*/
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Gerente General');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Administrador');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Secretaria');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Gerente de finanzas');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Recursos Humanos');
/*--------------------CONTACTO CLIENTE_JURIDICO------------------------*/
INSERT INTO CONTACTO VALUES(66666666,'Reinaldo','Cortes',1,1,null);
go
INSERT INTO CONTACTO VALUES(77777777,'Mercedes','Amilibia',2,2,null);
go
INSERT INTO CONTACTO VALUES(88888888,'Amaranta','Ruiz',3,3,null);
go
INSERT INTO CONTACTO VALUES(99999999,'Sebastian','Perez',4,4,null);
go
INSERT INTO CONTACTO VALUES(10101011,'Felipe','Mendes',5,5,null);
go

/*--------------------CONTACTO CLIENTE_NATURAL------------------------*/
INSERT INTO CONTACTO VALUES(11111111,'Valentina','Scioli',null,null,1);
go
INSERT INTO CONTACTO VALUES(22222222,'Guillermo','Gonzalez',null,null,2);
go
INSERT INTO CONTACTO VALUES(33333333,'Francisco','Torres',null,null,3);
go
INSERT INTO CONTACTO VALUES(44444444,'Pedro','De Jesus',null,null,4);
go
INSERT INTO CONTACTO VALUES(55555555,'Jessica','De Torres',null,null,5);
go


/*---------------------------------------TELEFONO-----------------------------------------*/
INSERT INTO TELEFONO VALUES('212','1111111',1,null);
go
INSERT INTO TELEFONO VALUES('223','2222222',2,null);
go
INSERT INTO TELEFONO VALUES('424','3333333',3,null);
go
INSERT INTO TELEFONO VALUES('212','4444444',4,null);
go
INSERT INTO TELEFONO VALUES('416','5555555',5,null);
go
INSERT INTO TELEFONO VALUES('412','6666666',null,1);
go
INSERT INTO TELEFONO VALUES('212','7777777',null,2);
go
INSERT INTO TELEFONO VALUES('412','8888888',null,3);
go
INSERT INTO TELEFONO VALUES('212','9999999',null,4);
go
INSERT INTO TELEFONO VALUES('212','5111110',null,5);

--END Inserts 2

--Begin Inserts 4


/*-----------------------------------PROYECTO---------------------------------------------------------*/

INSERT INTO dbo.PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_JURIDICO_cj_id) VALUES ('TOT','TOTEM',1,'Sistema de gestion de proyectos.',1000000,'BsF',1);

INSERT INTO dbo.PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_NATURAL_cn_id) VALUES ('FB','Facebook',1,'Un sitio web de redes sociales creado por Mark Zuckerberg 
y fundado junto a Eduardo Saverin, Chris Hughes y Dustin Moskovitz.',199999999,'$',1);

INSERT INTO dbo.PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_JURIDICO_cj_id) VALUES ('TW','Twitter',1,'La red permite enviar mensajes de texto plano de corta longitud,
 con un máximo de 140 caracteres, llamados tweets, que se muestran en la página principal del usuario. 
 Los usuarios pueden suscribirse a los tweets de otros usuarios.',159999999,'$',2);

 
--END Inserts 4 

--Begin Inserts 3
INSERT INTO [dbo].[INVOLUCRADOS_USUARIOS] ([USUARIO_usu_id], [PROYECTO_pro_id]) VALUES (1, 1)
INSERT INTO [dbo].[INVOLUCRADOS_USUARIOS] ([USUARIO_usu_id], [PROYECTO_pro_id]) VALUES (2, 1)
INSERT INTO [dbo].[INVOLUCRADOS_USUARIOS] ([USUARIO_usu_id], [PROYECTO_pro_id]) VALUES (3, 1)
INSERT INTO [dbo].[INVOLUCRADOS_USUARIOS] ([USUARIO_usu_id], [PROYECTO_pro_id]) VALUES (9, 1)
INSERT INTO [dbo].[INVOLUCRADOS_CLIENTES] ([CONTACTO_con_id], [PROYECTO_pro_id]) VALUES (1, 1)
INSERT INTO [dbo].[INVOLUCRADOS_CLIENTES] ([CONTACTO_con_id], [PROYECTO_pro_id]) VALUES (2, 1)
INSERT INTO [dbo].[INVOLUCRADOS_CLIENTES] ([CONTACTO_con_id], [PROYECTO_pro_id]) VALUES (3, 1)

--END Inserts 3 
--Begin Inserts 5


INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'TOT_RF_1','Descripcion Requerimiento Funcional 1 Totem','funcional','alta','finalizado',1);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'TOT_RF_2','Descripcion Requerimiento Funcional 2 Totem','funcional','Media','no finalizado',1);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'TOT_RF_3','Descripcion Requerimiento Funcional 3 Totem','funcional','baja','no finalizado',1);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'TOT_RNF_1','Descripcion Requerimiento No Funcional 1 Totem','no funcional','alta','no finalizado',1);


INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'FB_RF_1','Descripcion Requerimiento Funcional 1 Facebook','funcional','alta','finalizado',2);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'FB_RF_2','Descripcion Requerimiento Funcional 2 Facebook','funcional','Media','no finalizado',2);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'FB_RF_3','Descripcion Requerimiento Funcional 3 Facebook','funcional','baja','no finalizado',2);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'FB_RNF_1','Descripcion Requerimiento No Funcional 1 Facebook','no funcional','alta','no finalizado',2);


INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'TW_RF_1','Descripcion Requerimiento Funcional 1 Twitter','funcional','alta','finalizado',3);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'TW_RF_2','Descripcion Requerimiento Funcional 2 Twitter','funcional','medio','no finalizado',3);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'TW_RF_3','Descripcion Requerimiento Funcional 3 Twitter','funcional','baja','no finalizado',3);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(NEXT VALUE FOR secuenciaRequerimiento,'TW_RNF_1','Descripcion Requerimiento No Funcional 1 Twitter','no funcional','alta','no finalizado',3);


--END Inserts 5
--Begin Inserts 6

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('TOT-CU','Agregar Actor','Actor Creado','Actor no Creado','Menu principal -> Crear Actor',1);

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('TOT-CU','Leer Actor','Actor Leido','Actor no Leido','Menu principal -> Leer Actor',1);

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('TOT-CU','Modificar Actor','Actor Modificado','Actor no Modificado','Menu principal -> Modificar Actor',1);

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('TOT-CU','Eliminar Actor','Actor Eliminiado','Actor no Eliminado','Menu principal -> Eliminar Actor',1);

INSERT INTO ACTOR (act_nombre,act_descripcion,PROYECTO_pro_id) VALUES ('Administrador','El que mantiene la pagina',1);
INSERT INTO PRECONDICION VALUES (1,'Actor Creado',2);
INSERT INTO PASO VALUES (1,'A.','El administrador selecciona Leer Actor',2);
INSERT INTO EXTENSION VALUES (1,'El Administrador Selecciona Cancelar',1,2);
INSERT INTO PASO_EXTENSION VALUES (1,'Fin del Caso de Uso',1,1,2);

INSERT INTO CU_ACTOR VALUES (2,1);
INSERT INTO CU_REQUERIMIENTO VALUES (1,1);
INSERT INTO CU_REQUERIMIENTO VALUES (2,2);
INSERT INTO CU_REQUERIMIENTO VALUES (3,3);
INSERT INTO CU_REQUERIMIENTO VALUES (4,4);


INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('FB-CU','Crear Usuario','Usuario Creado','Usuario no Creado','Menu principal -> Crear Actor',2);

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('FB-CU','Leer Usuario','Usuario Leido','Usuario no Leido','Menu principal -> Leer Actor',2);

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('FB-CU','Modificar Usuario','Usuario Modificado','Usuario no Modificado','Menu principal -> Modificar Actor',2);

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('FB-CU','Eliminar Usuario','Usuario Eliminado','Usuario no eliminado','Menu principal -> Eliminar Actor',2);

INSERT INTO ACTOR (act_nombre,act_descripcion,PROYECTO_pro_id) VALUES ('Usuario','El que usa la aplicacion',2);
INSERT INTO PRECONDICION VALUES (1,'Usuario Creado',6);
INSERT INTO PASO VALUES (1,'A.','El administrador selecciona Leer Usuario',6);
INSERT INTO EXTENSION VALUES (1,'El Administrador Selecciona Cancelar',1,6);
INSERT INTO PASO_EXTENSION VALUES (1,'Fin del Caso de Uso',1,1,6);

INSERT INTO CU_ACTOR VALUES (6,2);
INSERT INTO CU_REQUERIMIENTO VALUES (5,5);
INSERT INTO CU_REQUERIMIENTO VALUES (6,6);
INSERT INTO CU_REQUERIMIENTO VALUES (7,7);
INSERT INTO CU_REQUERIMIENTO VALUES (8,8);


INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('TW-CU','Crear Tweet','Tweet Creado','Tweet no Creado','Menu principal -> Crear Tweet',3);

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('TW-CU','Leer Tweet','Tweet Leido','Tweet no Leido','Menu principal -> Leer Tweet',3);

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('TW-CU','Modificar Tweet','Tweet Modificado','Tweet no Modificado','Menu principal -> Modificar Tweet',3);

INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('TW-CU','Eliminar Tweet','Tweet Eliminado','Tweet no Eliminado','Menu principal -> Eliminar Tweet',3);

INSERT INTO ACTOR (act_nombre,act_descripcion,PROYECTO_pro_id) VALUES ('Administrador','El que revisa los tweets que se pueden',3);
INSERT INTO PRECONDICION VALUES (1,'Tweet Creado',10);
INSERT INTO PASO VALUES (1,'A.','El administrador selecciona Leer Tweet',10);
INSERT INTO EXTENSION VALUES (1,'El Administrador Selecciona Cancelar',1,10);
INSERT INTO PASO_EXTENSION VALUES (1,'Fin del Caso de Uso',1,1,10);

INSERT INTO CU_ACTOR VALUES (10,3);
INSERT INTO CU_REQUERIMIENTO VALUES (9,9);
INSERT INTO CU_REQUERIMIENTO VALUES (10,10);
INSERT INTO CU_REQUERIMIENTO VALUES (11,11);
INSERT INTO CU_REQUERIMIENTO VALUES (12,12);

--END Inserts  6
--Begin Inserts 8
/* ****************************  INSERTS  *************************************************** */

/* Minutas---------------------------------------------------------------------------------------------------------*/

INSERT INTO dbo.MINUTA(min_fecha, min_motivo, min_observaciones) VALUES ('20150425 18:00','Requerimientos',null);
INSERT INTO dbo.MINUTA(min_fecha, min_motivo, min_observaciones) VALUES ('20150428 07:45','Alcance',null);
INSERT INTO dbo.MINUTA(min_fecha, min_motivo, min_observaciones) VALUES ('20150502 19:47','Recursos a Utilizar','Los Recursos pueden variar');


/* Puntos----------------------------------------------------------------------------------------------------------*/
INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Levantamiento de Requerimientos','Se acordó las entrevistas que se realizarán al cliente.',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Requerimientos'));
INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Historias de Usuario','Se acordó el formato a utilizar para las Historias de Usuario.',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Requerimientos'));
INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Próxima Reunión','',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Requerimientos'));

INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Posibles Soluciones','Se conluyó que la Mejor Solución era una Aplicación Web ',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Alcance'));
INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Riesgos','Se redacto un documento enumerando los Riesgos',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Alcance'));
INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Limitaciones','Se redacto un documento con todas las limitantes',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Alcance'));
INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Alcance','Se redacto un documento con el alcance bien definido',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Alcance'));
INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Próxima Reunión','Se pauto la fecha de la próxima reunión',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Alcance'));


INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Framework','Se acordó que se utilizará .NET',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Recursos a Utilizar'));
INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('IDE','Se acordó que se utilizará Visual Studio 2012',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Recursos a Utilizar'));
INSERT INTO dbo.PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id) VALUES ('Próxima Reunión','Se acordó que la fecha de la próxima reunión se realizará el Viernes 15 de Mayo y tratará sobre la Arquitectura del Sistema',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Recursos a Utilizar'));

/* Acuerdos -------------------------------------------------------------------------------------------------------*/
INSERT INTO dbo.ACUERDO(acu_fecha, acu_desarrollo, MINUTA_min_id) VALUES ('20150426','Entrevista al Gerente',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Requerimientos'));
INSERT INTO dbo.ACUERDO(acu_fecha, acu_desarrollo, MINUTA_min_id) VALUES ('20150426','Encuesta al Personal Operativo',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Requerimientos'));
INSERT INTO dbo.ACUERDO(acu_fecha, acu_desarrollo, MINUTA_min_id) VALUES ('20150427','Entrevista al Director de RRHH',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Requerimientos'));

INSERT INTO dbo.ACUERDO(acu_fecha, acu_desarrollo, MINUTA_min_id) VALUES ('20150429','Redactar Documento de Visión',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Alcance'));

INSERT INTO dbo.ACUERDO(acu_fecha, acu_desarrollo, MINUTA_min_id) VALUES ('20150503','Links de Descarga de los Recursos',(SELECT min_id FROM MINUTA WHERE min_motivo = 'Recursos a Utilizar'));

/*-------------------Inserts de Involucrados en Minuta------------------------*/

INSERT INTO ACU_INV (ACUERDO_acu_id,INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id) VALUES (1,1,1);
INSERT INTO ACU_INV (ACUERDO_acu_id,INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id) VALUES (1,2,1);

INSERT INTO ACU_INV (ACUERDO_acu_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id, INVOLUCRADOS_CLIENTES_PROYECTO_pro_id) VALUES (1,1,1);
INSERT INTO ACU_INV (ACUERDO_acu_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id, INVOLUCRADOS_CLIENTES_PROYECTO_pro_id) VALUES (1,2,1);

INSERT INTO MIN_INV (MINUTA_min_id, INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id) VALUES (1,1,1);
INSERT INTO MIN_INV (MINUTA_min_id, INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id) VALUES (1,2,1);

INSERT INTO MIN_INV (MINUTA_min_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id, INVOLUCRADOS_CLIENTES_PROYECTO_pro_id) VALUES (1,1,1);
INSERT INTO MIN_INV (MINUTA_min_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id, INVOLUCRADOS_CLIENTES_PROYECTO_pro_id) VALUES (1,2,1);

--END Inserts  8