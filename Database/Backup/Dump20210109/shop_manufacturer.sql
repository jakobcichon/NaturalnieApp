-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: shop
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `manufacturer`
--

DROP TABLE IF EXISTS `manufacturer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manufacturer` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `BarcodeEanPrefix` varchar(8) DEFAULT NULL,
  `MaxNumberOfProducts` int NOT NULL DEFAULT '1' COMMENT 'This parameter is used to determine how many product space will be reserved in cash register for this manufacturer.',
  `FirstNumberInCashRegister` int NOT NULL,
  `LastNumberInCashRegister` int NOT NULL,
  `Info` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Name_UNIQUE` (`Name`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `FirstNumberInCashRegister_UNIQUE` (`FirstNumberInCashRegister`),
  UNIQUE KEY `LastNumberInCashRegister_UNIQUE` (`LastNumberInCashRegister`)
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci MAX_ROWS=99;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacturer`
--

LOCK TABLES `manufacturer` WRITE;
/*!40000 ALTER TABLE `manufacturer` DISABLE KEYS */;
INSERT INTO `manufacturer` VALUES (1,'YOPE','',150,300,449,NULL),(2,'Sylveco','',250,450,699,NULL),(3,'Mokosh',NULL,150,700,849,NULL),(4,'Orientana',NULL,100,850,949,NULL),(5,'Flos',NULL,320,950,1269,NULL),(6,'EkaMedica',NULL,200,1270,1469,NULL),(7,'Łysoń',NULL,250,1470,1719,NULL),(8,'Gosh',NULL,180,1720,1899,NULL),(9,'EnglishTeaShop','680275',120,1900,2019,NULL),(10,'Kinetics',NULL,30,2020,2049,NULL),(11,'Yodeyma',NULL,10,2050,2059,NULL),(12,'Zew',NULL,60,2060,2119,NULL),(13,'Ziaja',NULL,150,2120,2269,NULL),(14,'Cztery Szpaki',NULL,80,2270,2349,NULL),(15,'Bamer',NULL,10,2350,2359,NULL),(16,'Unmate',NULL,150,2360,2509,NULL),(17,'Oleofarm',NULL,250,2510,2759,NULL),(18,'Lumene',NULL,200,2760,2959,NULL),(19,'Sanbios',NULL,60,2960,3019,NULL),(20,'Dary Natury',NULL,150,3020,3169,NULL),(21,'LBiotica',NULL,100,3170,3269,NULL),(22,'Obroki',NULL,120,3270,3389,NULL),(23,'BGH',NULL,100,3390,3489,NULL),(24,'Boleslawiec Ceramika',NULL,200,3490,3689,NULL),(25,'Golden Rose',NULL,110,3690,3799,NULL),(26,'Temido',NULL,100,3800,3899,NULL),(27,'Nomak',NULL,10,4060,4069,NULL),(99,'Joanna',NULL,10,4050,4059,NULL);
/*!40000 ALTER TABLE `manufacturer` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-09 18:29:08
