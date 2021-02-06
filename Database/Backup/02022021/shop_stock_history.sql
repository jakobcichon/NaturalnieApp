CREATE DATABASE  IF NOT EXISTS `shop` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `shop`;
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
-- Table structure for table `stock_history`
--

DROP TABLE IF EXISTS `stock_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock_history` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProductId` int NOT NULL,
  `Quantity` int NOT NULL,
  `DateAndTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=176 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_history`
--

LOCK TABLES `stock_history` WRITE;
/*!40000 ALTER TABLE `stock_history` DISABLE KEYS */;
INSERT INTO `stock_history` VALUES (1,557,2,'2021-01-20 19:14:16'),(2,569,1,'2021-01-20 19:14:16'),(3,759,1,'2021-01-20 19:39:35'),(4,757,1,'2021-01-20 19:39:35'),(5,585,5,'2021-01-20 20:20:45'),(6,546,5,'2021-01-20 20:20:45'),(7,552,3,'2021-01-20 20:20:46'),(8,688,1,'2021-01-20 20:20:46'),(9,626,1,'2021-01-20 20:20:46'),(10,622,1,'2021-01-20 20:20:46'),(11,556,2,'2021-01-20 20:20:46'),(12,745,2,'2021-01-20 20:20:46'),(13,791,3,'2021-01-20 20:20:46'),(14,741,3,'2021-01-20 20:20:46'),(15,807,6,'2021-01-20 20:20:46'),(16,808,7,'2021-01-20 20:20:46'),(17,526,4,'2021-01-20 20:20:46'),(18,731,2,'2021-01-20 20:20:46'),(19,536,2,'2021-01-20 20:20:46'),(20,564,2,'2021-01-20 20:20:46'),(21,557,3,'2021-01-20 20:20:46'),(22,744,4,'2021-01-20 20:20:46'),(23,742,3,'2021-01-20 20:20:46'),(24,732,1,'2021-01-20 20:20:46'),(25,739,3,'2021-01-20 20:20:46'),(26,813,2,'2021-01-20 20:20:46'),(27,735,2,'2021-01-20 20:20:46'),(28,569,1,'2021-01-20 20:20:46'),(29,749,2,'2021-01-20 20:20:46'),(30,751,3,'2021-01-20 20:20:46'),(31,754,5,'2021-01-20 20:20:46'),(32,757,6,'2021-01-20 20:20:46'),(33,759,4,'2021-01-20 20:20:46'),(34,761,3,'2021-01-20 20:20:46'),(35,776,2,'2021-01-20 20:20:46'),(36,773,2,'2021-01-20 20:20:46'),(37,768,4,'2021-01-20 20:20:46'),(38,610,5,'2021-01-20 20:20:46'),(39,592,4,'2021-01-20 20:20:47'),(40,786,3,'2021-01-20 20:20:47'),(41,664,4,'2021-01-20 20:20:47'),(42,787,4,'2021-01-20 20:20:47'),(43,680,3,'2021-01-20 20:20:47'),(44,676,2,'2021-01-20 20:20:47'),(45,672,6,'2021-01-20 20:20:47'),(46,790,1,'2021-01-20 20:20:47'),(47,687,4,'2021-01-20 20:20:47'),(48,800,1,'2021-01-20 20:20:47'),(49,682,2,'2021-01-20 20:20:47'),(50,686,5,'2021-01-20 20:20:47'),(51,615,2,'2021-01-20 20:20:47'),(52,591,2,'2021-01-20 20:20:47'),(53,643,1,'2021-01-20 20:20:47'),(54,558,4,'2021-01-20 20:20:47'),(55,624,2,'2021-01-20 20:20:47'),(56,607,1,'2021-01-20 20:20:47'),(57,527,3,'2021-01-20 20:20:47'),(58,894,2,'2021-01-20 20:20:47'),(59,893,2,'2021-01-20 20:20:47'),(60,892,2,'2021-01-20 20:20:47'),(61,718,1,'2021-01-20 20:36:09'),(62,3318,7,'2021-01-20 20:36:09'),(63,3317,3,'2021-01-20 20:36:09'),(64,944,2,'2021-01-20 21:31:51'),(65,945,2,'2021-01-20 21:31:51'),(66,917,6,'2021-01-20 21:31:51'),(67,897,1,'2021-01-20 21:31:51'),(68,899,2,'2021-01-20 21:31:51'),(69,903,2,'2021-01-20 21:31:51'),(70,908,1,'2021-01-20 21:31:51'),(71,915,2,'2021-01-20 21:31:51'),(72,918,2,'2021-01-20 21:31:51'),(73,919,1,'2021-01-20 21:31:51'),(74,922,1,'2021-01-20 21:31:51'),(75,923,1,'2021-01-20 21:31:51'),(76,933,2,'2021-01-20 21:31:51'),(77,939,1,'2021-01-20 21:31:51'),(78,940,1,'2021-01-20 21:31:51'),(79,953,1,'2021-01-20 21:31:51'),(80,985,1,'2021-01-20 21:31:51'),(81,992,1,'2021-01-20 21:31:51'),(82,987,1,'2021-01-20 21:31:51'),(83,965,6,'2021-01-20 21:31:51'),(84,969,2,'2021-01-20 21:31:51'),(85,962,3,'2021-01-20 21:31:51'),(86,963,2,'2021-01-20 21:31:51'),(87,964,3,'2021-01-20 21:31:51'),(88,966,2,'2021-01-20 21:31:51'),(89,970,2,'2021-01-20 21:31:51'),(90,968,2,'2021-01-20 21:31:51'),(91,967,4,'2021-01-20 21:31:51'),(92,3319,2,'2021-01-20 21:35:42'),(93,327,2,'2021-01-23 16:15:11'),(94,330,2,'2021-01-23 16:15:11'),(95,335,2,'2021-01-23 16:15:11'),(96,345,1,'2021-01-23 16:15:11'),(97,351,2,'2021-01-23 16:15:11'),(98,355,2,'2021-01-23 16:15:11'),(99,356,3,'2021-01-23 16:15:11'),(100,414,1,'2021-01-23 16:15:11'),(101,360,5,'2021-01-23 16:15:11'),(102,363,6,'2021-01-23 16:15:11'),(103,399,1,'2021-01-23 16:15:11'),(104,402,1,'2021-01-23 16:15:11'),(105,360,-4,'2021-01-25 18:57:43'),(106,335,-1,'2021-01-25 19:00:23'),(107,361,5,'2021-01-25 19:03:25'),(108,3320,3,'2021-01-25 19:15:26'),(109,3321,1,'2021-01-25 20:41:50'),(110,3322,2,'2021-01-25 20:41:50'),(111,3323,2,'2021-01-25 20:41:50'),(112,3324,3,'2021-01-25 20:41:50'),(113,2601,1,'2021-01-25 20:41:50'),(114,2654,2,'2021-01-25 20:41:50'),(115,3325,2,'2021-01-25 20:41:50'),(116,3326,2,'2021-01-25 20:41:50'),(117,3327,2,'2021-01-25 20:41:50'),(118,3328,10,'2021-01-25 20:41:50'),(119,2596,1,'2021-01-25 20:41:50'),(120,3329,2,'2021-01-25 20:41:50'),(121,3330,1,'2021-01-25 20:41:50'),(122,3331,1,'2021-01-25 20:41:50'),(123,3332,5,'2021-01-25 20:41:50'),(124,2598,3,'2021-01-25 20:41:50'),(125,2572,2,'2021-01-25 20:41:50'),(126,2573,3,'2021-01-25 20:41:50'),(127,3333,1,'2021-01-25 20:41:51'),(128,3334,2,'2021-01-25 20:41:51'),(129,3335,1,'2021-01-25 20:41:51'),(130,3336,1,'2021-01-25 20:41:51'),(131,3337,2,'2021-01-25 20:41:51'),(132,2579,3,'2021-01-25 20:41:51'),(133,2581,6,'2021-01-25 20:41:51'),(134,2582,3,'2021-01-25 20:41:51'),(135,2655,1,'2021-01-25 20:41:51'),(136,3338,1,'2021-01-25 20:41:51'),(137,3339,3,'2021-01-25 20:41:51'),(138,1512,6,'2021-01-25 21:24:47'),(139,1514,1,'2021-01-25 21:24:47'),(140,1894,1,'2021-01-25 21:24:47'),(141,1443,1,'2021-01-25 21:24:47'),(142,1445,2,'2021-01-25 21:24:47'),(143,1513,1,'2021-01-25 21:24:47'),(144,1878,1,'2021-01-25 21:24:47'),(145,1872,1,'2021-01-25 21:24:47'),(146,1877,1,'2021-01-25 21:24:47'),(147,1882,1,'2021-01-25 21:24:48'),(148,1891,1,'2021-01-25 21:24:48'),(149,1890,1,'2021-01-25 21:24:48'),(150,1892,2,'2021-01-25 21:24:48'),(151,1846,6,'2021-01-25 21:24:48'),(152,1492,2,'2021-01-25 21:24:48'),(153,1474,1,'2021-01-25 21:24:48'),(154,1473,1,'2021-01-25 21:24:48'),(155,3340,6,'2021-01-25 21:24:48'),(156,72,6,'2021-01-26 16:44:53'),(157,3341,12,'2021-01-26 16:44:53'),(158,29,2,'2021-01-26 16:44:53'),(159,30,3,'2021-01-26 16:44:53'),(160,43,3,'2021-01-26 16:44:53'),(161,56,2,'2021-01-26 16:44:53'),(162,57,2,'2021-01-26 16:44:53'),(163,1526,2,'2021-01-28 18:37:16'),(164,1527,27,'2021-01-28 18:37:16'),(165,516,1,'2021-01-28 18:58:46'),(166,518,2,'2021-01-28 18:58:46'),(167,489,1,'2021-01-28 18:58:46'),(168,473,5,'2021-01-28 18:58:46'),(169,522,2,'2021-01-28 18:58:46'),(170,475,5,'2021-01-28 18:58:46'),(171,460,2,'2021-01-28 18:58:46'),(172,509,2,'2021-01-28 18:58:46'),(173,449,1,'2021-01-28 18:58:46'),(174,448,1,'2021-01-28 18:58:46'),(175,436,1,'2021-01-28 18:58:46');
/*!40000 ALTER TABLE `stock_history` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-02-02 17:54:13