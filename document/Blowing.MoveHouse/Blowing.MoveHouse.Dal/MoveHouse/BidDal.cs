using Blowing.MoveHouse.Common;
using Blowing.MoveHouse.Model.MoveHouse;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                                     @avg1);";
          #endregion

          #region - paras -
           MySqlParameter[] paras = 
           {
               new MySqlParameter("@MsgID",bidInfo.MsgID),
               new MySqlParameter("@BidUID",bidInfo.BidUID),
               new MySqlParameter("@avg1",string.Empty),
               new MySqlParameter("@avg1",string.Empty)
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
      #endregion
    }
}
