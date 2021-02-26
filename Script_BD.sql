/* Creación de Base de datos */

CREATE DATABASE Inmobiliaria
go
USE Inmobiliaria;
go

/* Creación de Tablas */

CREATE TABLE  tipo_inmueble (tipo char(3) PRIMARY KEY, descripcion Char(20))

CREATE TABLE inmueble (codinmueble integer IDENTITY PRIMARY KEY, tipo char(3), ubicacion varChar(200), fecha Date, importe integer, vendida tinyint DEFAULT 0,
FOREIGN KEY (tipo) REFERENCES tipo_inmueble(tipo))

INSERT INTO tipo_inmueble VALUES ('CAS','Casa'),('PIS','Piso'),('LOC','Local Comercial');
INSERT INTO inmueble VALUES ('CAS','Geneto', '2019-05-14',220000,1),('PIS','San Benito', '2019-02-08',158100,1),
('PIS', 'La Cuesta', '2019-05-06',140000,0),('LOC','Bajamar', '2015-05-06',95000,1);

/* 1º Procedimiento listainmuebles */

go
CREATE PROCEDURE listainmuebles(@tipo Char(3))
as
SELECT inmueble.codinmueble,inmueble.tipo, inmueble.ubicacion,inmueble.fecha,inmueble.importe, inmueble.vendida
FROM inmueble  WHERE inmueble.tipo=@tipo ORDER BY inmueble.fecha
go
/*EXEC listainmuebles 'PIS';
*/

/* 2º Función Numeroinmueblesportipo*/

CREATE FUNCTION Numeroinmueblesportipo(@tipo Char(3)) 
RETURNS int
BEGIN
RETURN (SELECT COUNT(*) FROM inmueble WHERE inmueble.tipo=@tipo);
END
GO
/*SELECT dbo.Numeroinmueblesportipo('PIS');
*/


--------------------------------------------------
/* Creación de Base de datos */

CREATE DATABASE Concesionario
go
USE Concesionario;
go

/* Creación de Tablas */

CREATE TABLE  tipo_vehiculo (tipo char(3) PRIMARY KEY, descripcion Char(15))

CREATE TABLE vehiculo (matricula Char(8) PRIMARY KEY, tipo char(3), modelo varChar(100), fecha Date, importe integer, pagado tinyint DEFAULT 0,
FOREIGN KEY (tipo) REFERENCES tipo_vehiculo(tipo))

INSERT INTO tipo_vehiculo VALUES ('SED','Sedan'),('TOD','Todoterrono'),('DEP','Deportivos');
INSERT INTO vehiculo VALUES ('E1598BZH','SED','Corrolla', '2019-05-14',20800,1),('E8954LUG','TOD','Rav4', '2019-02-08',28100,1),
('E5567DZJ','TOD', 'Land Cruiser', '2019-05-06',40000,0),('E8867DJM','DEP','GT86', '2015-05-06',35000,1);

/* 1º Procedimiento listavehiculos */

go
CREATE PROCEDURE listavehiculos(@tipo Char(3))
as
SELECT vehiculo.matricula,vehiculo.tipo, vehiculo.modelo,vehiculo.fecha,vehiculo.importe, vehiculo.pagado
FROM vehiculo  WHERE vehiculo.tipo=@tipo ORDER BY vehiculo.fecha
go
/*EXEC listavehiculos 'TOD';
*/

/* 2º Función Numerovehiculosportipo*/

CREATE FUNCTION Numerovehiculosportipo(@tipo Char(3)) 
RETURNS int
BEGIN
RETURN (SELECT COUNT(*) FROM vehiculo WHERE vehiculo.tipo=@tipo);
END
GO
/*SELECT dbo.Numerovehiculosportipo('TOD');
*/
