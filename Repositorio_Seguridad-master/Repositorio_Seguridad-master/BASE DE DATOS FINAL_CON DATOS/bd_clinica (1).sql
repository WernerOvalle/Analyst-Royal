-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema bd_seguridad
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema bd_seguridad
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `bd_seguridad` DEFAULT CHARACTER SET utf8 ;
USE `bd_seguridad` ;

-- -----------------------------------------------------
-- Table `bd_seguridad`.`alergias_cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`alergias_cliente` (
  `id_alergia` INT(11) NOT NULL AUTO_INCREMENT,
  `descrip_alergia` VARCHAR(60) NULL DEFAULT NULL,
  PRIMARY KEY (`id_alergia`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`aplicacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`aplicacion` (
  `id_aplicacion` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre_aplicacion` VARCHAR(50) NOT NULL,
  `descripcion_aplicacion` VARCHAR(80) NOT NULL,
  `habilitar_aplicacion` TINYINT(1) NOT NULL,
  `id_reporte` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id_aplicacion`))
ENGINE = InnoDB
AUTO_INCREMENT = 21
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`usuario` (
  `id_usuario` INT(11) NOT NULL AUTO_INCREMENT,
  `usuario` VARCHAR(50) NOT NULL,
  `nombre_usuario` VARCHAR(50) NOT NULL,
  `apellido_usuario` VARCHAR(50) NOT NULL,
  `correo_usuario` VARCHAR(45) NULL DEFAULT NULL,
  `telefono_usuario` INT(8) NULL DEFAULT NULL,
  `contrasena` BLOB NULL DEFAULT NULL,
  PRIMARY KEY (`id_usuario`),
  UNIQUE INDEX `usuario_UNIQUE` (`usuario` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 13
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`bitacora_app`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`bitacora_app` (
  `id_aplicacion` INT(11) NOT NULL,
  `desc_app` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id_aplicacion`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`bitacora`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`bitacora` (
  `id_bitacora` INT(11) NOT NULL AUTO_INCREMENT,
  `id_usuario` INT(11) NOT NULL,
  `fecha_bitacora` DATE NOT NULL,
  `hora_bitacora` TIME(6) NOT NULL,
  `accion_usuario` VARCHAR(45) NOT NULL,
  `id_aplicacion` INT(11) NOT NULL,
  `resultado_bitacora` VARCHAR(45) NOT NULL,
  `error_bitacora` VARCHAR(800) NOT NULL,
  `ip_pc` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_bitacora`),
  INDEX `FK_bitacora_usuario_idx` (`id_usuario` ASC),
  INDEX `Fk_app_idx` (`id_aplicacion` ASC),
  CONSTRAINT `FK_bitacora_usuario`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `bd_seguridad`.`usuario` (`id_usuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_app`
    FOREIGN KEY (`id_aplicacion`)
    REFERENCES `bd_seguridad`.`bitacora_app` (`id_aplicacion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 273
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`detalle_aplicacion_derecho`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`detalle_aplicacion_derecho` (
  `id_usuario` INT(11) NOT NULL,
  `id_aplicacion` INT(11) NOT NULL,
  `ingresar` TINYINT(1) NOT NULL,
  `modificar` TINYINT(1) NOT NULL,
  `eliminar` TINYINT(1) NOT NULL,
  `imprimir` TINYINT(1) NOT NULL,
  `consultar` TINYINT(1) NOT NULL,
  INDEX `FK_detalle_usuario_idx` (`id_usuario` ASC),
  INDEX `FK_detalle_aplicacion2` (`id_aplicacion` ASC),
  CONSTRAINT `FK_detalle_aplicacion2`
    FOREIGN KEY (`id_aplicacion`)
    REFERENCES `bd_seguridad`.`aplicacion` (`id_aplicacion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_detalle_usuario`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `bd_seguridad`.`usuario` (`id_usuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`perfil`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`perfil` (
  `id_perfil` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre_perfil` VARCHAR(50) NOT NULL,
  `descripcion_perfil` VARCHAR(80) NOT NULL,
  PRIMARY KEY (`id_perfil`),
  UNIQUE INDEX `nombre_perfil_UNIQUE` (`nombre_perfil` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 1998
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`detalle_perfil_aplicacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`detalle_perfil_aplicacion` (
  `id_perfil` INT(11) NOT NULL,
  `id_aplicacion` INT(11) NOT NULL,
  PRIMARY KEY (`id_perfil`, `id_aplicacion`),
  INDEX `FK_detalle_aplicacion_idx` (`id_aplicacion` ASC),
  CONSTRAINT `FK_detalle_aplicacion`
    FOREIGN KEY (`id_aplicacion`)
    REFERENCES `bd_seguridad`.`aplicacion` (`id_aplicacion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_detalle_perfil`
    FOREIGN KEY (`id_perfil`)
    REFERENCES `bd_seguridad`.`perfil` (`id_perfil`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`detalle_usuario_perfil`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`detalle_usuario_perfil` (
  `id_usuario` INT(11) NOT NULL,
  `id_perfil` INT(11) NOT NULL,
  PRIMARY KEY (`id_usuario`, `id_perfil`),
  INDEX `FK_detalle_up_perfil_idx` (`id_perfil` ASC),
  CONSTRAINT `FK_detalle_up_perfil`
    FOREIGN KEY (`id_perfil`)
    REFERENCES `bd_seguridad`.`perfil` (`id_perfil`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_detalle_up_usuario`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `bd_seguridad`.`usuario` (`id_usuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`doctores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`doctores` (
  `id_doc` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  `apellido` VARCHAR(45) NULL DEFAULT NULL,
  `telefono` INT(11) NULL DEFAULT NULL,
  `especialidad` VARCHAR(45) NULL DEFAULT NULL,
  `direccion` VARCHAR(45) NULL DEFAULT NULL,
  `correo` VARCHAR(40) NULL DEFAULT NULL,
  PRIMARY KEY (`id_doc`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`enfermedades`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`enfermedades` (
  `id_enfermedad` INT(11) NOT NULL AUTO_INCREMENT,
  `descrip_enfer` VARCHAR(60) NULL DEFAULT NULL,
  PRIMARY KEY (`id_enfermedad`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`farmacia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`farmacia` (
  `idFarmacia` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre_farmacia` VARCHAR(30) NULL DEFAULT NULL,
  `direccion_farmacia` VARCHAR(60) NULL DEFAULT NULL,
  `telefono` INT(11) NULL DEFAULT NULL,
  `correo_electronico` VARCHAR(30) NULL DEFAULT NULL,
  PRIMARY KEY (`idFarmacia`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`habitacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`habitacion` (
  `id_habitacion` INT(11) NOT NULL AUTO_INCREMENT,
  `estatus` VARCHAR(45) NULL DEFAULT NULL,
  `descripcion` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id_habitacion`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`folio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`folio` (
  `id_gasto` INT(11) NOT NULL AUTO_INCREMENT,
  `id_habitacion` INT(11) NOT NULL,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  `apellido` VARCHAR(45) NULL DEFAULT NULL,
  `servicio` VARCHAR(45) NULL DEFAULT NULL,
  `monto` FLOAT NULL DEFAULT NULL,
  `fecha` DATETIME NOT NULL,
  `descripcion` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id_gasto`),
  INDEX `fk_folio_habitacion1_idx` (`id_habitacion` ASC))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`proveedores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`proveedores` (
  `idProveedores` INT(11) NOT NULL AUTO_INCREMENT,
  `nombreProveedor` VARCHAR(45) NULL DEFAULT NULL,
  `direccion` VARCHAR(45) NULL DEFAULT NULL,
  `ciudad_proveedor` VARCHAR(45) NULL DEFAULT NULL,
  `pais_proveedor` VARCHAR(45) NULL DEFAULT NULL,
  `representante` VARCHAR(45) NULL DEFAULT NULL,
  `nit_proveedor` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idProveedores`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`medicamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`medicamento` (
  `idMedicamento` INT(11) NOT NULL AUTO_INCREMENT,
  `idProveedores` INT(11) NOT NULL,
  `nombre_medicamento` VARCHAR(40) NULL DEFAULT NULL,
  `categoria_medicamento` VARCHAR(30) NULL DEFAULT NULL,
  `descripcion_medicamento` VARCHAR(60) NULL DEFAULT NULL,
  `precio_medicamento` FLOAT NULL DEFAULT NULL,
  `cantidad_existente` INT(11) NULL DEFAULT NULL,
  `fecha_ingreso_medicamento` DATE NULL DEFAULT NULL,
  `fecha_expira_medicamento` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`idMedicamento`),
  INDEX `fk_medicamento_proveedores1_idx` (`idProveedores` ASC))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`paciente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`paciente` (
  `id_cliente` INT(11) NOT NULL AUTO_INCREMENT,
  `nit_cliente` INT(11) NULL DEFAULT NULL,
  `nombre_cliente` VARCHAR(60) NULL DEFAULT NULL,
  `apellido_cliente` VARCHAR(60) NULL DEFAULT NULL,
  `direccion_cliente` VARCHAR(60) NULL DEFAULT NULL,
  `ciudad_cliente` VARCHAR(60) NULL DEFAULT NULL,
  `pais_cliente` VARCHAR(60) NULL DEFAULT NULL,
  `telefono` INT(11) NULL DEFAULT NULL,
  `correo` VARCHAR(60) NULL DEFAULT NULL,
  `edad_cliente` INT(11) NULL DEFAULT NULL,
  `id_alergia` INT(11) NOT NULL,
  PRIMARY KEY (`id_cliente`),
  INDEX `fk_paciente_alergias_cliente1_idx` (`id_alergia` ASC))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`transaccional_cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`transaccional_cliente` (
  `cod_transaccion` INT(11) NOT NULL AUTO_INCREMENT,
  `descripcion` VARCHAR(60) NULL DEFAULT NULL,
  `accion` VARCHAR(5) NULL DEFAULT NULL,
  PRIMARY KEY (`cod_transaccion`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`movimientos_de_clientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`movimientos_de_clientes` (
  `id_mov_cliente` INT(11) NOT NULL AUTO_INCREMENT,
  `cod_transaccion` INT(11) NOT NULL,
  `id_cliente` INT(11) NOT NULL,
  `total_cobro` FLOAT NULL DEFAULT NULL,
  `saldo` FLOAT NULL DEFAULT NULL,
  `fecha` DATE NULL DEFAULT NULL,
  `fecha_vencimiento` DATE NULL DEFAULT NULL,
  `actual` FLOAT NULL DEFAULT NULL,
  PRIMARY KEY (`id_mov_cliente`),
  INDEX `fk_movimientos_de_clientes_paciente1_idx` (`id_cliente` ASC),
  INDEX `fk_movimientos_de_clientes_transaccional_cliente1_idx` (`cod_transaccion` ASC))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`transacciones_proveedores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`transacciones_proveedores` (
  `id_tranproveedor` INT(11) NOT NULL AUTO_INCREMENT,
  `descripcion` VARCHAR(45) NULL DEFAULT NULL,
  `accion` VARCHAR(45) NULL DEFAULT NULL,
  `cod_nomenclatura` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id_tranproveedor`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`movimientos_proveedor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`movimientos_proveedor` (
  `Id_mov_proveedor` INT(11) NOT NULL AUTO_INCREMENT,
  `id_proveedor` INT(11) NOT NULL,
  `total_pago` FLOAT NULL DEFAULT NULL,
  `saldo` FLOAT NULL DEFAULT NULL,
  `cod_transaccion` INT(11) NOT NULL,
  `saldo_actual` DOUBLE NULL DEFAULT NULL,
  `fecha` DATE NULL DEFAULT NULL,
  `fecha_vencimiento` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`Id_mov_proveedor`),
  INDEX `fk_movimientos_proveedor_proveedores1_idx` (`id_proveedor` ASC),
  INDEX `fk_movimientos_proveedor_transacciones_proveedores1_idx` (`cod_transaccion` ASC))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`reporteador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`reporteador` (
  `idReporte` INT(11) NOT NULL,
  `nombreReporte` VARCHAR(500) NULL DEFAULT NULL,
  `path` VARCHAR(500) NULL DEFAULT NULL,
  PRIMARY KEY (`idReporte`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`reportegeneral`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`reportegeneral` (
  `idReporteg` INT(11) NOT NULL AUTO_INCREMENT,
  `nombreReporteg` VARCHAR(65) NOT NULL,
  `pathr` VARCHAR(128) NOT NULL,
  `reporte_app_id` INT(11) NOT NULL,
  PRIMARY KEY (`idReporteg`),
  INDEX `fk_app_id_idx` (`reporte_app_id` ASC),
  CONSTRAINT `fk_app_id`
    FOREIGN KEY (`reporte_app_id`)
    REFERENCES `bd_seguridad`.`aplicacion` (`id_aplicacion`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `bd_seguridad`.`reservacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`reservacion` (
  `id_reservacion` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  `apellido` VARCHAR(45) NULL DEFAULT NULL,
  `id_habitacion` INT(11) NOT NULL,
  PRIMARY KEY (`id_reservacion`),
  INDEX `fk_reservacion_habitacion1_idx` (`id_habitacion` ASC))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8;

USE `bd_seguridad` ;

-- -----------------------------------------------------
-- Placeholder table for view `bd_seguridad`.`vista_bitacora`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`vista_bitacora` (`usuario` INT, `fecha_bitacora` INT, `hora_bitacora` INT, `accion_usuario` INT, `desc_app` INT, `resultado_bitacora` INT, `error_bitacora` INT, `ip_pc` INT);

-- -----------------------------------------------------
-- Placeholder table for view `bd_seguridad`.`Vpaciente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`Vpaciente` (`CODIGO` INT, `NIT` INT, `NOMBRE` INT, `APELLIDO` INT, `DIR` INT, `CIUDAD` INT, `PAIS` INT, `TELEFONO` INT, `CORREO` INT, `EDAD` INT, `COD_ALERGIA` INT);

-- -----------------------------------------------------
-- Placeholder table for view `bd_seguridad`.`Valergias_cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bd_seguridad`.`Valergias_cliente` (`CODIGO` INT, `DESCRIPCION` INT);

-- -----------------------------------------------------
-- View `bd_seguridad`.`vista_bitacora`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bd_seguridad`.`vista_bitacora`;
USE `bd_seguridad`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `bd_seguridad`.`vista_bitacora` AS select `u`.`usuario` AS `usuario`,`b`.`fecha_bitacora` AS `fecha_bitacora`,`b`.`hora_bitacora` AS `hora_bitacora`,`b`.`accion_usuario` AS `accion_usuario`,`ap`.`desc_app` AS `desc_app`,`b`.`resultado_bitacora` AS `resultado_bitacora`,`b`.`error_bitacora` AS `error_bitacora`,`b`.`ip_pc` AS `ip_pc` from ((`bd_seguridad`.`usuario` `u` join `bd_seguridad`.`bitacora` `b` on((`b`.`id_usuario` = `u`.`id_usuario`))) join `bd_seguridad`.`bitacora_app` `ap` on((`b`.`id_aplicacion` = `ap`.`id_aplicacion`)));

-- -----------------------------------------------------
-- View `bd_seguridad`.`Vpaciente`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bd_seguridad`.`Vpaciente`;
USE `bd_seguridad`;
CREATE  OR REPLACE VIEW `Vpaciente` AS select 
id_cliente AS CODIGO, 
nit_cliente AS NIT, 
nombre_cliente AS NOMBRE,
apellido_cliente AS APELLIDO,
direccion_cliente AS DIR,
ciudad_cliente AS CIUDAD,
pais_cliente AS PAIS,
telefono AS TELEFONO,
correo AS CORREO,
edad_cliente AS EDAD, 
id_alergia AS COD_ALERGIA FROM (paciente);

-- -----------------------------------------------------
-- View `bd_seguridad`.`Valergias_cliente`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bd_seguridad`.`Valergias_cliente`;
USE `bd_seguridad`;
CREATE  OR REPLACE VIEW `Valergias_cliente` AS select
id_alergia CODIGO,
descrip_alergia DESCRIPCION from(alergias_cliente);

CREATE  OR REPLACE VIEW `Venfermedades` AS select
id_enfermedad CODIGO,
descrip_enfer DESCRIPCION from(enfermedades);

CREATE  OR REPLACE VIEW `Vtransaccional_cliente` AS select
cod_transaccion CODIGO,
descripcion DESCRIPCION, 
accion ACCION from(transaccional_cliente);

CREATE  OR REPLACE VIEW `Vmovimientos_de_clientes` AS select
id_mov_cliente ID,
cod_transaccion COD_TRANS,
id_cliente COD_CLIENTE,
total_cobro TOTAL,
saldo SALDO,
fecha FECHA1,
fecha_vencimiento FECHA2,
actual ACTUAL from(movimientos_de_clientes);





SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
