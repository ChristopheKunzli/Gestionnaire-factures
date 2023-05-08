-- MySQL Script generated by MySQL Workbench
-- Mon May  8 10:27:38 2023
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Bill-manager
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `Bill-manager` ;

-- -----------------------------------------------------
-- Schema Bill-manager
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Bill-manager` DEFAULT CHARACTER SET utf8 ;
USE `Bill-manager` ;

-- -----------------------------------------------------
-- Table `Bill-manager`.`Providers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Bill-manager`.`Providers` ;

CREATE TABLE IF NOT EXISTS `Bill-manager`.`Providers` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(200) NOT NULL,
  `email` VARCHAR(255) NULL,
  `phoneNumber` VARCHAR(30) NULL,
  `roadName` VARCHAR(100) NULL,
  `number` INT NULL,
  `postalCode` INT NULL,
  `city` VARCHAR(200) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Bill-manager`.`Types`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Bill-manager`.`Types` ;

CREATE TABLE IF NOT EXISTS `Bill-manager`.`Types` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Bill-manager`.`Users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Bill-manager`.`Users` ;

CREATE TABLE IF NOT EXISTS `Bill-manager`.`Users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `email` VARCHAR(255) NOT NULL,
  `firstName` VARCHAR(200) NOT NULL,
  `lastName` VARCHAR(200) NOT NULL,
  `password` VARCHAR(255) NOT NULL,
  `isAdmin` TINYINT NOT NULL DEFAULT 0,
  `hasChangedPassword` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Bill-manager`.`Bills`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Bill-manager`.`Bills` ;

CREATE TABLE IF NOT EXISTS `Bill-manager`.`Bills` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `billNumber` VARCHAR(50) NOT NULL,
  `receiver` VARCHAR(200) NOT NULL,
  `date` DATE NOT NULL,
  `currency` VARCHAR(45) NOT NULL,
  `amountHT` INT NOT NULL,
  `amountTTC` INT NOT NULL,
  `storagelocation` VARCHAR(500) NOT NULL,
  `imgLink` VARCHAR(300) NOT NULL,
  `Provider_id` INT NOT NULL,
  `Type_id` INT NOT NULL,
  `User_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `billNumber_UNIQUE` (`billNumber` ASC) VISIBLE,
  INDEX `fk_Provider_sends_Bill` (`Provider_id` ASC) VISIBLE,
  INDEX `fk_Bill_has_Type` (`Type_id` ASC) VISIBLE,
  INDEX `fk_User_receives_Bill` (`User_id` ASC) VISIBLE,
  CONSTRAINT `fk_Provider_sends_Bill`
    FOREIGN KEY (`Provider_id`)
    REFERENCES `Bill-manager`.`Providers` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Bill_has_Type`
    FOREIGN KEY (`Type_id`)
    REFERENCES `Bill-manager`.`Types` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_User_receives_Bill`
    FOREIGN KEY (`User_id`)
    REFERENCES `Bill-manager`.`Users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
