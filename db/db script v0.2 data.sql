CREATE DATABASE  IF NOT EXISTS `dbloginclaims` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `dbloginclaims`;
-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: dbloginclaims
-- ------------------------------------------------------
-- Server version	5.7.27-log

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
-- Table structure for table `claims`
--

DROP TABLE IF EXISTS `claims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `claims` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DisplayName` varchar(100) NOT NULL,
  `Content` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `claims`
--

LOCK TABLES `claims` WRITE;
/*!40000 ALTER TABLE `claims` DISABLE KEYS */;
INSERT INTO `claims` VALUES (18,'Home','HomePolicy'),(19,'View 1','View1Policy'),(20,'View 2','View2Policy'),(21,'View 3','View3Policy'),(22,'View 4','View4Policy'),(23,'View 5','View5Policy'),(24,'View 6','View6Policy'),(25,'User List','UserListPolicy'),(26,'User View','UserViewPolicy'),(27,'User Add','UserAddPolicy'),(28,'User Edit','UserEditPolicy'),(29,'User Delete','UserDeletePolicy'),(30,'Rol List','RolListPolicy'),(31,'Rol View','RolViewPolicy'),(32,'Rol Add','RolAddPolicy'),(33,'Rol Edit','RolEditPolicy'),(34,'Rol Delete','RolDeletePolicy'),(35,'Claims List','ClaimsListPolicy'),(36,'Claims View','ClaimsViewPolicy'),(37,'Claims Add','ClaimsAddPolicy'),(38,'Claims Edit','ClaimsEditPolicy'),(39,'Claims Delete','ClaimsDeletePolicy'),(40,'RolClaims List','RolClaimsListPolicy'),(41,'RolClaims View','RolClaimsViewPolicy'),(42,'RolClaims Add','RolClaimsAddPolicy'),(43,'RolClaims Edit','RolClaimsEditPolicy'),(44,'RolClaims Delete','RolClaimsDeletePolicy'),(45,'Rol ManageRolClaims','RolManageRolClaimsPolicy'),(46,'Rol AddRolClaims','RolAddRolClaimsPolicy'),(47,'Rol DeleteRolClaims','RolDeleteRolClaimsPolicy'),(48,'StartPage List','StartPageListPolicy'),(49,'StartPage View','StartPageViewPolicy'),(50,'StartPage Add','StartPageAddPolicy'),(51,'StartPage Edit','StartPageEditPolicy'),(52,'StartPage Delete','StartPageDeletePolicy'),(53,'AreaAdmin Home','AreaAdminPolicy');
/*!40000 ALTER TABLE `claims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rol` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `idStartPage` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_rol_startpage1_idx` (`idStartPage`),
  CONSTRAINT `fk_rol_startpage1` FOREIGN KEY (`idStartPage`) REFERENCES `startpage` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (6,'administrator',5),(7,'moderator',1),(8,'user',2),(9,'user2',4);
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolclaims`
--

DROP TABLE IF EXISTS `rolclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rolclaims` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `idRol` int(11) NOT NULL,
  `idClaims` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_rol_has_claim_rol_idx` (`idRol`),
  KEY `fk_rolclaims_claims1_idx` (`idClaims`),
  CONSTRAINT `fk_rol_has_claim_rol` FOREIGN KEY (`idRol`) REFERENCES `rol` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rolclaims_claims1` FOREIGN KEY (`idClaims`) REFERENCES `claims` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolclaims`
--

LOCK TABLES `rolclaims` WRITE;
/*!40000 ALTER TABLE `rolclaims` DISABLE KEYS */;
INSERT INTO `rolclaims` VALUES (21,6,18),(22,6,19),(23,6,20),(24,6,21),(25,6,22),(26,6,23),(27,6,24),(28,6,25),(29,6,26),(30,6,27),(31,6,28),(32,6,29),(33,6,30),(34,6,31),(35,6,32),(36,6,33),(37,6,34),(38,6,35),(39,6,36),(40,6,37),(41,6,38),(42,6,39),(43,6,40),(44,6,41),(45,6,42),(46,6,43),(47,6,44),(48,6,45),(49,6,46),(50,6,47),(51,7,18),(52,7,19),(53,7,20),(54,7,21),(55,7,22),(56,7,23),(57,7,24),(58,7,25),(59,7,30),(60,7,35),(61,7,40),(62,7,45),(63,8,18),(64,8,19),(65,8,20),(66,8,21),(67,9,18),(69,9,19),(70,6,48),(71,6,49),(72,6,50),(73,6,51),(74,6,52),(75,6,53);
/*!40000 ALTER TABLE `rolclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `startpage`
--

DROP TABLE IF EXISTS `startpage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `startpage` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Url` varchar(300) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `startpage`
--

LOCK TABLES `startpage` WRITE;
/*!40000 ALTER TABLE `startpage` DISABLE KEYS */;
INSERT INTO `startpage` VALUES (1,'Home','/Home'),(2,'Test 1','/Home/Test1'),(3,'Test 2','/Home/Test2'),(4,'Test 3','/Home/Test3'),(5,'Admin Home','/Admin/Home');
/*!40000 ALTER TABLE `startpage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `idRol` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_user_rol1_idx` (`idRol`),
  CONSTRAINT `fk_user_rol1` FOREIGN KEY (`idRol`) REFERENCES `rol` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (4,'useradministrator','password','Administrator',6),(5,'usermoderator','password','User Moderator',7),(6,'user','password','User normal',8),(7,'user2','password','User normal 2',9);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'dbloginclaims'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-02 23:02:09
