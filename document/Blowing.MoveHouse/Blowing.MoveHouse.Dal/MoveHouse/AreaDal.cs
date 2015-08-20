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
   public  class AreaDal
    {

       public AreaDal() { }


        #region - method -
       /// <summary>
       /// 加载省市区
       /// </summary>
       /// <param name="parent">父ID</param>
       /// <returns></returns>
       public IList<AreaModel> GetAreaInfoList(string parent)
       {

           IList<AreaModel> areaModelList = new List<AreaModel>();

           #region - sql -
           string sqlSelectQy = @"SELECT
                                    `f_id`,
                                    `f_name`,
                                    `f_parent`,
                                    `f_order`
                                  FROM `movehouse`.`area` AS ar
                                  where ar.`f_parent`=@Parent";
           #endregion

           #region - paras -
           MySqlParameter[] paras = 
            {
               new MySqlParameter("@Parent",parent)

            };
           #endregion

           #region - excute -
           try
           {
               //记录查询
               DataTable dataTable = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, sqlSelectQy, paras).Tables[0];
               if (dataTable != null)
               {
                   AreaModel areaModel = new AreaModel();
                   foreach (DataRow row in dataTable.Rows)
                   {
                       areaModel = TransAreaModel(row);
                       areaModelList.Add(areaModel);
                   }
               }
           }
           catch (Exception ex)
           {

               throw ex;
           }
           #endregion

           return areaModelList;
       }
        #endregion

        #region - tans model -
              /// <summary>
        /// 转换至EClassAreaModel
       /// </summary>
       /// <param name="row"></param>
       /// <returns></returns>
        public AreaModel TransAreaModel(DataRow row)
        {
            AreaModel areaModel = new AreaModel();
            areaModel.F_ID = row["f_id"] != System.DBNull.Value ? row["f_id"].ToString() : string.Empty;
            areaModel.F_Name = row["f_name"] != System.DBNull.Value ? row["f_name"].ToString() : string.Empty;
            areaModel.F_Parent = row["f_parent"] != System.DBNull.Value ? row["f_parent"].ToString() : string.Empty;
            areaModel.F_Order = row["f_order"] != System.DBNull.Value ? Convert.ToInt32(row["f_order"]) : 0;
            return areaModel;
        }
        #endregion


    }
}
