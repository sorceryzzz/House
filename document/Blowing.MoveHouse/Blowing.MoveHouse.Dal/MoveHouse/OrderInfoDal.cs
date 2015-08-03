using Blowing.MoveHouse.Common;
using Blowing.MoveHouse.Model.MoveHouse;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Dal.MoveHouse
{
  public  class OrderInfoDal
  {
      public OrderInfoDal() { }



      #region - method -
      /// <summary>
      /// 记录订单信息
      /// </summary>
      /// <param name="orInfo">订单信息</param>
      /// <returns>结果</returns>
      public int InsertOrderInfo(OrderInfoModel  orInfo)
      {
          int resultInt = 0;

          #region - qy -
          string inserQy = @"INSERT INTO `movehouse`.`orderinfo`
                            (
                             `UID`,
                             `SpcUID`,
                             `MvhStarAddr`,
                             `MvhEndAddr`,
                             `Cost`,
                             `CarTypeInfoID`,
                             `IsHelpMvh`,
                             `InsertTime`,
                             `UpdateTime`,
                             `avg1`,
                             `avg2`)
                             VALUES 
                             (
                               @UID,
                               @SpcUID,
                               @MvhStarAddr,
                               @MvhEndAddr,
                               @Cost,
                               @CarTypeInfoID,
                               @IsHelpMvh,
                               @InsertTime,
                               @UpdateTime,
                               @avg1,
                               @avg2);";
          #endregion

          #region - paras -
          MySqlParameter[] paras = 
           {
               new MySqlParameter("@UID",orInfo.UID),
               new MySqlParameter("@SpcUID",orInfo.SpcUID),
               new MySqlParameter("@MvhStarAddr",orInfo.MvhStarAddr),
               new MySqlParameter("@MvhEndAddr",orInfo.MvhEndAddr),
               new MySqlParameter("@Cost",orInfo.Cost),
               new MySqlParameter("@CarTypeInfoID",orInfo.CarTypeInfoID),
               new MySqlParameter("@IsHelpMvh",orInfo.IsHelpMvh),
               new MySqlParameter("@InsertTime",orInfo.InsertTime),
               new MySqlParameter("@UpdateTime",orInfo.UpdateTime),
                new MySqlParameter("@avg1",string.Empty),
               new MySqlParameter("@avg2",string.Empty)
           };
          #endregion

          #region - Excute -
          try
          {
              resultInt = Convert.ToInt32(DbHelperMySql.ExecuteNonQuery(DbHelperMySql.connectionStringManager, System.Data.CommandType.Text, inserQy, paras));
          }
          catch (Exception ex)
          {
              //记录错误信息

              throw;
          }
          #endregion

          return resultInt;
      }
      /// <summary>
      /// 获取订单信息
      /// </summary>
      /// <param name="orderID">订单主键</param>
      /// <returns>订单信息</returns>
      public OrderInfoModel GetOrInfoByID(string orderID)
      {
          OrderInfoModel orInfoModel = new OrderInfoModel();

          #region - sql qy -
          string selectQy = @"SELECT
                                `OrderID`,
                                `UID`,
                                `SpcUID`,
                                `MvhStarAddr`,
                                `MvhEndAddr`,
                                `Cost`,
                                `CarTypeInfoID`,
                                `IsHelpMvh`,
                                `InsertTime`,
                                `UpdateTime`,
                                `avg1`,
                                `avg2`
                              FROM `movehouse`.`orderinfo` AS orinfo
                              WHERE orinfo.`OrderID`=@OrderID";
          #endregion

          #region - paras -
          MySqlParameter[] paras = 
           {
               new MySqlParameter("@OrderID",orderID)
           };
          #endregion

          #region - excute -
          try
          {
              //记录查询
              DataTable dataTable = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, selectQy, paras).Tables[0];

              if (dataTable != null)
              {
                  orInfoModel = new OrderInfoModel();
                  foreach (DataRow row in dataTable.Rows)
                  {
                      orInfoModel = TransOrderInfoModel(row);
                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;
          }
          #endregion

          return orInfoModel;
      }
      #endregion

      #region - trans model -

      /// <summary>
      /// 转换至OrderInfoModel
      /// </summary>
      /// <param name="row"></param>
      /// <returns></returns>
      public OrderInfoModel TransOrderInfoModel(DataRow row)
      {
          OrderInfoModel orInfoModel = new OrderInfoModel();
          orInfoModel.OrderID = row["OrderID"] != null ? Convert.ToInt32(row["OrderID"]) : 0;
          orInfoModel.UID = row["UID"] != null ? row["UID"].ToString() : string.Empty;
          orInfoModel.SpcUID = row["SpcUID"] != null ? row["SpcUID"].ToString() : string.Empty;
          orInfoModel.MvhStarAddr = row["MvhStarAddr"] != null ? row["MvhStarAddr"].ToString() : string.Empty;
          orInfoModel.MvhEndAddr = row["MvhEndAddr"] != null ? row["MvhEndAddr"].ToString() : string.Empty;
          orInfoModel.Cost = row["Cost"] != null ? Convert.ToDecimal(row["Cost"]) : 0;
          orInfoModel.CarTypeInfoID = row["CarTypeInfoID"] != null ? Convert.ToInt32(row["CarTypeInfoID"]) : 0;
          orInfoModel.IsHelpMvh = row["IsHelpMvh"] != null ? Convert.ToInt32(row["IsHelpMvh"]) : 0;
          orInfoModel.InsertTime = row["InsertTime"] != null ? Convert.ToDateTime(row["InsertTime"]) : DateTime.MinValue;
          orInfoModel.UpdateTime = row["UpdateTime"] != null ? Convert.ToDateTime(row["UpdateTime"]) : DateTime.MinValue;
          return orInfoModel;
      }
      #endregion
  }
}
