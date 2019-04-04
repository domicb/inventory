-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
SHOW WARNINGS;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `client`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `client` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `client` (
  `idclient` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  `tlf` VARCHAR(45) NULL DEFAULT NULL,
  `email` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idclient`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `invoice`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `invoice` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `invoice` (
  `idinvoice` INT(11) NOT NULL AUTO_INCREMENT,
  `dateCreate` DATE NULL DEFAULT NULL,
  `amount` DOUBLE NULL DEFAULT NULL,
  `client_idclient` INT(11) NOT NULL,
  PRIMARY KEY (`idinvoice`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `invoice_has_product`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `invoice_has_product` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `invoice_has_product` (
  `invoice_idinvoice` INT(11) NOT NULL,
  `product_idproduct` INT(11) NOT NULL,
  `id_subproduct` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`invoice_idinvoice`, `product_idproduct`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `product`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `product` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `product` (
  `idproduct` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  `size` VARCHAR(45) NULL DEFAULT NULL,
  `quantity` VARCHAR(500) NULL DEFAULT NULL,
  `dateIn` DATE NULL DEFAULT NULL,
  `dateOut` DATE NULL DEFAULT NULL,
  `kg` DOUBLE NULL DEFAULT NULL,
  `price` DOUBLE NULL DEFAULT NULL,
  `info` VARCHAR(500) NULL DEFAULT NULL,
  PRIMARY KEY (`idproduct`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `subproduct`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `subproduct` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `subproduct` (
  `idsubProduct` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  `size` VARCHAR(45) NULL DEFAULT NULL,
  `product_idproduct` INT(11) NOT NULL,
  `kg` DOUBLE NULL DEFAULT NULL,
  `quantity` VARCHAR(500) NULL DEFAULT NULL,
  `price` DOUBLE NULL DEFAULT NULL,
  `dateIn` DATE NULL DEFAULT NULL,
  `dateOut` DATE NULL DEFAULT NULL,
  `info` VARCHAR(500) NULL DEFAULT NULL,
  PRIMARY KEY (`idsubProduct`))
ENGINE = InnoDB
AUTO_INCREMENT = 17
DEFAULT CHARACTER SET = utf8;

SHOW WARNINGS;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
