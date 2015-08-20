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
  public  class BidDal
    {
      public BidDal() { }

        #region - method -
      /// <summary>
      /// 获取所有竞标信息
      /// </summary>
      /// <param name="msgID">信息ID</param>
      /// <returns>竞标信息</returns>
      public IList<BidInfoExtModel> GetBidInfoListBy(int msgID)
      {
          IList<BidInfoExtModel> bidExtInfoList = new List<BidInfoExtModel>();

          #region - sql qy -
          string selectBidInfoList = @"SELECT
                                         `BidID`,
                                         `MsgID`,
                                         `BidUID`,
                                         `UserName`
                                       FROM `movehouse`.`bidinfo` AS bidInfo LEFT JOIN movehouse.`userinfo` AS usr ON bidinfo.`BidUID`=usr.`ID`
                                       WHERE bidinfo.`MsgID`=@MsgID";
          #endregion

          #region - paras -
           MySqlParameter[] paras = 
           {
               new MySqlParameter("@MsgID",msgID),
           };
          #endregion

          #region - excute -
           try
           {
               //记录查询
               DataTable dataTable = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, selectBidInfoList, paras).Tables[0];
               if (dataTable != null)
               {
                   foreach (DataRow row in dataTable.Rows)
                   {
                       bidExtInfoList.Add(TransBidInfoExtModel(row));
                   }
               }
           }
           catch (Exception ex)
           {
               //记录日志
               throw ex;
           }

          #endregion

          return bidExtInfoList;
      }
      /// <summary>
      /// 插入竞标信息
      /// </summary>
      /// <param name="bidInfo">竞标信息</param>
      /// <returns>结果</returns>
      public int InserBidInfo(BidInfoModel bidInfo)
      {
          int resultInt = 0;

          #region - sql qy -
          string insertQy = @"INSERT INTO `movehouse`.`bidinfo`
                            (
                             `MsgID`,
                             `BidUID`,
                             `avg1`,
                             `avg2`)
                             VALUES (
                                     @MsgID,
                                     @BidUID,
                                     @avg1,
                                     @avg2);";
          #endregion

          #region - paras -
           MySqlParameter[] paras = 
           {
               new MySqlParameter("@MsgID",bidInfo.MsgID),
               new MySqlParameter("@BidUID",bidInfo.BidUID),
               new MySqlParameter("@avg1",string.Empty),
               new MySqlParameter("@avg2",string.Empty)
           };
          #endregion

          #region - Excute -
           try
           {
               resultInt = Convert.ToInt32(DbHelperMySql.ExecuteNonQuery(DbHelperMySql.connectionStringManager, System.Data.CommandType.Text, insertQy, paras));
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
      /// 是否存在竞标信息
      /// </summary>
      /// <param name="msgID">信息ID</param>
      /// <param name="bidUID">竞标用户ID</param>
      /// <returns>结果 0 不存在 1 存在</returns>
      public int IsBidInfoExist(int msgID,string bidUID)
      {
          int resultInt=0;

          #region - sql qy -
          string selectDetailQy = @"SELECT COUNT(1) FROM `movehouse`.`bidinfo` AS bidInfo WHERE bidInfo.`MsgID`=@MsgID AND bidInfo.`BidUID`=@BidUID";
          #endregion

          #region - paras  -
           MySqlParameter[] paras = 
           {
               new MySqlParameter("@MsgID",msgID),
               new MySqlParameter("@BidUID",bidUID)
           };
          #endregion

          #region - excute -
           try
           {
               resultInt = Convert.ToInt32(DbHelperMySql.ExecuteScalar(DbHelperMySql.connectionStringManager, System.Data.CommandType.Text, selectDetailQy, paras));
           }
           catch (Exception ex)
           {
               //记录错误信息

               throw;
           }
           #endregion

          return resultInt;
      }
      #endregion

      #region - trans model -
      /// <summary>
      /// 转换至BidInfoExtModel
      /// </summary>
      /// <param name="row">行</param>
      /// <returns></returns>
      public BidInfoExtModel TransBidInfoExtModel(DataRow row)
      {
          BidInfoExtModel bidInfoExtModel = new BidInfoExtModel();
          bidInfoExtModel.BidID = row["BidID"] != null ? Convert.ToInt32(row["BidID"]) : 0;
          bidInfoExtModel.MsgID = row["MsgID"] != null ? Convert.ToInt32(row["MsgID"]) : 0;
          bidInfoExtModel.BidUID = row["BidUID"] != null ? row["BidUID"].ToString() : string.Empty;
          bidInfoExtModel.UserName = row["UserName"] != null ? row["UserName"].ToString() : string.Empty;
          return bidInfoExtModel;
      }
      #endregion
    }
}
