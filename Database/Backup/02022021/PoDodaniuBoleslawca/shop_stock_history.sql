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
) ENGINE=InnoDB AUTO_INCREMENT=304 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_history`
--

LOCK TABLES `stock_history` WRITE;
/*!40000 ALTER TABLE `stock_history` DISABLE KEYS */;
INSERT INTO `stock_history` VALUES (1,557,2,'2021-01-20 19:14:16'),(2,569,1,'2021-01-20 19:14:16'),(3,759,1,'2021-01-20 19:39:35'),(4,757,1,'2021-01-20 19:39:35'),(5,585,5,'2021-01-20 20:20:45'),(6,546,5,'2021-01-20 20:20:45'),(7,552,3,'2021-01-20 20:20:46'),(8,688,1,'2021-01-20 20:20:46'),(9,626,1,'2021-01-20 20:20:46'),(10,622,1,'2021-01-20 20:20:46'),(11,556,2,'2021-01-20 20:20:46'),(12,745,2,'2021-01-20 20:20:46'),(13,791,3,'2021-01-20 20:20:46'),(14,741,3,'2021-01-20 20:20:46'),(15,807,6,'2021-01-20 20:20:46'),(16,808,7,'2021-01-20 20:20:46'),(17,526,4,'2021-01-20 20:20:46'),(18,731,2,'2021-01-20 20:20:46'),(19,536,2,'2021-01-20 20:20:46'),(20,564,2,'2021-01-20 20:20:46'),(21,557,3,'2021-01-20 20:20:46'),(22,744,4,'2021-01-20 20:20:46'),(23,742,3,'2021-01-20 20:20:46'),(24,732,1,'2021-01-20 20:20:46'),(25,739,3,'2021-01-20 20:20:46'),(26,813,2,'2021-01-20 20:20:46'),(27,735,2,'2021-01-20 20:20:46'),(28,569,1,'2021-01-20 20:20:46'),(29,749,2,'2021-01-20 20:20:46'),(30,751,3,'2021-01-20 20:20:46'),(31,754,5,'2021-01-20 20:20:46'),(32,757,6,'2021-01-20 20:20:46'),(33,759,4,'2021-01-20 20:20:46'),(34,761,3,'2021-01-20 20:20:46'),(35,776,2,'2021-01-20 20:20:46'),(36,773,2,'2021-01-20 20:20:46'),(37,768,4,'2021-01-20 20:20:46'),(38,610,5,'2021-01-20 20:20:46'),(39,592,4,'2021-01-20 20:20:47'),(40,786,3,'2021-01-20 20:20:47'),(41,664,4,'2021-01-20 20:20:47'),(42,787,4,'2021-01-20 20:20:47'),(43,680,3,'2021-01-20 20:20:47'),(44,676,2,'2021-01-20 20:20:47'),(45,672,6,'2021-01-20 20:20:47'),(46,790,1,'2021-01-20 20:20:47'),(47,687,4,'2021-01-20 20:20:47'),(48,800,1,'2021-01-20 20:20:47'),(49,682,2,'2021-01-20 20:20:47'),(50,686,5,'2021-01-20 20:20:47'),(51,615,2,'2021-01-20 20:20:47'),(52,591,2,'2021-01-20 20:20:47'),(53,643,1,'2021-01-20 20:20:47'),(54,558,4,'2021-01-20 20:20:47'),(55,624,2,'2021-01-20 20:20:47'),(56,607,1,'2021-01-20 20:20:47'),(57,527,3,'2021-01-20 20:20:47'),(58,894,2,'2021-01-20 20:20:47'),(59,893,2,'2021-01-20 20:20:47'),(60,892,2,'2021-01-20 20:20:47'),(61,718,1,'2021-01-20 20:36:09'),(62,3318,7,'2021-01-20 20:36:09'),(63,3317,3,'2021-01-20 20:36:09'),(64,944,2,'2021-01-20 21:31:51'),(65,945,2,'2021-01-20 21:31:51'),(66,917,6,'2021-01-20 21:31:51'),(67,897,1,'2021-01-20 21:31:51'),(68,899,2,'2021-01-20 21:31:51'),(69,903,2,'2021-01-20 21:31:51'),(70,908,1,'2021-01-20 21:31:51'),(71,915,2,'2021-01-20 21:31:51'),(72,918,2,'2021-01-20 21:31:51'),(73,919,1,'2021-01-20 21:31:51'),(74,922,1,'2021-01-20 21:31:51'),(75,923,1,'2021-01-20 21:31:51'),(76,933,2,'2021-01-20 21:31:51'),(77,939,1,'2021-01-20 21:31:51'),(78,940,1,'2021-01-20 21:31:51'),(79,953,1,'2021-01-20 21:31:51'),(80,985,1,'2021-01-20 21:31:51'),(81,992,1,'2021-01-20 21:31:51'),(82,987,1,'2021-01-20 21:31:51'),(83,965,6,'2021-01-20 21:31:51'),(84,969,2,'2021-01-20 21:31:51'),(85,962,3,'2021-01-20 21:31:51'),(86,963,2,'2021-01-20 21:31:51'),(87,964,3,'2021-01-20 21:31:51'),(88,966,2,'2021-01-20 21:31:51'),(89,970,2,'2021-01-20 21:31:51'),(90,968,2,'2021-01-20 21:31:51'),(91,967,4,'2021-01-20 21:31:51'),(92,3319,2,'2021-01-20 21:35:42'),(93,327,2,'2021-01-23 16:15:11'),(94,330,2,'2021-01-23 16:15:11'),(95,335,2,'2021-01-23 16:15:11'),(96,345,1,'2021-01-23 16:15:11'),(97,351,2,'2021-01-23 16:15:11'),(98,355,2,'2021-01-23 16:15:11'),(99,356,3,'2021-01-23 16:15:11'),(100,414,1,'2021-01-23 16:15:11'),(101,360,5,'2021-01-23 16:15:11'),(102,363,6,'2021-01-23 16:15:11'),(103,399,1,'2021-01-23 16:15:11'),(104,402,1,'2021-01-23 16:15:11'),(105,360,-4,'2021-01-25 18:57:43'),(106,335,-1,'2021-01-25 19:00:23'),(107,361,5,'2021-01-25 19:03:25'),(108,3320,3,'2021-01-25 19:15:26'),(109,3321,1,'2021-01-25 20:41:50'),(110,3322,2,'2021-01-25 20:41:50'),(111,3323,2,'2021-01-25 20:41:50'),(112,3324,3,'2021-01-25 20:41:50'),(113,2601,1,'2021-01-25 20:41:50'),(114,2654,2,'2021-01-25 20:41:50'),(115,3325,2,'2021-01-25 20:41:50'),(116,3326,2,'2021-01-25 20:41:50'),(117,3327,2,'2021-01-25 20:41:50'),(118,3328,10,'2021-01-25 20:41:50'),(119,2596,1,'2021-01-25 20:41:50'),(120,3329,2,'2021-01-25 20:41:50'),(121,3330,1,'2021-01-25 20:41:50'),(122,3331,1,'2021-01-25 20:41:50'),(123,3332,5,'2021-01-25 20:41:50'),(124,2598,3,'2021-01-25 20:41:50'),(125,2572,2,'2021-01-25 20:41:50'),(126,2573,3,'2021-01-25 20:41:50'),(127,3333,1,'2021-01-25 20:41:51'),(128,3334,2,'2021-01-25 20:41:51'),(129,3335,1,'2021-01-25 20:41:51'),(130,3336,1,'2021-01-25 20:41:51'),(131,3337,2,'2021-01-25 20:41:51'),(132,2579,3,'2021-01-25 20:41:51'),(133,2581,6,'2021-01-25 20:41:51'),(134,2582,3,'2021-01-25 20:41:51'),(135,2655,1,'2021-01-25 20:41:51'),(136,3338,1,'2021-01-25 20:41:51'),(137,3339,3,'2021-01-25 20:41:51'),(138,1512,6,'2021-01-25 21:24:47'),(139,1514,1,'2021-01-25 21:24:47'),(140,1894,1,'2021-01-25 21:24:47'),(141,1443,1,'2021-01-25 21:24:47'),(142,1445,2,'2021-01-25 21:24:47'),(143,1513,1,'2021-01-25 21:24:47'),(144,1878,1,'2021-01-25 21:24:47'),(145,1872,1,'2021-01-25 21:24:47'),(146,1877,1,'2021-01-25 21:24:47'),(147,1882,1,'2021-01-25 21:24:48'),(148,1891,1,'2021-01-25 21:24:48'),(149,1890,1,'2021-01-25 21:24:48'),(150,1892,2,'2021-01-25 21:24:48'),(151,1846,6,'2021-01-25 21:24:48'),(152,1492,2,'2021-01-25 21:24:48'),(153,1474,1,'2021-01-25 21:24:48'),(154,1473,1,'2021-01-25 21:24:48'),(155,3340,6,'2021-01-25 21:24:48'),(156,72,6,'2021-01-26 16:44:53'),(157,3341,12,'2021-01-26 16:44:53'),(158,29,2,'2021-01-26 16:44:53'),(159,30,3,'2021-01-26 16:44:53'),(160,43,3,'2021-01-26 16:44:53'),(161,56,2,'2021-01-26 16:44:53'),(162,57,2,'2021-01-26 16:44:53'),(163,1526,2,'2021-01-28 18:37:16'),(164,1527,27,'2021-01-28 18:37:16'),(165,516,1,'2021-01-28 18:58:46'),(166,518,2,'2021-01-28 18:58:46'),(167,489,1,'2021-01-28 18:58:46'),(168,473,5,'2021-01-28 18:58:46'),(169,522,2,'2021-01-28 18:58:46'),(170,475,5,'2021-01-28 18:58:46'),(171,460,2,'2021-01-28 18:58:46'),(172,509,2,'2021-01-28 18:58:46'),(173,449,1,'2021-01-28 18:58:46'),(174,448,1,'2021-01-28 18:58:46'),(175,436,1,'2021-01-28 18:58:46'),(176,3342,1,'2021-02-02 18:20:36'),(177,3343,1,'2021-02-02 18:20:36'),(178,3344,1,'2021-02-02 18:20:36'),(179,3345,1,'2021-02-02 18:20:36'),(180,3346,1,'2021-02-02 18:20:36'),(181,3347,1,'2021-02-02 18:20:36'),(182,3348,1,'2021-02-02 18:20:36'),(183,3349,1,'2021-02-02 18:20:36'),(184,3350,1,'2021-02-02 18:20:36'),(185,3351,1,'2021-02-02 18:20:36'),(186,3352,1,'2021-02-02 18:20:36'),(187,3353,1,'2021-02-02 18:20:36'),(188,3353,2,'2021-02-02 18:20:36'),(189,3354,1,'2021-02-02 18:20:36'),(190,3355,1,'2021-02-02 18:20:36'),(191,3356,1,'2021-02-02 18:20:36'),(192,3357,1,'2021-02-02 18:20:36'),(193,3358,1,'2021-02-02 18:20:36'),(194,3359,1,'2021-02-02 18:20:36'),(195,3360,1,'2021-02-02 18:20:36'),(196,3361,1,'2021-02-02 18:20:36'),(197,3362,1,'2021-02-02 18:20:36'),(198,3363,4,'2021-02-02 18:20:36'),(199,3364,2,'2021-02-02 18:20:37'),(200,3365,1,'2021-02-02 18:20:37'),(201,3366,1,'2021-02-02 18:20:37'),(202,3367,1,'2021-02-02 18:20:37'),(203,3368,1,'2021-02-02 18:20:37'),(204,3369,1,'2021-02-02 18:20:37'),(205,3370,1,'2021-02-02 18:20:37'),(206,3371,1,'2021-02-02 18:20:37'),(207,3372,2,'2021-02-02 18:20:37'),(208,3373,2,'2021-02-02 18:20:37'),(209,3374,1,'2021-02-02 18:20:37'),(210,3375,1,'2021-02-02 18:20:37'),(211,3376,1,'2021-02-02 18:20:37'),(212,3377,1,'2021-02-02 18:20:37'),(213,3378,1,'2021-02-02 18:20:37'),(214,3379,1,'2021-02-02 18:20:37'),(215,3380,1,'2021-02-02 18:20:37'),(216,3381,1,'2021-02-02 18:20:37'),(217,3382,1,'2021-02-02 18:20:37'),(218,3382,2,'2021-02-02 18:20:37'),(219,3383,1,'2021-02-02 18:20:37'),(220,3384,1,'2021-02-02 18:20:37'),(221,3384,2,'2021-02-02 18:20:37'),(222,3385,1,'2021-02-02 18:20:37'),(223,3386,1,'2021-02-02 18:20:37'),(224,3387,1,'2021-02-02 18:20:37'),(225,3388,1,'2021-02-02 18:20:37'),(226,3389,1,'2021-02-02 18:20:37'),(227,3390,1,'2021-02-02 18:20:37'),(228,3391,1,'2021-02-02 18:20:37'),(229,3392,1,'2021-02-02 18:20:37'),(230,3393,1,'2021-02-02 18:20:37'),(231,3394,1,'2021-02-02 18:20:37'),(232,3395,1,'2021-02-02 18:20:37'),(233,3396,3,'2021-02-02 18:20:37'),(234,3397,1,'2021-02-02 18:20:37'),(235,3398,1,'2021-02-02 18:20:37'),(236,3399,1,'2021-02-02 18:20:37'),(237,3400,1,'2021-02-02 18:20:37'),(238,3401,4,'2021-02-02 18:20:37'),(239,3401,5,'2021-02-02 18:20:37'),(240,3402,2,'2021-02-02 18:20:37'),(241,3403,2,'2021-02-02 18:20:37'),(242,3404,1,'2021-02-02 18:20:37'),(243,3405,1,'2021-02-02 18:20:37'),(244,3405,2,'2021-02-02 18:20:38'),(245,3406,3,'2021-02-02 18:20:38'),(246,3407,1,'2021-02-02 18:20:38'),(247,3408,1,'2021-02-02 18:20:38'),(248,3409,1,'2021-02-02 18:20:38'),(249,3410,1,'2021-02-02 18:20:38'),(250,3411,1,'2021-02-02 18:20:38'),(251,3412,1,'2021-02-02 18:20:38'),(252,3413,1,'2021-02-02 18:20:38'),(253,3413,2,'2021-02-02 18:20:38'),(254,3414,2,'2021-02-02 18:20:38'),(255,3415,1,'2021-02-02 18:20:38'),(256,3416,1,'2021-02-02 18:20:38'),(257,3417,1,'2021-02-02 18:20:38'),(258,3418,1,'2021-02-02 18:20:38'),(259,3419,1,'2021-02-02 18:20:38'),(260,3419,2,'2021-02-02 18:20:38'),(261,3420,1,'2021-02-02 18:20:38'),(262,3421,6,'2021-02-02 18:20:38'),(263,3422,1,'2021-02-02 18:20:38'),(264,3422,2,'2021-02-02 18:20:38'),(265,3423,1,'2021-02-02 18:20:38'),(266,3424,2,'2021-02-02 18:20:38'),(267,3425,2,'2021-02-02 18:20:38'),(268,3426,4,'2021-02-02 18:20:38'),(269,3426,6,'2021-02-02 18:20:38'),(270,3427,1,'2021-02-02 18:20:38'),(271,3428,2,'2021-02-02 18:20:38'),(272,3429,2,'2021-02-02 18:20:38'),(273,3430,5,'2021-02-02 18:20:38'),(274,3431,1,'2021-02-02 18:20:38'),(275,3432,1,'2021-02-02 18:20:38'),(276,3433,2,'2021-02-02 18:20:38'),(277,3434,1,'2021-02-02 18:20:38'),(278,3435,2,'2021-02-02 18:20:38'),(279,3436,3,'2021-02-02 18:20:38'),(280,3437,1,'2021-02-02 18:20:38'),(281,3438,1,'2021-02-02 18:20:38'),(282,3439,1,'2021-02-02 18:20:38'),(283,3440,1,'2021-02-02 18:20:38'),(284,3441,2,'2021-02-02 18:20:38'),(285,3442,1,'2021-02-02 18:20:38'),(286,3443,1,'2021-02-02 18:20:38'),(287,3444,2,'2021-02-02 18:20:39'),(288,3445,1,'2021-02-02 18:20:39'),(289,3446,1,'2021-02-02 18:20:39'),(290,3447,1,'2021-02-02 18:20:39'),(291,3448,1,'2021-02-02 18:20:39'),(292,3449,1,'2021-02-02 18:20:39'),(293,3450,1,'2021-02-02 18:20:39'),(294,3451,1,'2021-02-02 18:20:39'),(295,3452,1,'2021-02-02 18:20:39'),(296,3453,2,'2021-02-02 18:20:39'),(297,3454,1,'2021-02-02 18:20:39'),(298,3455,1,'2021-02-02 18:20:39'),(299,3456,1,'2021-02-02 18:20:39'),(300,3457,1,'2021-02-02 18:20:39'),(301,3428,5,'2021-02-02 22:49:38'),(302,3424,5,'2021-02-02 22:49:38'),(303,3458,2,'2021-02-02 22:54:19');
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

-- Dump completed on 2021-02-02 22:56:29