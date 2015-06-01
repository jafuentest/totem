
/*-----------------------------------------------------------Modulo 7------------------------------------------------------------------------*/
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Gerente');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Desarrollador');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Diseñador');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Lider de Proyecto');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Arquitecto de Solucion');
insert into Cargo (car_id,car_nombre) values (NEXT VALUE FOR secuenciaIdCargo,'Arquitecto de Base de Datos');



insert into usuario  values (NEXT VALUE FOR secuenciaIdUsuario,'albertods','5563albert','Albeto','Da Silva','Administrador','alberto21ds@gmail.com','como se llama mi perro','fifi',(Select car_id from Cargo where car_nombre='Gerente'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'argenis12','123546hola','Argenis','Rodriguez','Administrador','rodarge32@gmail.com','como se llama mi gato','miau',(Select car_id from Cargo where car_nombre='Desarrollador'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'scherylu12','gilopo145','Scheryl','Palencia','Usuario','scheryluci@gmail.com','mi isla favorita','ibiza',(Select car_id from Cargo where car_nombre='Diseñador'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'carlo125','carlo1990','Carlo','Unda','Usuario','carlos651@gmail.com','como se llama mi tio mayor','juan',(Select car_id from Cargo where car_nombre='Lider de Proyecto'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'santiagop85','santi1890a','Santiago','Bernal','Usuario','santiagobernal93@gmail.com','cual es mi carro favorito','chevette',(Select car_id from Cargo where car_nombre='Arquitecto de Solucion'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'Maria78la','4212mar','Maria','Vargas','Usuario','mariavargas@gmail.com','como se llama mi perro','dogui',(Select car_id from Cargo where car_nombre='Arquitecto de Solucion'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'Roger1245','roger47824','Roger','Perez','Usuario','rogerperez123@gmail.com','como se llama mi papa','pedro',(Select car_id from Cargo where car_nombre='Arquitecto de Base de Datos'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'Juanfe1422','juan78009!!','Juan','Fuentes','Usuario','juanfuentes12@gmail.com','cual es mi bebida alcoholica favorita','anis',(Select car_id from Cargo where car_nombre='Gerente'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'eduardo785','edu7582?1','Eduardo','Palacios','Usuario','eduardo852@gmail.com','cual es mi color favorito','rosado',(Select car_id from Cargo where car_nombre='Desarrollador'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'johan7850','!!?hola8541','Johan','plascensia','Usuario','Johaplas123@gmail.com','cual es mi clave de wifi','nosepreguntaleaotro',(Select car_id from Cargo where car_nombre='Arquitecto de Base de Datos'));

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

/*-----------------------------------------------------------------Modulo 2----------------------------------------------------------------*/



/*---------------------------------------LUGAR-----------------------------------------*/
INSERT INTO LUGAR VALUES(1,'Venezuela','País',null,null);
go
INSERT INTO LUGAR VALUES(2,'Dtto Capital','Estado',null,1);
go
INSERT INTO LUGAR VALUES(3,'Mirada','Estado',null,2);
go
INSERT INTO LUGAR VALUES(4,'Caracas','Ciudad',1020,2);
go
INSERT INTO LUGAR VALUES(5,'Los Teques','Ciudad',1011,3);
go
INSERT INTO LUGAR VALUES(6,'Guarenas','Ciudad',1015,3);
go
INSERT INTO LUGAR VALUES(7,'Parroquia Caricuao UD 3, Bloque 6, piso 1, apt 01','Direccion',null,4);
go
INSERT INTO LUGAR VALUES(8,'Parroquia San Juan, Bloque 16, piso 4, apt 04','Direccion',null,4);
go
INSERT INTO LUGAR VALUES(9,'Parroquia Altagracia, Edif 3, piso 8, apt 07','Direccion',null,4);
go
INSERT INTO LUGAR VALUES(10,'Parroquia Candelaria, edif 8, piso 15, apt 05','Direccion',null,4);
go
INSERT INTO LUGAR VALUES(11,'Parroquia San pedro, residencia Virgen María, Casa # 3','Direccion',null,5);
go
INSERT INTO LUGAR VALUES(12,'Zona industrial de Cloris Urb. Terrazas del Este, Primera Etapa, edif 20, apt 3-2','Direccion',null,6);
go
INSERT INTO LUGAR VALUES(13,'Parroquia Caricuao, Calle A, Local Q, Coche','Direccion',null,4);
go
INSERT INTO LUGAR VALUES(14,'Parroquia San Juan, Calle C, Local 34, Santa Rosa de Lima','Direccion',null,4);
go
INSERT INTO LUGAR VALUES(15,'Parroquia Altagracia, Calle Guaicaipuro, Local 76, Bello Monte','Direccion',null,4);
go
INSERT INTO LUGAR VALUES(16,'Parroquia Candelaria, De Tablitas A Sordo, Parcelas 2-5, Los Ruices','Direccion',null,4);
go
INSERT INTO LUGAR VALUES(17,'Parroquia San Pedro, Avenida Principal de Lomas de Prados del Este, Indialca, Alto Prado','Direccion',null,5);
go
INSERT INTO LUGAR VALUES(18,'Estados Unidos','País',null,NULL);
go
INSERT INTO LUGAR VALUES(19,'Florida','Estado',null,18);
go
INSERT INTO LUGAR VALUES(20,'Georgia','Estado',null,18);
go
INSERT INTO LUGAR VALUES(21,'Jacksonville','Ciudad',29320,19);
go
INSERT INTO LUGAR VALUES(22,'Miami','Ciudad',83921,19);
go
INSERT INTO LUGAR VALUES(23,'Atlanta','Ciudad',82193,20);
go
INSERT INTO LUGAR VALUES(24,'Eastport Apartments, The 11701 Palm Lake Drive Jacksonville, FL 32218-3985','Direccion',null,21);
go
INSERT INTO LUGAR VALUES(25,'La Esperanza 3800 University Blvd S Jacksonville, FL 32216-4328','Direccion',null,21);
go
INSERT INTO LUGAR VALUES(26,'1231 PENNSYLVANIA AV 10','Direccion',null,22);
go
INSERT INTO LUGAR VALUES(27,'1250 WEST AV 10D','Direccion',null,22);
go
INSERT INTO LUGAR VALUES(28,'415 Fairburn Rd SW Atlanta, GA 30331-1996','Direccion',null,23);
go
INSERT INTO LUGAR VALUES(29,'1800 Windridge Dr Sandy Springs, GA 30350-2873','Direccion',null,23);
go

/*---------------------------------------CLIENTE_JURIDICO-----------------------------------------*/
INSERT INTO CLIENTE_JURIDICO VALUES (1,'J-11111111-1','Locatel',null,15);
go
INSERT INTO CLIENTE_JURIDICO VALUES (2,'J-22222222-2','Swatch',null,24);
go
INSERT INTO CLIENTE_JURIDICO VALUES (3,'J-33333333-3','Tealca',null,25);
go
INSERT INTO CLIENTE_JURIDICO VALUES (4,'J-44444444-4','PaperMate',null,26);
go
INSERT INTO CLIENTE_JURIDICO VALUES (5,'J-55555555-5','Vernet',null,28);
go


/*---------------------------------------CLIENTE_NATURAL-----------------------------------------*/
INSERT INTO CLIENTE_NATURAL VALUES(1,11111111,'Valentina','Scioli','valensciove@hotmail.com',16);
go
INSERT INTO CLIENTE_NATURAL VALUES(2,22222222,'Guillermo','Gonzalez','guillegonzale@gmail.com',17);
go
INSERT INTO CLIENTE_NATURAL VALUES(3,33333333,'Francisco','Torres','franctorre@hotmail.com',13);
go
INSERT INTO CLIENTE_NATURAL VALUES(4,44444444,'Pedro','De Jesus','pedrdejesus@gmail.com',25);
go
INSERT INTO CLIENTE_NATURAL VALUES(5,55555555,'Jessica','De Torres','jesidetorres@gmail.com',26);
go


/*---------------------------------------CONTACTO-----------------------------------------*/
/*--------------------CONTACTO CLIENTE_JURIDICO------------------------*/
INSERT INTO CONTACTO VALUES(1,66666666,'Reinaldo','Cortes',1,1,null);
go
INSERT INTO CONTACTO VALUES(2,77777777,'Mercedes','Amilibia',2,2,null);
go
INSERT INTO CONTACTO VALUES(3,88888888,'Amaranta','Ruiz',3,3,null);
go
INSERT INTO CONTACTO VALUES(4,99999999,'Sebastian','Perez',4,4,null);
go
INSERT INTO CONTACTO VALUES(5,10101011,'Felipe','Mendes',5,5,null);
go

/*--------------------CONTACTO CLIENTE_NATURAL------------------------*/
INSERT INTO CONTACTO VALUES(6,11111111,'Valentina','Scioli',null,null,1);
go
INSERT INTO CONTACTO VALUES(7,22222222,'Guillermo','Gonzalez',null,null,2);
go
INSERT INTO CONTACTO VALUES(8,33333333,'Francisco','Torres',null,null,3);
go
INSERT INTO CONTACTO VALUES(9,44444444,'Pedro','De Jesus',null,null,4);
go
INSERT INTO CONTACTO VALUES(10,55555555,'Jessica','De Torres',null,null,5);
go


/*---------------------------------------TELEFONO-----------------------------------------*/
INSERT INTO TELEFONO VALUES(1,212,1111111,1,null);
go
INSERT INTO TELEFONO VALUES(2,223,2222222,2,null);
go
INSERT INTO TELEFONO VALUES(3,424,3333333,3,null);
go
INSERT INTO TELEFONO VALUES(4,212,4444444,4,null);
go
INSERT INTO TELEFONO VALUES(5,416,5555555,5,null);
go
INSERT INTO TELEFONO VALUES(6,412,6666666,null,1);
go
INSERT INTO TELEFONO VALUES(7,212,7777777,null,2);
go
INSERT INTO TELEFONO VALUES(8,412,8888888,null,3);
go
INSERT INTO TELEFONO VALUES(9,212,9999999,null,4);
go
INSERT INTO TELEFONO VALUES(10,212,5111110,null,5);

/*---------------------------------------------------Modulo 4-------------------------------------------------------------------------------*/

/*-----------------------------------PROYECTO---------------------------------------------------------*/

INSERT INTO dbo.PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_JURIDICO_cj_id) VALUES ('TOT','TOTEM',1,'Sistema de gestion de proyectos.',1000000,'BsF',1);

INSERT INTO dbo.PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_NATURAL_cn_id) VALUES ('FB','Facebook',1,'Un sitio web de redes sociales creado por Mark Zuckerberg 
y fundado junto a Eduardo Saverin, Chris Hughes y Dustin Moskovitz.',199999999,'$',1);

INSERT INTO dbo.PROYECTO(pro_codigo, pro_nombre, pro_estado,pro_descripcion,pro_costo,pro_moneda,CLIENTE_JURIDICO_cj_id) VALUES ('TW','Twitter',1,'La red permite enviar mensajes de texto plano de corta longitud,
 con un máximo de 140 caracteres, llamados tweets, que se muestran en la página principal del usuario. 
 Los usuarios pueden suscribirse a los tweets de otros usuarios.',159999999,'$',2);

/*--------------------------------------------------Modulo 3------------------------------------------------------------------------------*/

INSERT INTO [dbo].[INVOLUCRADOS_USUARIOS] ([USUARIO_usu_id], [PROYECTO_pro_id]) VALUES (1, 1)
INSERT INTO [dbo].[INVOLUCRADOS_USUARIOS] ([USUARIO_usu_id], [PROYECTO_pro_id]) VALUES (2, 1)
INSERT INTO [dbo].[INVOLUCRADOS_USUARIOS] ([USUARIO_usu_id], [PROYECTO_pro_id]) VALUES (3, 1)
INSERT INTO [dbo].[INVOLUCRADOS_USUARIOS] ([USUARIO_usu_id], [PROYECTO_pro_id]) VALUES (9, 1)
INSERT INTO [dbo].[INVOLUCRADOS_CLIENTES] ([CONTACTO_con_id], [PROYECTO_pro_id]) VALUES (1, 1)
INSERT INTO [dbo].[INVOLUCRADOS_CLIENTES] ([CONTACTO_con_id], [PROYECTO_pro_id]) VALUES (2, 1)
INSERT INTO [dbo].[INVOLUCRADOS_CLIENTES] ([CONTACTO_con_id], [PROYECTO_pro_id]) VALUES (3, 1)


/*----------------------------------------------------------------------------Modulo 5-------------------------------------------------------*/


/*
CREATE
  TABLE REQUERIMIENTO
  (
    req_id          INTEGER NOT NULL ,
    req_codigo    VARCHAR (15) NOT NULL,
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

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(,,,,,,);*/


INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(1,'TOT_RF_1','Descripcion Requerimiento Funcional 1 Totem','Funcional','Alta','Finalizado',1);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(2,'TOT_RF_2','Descripcion Requerimiento Funcional 2 Totem','Funcional','Media','No Finalizado',1);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(3,'TOT_RF_3','Descripcion Requerimiento Funcional 3 Totem','Funcional','Baja','No Finalizado',1);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(4,'TOT_RNF_1','Descripcion Requerimiento No Funcional 1 Totem','No Funcional','Alta','No Finalizado',1);


INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(5,'FB_RF_1','Descripcion Requerimiento Funcional 1 Facebook','Funcional','Alta','Finalizado',2);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(6,'FB_RF_2','Descripcion Requerimiento Funcional 2 Facebook','Funcional','Media','No Finalizado',2);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(7,'FB_RF_3','Descripcion Requerimiento Funcional 3 Facebook','Funcional','Baja','No Finalizado',2);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(8,'FB_RNF_1','Descripcion Requerimiento No Funcional 1 Facebook','No Funcional','Alta','No Finalizado',2);


INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(9,'TW_RF_1','Descripcion Requerimiento Funcional 1 Twitter','Funcional','Alta','Finalizado',3);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(10,'TW_RF_2','Descripcion Requerimiento Funcional 2 Twitter','Funcional','Medio','No Finalizado',3);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(11,'TW_RF_3','Descripcion Requerimiento Funcional 3 Twitter','Funcional','Baja','No Finalizado',3);

INSERT INTO dbo.REQUERIMIENTO(req_id,req_codigo,req_descripcion,req_tipo,req_prioridad,req_estatus,PROYECTO_pro_id) VALUES
(12,'TW_RNF_1','Descripcion Requerimiento No Funcional 1 Twitter','No Funcional','Alta','No Finalizado',3);

/*----------------------------------------Modulo 6-----------------------------------------------------------------------------*/
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

/*-----------------------------------------------------------------Modulo 8------------------------------------------------------------------*/
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

insert into INVOLUCRADOS_CLIENTES values (1,1);
insert into INVOLUCRADOS_CLIENTES values (2,1);
insert into INVOLUCRADOS_CLIENTES values (3,1);

insert into INVOLUCRADOS_USUARIOS values (1,1);
insert into INVOLUCRADOS_USUARIOS values (2,1);
insert into INVOLUCRADOS_USUARIOS values (3,1);

INSERT INTO ACU_INV (ACUERDO_acu_id,INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id) VALUES (1,1,1);
INSERT INTO ACU_INV (ACUERDO_acu_id,INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id) VALUES (1,2,1);

INSERT INTO ACU_INV (ACUERDO_acu_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id, INVOLUCRADOS_CLIENTES_PROYECTO_pro_id) VALUES (1,1,1);
INSERT INTO ACU_INV (ACUERDO_acu_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id, INVOLUCRADOS_CLIENTES_PROYECTO_pro_id) VALUES (1,2,1);

INSERT INTO MIN_INV (MINUTA_min_id, INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id) VALUES (1,1,1);
INSERT INTO MIN_INV (MINUTA_min_id, INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id) VALUES (1,2,1);

INSERT INTO MIN_INV (MINUTA_min_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id, INVOLUCRADOS_CLIENTES_PROYECTO_pro_id) VALUES (1,1,1);
INSERT INTO MIN_INV (MINUTA_min_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id, INVOLUCRADOS_CLIENTES_PROYECTO_pro_id) VALUES (1,2,1);
