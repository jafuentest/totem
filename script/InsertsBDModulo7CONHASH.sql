

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

