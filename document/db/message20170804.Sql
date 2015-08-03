/*
SQLyog Ultimate v11.24 (32 bit)
MySQL - 5.6.25-log : Database - movehouse
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`movehouse` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `movehouse`;

/*Table structure for table `bidinfo` */

DROP TABLE IF EXISTS `bidinfo`;

CREATE TABLE `bidinfo` (
  `BidID` int(11) NOT NULL AUTO_INCREMENT,
  `MsgID` int(11) DEFAULT NULL,
  `BidUID` varchar(50) DEFAULT NULL,
  `avg1` varchar(5) DEFAULT NULL,
  `avg2` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`BidID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `bidinfo` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
