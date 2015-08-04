/*
SQLyog Ultimate v11.24 (32 bit)
MySQL - 5.6.24 : Database - mfg_campus
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`mfg_campus` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `mfg_campus`;

/*Table structure for table `t_mfg_SocreInfo` */

DROP TABLE IF EXISTS `t_mfg_SocreInfo`;

CREATE TABLE `t_mfg_SocreInfo` (
  `f_ID` int(15) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `f_UID` int(11) NOT NULL COMMENT '用户ID',
  `f_ScoreTypeID` int(5) NOT NULL COMMENT '积分类别',
  `f_Score` int(11) NOT NULL DEFAULT '0' COMMENT '积分值',
  `f_InsertTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '记录生成时间',
  `f_UpdateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '记录更新时间',
  `avg1` varchar(10) DEFAULT '' COMMENT '扩展字段',
  `avg2` varchar(10) DEFAULT '' COMMENT '扩展字段',
  PRIMARY KEY (`f_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

/*Data for the table `t_mfg_SocreInfo` */

insert  into `t_mfg_SocreInfo`(`f_ID`,`f_UID`,`f_ScoreTypeID`,`f_Score`,`f_InsertTime`,`f_UpdateTime`,`avg1`,`avg2`) values (1,60008000,1,73,'2015-07-18 15:12:42','2015-07-30 10:51:03','',''),(2,60008000,2,20,'2015-07-18 15:12:42','2015-07-18 15:12:42','',''),(3,60008000,3,50,'2015-07-18 15:12:42','2015-07-18 15:12:42','',''),(4,60008000,4,55,'2015-07-18 15:12:42','2015-07-18 15:12:42','',''),(5,60008000,5,56,'2015-07-18 15:12:42','2015-07-18 15:12:42','',''),(6,60041376,1,28,'2015-08-03 21:31:36','2015-08-03 21:31:36','',''),(7,60041376,2,20,'2015-08-03 21:33:13','2015-08-03 21:33:13','',''),(8,60041376,3,-20,'2015-08-03 21:35:24','2015-08-03 21:35:24','','');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
