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
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProductId` int NOT NULL,
  `ActualQuantity` int DEFAULT NULL,
  `ModificationDate` date DEFAULT NULL,
  `ExpirationDate` date DEFAULT NULL,
  `BarcodeWithDate` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `BarcodeWithDate_UNIQUE` (`BarcodeWithDate`),
  KEY `fk_Stock_Products1` (`ProductId`),
  CONSTRAINT `fk_Stock_Products1` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=874 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES (1,90,3,'2021-01-03','0001-01-01',NULL),(2,94,1,'2021-01-03','0001-01-01',NULL),(3,9,1,'2021-01-03','0001-01-01',NULL),(4,106,1,'2021-01-03','0001-01-01',NULL),(5,10,1,'2021-01-03','0001-01-01',NULL),(6,8,2,'2021-01-03','0001-01-01',NULL),(7,81,1,'2021-01-03','0001-01-01',NULL),(8,1,19,'2021-01-03','0001-01-01',NULL),(11,42,6,'2021-01-03','0001-01-01',NULL),(12,44,1,'2021-01-03','0001-01-01',NULL),(13,104,3,'2021-01-03','0001-01-01',NULL),(14,101,2,'2021-01-03','0001-01-01',NULL),(15,34,1,'2021-01-03','0001-01-01',NULL),(16,28,8,'2021-01-03','0001-01-01',NULL),(17,33,3,'2021-01-03','0001-01-01',NULL),(18,31,3,'2021-01-03','0001-01-01',NULL),(19,27,4,'2021-01-03','0001-01-01',NULL),(20,29,1,'2021-01-03','0001-01-01',NULL),(21,30,1,'2021-01-03','0001-01-01',NULL),(22,32,4,'2021-01-03','0001-01-01',NULL),(23,45,1,'2021-01-03','0001-01-01',NULL),(24,47,2,'2021-01-03','0001-01-01',NULL),(25,97,2,'2021-01-03','0001-01-01',NULL),(26,98,1,'2021-01-03','0001-01-01',NULL),(27,13,3,'2021-01-03','0001-01-01',NULL),(28,11,2,'2021-01-03','0001-01-01',NULL),(29,12,6,'2021-01-03','0001-01-01',NULL),(30,102,0,'2021-01-03','0001-01-01',NULL),(31,26,3,'2021-01-03','0001-01-01',NULL),(32,25,3,'2021-01-03','0001-01-01',NULL),(33,15,2,'2021-01-03','0001-01-01',NULL),(34,19,2,'2021-01-03','0001-01-01',NULL),(35,18,1,'2021-01-03','0001-01-01',NULL),(36,20,1,'2021-01-03','0001-01-01',NULL),(37,17,1,'2021-01-03','0001-01-01',NULL),(38,52,3,'2021-01-03','0001-01-01',NULL),(39,21,1,'2021-01-03','0001-01-01',NULL),(40,54,2,'2021-01-03','0001-01-01',NULL),(41,23,2,'2021-01-03','0001-01-01',NULL),(42,55,2,'2021-01-03','0001-01-01',NULL),(43,53,1,'2021-01-03','0001-01-01',NULL),(44,100,1,'2021-01-03','0001-01-01',NULL),(45,58,1,'2021-01-03','0001-01-01',NULL),(46,70,4,'2021-01-03','0001-01-01',NULL),(47,71,2,'2021-01-03','0001-01-01',NULL),(48,69,2,'2021-01-03','0001-01-01',NULL),(49,60,5,'2021-01-03','0001-01-01',NULL),(50,61,1,'2021-01-03','0001-01-01',NULL),(51,63,1,'2021-01-03','0001-01-01',NULL),(52,62,6,'2021-01-03','0001-01-01',NULL),(53,67,2,'2021-01-03','0001-01-01',NULL),(54,66,1,'2021-01-03','0001-01-01',NULL),(55,74,4,'2021-01-03','0001-01-01',NULL),(56,59,2,'2021-01-03','0001-01-01',NULL),(57,77,3,'2021-01-03','0001-01-01',NULL),(58,75,3,'2021-01-03','0001-01-01',NULL),(59,76,3,'2021-01-03','0001-01-01',NULL),(60,79,1,'2021-01-03','0001-01-01',NULL),(61,3,1,'2021-01-03','0001-01-01',NULL),(62,117,1,'2021-01-03','0001-01-01',NULL),(63,2,1,'2021-01-03','0001-01-01',NULL),(64,4,2,'2021-01-03','0001-01-01',NULL),(65,99,1,'2021-01-03','0001-01-01',NULL),(66,5,3,'2021-01-03','0001-01-01',NULL),(67,112,1,'2021-01-03','0001-01-01',NULL),(68,6,2,'2021-01-03','0001-01-01',NULL),(69,7,2,'2021-01-03','0001-01-01',NULL),(70,37,5,'2021-01-03','0001-01-01',NULL),(71,35,2,'2021-01-03','0001-01-01',NULL),(72,41,1,'2021-01-03','0001-01-01',NULL),(73,40,2,'2021-01-03','0001-01-01',NULL),(74,122,2,'2021-01-03','0001-01-01',NULL),(75,123,1,'2021-01-03','0001-01-01',NULL),(76,118,3,'2021-01-03','0001-01-01',NULL),(77,124,2,'2021-01-03','0001-01-01',NULL),(78,148,2,'2021-01-03','0001-01-01',NULL),(79,143,1,'2021-01-03','0001-01-01',NULL),(80,144,1,'2021-01-03','0001-01-01',NULL),(81,128,2,'2021-01-03','0001-01-01',NULL),(82,129,1,'2021-01-03','0001-01-01',NULL),(83,127,1,'2021-01-03','0001-01-01',NULL),(84,130,4,'2021-01-03','0001-01-01',NULL),(85,119,3,'2021-01-03','0001-01-01',NULL),(86,121,1,'2021-01-03','0001-01-01',NULL),(87,134,2,'2021-01-03','0001-01-01',NULL),(88,147,1,'2021-01-03','0001-01-01',NULL),(89,165,1,'2021-01-03','0001-01-01',NULL),(90,162,3,'2021-01-03','0001-01-01',NULL),(91,132,1,'2021-01-03','0001-01-01',NULL),(92,157,1,'2021-01-03','0001-01-01',NULL),(93,131,2,'2021-01-03','0001-01-01',NULL),(94,136,1,'2021-01-03','0001-01-01',NULL),(95,142,1,'2021-01-03','0001-01-01',NULL),(96,164,2,'2021-01-03','0001-01-01',NULL),(97,210,2,'2021-01-03','0001-01-01',NULL),(98,209,2,'2021-01-03','0001-01-01',NULL),(99,211,2,'2021-01-03','0001-01-01',NULL),(100,206,3,'2021-01-03','0001-01-01',NULL),(101,207,1,'2021-01-03','0001-01-01',NULL),(102,205,2,'2021-01-03','0001-01-01',NULL),(103,172,1,'2021-01-03','0001-01-01',NULL),(104,173,1,'2021-01-03','0001-01-01',NULL),(105,170,2,'2021-01-03','0001-01-01',NULL),(106,171,2,'2021-01-03','0001-01-01',NULL),(107,175,4,'2021-01-03','0001-01-01',NULL),(108,176,3,'2021-01-03','0001-01-01',NULL),(109,168,1,'2021-01-03','0001-01-01',NULL),(110,167,2,'2021-01-03','0001-01-01',NULL),(111,178,2,'2021-01-03','0001-01-01',NULL),(112,169,1,'2021-01-03','0001-01-01',NULL),(113,194,2,'2021-01-03','0001-01-01',NULL),(114,193,2,'2021-01-03','0001-01-01',NULL),(115,195,1,'2021-01-03','0001-01-01',NULL),(116,189,4,'2021-01-03','0001-01-01',NULL),(117,191,2,'2021-01-03','0001-01-01',NULL),(118,192,1,'2021-01-03','0001-01-01',NULL),(119,190,1,'2021-01-03','0001-01-01',NULL),(120,185,1,'2021-01-03','0001-01-01',NULL),(121,181,2,'2021-01-03','0001-01-01',NULL),(122,179,4,'2021-01-03','0001-01-01',NULL),(123,187,1,'2021-01-03','0001-01-01',NULL),(124,251,3,'2021-01-03','0001-01-01',NULL),(125,252,2,'2021-01-03','0001-01-01',NULL),(126,253,1,'2021-01-03','0001-01-01',NULL),(127,248,1,'2021-01-03','0001-01-01',NULL),(128,249,2,'2021-01-03','0001-01-01',NULL),(129,250,2,'2021-01-03','0001-01-01',NULL),(130,235,2,'2021-01-03','0001-01-01',NULL),(131,237,2,'2021-01-03','0001-01-01',NULL),(132,234,5,'2021-01-03','0001-01-01',NULL),(133,232,2,'2021-01-03','0001-01-01',NULL),(134,233,1,'2021-01-03','0001-01-01',NULL),(135,226,2,'2021-01-03','0001-01-01',NULL),(136,256,2,'2021-01-03','0001-01-01',NULL),(137,196,2,'2021-01-03','0001-01-01',NULL),(138,197,2,'2021-01-03','0001-01-01',NULL),(139,220,3,'2021-01-03','0001-01-01',NULL),(140,219,3,'2021-01-03','0001-01-01',NULL),(141,218,2,'2021-01-03','0001-01-01',NULL),(142,217,3,'2021-01-03','0001-01-01',NULL),(143,224,2,'2021-01-03','0001-01-01',NULL),(144,221,1,'2021-01-03','0001-01-01',NULL),(145,296,7,'2021-01-03','0001-01-01',NULL),(146,276,4,'2021-01-03','0001-01-01',NULL),(147,254,2,'2021-01-03','0001-01-01',NULL),(148,222,6,'2021-01-03','0001-01-01',NULL),(149,238,3,'2021-01-03','0001-01-01',NULL),(150,247,1,'2021-01-03','0001-01-01',NULL),(151,265,1,'2021-01-03','0001-01-01',NULL),(152,231,2,'2021-01-03','0001-01-01',NULL),(153,203,2,'2021-01-03','0001-01-01',NULL),(154,145,1,'2021-01-03','0001-01-01',NULL),(155,138,2,'2021-01-03','0001-01-01',NULL),(156,139,1,'2021-01-03','0001-01-01',NULL),(157,264,1,'2021-01-03','0001-01-01',NULL),(158,263,1,'2021-01-03','0001-01-01',NULL),(159,230,1,'2021-01-03','0001-01-01',NULL),(160,202,2,'2021-01-03','0001-01-01',NULL),(161,267,3,'2021-01-03','0001-01-01',NULL),(162,268,2,'2021-01-03','0001-01-01',NULL),(163,269,1,'2021-01-03','0001-01-01',NULL),(164,273,3,'2021-01-03','0001-01-01',NULL),(165,272,2,'2021-01-03','0001-01-01',NULL),(166,271,3,'2021-01-03','0001-01-01',NULL),(167,274,2,'2021-01-03','0001-01-01',NULL),(168,277,1,'2021-01-03','0001-01-01',NULL),(169,278,1,'2021-01-03','0001-01-01',NULL),(170,275,1,'2021-01-03','0001-01-01',NULL),(171,260,3,'2021-01-03','0001-01-01',NULL),(172,261,1,'2021-01-03','0001-01-01',NULL),(173,158,14,'2021-01-03','0001-01-01',NULL),(174,125,15,'2021-01-03','0001-01-01',NULL),(175,140,9,'2021-01-03','0001-01-01',NULL),(176,126,3,'2021-01-03','0001-01-01',NULL),(177,212,1,'2021-01-03','0001-01-01',NULL),(178,294,2,'2021-01-03','0001-01-01',NULL),(179,295,1,'2021-01-03','0001-01-01',NULL),(180,292,1,'2021-01-03','0001-01-01',NULL),(181,291,4,'2021-01-03','0001-01-01',NULL),(182,290,2,'2021-01-03','0001-01-01',NULL),(183,160,1,'2021-01-03','0001-01-01',NULL),(184,159,1,'2021-01-03','0001-01-01',NULL),(185,225,4,'2021-01-03','0001-01-01',NULL),(186,297,2,'2021-01-03','0001-01-01',NULL),(187,298,1,'2021-01-03','0001-01-01',NULL),(188,300,1,'2021-01-03','0001-01-01',NULL),(189,301,3,'2021-01-03','0001-01-01',NULL),(190,302,3,'2021-01-03','0001-01-01',NULL),(191,303,2,'2021-01-03','0001-01-01',NULL),(192,286,2,'2021-01-03','0001-01-01',NULL),(193,288,1,'2021-01-03','0001-01-01',NULL),(194,281,3,'2021-01-03','0001-01-01',NULL),(195,280,3,'2021-01-03','0001-01-01',NULL),(196,282,3,'2021-01-03','0001-01-01',NULL),(197,284,2,'2021-01-03','0001-01-01',NULL),(198,137,1,'2021-01-03','0001-01-01',NULL),(199,133,1,'2021-01-03','0001-01-01',NULL),(200,406,2,'2021-01-04','0001-01-01',NULL),(201,405,1,'2021-01-04','0001-01-01',NULL),(202,404,1,'2021-01-04','0001-01-01',NULL),(203,336,1,'2021-01-04','0001-01-01',NULL),(204,397,1,'2021-01-04','0001-01-01',NULL),(205,387,1,'2021-01-04','0001-01-01',NULL),(206,348,1,'2021-01-04','0001-01-01',NULL),(207,355,1,'2021-01-04','0001-01-01',NULL),(208,353,2,'2021-01-04','0001-01-01',NULL),(209,354,1,'2021-01-04','0001-01-01',NULL),(210,402,1,'2021-01-04','0001-01-01',NULL),(211,327,2,'2021-01-04','0001-01-01',NULL),(212,338,2,'2021-01-04','0001-01-01',NULL),(213,356,1,'2021-01-04','0001-01-01',NULL),(214,413,2,'2021-01-04','0001-01-01',NULL),(215,410,2,'2021-01-04','0001-01-01',NULL),(216,358,2,'2021-01-04','0001-01-01',NULL),(217,373,1,'2021-01-04','0001-01-01',NULL),(218,379,1,'2021-01-04','0001-01-01',NULL),(219,335,2,'2021-01-04','0001-01-01',NULL),(220,330,1,'2021-01-04','0001-01-01',NULL),(221,366,1,'2021-01-04','0001-01-01',NULL),(222,372,1,'2021-01-04','0001-01-01',NULL),(223,377,1,'2021-01-04','0001-01-01',NULL),(224,359,3,'2021-01-04','0001-01-01',NULL),(225,412,5,'2021-01-04','0001-01-01',NULL),(226,350,3,'2021-01-04','0001-01-01',NULL),(227,352,4,'2021-01-04','0001-01-01',NULL),(228,428,4,'2021-01-04','0001-01-01',NULL),(229,429,1,'2021-01-04','0001-01-01',NULL),(230,422,4,'2021-01-04','0001-01-01',NULL),(231,420,4,'2021-01-04','0001-01-01',NULL),(232,421,2,'2021-01-04','0001-01-01',NULL),(233,424,1,'2021-01-04','0001-01-01',NULL),(234,426,2,'2021-01-04','0001-01-01',NULL),(235,427,1,'2021-01-04','0001-01-01',NULL),(236,425,1,'2021-01-04','0001-01-01',NULL),(237,423,5,'2021-01-04','0001-01-01',NULL),(238,524,1,'2021-01-05','0001-01-01',NULL),(239,432,4,'2021-01-05','0001-01-01',NULL),(240,433,5,'2021-01-05','0001-01-01',NULL),(241,437,2,'2021-01-05','0001-01-01',NULL),(242,438,2,'2021-01-05','0001-01-01',NULL),(243,439,1,'2021-01-05','0001-01-01',NULL),(244,461,1,'2021-01-05','0001-01-01',NULL),(245,451,1,'2021-01-05','0001-01-01',NULL),(246,452,1,'2021-01-05','0001-01-01',NULL),(247,450,1,'2021-01-05','0001-01-01',NULL),(248,453,1,'2021-01-05','0001-01-01',NULL),(249,444,1,'2021-01-05','0001-01-01',NULL),(250,442,2,'2021-01-05','0001-01-01',NULL),(251,480,1,'2021-01-05','0001-01-01',NULL),(252,440,1,'2021-01-05','0001-01-01',NULL),(253,459,1,'2021-01-05','0001-01-01',NULL),(254,507,1,'2021-01-05','0001-01-01',NULL),(255,470,1,'2021-01-05','0001-01-01',NULL),(256,471,1,'2021-01-05','0001-01-01',NULL),(257,474,1,'2021-01-05','0001-01-01',NULL),(258,479,1,'2021-01-05','0001-01-01',NULL),(259,478,1,'2021-01-05','0001-01-01',NULL),(260,505,1,'2021-01-05','0001-01-01',NULL),(261,487,1,'2021-01-05','0001-01-01',NULL),(262,488,1,'2021-01-05','0001-01-01',NULL),(263,508,1,'2021-01-05','0001-01-01',NULL),(264,441,1,'2021-01-05','0001-01-01',NULL),(265,486,1,'2021-01-05','0001-01-01',NULL),(266,473,1,'2021-01-05','0001-01-01',NULL),(267,497,1,'2021-01-05','0001-01-01',NULL),(268,435,1,'2021-01-05','0001-01-01',NULL),(269,436,1,'2021-01-05','0001-01-01',NULL),(270,523,1,'2021-01-05','0001-01-01',NULL),(271,767,8,'2021-01-05','0001-01-01',NULL),(272,806,6,'2021-01-05','0001-01-01',NULL),(273,741,6,'2021-01-05','0001-01-01',NULL),(274,807,2,'2021-01-05','0001-01-01',NULL),(275,808,3,'2021-01-05','0001-01-01',NULL),(276,725,2,'2021-01-05','0001-01-01',NULL),(277,525,1,'2021-01-05','0001-01-01',NULL),(278,727,1,'2021-01-05','0001-01-01',NULL),(279,730,5,'2021-01-05','0001-01-01',NULL),(280,731,1,'2021-01-05','0001-01-01',NULL),(281,539,1,'2021-01-05','0001-01-01',NULL),(282,733,1,'2021-01-05','0001-01-01',NULL),(283,809,3,'2021-01-05','0001-01-01',NULL),(284,540,1,'2021-01-05','0001-01-01',NULL),(285,735,2,'2021-01-05','0001-01-01',NULL),(286,542,4,'2021-01-05','0001-01-01',NULL),(287,813,2,'2021-01-05','0001-01-01',NULL),(288,545,1,'2021-01-05','0001-01-01',NULL),(289,739,2,'2021-01-05','0001-01-01',NULL),(290,742,1,'2021-01-05','0001-01-01',NULL),(291,746,9,'2021-01-05','0001-01-01',NULL),(292,748,2,'2021-01-05','0001-01-01',NULL),(293,566,2,'2021-01-05','0001-01-01',NULL),(294,572,6,'2021-01-05','0001-01-01',NULL),(295,571,5,'2021-01-05','0001-01-01',NULL),(296,749,1,'2021-01-05','0001-01-01',NULL),(297,575,4,'2021-01-05','0001-01-01',NULL),(298,577,2,'2021-01-05','0001-01-01',NULL),(299,750,6,'2021-01-05','0001-01-01',NULL),(300,752,5,'2021-01-05','0001-01-01',NULL),(301,583,8,'2021-01-05','0001-01-01',NULL),(302,738,4,'2021-01-05','0001-01-01',NULL),(303,755,3,'2021-01-05','0001-01-01',NULL),(304,754,3,'2021-01-05','0001-01-01',NULL),(305,757,1,'2021-01-05','0001-01-01',NULL),(306,756,3,'2021-01-05','0001-01-01',NULL),(307,758,2,'2021-01-05','0001-01-01',NULL),(308,587,4,'2021-01-05','0001-01-01',NULL),(309,701,2,'2021-01-05','0001-01-01',NULL),(310,761,1,'2021-01-05','0001-01-01',NULL),(311,670,1,'2021-01-05','0001-01-01',NULL),(312,588,3,'2021-01-05','0001-01-01',NULL),(313,763,4,'2021-01-05','0001-01-01',NULL),(314,589,6,'2021-01-05','0001-01-01',NULL),(315,593,1,'2021-01-05','0001-01-01',NULL),(316,594,1,'2021-01-05','0001-01-01',NULL),(317,782,2,'2021-01-05','0001-01-01',NULL),(318,656,2,'2021-01-05','0001-01-01',NULL),(319,764,1,'2021-01-05','0001-01-01',NULL),(320,610,4,'2021-01-05','0001-01-01',NULL),(321,611,3,'2021-01-05','0001-01-01',NULL),(322,613,2,'2021-01-05','0001-01-01',NULL),(323,616,2,'2021-01-05','0001-01-01',NULL),(324,768,2,'2021-01-05','0001-01-01',NULL),(325,769,2,'2021-01-05','0001-01-01',NULL),(326,621,2,'2021-01-05','0001-01-01',NULL),(327,619,2,'2021-01-05','0001-01-01',NULL),(328,771,4,'2021-01-05','0001-01-01',NULL),(329,627,4,'2021-01-05','0001-01-01',NULL),(330,773,6,'2021-01-05','0001-01-01',NULL),(331,774,1,'2021-01-05','0001-01-01',NULL),(332,775,3,'2021-01-05','0001-01-01',NULL),(333,528,4,'2021-01-05','0001-01-01',NULL),(334,708,2,'2021-01-05','0001-01-01',NULL),(335,778,3,'2021-01-05','0001-01-01',NULL),(336,783,3,'2021-01-05','0001-01-01',NULL),(337,781,2,'2021-01-05','0001-01-01',NULL),(338,786,1,'2021-01-05','0001-01-01',NULL),(339,659,2,'2021-01-05','0001-01-01',NULL),(340,669,2,'2021-01-05','0001-01-01',NULL),(341,668,2,'2021-01-05','0001-01-01',NULL),(342,664,2,'2021-01-05','0001-01-01',NULL),(343,801,3,'2021-01-05','0001-01-01',NULL),(344,681,4,'2021-01-05','0001-01-01',NULL),(345,682,2,'2021-01-05','0001-01-01',NULL),(346,687,2,'2021-01-05','0001-01-01',NULL),(347,802,1,'2021-01-05','0001-01-01',NULL),(348,686,1,'2021-01-05','0001-01-01',NULL),(349,691,1,'2021-01-05','0001-01-01',NULL),(350,694,6,'2021-01-05','0001-01-01',NULL),(351,792,6,'2021-01-05','0001-01-01',NULL),(352,672,2,'2021-01-05','0001-01-01',NULL),(353,793,1,'2021-01-05','0001-01-01',NULL),(354,772,2,'2021-01-05','0001-01-01',NULL),(355,798,1,'2021-01-05','0001-01-01',NULL),(356,676,1,'2021-01-05','0001-01-01',NULL),(357,799,1,'2021-01-05','0001-01-01',NULL),(358,551,2,'2021-01-05','0001-01-01',NULL),(359,550,2,'2021-01-05','0001-01-01',NULL),(360,606,1,'2021-01-05','0001-01-01',NULL),(361,582,4,'2021-01-05','0001-01-01',NULL),(362,658,1,'2021-01-05','0001-01-01',NULL),(363,618,1,'2021-01-05','0001-01-01',NULL),(364,535,3,'2021-01-05','0001-01-01',NULL),(365,643,1,'2021-01-05','0001-01-01',NULL),(366,736,2,'2021-01-05','0001-01-01',NULL),(367,784,2,'2021-01-05','0001-01-01',NULL),(368,591,1,'2021-01-05','0001-01-01',NULL),(369,678,3,'2021-01-05','0001-01-01',NULL),(370,615,1,'2021-01-05','0001-01-01',NULL),(371,660,6,'2021-01-05','0001-01-01',NULL),(372,559,1,'2021-01-05','0001-01-01',NULL),(373,565,1,'2021-01-05','0001-01-01',NULL),(374,661,1,'2021-01-05','0001-01-01',NULL),(375,693,2,'2021-01-06','0001-01-01',NULL),(376,607,1,'2021-01-06','0001-01-01',NULL),(377,568,6,'2021-01-06','0001-01-01',NULL),(378,688,1,'2021-01-06','0001-01-01',NULL),(379,547,4,'2021-01-06','0001-01-01',NULL),(380,690,2,'2021-01-06','0001-01-01',NULL),(381,530,1,'2021-01-06','0001-01-01',NULL),(382,585,1,'2021-01-06','0001-01-01',NULL),(383,548,1,'2021-01-06','0001-01-01',NULL),(384,719,1,'2021-01-06','0001-01-01',NULL),(385,629,1,'2021-01-06','0001-01-01',NULL),(386,663,6,'2021-01-06','0001-01-01',NULL),(387,558,3,'2021-01-06','0001-01-01',NULL),(388,705,2,'2021-01-06','0001-01-01',NULL),(389,603,2,'2021-01-06','0001-01-01',NULL),(390,704,2,'2021-01-06','0001-01-01',NULL),(391,711,2,'2021-01-06','0001-01-01',NULL),(392,698,1,'2021-01-06','0001-01-01',NULL),(393,709,1,'2021-01-06','0001-01-01',NULL),(394,564,1,'2021-01-06','0001-01-01',NULL),(395,766,1,'2021-01-06','0001-01-01',NULL),(396,791,3,'2021-01-06','0001-01-01',NULL),(397,745,1,'2021-01-06','0001-01-01',NULL),(398,614,1,'2021-01-06','0001-01-01',NULL),(399,788,5,'2021-01-06','0001-01-01',NULL),(400,567,1,'2021-01-06','0001-01-01',NULL),(401,743,4,'2021-01-06','0001-01-01',NULL),(402,795,3,'2021-01-06','0001-01-01',NULL),(403,765,4,'2021-01-06','0001-01-01',NULL),(404,794,2,'2021-01-06','0001-01-01',NULL),(405,779,4,'2021-01-06','0001-01-01',NULL),(406,762,3,'2021-01-06','0001-01-01',NULL),(407,891,2,'2021-01-06','0001-01-01',NULL),(408,700,2,'2021-01-06','0001-01-01',NULL),(409,740,4,'2021-01-06','0001-01-01',NULL),(410,777,2,'2021-01-06','0001-01-01',NULL),(411,561,8,'2021-01-06','0001-01-01',NULL),(412,797,2,'2021-01-06','0001-01-01',NULL),(413,563,4,'2021-01-06','0001-01-01',NULL),(414,562,2,'2021-01-06','0001-01-01',NULL),(415,586,1,'2021-01-06','0001-01-01',NULL),(416,552,2,'2021-01-06','0001-01-01',NULL),(417,537,4,'2021-01-06','0001-01-01',NULL),(418,892,2,'2021-01-06','0001-01-01',NULL),(419,893,1,'2021-01-06','0001-01-01',NULL),(420,894,1,'2021-01-06','0001-01-01',NULL),(421,895,1,'2021-01-06','0001-01-01',NULL),(422,996,2,'2021-01-06','0001-01-01',NULL),(423,1004,1,'2021-01-06','0001-01-01',NULL),(424,1003,1,'2021-01-06','0001-01-01',NULL),(425,1007,1,'2021-01-06','0001-01-01',NULL),(426,997,1,'2021-01-06','0001-01-01',NULL),(427,1000,1,'2021-01-06','0001-01-01',NULL),(428,995,1,'2021-01-06','0001-01-01',NULL),(429,1005,1,'2021-01-06','0001-01-01',NULL),(430,1032,1,'2021-01-06','0001-01-01',NULL),(431,993,1,'2021-01-06','0001-01-01',NULL),(432,1021,1,'2021-01-06','0001-01-01',NULL),(433,1024,1,'2021-01-06','0001-01-01',NULL),(434,1016,1,'2021-01-06','0001-01-01',NULL),(435,1038,1,'2021-01-06','0001-01-01',NULL),(436,1037,1,'2021-01-06','0001-01-01',NULL),(437,1036,2,'2021-01-06','0001-01-01',NULL),(438,625,3,'2021-01-06','0001-01-01',NULL),(439,624,1,'2021-01-06','0001-01-01',NULL),(440,628,2,'2021-01-06','0001-01-01',NULL),(441,1031,1,'2021-01-06','0001-01-01',NULL),(442,906,1,'2021-01-06','0001-01-01',NULL),(443,929,1,'2021-01-06','0001-01-01',NULL),(444,928,2,'2021-01-06','0001-01-01',NULL),(445,910,2,'2021-01-06','0001-01-01',NULL),(446,938,2,'2021-01-06','0001-01-01',NULL),(447,921,1,'2021-01-06','0001-01-01',NULL),(448,897,0,'2021-01-06','0001-01-01',NULL),(449,946,0,'2021-01-06','0001-01-01',NULL),(450,953,1,'2021-01-06','0001-01-01',NULL),(451,907,1,'2021-01-06','0001-01-01',NULL),(452,931,1,'2021-01-06','0001-01-01',NULL),(453,942,1,'2021-01-06','0001-01-01',NULL),(454,1135,3,'2021-01-06','0001-01-01',NULL),(455,1054,1,'2021-01-06','0001-01-01',NULL),(456,1112,1,'2021-01-06','0001-01-01',NULL),(457,1088,4,'2021-01-06','0001-01-01',NULL),(458,1094,2,'2021-01-06','0001-01-01',NULL),(459,1082,1,'2021-01-06','0001-01-01',NULL),(460,1049,1,'2021-01-06','0001-01-01',NULL),(461,1097,1,'2021-01-06','0001-01-01',NULL),(462,1073,1,'2021-01-06','0001-01-01',NULL),(463,1061,1,'2021-01-06','0001-01-01',NULL),(464,1256,1,'2021-01-06','0001-01-01',NULL),(465,1262,0,'2021-01-06','0001-01-01',NULL),(466,1222,1,'2021-01-06','0001-01-01',NULL),(467,1215,1,'2021-01-06','0001-01-01',NULL),(468,609,1,'2021-01-06','0001-01-01',NULL),(469,73,2,'2021-01-07','0001-01-01',NULL),(470,1278,148,'2021-01-07','0001-01-01',NULL),(471,1287,3,'2021-01-07','0001-01-01',NULL),(472,1524,36,'2021-01-07','0001-01-01',NULL),(473,1527,67,'2021-01-07','0001-01-01',NULL),(474,1526,2,'2021-01-07','0001-01-01',NULL),(475,1529,1,'2021-01-07','0001-01-01',NULL),(476,1532,1,'2021-01-07','0001-01-01',NULL),(477,1530,1,'2021-01-07','0001-01-01',NULL),(478,1430,1,'2021-01-07','0001-01-01',NULL),(479,1427,1,'2021-01-07','0001-01-01',NULL),(480,1429,1,'2021-01-07','0001-01-01',NULL),(481,1436,1,'2021-01-07','0001-01-01',NULL),(482,1422,2,'2021-01-07','0001-01-01',NULL),(483,1423,2,'2021-01-07','0001-01-01',NULL),(484,1535,1,'2021-01-07','0001-01-01',NULL),(485,1425,2,'2021-01-07','0001-01-01',NULL),(486,1360,1,'2021-01-07','0001-01-01',NULL),(487,1363,2,'2021-01-07','0001-01-01',NULL),(488,1386,2,'2021-01-07','0001-01-01',NULL),(489,1410,2,'2021-01-07','0001-01-01',NULL),(490,1394,3,'2021-01-07','0001-01-01',NULL),(491,1402,2,'2021-01-07','0001-01-01',NULL),(492,1415,1,'2021-01-07','0001-01-01',NULL),(493,1361,2,'2021-01-07','0001-01-01',NULL),(494,1437,1,'2021-01-07','0001-01-01',NULL),(495,1358,2,'2021-01-07','0001-01-01',NULL),(496,1426,1,'2021-01-07','0001-01-01',NULL),(497,1419,1,'2021-01-07','0001-01-01',NULL),(498,1536,1,'2021-01-07','0001-01-01',NULL),(499,1534,1,'2021-01-07','0001-01-01',NULL),(500,1432,1,'2021-01-07','0001-01-01',NULL),(501,1435,1,'2021-01-07','0001-01-01',NULL),(502,1362,1,'2021-01-07','0001-01-01',NULL),(503,1364,3,'2021-01-07','0001-01-01',NULL),(504,1365,3,'2021-01-07','0001-01-01',NULL),(505,1356,3,'2021-01-07','0001-01-01',NULL),(506,1359,2,'2021-01-07','0001-01-01',NULL),(507,1397,2,'2021-01-07','0001-01-01',NULL),(508,1393,3,'2021-01-07','0001-01-01',NULL),(509,1411,5,'2021-01-07','0001-01-01',NULL),(510,1387,2,'2021-01-07','0001-01-01',NULL),(511,1416,3,'2021-01-07','0001-01-01',NULL),(512,1391,16,'2021-01-07','0001-01-01',NULL),(513,1392,33,'2021-01-07','0001-01-01',NULL),(514,1376,1,'2021-01-07','0001-01-01',NULL),(515,1370,1,'2021-01-07','0001-01-01',NULL),(516,1375,1,'2021-01-07','0001-01-01',NULL),(517,516,1,'2021-01-07','0001-01-01',NULL),(518,512,1,'2021-01-07','0001-01-01',NULL),(519,154,1,'2021-01-07','0001-01-01',NULL),(520,1549,2,'2021-01-07','0001-01-01',NULL),(521,1548,1,'2021-01-07','0001-01-01',NULL),(522,1537,2,'2021-01-07','0001-01-01',NULL),(523,1540,1,'2021-01-07','0001-01-01',NULL),(524,1538,0,'2021-01-07','0001-01-01',NULL),(525,1560,4,'2021-01-07','0001-01-01',NULL),(526,1559,1,'2021-01-07','0001-01-01',NULL),(527,1547,0,'2021-01-07','0001-01-01',NULL),(528,1544,4,'2021-01-07','0001-01-01',NULL),(529,1554,1,'2021-01-07','0001-01-01',NULL),(530,1681,1,'2021-01-07','0001-01-01',NULL),(531,1680,1,'2021-01-07','0001-01-01',NULL),(532,1658,1,'2021-01-07','0001-01-01',NULL),(533,1662,0,'2021-01-07','0001-01-01',NULL),(534,1676,4,'2021-01-07','0001-01-01',NULL),(535,1638,1,'2021-01-07','0001-01-01',NULL),(536,1685,1,'2021-01-07','0001-01-01',NULL),(537,1671,1,'2021-01-07','0001-01-01',NULL),(538,1669,1,'2021-01-07','0001-01-01',NULL),(539,1659,1,'2021-01-07','0001-01-01',NULL),(540,1645,2,'2021-01-07','0001-01-01',NULL),(541,1660,0,'2021-01-07','0001-01-01',NULL),(542,1663,1,'2021-01-07','0001-01-01',NULL),(543,1643,1,'2021-01-07','0001-01-01',NULL),(544,1656,2,'2021-01-07','0001-01-01',NULL),(545,1655,1,'2021-01-07','0001-01-01',NULL),(546,1687,5,'2021-01-07','0001-01-01',NULL),(547,1688,1,'2021-01-07','0001-01-01',NULL),(548,1692,2,'2021-01-07','0001-01-01',NULL),(549,1691,13,'2021-01-07','0001-01-01',NULL),(550,1693,19,'2021-01-07','0001-01-01',NULL),(551,1690,13,'2021-01-07','0001-01-01',NULL),(552,1689,51,'2021-01-07','0001-01-01',NULL),(554,1446,1,'2021-01-07','0001-01-01',NULL),(555,1444,1,'2021-01-07','0001-01-01',NULL),(556,1440,2,'2021-01-07','0001-01-01',NULL),(557,1441,1,'2021-01-07','0001-01-01',NULL),(558,1442,1,'2021-01-07','0001-01-01',NULL),(560,1513,2,'2021-01-07','0001-01-01',NULL),(561,1511,1,'2021-01-07','0001-01-01',NULL),(562,1512,1,'2021-01-07','0001-01-01',NULL),(563,1473,1,'2021-01-07','0001-01-01',NULL),(565,1492,4,'2021-01-07','0001-01-01',NULL),(566,1522,1,'2021-01-07','0001-01-01',NULL),(567,1518,1,'2021-01-07','0001-01-01',NULL),(568,1519,1,'2021-01-07','0001-01-01',NULL),(569,1510,1,'2021-01-07','0001-01-01',NULL),(571,1753,1,'2021-01-08','0001-01-01',NULL),(572,1752,1,'2021-01-08','0001-01-01',NULL),(573,1751,1,'2021-01-08','0001-01-01',NULL),(574,1754,1,'2021-01-08','0001-01-01',NULL),(575,1756,1,'2021-01-08','0001-01-01',NULL),(576,1755,4,'2021-01-08','0001-01-01',NULL),(577,1705,1,'2021-01-08','0001-01-01',NULL),(578,1702,1,'2021-01-08','0001-01-01',NULL),(579,1703,1,'2021-01-08','0001-01-01',NULL),(580,1704,1,'2021-01-08','0001-01-01',NULL),(581,1811,1,'2021-01-08','0001-01-01',NULL),(582,1810,1,'2021-01-08','0001-01-01',NULL),(583,1812,1,'2021-01-08','0001-01-01',NULL),(584,1709,1,'2021-01-08','0001-01-01',NULL),(585,1706,1,'2021-01-08','0001-01-01',NULL),(586,1710,1,'2021-01-08','0001-01-01',NULL),(587,1707,1,'2021-01-08','0001-01-01',NULL),(588,1713,1,'2021-01-08','0001-01-01',NULL),(589,1708,1,'2021-01-08','0001-01-01',NULL),(590,1714,1,'2021-01-08','0001-01-01',NULL),(591,1711,1,'2021-01-08','0001-01-01',NULL),(592,1717,1,'2021-01-08','0001-01-01',NULL),(593,1712,1,'2021-01-08','0001-01-01',NULL),(594,1721,1,'2021-01-08','0001-01-01',NULL),(595,1718,1,'2021-01-08','0001-01-01',NULL),(596,1720,2,'2021-01-08','0001-01-01',NULL),(597,1750,2,'2021-01-08','0001-01-01',NULL),(598,1749,2,'2021-01-08','0001-01-01',NULL),(599,1748,1,'2021-01-08','0001-01-01',NULL),(600,1747,1,'2021-01-08','0001-01-01',NULL),(601,1744,2,'2021-01-08','0001-01-01',NULL),(602,1738,1,'2021-01-08','0001-01-01',NULL),(603,1736,1,'2021-01-08','0001-01-01',NULL),(604,1737,1,'2021-01-08','0001-01-01',NULL),(605,1735,1,'2021-01-08','0001-01-01',NULL),(606,1726,1,'2021-01-08','0001-01-01',NULL),(607,1723,1,'2021-01-08','0001-01-01',NULL),(608,1724,1,'2021-01-08','0001-01-01',NULL),(609,1715,1,'2021-01-08','0001-01-01',NULL),(610,1716,1,'2021-01-08','0001-01-01',NULL),(611,1818,0,'2021-01-08','0001-01-01',NULL),(612,1822,1,'2021-01-08','0001-01-01',NULL),(613,1820,2,'2021-01-08','0001-01-01',NULL),(614,1741,1,'2021-01-08','0001-01-01',NULL),(615,1740,1,'2021-01-08','0001-01-01',NULL),(616,1739,1,'2021-01-08','0001-01-01',NULL),(617,1817,1,'2021-01-08','0001-01-01',NULL),(618,1734,1,'2021-01-08','0001-01-01',NULL),(619,1733,1,'2021-01-08','0001-01-01',NULL),(620,1727,1,'2021-01-08','0001-01-01',NULL),(621,1725,2,'2021-01-08','0001-01-01',NULL),(622,1732,2,'2021-01-08','0001-01-01',NULL),(623,1731,1,'2021-01-08','0001-01-01',NULL),(624,1730,1,'2021-01-08','0001-01-01',NULL),(625,1729,1,'2021-01-08','0001-01-01',NULL),(626,1728,2,'2021-01-08','0001-01-01',NULL),(627,1893,1,'2021-01-08','0001-01-01',NULL),(628,1921,1,'2021-01-08','0001-01-01',NULL),(629,1883,2,'2021-01-08','0001-01-01',NULL),(630,1906,1,'2021-01-08','0001-01-01',NULL),(631,1926,1,'2021-01-08','0001-01-01',NULL),(632,1924,1,'2021-01-08','0001-01-01',NULL),(633,1923,1,'2021-01-08','0001-01-01',NULL),(634,1925,2,'2021-01-08','0001-01-01',NULL),(635,1922,2,'2021-01-08','0001-01-01',NULL),(636,1295,8,'2021-01-08','0001-01-01',NULL),(637,1927,3,'2021-01-08','0001-01-01',NULL),(638,1299,8,'2021-01-08','0001-01-01',NULL),(639,1302,5,'2021-01-08','0001-01-01',NULL),(640,1303,14,'2021-01-08','0001-01-01',NULL),(641,1305,2,'2021-01-08','0001-01-01',NULL),(642,1307,8,'2021-01-08','0001-01-01',NULL),(643,1309,18,'2021-01-08','0001-01-01',NULL),(644,1310,3,'2021-01-08','0001-01-01',NULL),(645,1311,5,'2021-01-08','0001-01-01',NULL),(646,1312,1,'2021-01-08','0001-01-01',NULL),(647,1322,10,'2021-01-08','0001-01-01',NULL),(648,1323,2,'2021-01-08','0001-01-01',NULL),(649,1330,7,'2021-01-08','0001-01-01',NULL),(650,1352,4,'2021-01-08','0001-01-01',NULL),(651,1298,5,'2021-01-08','0001-01-01',NULL),(652,1332,1,'2021-01-08','0001-01-01',NULL),(653,1345,2,'2021-01-08','0001-01-01',NULL),(654,1928,3,'2021-01-08','0001-01-01',NULL),(655,1331,1,'2021-01-08','0001-01-01',NULL),(656,1929,2,'2021-01-08','0001-01-01',NULL),(657,1930,6,'2021-01-08','0001-01-01',NULL),(658,1291,2,'2021-01-08','0001-01-01',NULL),(659,1931,2,'2021-01-08','0001-01-01',NULL),(660,1932,1,'2021-01-08','0001-01-01',NULL),(661,1301,2,'2021-01-08','0001-01-01',NULL),(662,1348,1,'2021-01-08','0001-01-01',NULL),(663,1933,2,'2021-01-08','0001-01-01',NULL),(664,1934,6,'2021-01-08','0001-01-01',NULL),(665,1935,2,'2021-01-08','0001-01-01',NULL),(666,2548,1,'2021-01-09','0001-01-01',NULL),(667,2549,2,'2021-01-09','0001-01-01',NULL),(668,2535,2,'2021-01-09','0001-01-01',NULL),(669,2514,1,'2021-01-09','0001-01-01',NULL),(670,2515,2,'2021-01-09','0001-01-01',NULL),(671,2517,1,'2021-01-09','0001-01-01',NULL),(672,2518,1,'2021-01-09','0001-01-01',NULL),(673,2516,1,'2021-01-09','0001-01-01',NULL),(674,2512,3,'2021-01-09','0001-01-01',NULL),(675,2513,2,'2021-01-09','0001-01-01',NULL),(676,2534,2,'2021-01-09','0001-01-01',NULL),(677,2533,1,'2021-01-09','0001-01-01',NULL),(678,2532,1,'2021-01-09','0001-01-01',NULL),(679,2531,1,'2021-01-09','0001-01-01',NULL),(680,2530,1,'2021-01-09','0001-01-01',NULL),(681,2529,1,'2021-01-09','0001-01-01',NULL),(682,2547,1,'2021-01-09','0001-01-01',NULL),(683,2528,1,'2021-01-09','0001-01-01',NULL),(684,2527,1,'2021-01-09','0001-01-01',NULL),(685,2526,1,'2021-01-09','0001-01-01',NULL),(686,2525,1,'2021-01-09','0001-01-01',NULL),(687,2524,1,'2021-01-09','0001-01-01',NULL),(688,2519,3,'2021-01-09','0001-01-01',NULL),(689,2546,1,'2021-01-09','0001-01-01',NULL),(690,2545,15,'2021-01-09','0001-01-01',NULL),(691,2544,25,'2021-01-09','0001-01-01',NULL),(692,2541,1,'2021-01-09','0001-01-01',NULL),(693,2540,1,'2021-01-09','0001-01-01',NULL),(694,2539,1,'2021-01-09','0001-01-01',NULL),(695,2538,1,'2021-01-09','0001-01-01',NULL),(696,2537,1,'2021-01-09','0001-01-01',NULL),(697,2536,2,'2021-01-09','0001-01-01',NULL),(698,2542,1,'2021-01-09','0001-01-01',NULL),(699,2543,1,'2021-01-09','0001-01-01',NULL),(700,2198,3,'2021-01-09','0001-01-01',NULL),(701,2201,4,'2021-01-09','0001-01-01',NULL),(702,2242,7,'2021-01-09','0001-01-01',NULL),(703,2208,4,'2021-01-09','0001-01-01',NULL),(704,2207,1,'2021-01-09','0001-01-01',NULL),(705,2194,3,'2021-01-09','0001-01-01',NULL),(706,2202,2,'2021-01-09','0001-01-01',NULL),(707,2216,4,'2021-01-09','0001-01-01',NULL),(708,2214,1,'2021-01-09','0001-01-01',NULL),(709,2209,3,'2021-01-09','0001-01-01',NULL),(710,2211,4,'2021-01-09','0001-01-01',NULL),(711,2193,3,'2021-01-09','0001-01-01',NULL),(712,2224,2,'2021-01-09','0001-01-01',NULL),(713,2196,1,'2021-01-09','0001-01-01',NULL),(714,2210,1,'2021-01-09','0001-01-01',NULL),(715,2607,14,'2021-01-09','0001-01-01',NULL),(716,2454,4,'2021-01-09','0001-01-01',NULL),(717,2485,2,'2021-01-09','0001-01-01',NULL),(718,2414,1,'2021-01-09','0001-01-01',NULL),(719,2309,5,'2021-01-09','0001-01-01',NULL),(720,2354,1,'2021-01-09','0001-01-01',NULL),(721,2359,2,'2021-01-09','0001-01-01',NULL),(722,2511,4,'2021-01-09','0001-01-01',NULL),(723,2310,3,'2021-01-09','0001-01-01',NULL),(724,2501,3,'2021-01-09','0001-01-01',NULL),(725,2430,3,'2021-01-09','0001-01-01',NULL),(726,2324,4,'2021-01-09','0001-01-01',NULL),(727,2325,2,'2021-01-09','0001-01-01',NULL),(728,2393,1,'2021-01-09','0001-01-01',NULL),(729,2394,7,'2021-01-09','0001-01-01',NULL),(730,2313,1,'2021-01-09','0001-01-01',NULL),(731,2327,2,'2021-01-09','0001-01-01',NULL),(732,2306,3,'2021-01-09','0001-01-01',NULL),(733,2440,1,'2021-01-09','0001-01-01',NULL),(734,2441,1,'2021-01-09','0001-01-01',NULL),(735,2502,2,'2021-01-09','0001-01-01',NULL),(736,2332,1,'2021-01-09','0001-01-01',NULL),(737,2330,2,'2021-01-09','0001-01-01',NULL),(738,2305,1,'2021-01-09','0001-01-01',NULL),(739,2389,2,'2021-01-09','0001-01-01',NULL),(740,2303,1,'2021-01-09','0001-01-01',NULL),(741,2304,1,'2021-01-09','0001-01-01',NULL),(742,2312,1,'2021-01-09','0001-01-01',NULL),(743,2311,3,'2021-01-09','0001-01-01',NULL),(744,2448,6,'2021-01-09','0001-01-01',NULL),(745,2450,5,'2021-01-09','0001-01-01',NULL),(746,2397,3,'2021-01-09','0001-01-01',NULL),(747,2572,2,'2021-01-10','0001-01-01',NULL),(748,2574,1,'2021-01-10','0001-01-01',NULL),(749,2582,3,'2021-01-10','0001-01-01',NULL),(750,2598,1,'2021-01-10','0001-01-01',NULL),(751,2579,1,'2021-01-10','0001-01-01',NULL),(752,2562,1,'2021-01-10','0001-01-01',NULL),(753,2652,1,'2021-01-10','0001-01-01',NULL),(754,2653,2,'2021-01-10','0001-01-01',NULL),(755,2601,2,'2021-01-10','0001-01-01',NULL),(756,2654,2,'2021-01-10','0001-01-01',NULL),(757,2604,1,'2021-01-10','0001-01-01',NULL),(758,2655,1,'2021-01-10','0001-01-01',NULL),(759,2596,1,'2021-01-10','0001-01-01',NULL),(760,2581,0,'2021-01-10','0001-01-01',NULL),(761,2577,2,'2021-01-10','0001-01-01',NULL),(762,2656,1,'2021-01-10','0001-01-01',NULL),(763,2550,2,'2021-01-10','0001-01-01',NULL),(764,2584,3,'2021-01-10','0001-01-01',NULL),(765,2551,2,'2021-01-10','0001-01-01',NULL),(766,2585,1,'2021-01-10','0001-01-01',NULL),(767,2552,2,'2021-01-10','0001-01-01',NULL),(768,2669,1,'2021-01-10','0001-01-01',NULL),(769,2670,1,'2021-01-10','0001-01-01',NULL),(770,2671,0,'2021-01-10','0001-01-01',NULL),(771,2668,1,'2021-01-10','0001-01-01',NULL),(772,2561,1,'2021-01-10','0001-01-01',NULL),(773,2556,2,'2021-01-10','0001-01-01',NULL),(774,2558,1,'2021-01-10','0001-01-01',NULL),(775,2557,1,'2021-01-10','0001-01-01',NULL),(776,2559,1,'2021-01-10','0001-01-01',NULL),(777,2658,2,'2021-01-10','0001-01-01',NULL),(778,2660,2,'2021-01-10','0001-01-01',NULL),(779,2667,1,'2021-01-10','0001-01-01',NULL),(780,2167,1,'2021-01-10','0001-01-01',NULL),(781,2662,1,'2021-01-10','0001-01-01',NULL),(782,2169,1,'2021-01-10','0001-01-01',NULL),(783,2666,1,'2021-01-10','0001-01-01',NULL),(784,2657,1,'2021-01-10','0001-01-01',NULL),(785,2661,1,'2021-01-10','0001-01-01',NULL),(786,2663,1,'2021-01-10','0001-01-01',NULL),(787,2659,2,'2021-01-10','0001-01-01',NULL),(788,2192,1,'2021-01-10','0001-01-01',NULL),(789,2191,1,'2021-01-10','0001-01-01',NULL),(790,2664,1,'2021-01-10','0001-01-01',NULL),(791,2161,1,'2021-01-10','0001-01-01',NULL),(792,2665,1,'2021-01-10','0001-01-01',NULL),(793,2178,1,'2021-01-10','0001-01-01',NULL),(794,2180,1,'2021-01-10','0001-01-01',NULL),(795,2179,1,'2021-01-10','0001-01-01',NULL),(796,2176,1,'2021-01-10','0001-01-01',NULL),(797,2182,1,'2021-01-10','0001-01-01',NULL),(798,2181,1,'2021-01-10','0001-01-01',NULL),(799,2676,1,'2021-01-10','0001-01-01',NULL),(800,2677,1,'2021-01-10','0001-01-01',NULL),(801,2672,1,'2021-01-10','0001-01-01',NULL),(802,2673,2,'2021-01-10','0001-01-01',NULL),(803,2674,1,'2021-01-10','0001-01-01',NULL),(804,2675,1,'2021-01-10','0001-01-01',NULL),(805,2678,4,'2021-01-10','0001-01-01',NULL),(806,2679,1,'2021-01-10','0001-01-01',NULL),(807,2682,60,'2021-01-10','0001-01-01',NULL),(808,2683,13,'2021-01-10','0001-01-01',NULL),(809,2681,18,'2021-01-10','0001-01-01',NULL),(810,2684,1,'2021-01-10','0001-01-01',NULL),(811,2685,1,'2021-01-10','0001-01-01',NULL),(812,2686,1,'2021-01-10','0001-01-01',NULL),(813,2243,2,'2021-01-10','0001-01-01',NULL),(814,2277,5,'2021-01-10','0001-01-01',NULL),(815,2709,3,'2021-01-10','0001-01-01',NULL),(816,2716,2,'2021-01-10','0001-01-01',NULL),(817,2707,2,'2021-01-10','0001-01-01',NULL),(818,2283,3,'2021-01-10','0001-01-01',NULL),(819,2279,3,'2021-01-10','0001-01-01',NULL),(820,2712,2,'2021-01-10','0001-01-01',NULL),(821,2715,3,'2021-01-10','0001-01-01',NULL),(822,2693,1,'2021-01-10','0001-01-01',NULL),(823,2275,1,'2021-01-10','0001-01-01',NULL),(824,2714,1,'2021-01-10','0001-01-01',NULL),(825,2724,1,'2021-01-10','0001-01-01',NULL),(826,2266,2,'2021-01-10','0001-01-01',NULL),(827,2286,1,'2021-01-10','0001-01-01',NULL),(828,2719,2,'2021-01-10','0001-01-01',NULL),(829,2290,2,'2021-01-10','0001-01-01',NULL),(830,2291,2,'2021-01-10','0001-01-01',NULL),(831,2284,2,'2021-01-10','0001-01-01',NULL),(832,2704,1,'2021-01-10','0001-01-01',NULL),(833,2264,2,'2021-01-10','0001-01-01',NULL),(834,2248,4,'2021-01-10','0001-01-01',NULL),(835,2261,1,'2021-01-10','0001-01-01',NULL),(836,2249,2,'2021-01-10','0001-01-01',NULL),(837,2254,2,'2021-01-10','0001-01-01',NULL),(838,2246,3,'2021-01-10','0001-01-01',NULL),(839,2250,2,'2021-01-10','0001-01-01',NULL),(840,2695,1,'2021-01-10','0001-01-01',NULL),(841,2258,2,'2021-01-10','0001-01-01',NULL),(842,2698,1,'2021-01-10','0001-01-01',NULL),(843,2699,1,'2021-01-10','0001-01-01',NULL),(844,2259,2,'2021-01-10','0001-01-01',NULL),(845,2701,1,'2021-01-10','0001-01-01',NULL),(846,2276,2,'2021-01-10','0001-01-01',NULL),(847,2257,2,'2021-01-10','0001-01-01',NULL),(848,2697,1,'2021-01-10','0001-01-01',NULL),(849,2702,2,'2021-01-10','0001-01-01',NULL),(850,2696,1,'2021-01-10','0001-01-01',NULL),(851,2252,2,'2021-01-10','0001-01-01',NULL),(852,2247,12,'2021-01-10','0001-01-01',NULL),(853,2703,1,'2021-01-10','0001-01-01',NULL),(854,2700,2,'2021-01-10','0001-01-01',NULL),(855,2737,1,'2021-01-11','0001-01-01',NULL),(856,2614,1,'2021-01-11','0001-01-01',NULL),(857,2615,1,'2021-01-11','0001-01-01',NULL),(858,2736,1,'2021-01-11','0001-01-01',NULL),(859,2733,1,'2021-01-11','0001-01-01',NULL),(860,2735,1,'2021-01-11','0001-01-01',NULL),(861,2734,1,'2021-01-11','0001-01-01',NULL),(862,2647,1,'2021-01-11','0001-01-01',NULL),(863,2626,2,'2021-01-11','0001-01-01',NULL),(864,2617,1,'2021-01-11','0001-01-01',NULL),(865,2608,2,'2021-01-11','0001-01-01',NULL),(866,2609,2,'2021-01-11','0001-01-01',NULL),(867,2623,1,'2021-01-11','0001-01-01',NULL),(868,2630,1,'2021-01-11','0001-01-01',NULL),(869,2632,1,'2021-01-11','0001-01-01',NULL),(870,2625,1,'2021-01-11','0001-01-01',NULL),(871,2732,1,'2021-01-11','0001-01-01',NULL),(872,2613,1,'2021-01-11','0001-01-01',NULL),(873,2616,1,'2021-01-11','0001-01-01',NULL);
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-11 13:48:28
