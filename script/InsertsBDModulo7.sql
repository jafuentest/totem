

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
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'santiagop85','AA-C4-CA-81-9C-8A-DD-BD-73-FC-19-17-35-A5-D8-32-4A-A3-4C-35-F4-D8-DF-D8-F2-6D-B2-3E-E6-B0-0A-68','Santiago','Bernal','Usuario','santiagobernal93@gmail.com','cual es mi carro favorito','chevette',(Select car_id from Cargo where car_nombre='Arquitecto de Solucion'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'Maria78la','4212mar','Maria','Vargas','Usuario','mariavargas@gmail.com','como se llama mi perro','dogui',(Select car_id from Cargo where car_nombre='Arquitecto de Solucion'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'Roger1245','roger47824','Roger','Perez','Usuario','rogerperez123@gmail.com','como se llama mi papa','pedro',(Select car_id from Cargo where car_nombre='Arquitecto de Base de Datos'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'Juanfe1422','juan78009!!','Juan','Fuentes','Usuario','juanfuentes12@gmail.com','cual es mi bebida alcoholica favorita','anis',(Select car_id from Cargo where car_nombre='Gerente'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'eduardo785','edu7582?1','Eduardo','Palacios','Usuario','eduardo852@gmail.com','cual es mi color favorito','rosado',(Select car_id from Cargo where car_nombre='Desarrollador'));
insert into usuario values (NEXT VALUE FOR secuenciaIdUsuario,'johan7850','!!?hola8541','Johan','plascensia','Usuario','Johaplas123@gmail.com','cual es mi clave de wifi','nosepreguntaleaotro',(Select car_id from Cargo where car_nombre='Arquitecto de Base de Datos'));

