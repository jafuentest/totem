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
