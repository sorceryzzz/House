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
    public class MoveHouseDal
    {

        public MoveHouseDal() { }

        #region - method -
        /// <summary>
        /// 获取搬家信息分页
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="pageSize">大小</param>
        /// <param name="count">总条数</param>
        /// <returns>搬家信息集合</returns>
        public IList<MoveHouseInfo> GetMoveHouseInfoRecordsBy(string uid,int pageIndex,int pageSize,ref int count)
        {

            IList<MoveHouseInfo> mvhInfoList = null;

            pageIndex = pageSize * (pageIndex - 1);
            #region - sql qy -
            string sqlCountQy = @"SELECT COUNT(mvhInfo.f_Bj_ID)
                                  FROM `movehouse`.`movehouseinfo` AS mvhInfo ";

            string sqlPageQy = @"SELECT mvhInfo.f_Bj_ID,mvhInfo.f_Bj_UID,mvhInfo.f_IsDiplaySex,mvhInfo.f_IsDiplaySex,mvhInfo.f_IsNeedHelpBj,f_BjCostsStart,
                                    mvhInfo.f_BjCostEnd, mvhInfo.f_BjDecription,mvhInfo.f_InsertTime,mvhInfo.f_UpdateTime
                             FROM `movehouse`.`movehouseinfo` AS mvhInfo ";

            StringBuilder sbWhereStr=new StringBuilder();
            sbWhereStr.Append("WHERE mvhInfo.f_Bj_UID=@UID ");

            sqlCountQy += sbWhereStr.ToString();

            sbWhereStr.Append(@" AND (mvhInfo.f_bj_id >=(
                                    SELECT MAX(mvhInfo.f_bj_id) FROM (
                                        SELECT mvhA.f_bj_id FROM `movehouse`.`movehouseinfo` AS mvhA ORDER BY mvhA.f_bj_id LIMIT @PageIndex,1) AS tmp
                                    ) )
                             ORDER BY mvhInfo.f_bj_id ASC      
                             LIMIT @PageSize;");
            sqlPageQy += sbWhereStr.ToString();  
            #endregion

            #region - params -

            MySqlParameter[] paras = 
           {
               new MySqlParameter("@UID",uid),
               new MySqlParameter("@PageIndex",pageIndex),
               new MySqlParameter("@PageSize",pageSize)
           };
            #endregion

            #region - Excute-
            try
            {
                //记录总数
                count = Convert.ToInt32(DbHelperMySql.ExecuteScalar(DbHelperMySql.connectionStringManager,System.Data.CommandType.Text,sqlCountQy, paras));

                //记录查询
                DataTable dataTable = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, sqlPageQy, paras).Tables[0];
                if (dataTable != null)
                {
                    mvhInfoList = new List<MoveHouseInfo>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mvhInfoList.Add(TransMoveHouseInfo(row));
                    }
                }
            }
            catch (Exception ex)
            {
                //记录日志
                throw ex;
            }
            #endregion
            return mvhInfoList;
        }
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

        #region - trans model  -
        /// <summary>
        /// 转换至MoveHouesInfo
        /// </summary>
        /// <param name="row">数据项</param>
        /// <returns>MoveHouesInfo实体</returns>
        public MoveHouseInfo TransMoveHouseInfo(DataRow row)
        {
            MoveHouseInfo mvhInfo = new MoveHouseInfo();
            mvhInfo.F_Bj_ID = row["f_bj_id"] != null ? row["f_bj_id"].ToString() : string.Empty;
            mvhInfo.F_Bj_UID = row["f_bj_id"] != null ? row["f_bj_id"].ToString() : string.Empty;
            mvhInfo.F_IsDisplaySex = row["f_IsDiplaySex"] != null ? Convert.ToInt32(row["f_IsDiplaySex"]) : 0;
            mvhInfo.F_IsNeedHelpBj = row["f_IsNeedHelpBj"] != null ? Convert.ToInt32(row["f_IsNeedHelpBj"]) : 0;
            mvhInfo.F_BjCostStart = row["f_BjCostsStart"] != null ? Convert.ToDecimal(row["f_BjCostsStart"]) : 0;
            mvhInfo.F_BjCostEnd = row["f_BjCostEnd"] != null ? Convert.ToDecimal(row["f_BjCostEnd"]) : 0;
            mvhInfo.F_BjDecription = row["f_BjDecription"] != null ? row["f_BjDecription"].ToString() : string.Empty;
            mvhInfo.F_InsetTime = row["f_InsertTime"] != null ? Convert.ToDateTime(row["f_InsertTime"]) : DateTime.MinValue;
            mvhInfo.F_InsetTime = row["f_UpdateTime"] != null ? Convert.ToDateTime(row["f_UpdateTime"]) : DateTime.MinValue;
            return mvhInfo;
        }

        #endregion

    }
}
