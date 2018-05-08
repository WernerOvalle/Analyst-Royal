CREATE database bd_seguridad;
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
cantidad_de_cirujias int);

CREATE TABLE historial_medico(
id_historial_clinico int primary key,
procendecia varchar(40),
fecha_de_ingreso  varchar(40),
id_medico int,
numero_de_planta varchar(40),
numero_de_cama varchar(40),
observaciones varchar(40))