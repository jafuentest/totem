﻿INSERT INTO CASO_USO (cu_identificador,cu_titulo,cu_condexito,cu_condfallo,cu_disparador, PROYECTO_pro_id) VALUES ('TOT-CU','Agregar Actor','Actor Creado','Actor no Creado','Menu principal -> Crear Actor',1);

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
