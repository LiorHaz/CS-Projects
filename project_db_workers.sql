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
-- Table structure for table `workers`
--

DROP TABLE IF EXISTS `workers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `workers` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `Sex` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `Specialty` varchar(45) DEFAULT NULL,
  `Seniority` varchar(45) DEFAULT NULL,
  `Salary` int(11) DEFAULT NULL,
  `Spa` int(11) DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workers`
--

LOCK TABLES `workers` WRITE;
/*!40000 ALTER TABLE `workers` DISABLE KEYS */;
INSERT INTO `workers` VALUES (1,'Lior','Hazael','Male','Tel-Aviv','Masseur','5',10500,3,26),(2,'Avi','Cohen','Male','Haifa','Holistic Therapist','12',13400,5,31),(3,'Osnat','Keinan','Female','Beer-Sheva','Reflexologist','9',13500,1,37),(4,'Ehud','Kaplinsky','Male','Ramat-Gan','Reflexologist','20',23540,8,45),(5,'Omer','Malul','Male','Ashdod','Masseur','9',11300,12,27),(6,'Neta','Or','Female','Givataim','Holistic Therapist','20',21000,7,52),(7,'Hagit','Baron','Female','Ashkelon','Reflexologist','5',9100,6,34),(8,'Ron','Hemo','Male','Hertzelia','Manager','25',30340,15,42),(9,'Shimon','Hasuri','Male','Jaffa','Reflexologist','17',27800,17,47),(10,'Albert','Habakbuk','Male','Ramla','Holistic Therapist','14',15300,4,49),(11,'Shir','Tal','Female','Rehovot','Masseur','4',9800,2,28),(12,'Eli','Hofman','Male','Raanana','Manager','20',26540,10,48),(13,'Avi','Uzan','Male','Sderot','Massuer','2',7000,14,28);
/*!40000 ALTER TABLE `workers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-13 15:58:48
