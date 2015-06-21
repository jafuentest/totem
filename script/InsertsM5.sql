-- ========================================================================= --
-- Inserts para el Módulo 5
-- ========================================================================= --

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