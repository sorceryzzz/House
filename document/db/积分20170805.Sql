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

/*Table structure for table `t_mfg_ScoreTypeInfo` */

DROP TABLE IF EXISTS `t_mfg_ScoreTypeInfo`;

CREATE TABLE `t_mfg_ScoreTypeInfo` (
  `f_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `f_ScoreTypeName` varchar(15) NOT NULL COMMENT '积分类别名称',
  `avg1` varchar(10) DEFAULT NULL COMMENT '扩展字段',
  `avg2` varchar(10) DEFAULT NULL COMMENT '扩展字段',
  `f_InsertTime` datetime NOT NULL COMMENT '记录生成时间',
  `f_UpdateTime` datetime NOT NULL COMMENT '记录更新时间',
  PRIMARY KEY (`f_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `t_mfg_ScoreTypeInfo` */

insert  into `t_mfg_ScoreTypeInfo`(`f_ID`,`f_ScoreTypeName`,`avg1`,`avg2`,`f_InsertTime`,`f_UpdateTime`) values (1,'作业得分','','','0000-00-00 00:00:00','0000-00-00 00:00:00'),(2,'附加题得分','','','0000-00-00 00:00:00','0000-00-00 00:00:00'),(3,'竞赛机会兑换','','','0000-00-00 00:00:00','0000-00-00 00:00:00'),(4,'竞赛得分','','','0000-00-00 00:00:00','0000-00-00 00:00:00'),(5,'错题重练','','','0000-00-00 00:00:00','0000-00-00 00:00:00');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
