-- --------------------------------------------------------
-- Hôte:                         127.0.0.1
-- Version du serveur:           10.9.2-MariaDB - mariadb.org binary distribution
-- SE du serveur:                Win64
-- HeidiSQL Version:             12.4.0.6659
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Listage de la structure de la base pour bill-manager
DROP DATABASE IF EXISTS `bill-manager`;
CREATE DATABASE IF NOT EXISTS `bill-manager` /*!40100 DEFAULT CHARACTER SET utf8mb3 */;
USE `bill-manager`;

-- Listage de la structure de la table bill-manager. bills
DROP TABLE IF EXISTS `bills`;
CREATE TABLE IF NOT EXISTS `bills` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `billNumber` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `currency` varchar(45) NOT NULL,
  `amountHT` double NOT NULL DEFAULT 0,
  `amountTTC` double NOT NULL DEFAULT 0,
  `storagelocation` varchar(500) NOT NULL DEFAULT '',
  `imgLink` varchar(300) NOT NULL,
  `Provider_id` int(11) NOT NULL,
  `Type_id` int(11) NOT NULL,
  `User_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `billNumber_UNIQUE` (`billNumber`),
  KEY `fk_Provider_sends_Bill` (`Provider_id`),
  KEY `fk_Bill_has_Type` (`Type_id`),
  KEY `fk_User_receives_Bill` (`User_id`),
  CONSTRAINT `fk_Bill_has_Type` FOREIGN KEY (`Type_id`) REFERENCES `types` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Provider_sends_Bill` FOREIGN KEY (`Provider_id`) REFERENCES `providers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_User_receives_Bill` FOREIGN KEY (`User_id`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table bill-manager.bills : ~3 rows (environ)
DELETE FROM `bills`;
INSERT INTO `bills` (`id`, `billNumber`, `date`, `currency`, `amountHT`, `amountTTC`, `storagelocation`, `imgLink`, `Provider_id`, `Type_id`, `User_id`) VALUES
	(1, '1244809487', '2022-05-01', 'CHF', 36.21, 39, '', 'C:\\bills\\swisscom abonnement\\1244809487.pdf', 1, 2, 1),
	(2, '1257320276', '2022-06-01', 'CHF', 36.21, 39, '', 'C:\\bills\\swisscom abonnement\\1257320276.pdf', 1, 2, 1),
	(3, '85498594745', '2023-05-03', 'CHF', 200, 200, '', 'C:\\bills\\Administration cantonale vaudoise des impôts\\1244809487.pdf', 3, 3, 1);

-- Listage de la structure de la table bill-manager. providers
DROP TABLE IF EXISTS `providers`;
CREATE TABLE IF NOT EXISTS `providers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phoneNumber` varchar(30) DEFAULT NULL,
  `roadName` varchar(100) DEFAULT NULL,
  `number` int(11) DEFAULT NULL,
  `zip` int(11) DEFAULT NULL,
  `city` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table bill-manager.providers : ~2 rows (environ)
DELETE FROM `providers`;
INSERT INTO `providers` (`id`, `name`, `email`, `phoneNumber`, `roadName`, `number`, `zip`, `city`) VALUES
	(1, 'swisscom abonnement', '', '', 'Rte de Lausanne', 27, 1014, 'Lausanne'),
	(3, 'Administration cantonale vaudoise des impôts', 'info.aci@vd.ch', '021 316 10 40', 'Route de Berne', 46, 1014, 'Lausanne');

-- Listage de la structure de la table bill-manager. types
DROP TABLE IF EXISTS `types`;
CREATE TABLE IF NOT EXISTS `types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table bill-manager.types : ~4 rows (environ)
DELETE FROM `types`;
INSERT INTO `types` (`id`, `name`) VALUES
	(2, 'communication'),
	(3, 'électricité'),
	(4, 'loyer'),
	(1, 'médicale');

-- Listage de la structure de la table bill-manager. users
DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(255) NOT NULL,
  `firstName` varchar(200) NOT NULL,
  `lastName` varchar(200) NOT NULL,
  `password` varchar(255) NOT NULL,
  `isAdmin` tinyint(4) NOT NULL DEFAULT 0,
  `hasChangedPassword` tinyint(4) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table bill-manager.users : ~4 rows (environ)
DELETE FROM `users`;
INSERT INTO `users` (`id`, `email`, `firstName`, `lastName`, `password`, `isAdmin`, `hasChangedPassword`) VALUES
	(1, 'christophe.kunzli@cpnv.ch', 'christophe', 'kunzli', '$2a$11$GdHRQaMKREvLO3wOqQSoT.rkLmItgyuT.OlwBMDsWGBhPcqFK76V2', 1, 1),
	(2, 'corentin.bardet@cpnv.ch', 'corentin', 'bardet', '$2a$11$FAmPrJodxjymDWT.v2mA/....cX1bJ8o.E71xBKfAhc/YHb46Qta2', 0, 1),
	(3, 'theo.ghelmini@cpnv.ch', 'theo', 'ghelmini', '$2a$11$gyKqU3okEqsFFk7SeFDEMe2AptL/rgGHbZxKXvC7SpmU6x5jwhiWK', 1, 0),
	(4, 'jean.paul@cpnv.ch', 'jean', 'paul', '$2a$11$lNCLoP5u1.q05l2a.4mfbuQaQLSmVVZ6N6GF/DsMul.SHGhLwNuli', 0, 0);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
