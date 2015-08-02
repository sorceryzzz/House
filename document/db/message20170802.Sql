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

/*Table structure for table `orderinfo` */

DROP TABLE IF EXISTS `orderinfo`;

CREATE TABLE `orderinfo` (
  `OrderID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `UID` varchar(20) DEFAULT NULL COMMENT '搬家人UID',
  `SpcUID` varchar(20) DEFAULT NULL COMMENT '专人UID',
  `MvhStarAddr` varchar(255) DEFAULT NULL COMMENT '原地址',
  `MvhEndAddr` varchar(255) DEFAULT NULL COMMENT '目的地址',
  `Cost` decimal(10,0) DEFAULT NULL COMMENT '花费',
  `CarTypeInfoID` int(11) DEFAULT NULL COMMENT '车型ID',
  `IsHelpMvh` int(11) DEFAULT NULL COMMENT '是否需要帮助搬家(0:不需要,1:需要)',
  `InsertTime` datetime DEFAULT NULL COMMENT '记录生成时间',
  `UpdateTime` datetime DEFAULT NULL COMMENT '记录更新时间',
  `avg1` varchar(5) DEFAULT NULL COMMENT '扩展字段1',
  `avg2` varchar(5) DEFAULT NULL COMMENT '扩展字段2',
  PRIMARY KEY (`OrderID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `orderinfo` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
