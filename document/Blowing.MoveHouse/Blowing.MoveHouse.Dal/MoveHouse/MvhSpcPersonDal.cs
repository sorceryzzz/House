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
   public  class MvhSpcPersonDal
    {

       public MvhSpcPersonDal() { }


       #region - method -
       /// <summary>
       /// 查询专人搬家信息分页
       /// </summary>
       /// <param name="pageIndex">当前索引</param>
       /// <param name="pageSize">页大小</param>
       /// <param name="count">总条数</param>
       /// <returns></returns>
       public IList<MvhSpcPersonModel> GetMvhSpcPersonList(int pageIndex,int pageSize,ref int count)
       {
           #region - init -
           IList<MvhSpcPersonModel> mvhSpcPresonList = null;
           pageIndex = pageSize * (pageIndex - 1); 

           #endregion

           #region - sql qy -
           string sqlCountQy = @" SELECT COUNT(mvhspc.f_Bjp_ID)  FROM  `movehouse`.`mvhspcinfo` AS mvhspc";
           string sqlPageQy = @" SELECT
                                   `f_Bjp_ID`,
                                   `f_Bjp_UID`,
                                   `f_BjpCarTypeID`,
                                   `f_BjpCostStart`,
                                   `f_BjpCostEnd`,
                                   `f_BjpDecription`,
                                   `f_InsertTime`,
                                   `f_UpdateTime`,
                                   `avg1`,
                                   `avg2`
                                 FROM `movehouse`.`mvhspcinfo` AS mvhspc
                                 WHERE
                                  (MvhSpc.f_Bjp_ID >=(
                                                       SELECT MAX(MvhSpc.f_Bjp_ID) FROM (
                                                                         SELECT mvhspcA.f_Bjp_ID FROM `movehouse`.`mvhspcinfo` AS mvhspcA ORDER BY mvhspcA.f_Bjp_ID LIMIT @PageIndex,1) AS tmp
                                    ) )
                                ORDER BY mvhspc.f_Bjp_ID ASC      
                                LIMIT @PageSize;";

           #endregion   

           #region - paras  -
            MySqlParameter[] paras = 
           {
               new MySqlParameter("@PageIndex",pageIndex),
               new MySqlParameter("@PageSize",pageSize)
           };
           #endregion

           #region - Excute-
            try
            {
                //记录总数
                count = Convert.ToInt32(DbHelperMySql.ExecuteScalar(DbHelperMySql.connectionStringManager, System.Data.CommandType.Text, sqlCountQy, paras));

                //记录查询
                DataTable dataTable = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, sqlPageQy, paras).Tables[0];

                if (dataTable != null)
                {
                    mvhSpcPresonList = new List<MvhSpcPersonModel>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mvhSpcPresonList.Add(TransMvhSpcPersonModel(row));
                    }
                }
            }
            catch (Exception ex)
            {
                //记录日志
                throw ex;
            }
            #endregion

           return mvhSpcPresonList;
       }
       /// <summary>
       /// 生成专人搬家信息
       /// </summary>
       /// <param name="mvhSpcModel">搬家专人信息实体</param>
       /// <returns></returns>
       public int InserMvhSpcPerson(MvhSpcPersonModel mvhSpcModel)
       {
           int resultInt = 0;

           #region - sql qy -
           string sqlQy = @"INSERT INTO `movehouse`.`mvhspcinfo`
                                        (`f_Bjp_UID`,
                                         `f_BjpCarTypeID`,
                                         `f_Name`,
                                         `f_mvhSpcType`,
                                         `f_place`,
                                         `f_mobile`,
                                         `f_BjpCostStart`,
                                         `f_BjpDecription`,
                                         `f_BjpCostEnd`,
                                         `f_InsertTime`,
                                         `f_UpdateTime`,
                                         `avg1`,
                                         `avg2`)
                            VALUES (@f_Bjp_UID,
                                    @f_BjpCarTypeID,
                                    @f_Name,
                                    @f_mvhSpcType,
                                    @f_place,
                                    @f_mobile,
                                    @f_BjpCostStart,
                                    @f_BjpDecription,
                                    @f_BjpCostEnd,
                                    @f_InsertTime,
                                    @f_UpdateTime,
                                    @avg1,
                                    @avg2);;";

           #endregion

           #region - params -
             MySqlParameter[] paras = 
           {
               new MySqlParameter("@f_Bjp_UID",mvhSpcModel.F_Bjp_UID),
               new MySqlParameter("@f_BjpCarTypeID",mvhSpcModel.F_BjpCarTypeID),
               new MySqlParameter("@f_Name",mvhSpcModel.F_Name),
               new MySqlParameter("@f_mvhSpcType",mvhSpcModel.F_MvhSpcType),
               new MySqlParameter("@f_place",1),
               new MySqlParameter("@f_mobile",mvhSpcModel.F_Mobile),
               new MySqlParameter("@f_BjpCostStart",mvhSpcModel.F_BjpCostStart),
               new MySqlParameter("@f_BjpCostEnd",mvhSpcModel.F_BjpCostEnd),
               new MySqlParameter("@f_BjpDecription",mvhSpcModel.F_BjpDecription),
               new MySqlParameter("@f_InsertTime",mvhSpcModel.F_InsetTime),
               new MySqlParameter("@f_UpdateTime",mvhSpcModel.F_UpdateTime),
                new MySqlParameter("@avg1",string.Empty),
               new MySqlParameter("@avg2",string.Empty)
           };
           #endregion

           #region - Excute -
             try
             {
                 resultInt = Convert.ToInt32(DbHelperMySql.ExecuteNonQuery(DbHelperMySql.connectionStringManager, System.Data.CommandType.Text, sqlQy, paras));
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

        #region - tarns model -
       /// <summary>
       /// 转换至实体：MvhSpcPersonModel
       /// </summary>
       /// <param name="row"></param>
       /// <returns></returns>
       public MvhSpcPersonModel TransMvhSpcPersonModel(DataRow row)
       {
           MvhSpcPersonModel mvhSpcModel = new MvhSpcPersonModel();
           mvhSpcModel.F_Bjp_ID = row["f_Bjp_ID"] != null ? Convert.ToInt32(row["f_Bjp_ID"]) : 0;
           mvhSpcModel.F_Bjp_UID = row["f_Bjp_UID"] != null ? row["f_Bjp_UID"].ToString() : string.Empty;
           mvhSpcModel.F_BjpCarTypeID = row["f_BjpCarTypeID"] != null ? Convert.ToInt32(row["f_BjpCarTypeID"]) : 0;
           mvhSpcModel.F_BjpCostStart = row["f_BjpCostStart"] != null ? Convert.ToDecimal(row["f_BjpCostStart"]) : 0;
           mvhSpcModel.F_BjpCostEnd = row["f_BjpCostEnd"] != null ? Convert.ToDecimal(row["f_BjpCostEnd"]) : 0;
           mvhSpcModel.F_BjpDecription = row["f_BjpDecription"] != null ? row["f_BjpDecription"].ToString() : string.Empty;
           mvhSpcModel.F_InsetTime = row["f_InsertTime"] != null ? Convert.ToDateTime(row["f_InsertTime"]) : DateTime.MinValue;
           mvhSpcModel.F_UpdateTime = row["f_UpdateTime"] != null ? Convert.ToDateTime(row["f_UpdateTime"]) : DateTime.MinValue;
           return mvhSpcModel;
       }

        #endregion
    }
}
