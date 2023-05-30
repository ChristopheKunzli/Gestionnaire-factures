-- --------------------------------------------------------
-- Hôte:                         127.0.0.1
-- Version du serveur:           10.9.2-MariaDB - mariadb.org binary distribution
-- SE du serveur:                Win64
-- HeidiSQL Version:             12.5.0.6677
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
CREATE DATABASE IF NOT EXISTS `bill-manager` /*!40100 DEFAULT CHARACTER SET utf8mb3 */;
USE `bill-manager`;

-- Listage de la structure de la table bill-manager. bills
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
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table bill-manager.bills : ~14 rows (environ)
DELETE FROM `bills`;
INSERT INTO `bills` (`id`, `billNumber`, `date`, `currency`, `amountHT`, `amountTTC`, `storagelocation`, `imgLink`, `Provider_id`, `Type_id`, `User_id`) VALUES
	(1, '1244809487', '2022-05-01', 'CHF', 36.21, 39, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\swisscom abonnement\\1244809487.pdf', 1, 2, 1),
	(2, '1257320276', '2022-06-01', 'CHF', 36.21, 39, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\swisscom abonnement\\1257320276.pdf', 1, 2, 1),
	(3, '85498594745', '2023-05-03', 'CHF', 150, 150, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\Administration cantonale vaudoise des impôts\\1244809487.pdf', 3, 3, 1),
	(4, '1266916119', '2022-07-01', 'CHF', 50.34, 52, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\swisscom abonnement\\1266916119.pdf', 1, 2, 1),
	(5, '202359735051', '2023-03-22', 'CHF', 76, 85, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\swisscom abonnement\\1359735051.pdf', 1, 2, 1),
	(6, '20219735051', '2021-04-14', 'CHF', 45, 55, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\Administration cantonale vaudoise des impôts\\1359735051.pdf', 3, 2, 1),
	(7, '1202159735051', '2021-11-11', 'CHF', 89, 102, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\Administration cantonale vaudoise des impôts\\1359735051.pdf', 3, 3, 1),
	(8, '20201359735051', '2020-01-15', 'CHF', 50, 53.5, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\swisscom abonnement\\1359735051.pdf', 1, 3, 1),
	(9, '1202059735051', '2020-05-23', 'CHF', 66, 74.25, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\swisscom abonnement\\1359735051.pdf', 1, 3, 1),
	(10, '20199735051', '2023-05-05', 'CHF', 80, 90.5, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\swisscom abonnement\\1359735051.pdf', 1, 2, 1),
	(11, '1201959735051', '2019-02-14', 'CHF', 24.89, 28, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\swisscom abonnement\\1359735051.pdf', 1, 2, 1),
	(12, '20191359735051', '2019-11-22', 'CHF', 20, 22, '', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\swisscom abonnement\\1359735051.pdf', 1, 2, 1),
	(13, '1287890541', '2022-09-01', 'CHF', 36.21, 39, 'Sur la table du salon', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\Argentcontent\\1287890541.pdf', 5, 2, 2),
	(14, '1307260031', '2022-11-01', 'CHF', 364, 369, 'Sur le canapé', 'N:\\COMMUN\\ELEVE\\INFO\\SI-CA2a\\TPI\\bills\\sunrise abonnement\\1307260031.pdf', 4, 2, 2);

-- Listage de la structure de la table bill-manager. providers
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table bill-manager.providers : ~4 rows (environ)
DELETE FROM `providers`;
INSERT INTO `providers` (`id`, `name`, `email`, `phoneNumber`, `roadName`, `number`, `zip`, `city`) VALUES
	(1, 'swisscom abonnement', '', '', 'Rte de Lausanne', 27, 1014, 'Lausanne'),
	(3, 'Administration cantonale vaudoise des impôts', 'info.aci@vd.ch', '021 316 10 40', 'Route de Berne', 46, 1014, 'Lausanne'),
	(4, 'sunrise abonnement', '', '', 'Rue de Rive', 8, 1204, 'Genève'),
	(5, 'Argentcontent', 'argent@content.ch', '', 'Avenue du bonheur ', 69, 1450, 'Ste-Croix');

-- Listage de la structure de la table bill-manager. types
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table bill-manager.users : ~5 rows (environ)
DELETE FROM `users`;
INSERT INTO `users` (`id`, `email`, `firstName`, `lastName`, `password`, `isAdmin`, `hasChangedPassword`) VALUES
	(1, 'Christophe.kunzli@cpnv.ch', 'christophe', 'kunzli', '$2a$11$GdHRQaMKREvLO3wOqQSoT.rkLmItgyuT.OlwBMDsWGBhPcqFK76V2', 1, 1),
	(2, 'corentin.bardet@cpnv.ch', 'corentin', 'bardet', '$2a$11$8zhCfjtBVFzE1y7w2ca34.zsRxjEyp2Kf7QUVW76YyG41JpiueF1C', 1, 1),
	(3, 'theo.ghelmini@cpnv.ch', 'theo', 'ghelmini', '$2a$11$9NjGnA5f5Ubn.NHorBANGut/3INOi7o6r4IASKKXQpbhcDWp/FhGG', 0, 1),
	(4, 'jean.paul@cpnv.ch', 'jean', 'paul', '$2a$11$lNCLoP5u1.q05l2a.4mfbuQaQLSmVVZ6N6GF/DsMul.SHGhLwNuli', 0, 0),
	(5, 'David.MOSER@cpnv.ch', 'david', 'moser', '$2a$11$lxQZql0t/k0zU.8tWsDdw.o8iaCLO9m2906WvT2YyexJNBWY59uG6', 1, 0);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
