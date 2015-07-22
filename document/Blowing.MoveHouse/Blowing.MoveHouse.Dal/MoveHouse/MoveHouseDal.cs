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
    public class MoveHouseDal
    {

        public MoveHouseDal() { }

        #region - method -
        /// <summary>
        /// 生成搬家信息记录
        /// </summary>
        /// <param name="mvhInfo">搬家信息实体</param>
        /// <returns>影响行数</returns>
        public int InsertMvhInfo(MoveHouseInfo mvhInfo)
        {
            int resultInt = 0;

            #region - sql qy -
            string sqlQy = @"INSERT INTO `movehouse`.`movehouseinfo`
            (                   `f_Bj_ID`,
                                `f_Bj_UID`,
                                `f_IsDiplaySex`,
                                `f_IsNeedHelpBj`,
                                `f_BjCostsStart`,
                                `f_BjCostEnd`,
                                `f_BjDecription`,
                                `f_InsertTime`,
                                `f_UpdateTime`,
                                `avg1`,
                                `avg2`)
                             VALUES (@f_Bj_ID,
                                 @f_Bj_UID,
                                 @f_IsDiplaySex,
                                 @f_IsNeedHelpBj,
                                 @f_BjCostsStart,
                                 @f_BjCostEnd,
                                 @f_BjDecription,
                                 @f_InsertTime,
                                 @f_UpdateTime,
                                 @avg1,
                                 @avg2);";
            #endregion

            #region - params -

            MySqlParameter[] paras = 
           {
               new MySqlParameter("@f_Bj_ID",mvhInfo.F_Bj_ID),
               new MySqlParameter("@f_Bj_UID",mvhInfo.F_Bj_UID),
               new MySqlParameter("@f_IsDiplaySex",mvhInfo.F_IsDisplaySex),
               new MySqlParameter("@f_IsNeedHelpBj",mvhInfo.F_IsNeedHelpBj),
               new MySqlParameter("@f_BjCostsStart",mvhInfo.F_BjCostStart),
               new MySqlParameter("@f_BjCostEnd",mvhInfo.F_BjCostEnd),
               new MySqlParameter("@f_BjDecription",mvhInfo.F_BjDecription),
               new MySqlParameter("@f_InsertTime",mvhInfo.F_InsetTime),
               new MySqlParameter("@f_UpdateTime",mvhInfo.F_UpdateTime),
                new MySqlParameter("@avg1",string.Empty),
               new MySqlParameter("@avg2",string.Empty)
           };
            #endregion

            #region - Excute -

            try
            {
                resultInt = Convert.ToInt32(DbHelperMySql.ExecuteNonQuery(DbHelperMySql.connectionStringManager,System.Data.CommandType.Text,sqlQy,paras));
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
