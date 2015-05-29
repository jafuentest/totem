
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

