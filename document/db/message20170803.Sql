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

/*Table structure for table `userinfo` */

DROP TABLE IF EXISTS `userinfo`;

CREATE TABLE `userinfo` (
  `ID` varchar(50) NOT NULL COMMENT '主键',
  `UserName` varchar(25) NOT NULL COMMENT '用户名',
  `Pwd` varchar(50) NOT NULL COMMENT '密码',
  `Mail` varchar(50) NOT NULL COMMENT '邮箱',
  `Mobile` varchar(20) NOT NULL COMMENT '手机号',
  `RegisterLogin` datetime DEFAULT NULL COMMENT '注册时间',
  `LastLogin` datetime DEFAULT NULL COMMENT '最后登录时间',
  `avg1` varchar(5) DEFAULT NULL COMMENT '扩展字段1',
  `avg2` varchar(5) DEFAULT NULL COMMENT '扩展字段2',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `userinfo` */

insert  into `userinfo`(`ID`,`UserName`,`Pwd`,`Mail`,`Mobile`,`RegisterLogin`,`LastLogin`,`avg1`,`avg2`) values ('aa897dd5-f352-4395-8fd5-250cba00598d','sorcery','D79UcuRhO9UARUUEGsQ0zw==','sorcery.zzz@gmail.com','15801373672','2015-08-03 15:02:50','2015-08-03 15:02:50','','');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
