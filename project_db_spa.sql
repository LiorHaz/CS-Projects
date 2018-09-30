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
-- Table structure for table `spa`
--

DROP TABLE IF EXISTS `spa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spa` (
  `SpaID` int(11) NOT NULL,
  `SpaName` varchar(45) DEFAULT NULL,
  `Region` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `PhoneNumber` varchar(45) DEFAULT NULL,
  `Rating` int(11) DEFAULT NULL,
  PRIMARY KEY (`SpaID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spa`
--

LOCK TABLES `spa` WRITE;
/*!40000 ALTER TABLE `spa` DISABLE KEYS */;
INSERT INTO `spa` VALUES (1,'Alma','North','Zichron-Yaakov','044582396',7),(2,'Village','North','Hamat-Gader','042547854',8),(3,'Yaarot-Hacarmel','North','Haifa','044478558',9),(4,'Pastoral','North','Kfar-Blum','049967778',9),(5,'Bazelet','North','Tiberias','045558221',7),(6,'Mariss','North','Kiryat-Yam','041178634',5),(7,'Kessem','Center','Or-Yehuda','035428447',6),(8,'Ahuza','Center','Rehovot','036966545',7),(9,'Villa','Center','Tel-Aviv','038255893',8),(10,'Butik','Center','Tel-Aviv','032288747',9),(11,'555','Center','Rishon-LeTzion','035455478',10),(12,'House','Center','Petach-Tikva','033336863',7),(13,'Klarity','Center','Ramat-Gan','037874473',8),(14,'Marok','Center','Kfar-Saba','098588963',7),(15,'Olympus','South','Beer-Sheva','085855872',5),(16,'Lido','South','Beer-Sheva','085568742',6),(17,'Garden','South','Ashkelon','088587968',9),(18,'Hamelech','South','Ashdod','085447821',7),(19,'Royal','South','Eilat','082255456',10);
/*!40000 ALTER TABLE `spa` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-13 15:58:47
