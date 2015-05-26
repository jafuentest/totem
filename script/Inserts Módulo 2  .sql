

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

