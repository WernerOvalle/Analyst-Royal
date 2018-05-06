
use bd_seguridad
;
CREATE TABLE planilla_doctores(
No_de_medico int primary key,
Nombre varchar(40),
apellido varchar(40),
DPI int,
titulo_del_cargo varchar(40),
sueldo varchar(40),
tipo_de_trabajo varchar(40),
mes varchar(40),
cantidad_de_cirujias int)