-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: project_db
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `therapy`
--

DROP TABLE IF EXISTS `therapy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `therapy` (
  `TransactionID` int(11) NOT NULL,
  `ClientID` int(11) DEFAULT NULL,
  `WorkerID` int(11) DEFAULT NULL,
  `SpaID` int(11) DEFAULT NULL,
  `TherapyType` varchar(45) DEFAULT NULL,
  `TherapyTime` int(11) DEFAULT NULL,
  `TherapyDate` varchar(45) DEFAULT NULL,
  `Price` int(11) DEFAULT NULL,
  `Payment` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`TransactionID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `therapy`
--

LOCK TABLES `therapy` WRITE;
/*!40000 ALTER TABLE `therapy` DISABLE KEYS */;
INSERT INTO `therapy` VALUES (1,3,5,11,'Acupuncture',45,'04/14/2018',250,'Cash'),(2,6,1,6,'Swedish Massage',45,'05/22/2018',200,'Visa'),(3,8,7,17,'Medical Massage',60,'03/15/2018',270,'Isracard'),(4,2,9,15,'Hot Stones Massage',45,'04/02/2018',250,'Diners'),(5,10,2,4,'Swedish Massage',90,'05/05/2018',300,'Diners'),(6,12,10,8,'Thai Massage',60,'01/13/2018',220,'Visa'),(7,1,14,2,'Thai Massage',45,'09/03/2018',250,'Cash'),(8,9,6,13,'Acupuncture',60,'02/27/2018',300,'Diners'),(9,1,2,3,'Swedish Massage',60,'01/01/2018',250,'Cash'),(10,5,13,14,'Medical Massage',45,'04/30/2018',220,'Visa');
/*!40000 ALTER TABLE `therapy` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-13 15:58:49
