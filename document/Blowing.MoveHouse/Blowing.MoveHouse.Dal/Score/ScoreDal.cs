using Blowing.MoveHouse.Common;
using Blowing.MoveHouse.Model.Score;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Dal.Score
{
  public  class ScoreDal
    {
      public ScoreDal() { }


        #region - method -

      /// <summary>
      /// 生成积分明细信息
      /// </summary>
      /// <param name="scoreModel">积分明细</param>
      /// <returns></returns>
      public int InsertSocreDetail(ScoreDetailModel scoreModel)
      {
          int resultInt = 0;


          #region - sql qy-
          //string StoredProcQy = string.Format(@"CALL `movehouse_score_addScore`({0},{1},{2},{3},{4})", scoreModel.F_UID, scoreModel.F_Add, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), scoreModel.F_CastID,scoreModel.F_Memo);
          string StoredProcQy = "movehouse_score_addScore";
          
          #endregion

          
          #region - paras -
          MySqlParameter[] paras = 
           {
               new MySqlParameter("@I_uID",scoreModel.F_UID),
               new MySqlParameter("@I_add",scoreModel.F_Add),
               new MySqlParameter("@I_time",DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
               new MySqlParameter("@I_ScoreTypeID",scoreModel.F_CastID),
               new MySqlParameter("@I_memo",scoreModel.F_CastID)
           };
          //paras[5].Value = ParameterDirection.InputOutput;
          #endregion

          #region - excute -
          try
          {
              MySqlDataReader reader = DbHelperMySql.ExecuteReader(DbHelperMySql.connectionStringManager, CommandType.StoredProcedure, StoredProcQy, paras);
              if (reader.Read())
              {
                  if (reader.HasRows)
                  {
                      resultInt = reader.GetInt32("resultInt"); ;
                  }
              }

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
      /// 查询积分明细记录分页
      /// </summary>
      /// <param name="uID">用户ID</param>
      /// <param name="pageIndex">当前页</param>
      /// <param name="pageSize">页大小</param>
      /// <param name="srCondation">查询条件实体</param>
      /// <param name="count">记录总数</param>
      /// <returns>积分明细记录集合</returns>
      public IList<ScoreDetailModel> GetScoreDetailRecordBy(string uID, int pageIndex,
           int pageSize,ScoreCondation srCondation, out int count)
      {

          List<ScoreDetailModel> scoreList = null;

          pageIndex = pageSize * (pageIndex - 1);


          #region - sql qy -
          string selectConutQy = @"SELECT COUNT(tms.f_id) FROM `movehouse`.`scoredetail` AS tms ";
          string selectPageQy = @"SELECT tms.f_id,tms.f_uid,tms.f_add,tms.f_leval,tms.f_time,tms.f_castid,tms.f_memo
                                   FROM `movehouse`.`scoredetail` AS tms ";
          StringBuilder whereStr = new StringBuilder();
          whereStr.Append("WHERE");
          #endregion

          #region - where condation -
          whereStr.Append(@" (tms.f_uid=@UID)");
          if (srCondation != null || (srCondation.StartDatetime != DateTime.MinValue && srCondation.EndDatetime != DateTime.MinValue))
          {
              whereStr.Append(" AND (tms.f_time BETWEEN @StartTime AND @EndTime) ");
          }
          selectConutQy += whereStr.ToString();

          //           whereStr.Append(@" AND (tms.f_id  BETWEEN @PageIndex AND @PageEnd)
          //                                  ORDER BY tms.f_id ASC ;");


          whereStr.Append(@" AND (tms.f_id >=(
                                        SELECT MAX(tmp.f_id) FROM (
                                        SELECT tmsA.f_id FROM `movehouse`.`scoredetail` AS tmsA where tmsA.f_time BETWEEN @StartTime AND @EndTime ORDER BY tmsA.f_id LIMIT @PageIndex,1) AS tmp
                                    ))
                                  ORDER BY tms.f_id ASC  
                                  LIMIT @PageSize;");



          selectPageQy += whereStr.ToString();
          #endregion

          #region - sql paras -

          MySqlParameter[] paras = 
           {
               new MySqlParameter("@UID",uID),
               new MySqlParameter("@StartTime",srCondation.StartDatetime.ToString("yyyy-MM-dd 00:00:00")),
               new MySqlParameter("@EndTime",srCondation.EndDatetime.ToString("yyyy-MM-dd 23:59:59")),
               new MySqlParameter("@PageIndex",pageIndex),
               new MySqlParameter("@PageSize",pageSize)
           };
          #endregion

          #region - Excute-
          try
          {
              //记录总数
              count = Convert.ToInt32(DbHelperMySql.ExecuteScalar(DbHelperMySql.connectionStringManager, System.Data.CommandType.Text, selectConutQy, paras));

              //记录查询
              DataTable dataTable = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, selectPageQy, paras).Tables[0];

              if (dataTable != null)
              {
                  scoreList = new List<ScoreDetailModel>();
                  foreach (DataRow row in dataTable.Rows)
                  {
                      scoreList.Add(TransToScoreInfoModel(row));
                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;
          }
          #endregion

          return scoreList;
      } 
      /// <summary>
      /// 查询积分明细记录分页(类别)
      /// </summary>
      /// <param name="uID">用户ID</param>
      /// <param name="pageIndex">当前页</param>
      /// <param name="pageSize">页大小</param>
      /// <param name="srCondation">查询条件实体</param>
      /// <param name="count">记录总数</param>
      /// <returns>积分明细记录集合</returns>
      public IList<ScoreInfoModel> GetScoreInfoRecordBy(string uID, int pageIndex,
           int pageSize, ScoreCondation srCondation, out int count)
      {

          IList<ScoreInfoModel> scoreList = null;

          pageIndex = pageSize * (pageIndex - 1);


          #region - sql qy -
          string selectConutQy = @"SELECT COUNT(tms.f_id) FROM `movehouse`.`socreinfo` AS tms ";
          string selectPageQy = @"SELECT   tms.`f_ID`,tms.`f_UID`,tms.`f_ScoreTypeID`,tms.`f_Score`,tms.`f_InsertTime`, tms.`f_UpdateTime`
                                   FROM `movehouse`.`socreinfo` AS tms ";
          StringBuilder whereStr = new StringBuilder();
          whereStr.Append("WHERE");
          #endregion

          #region - where condation -
          whereStr.Append(@" (tms.f_uid=@UID)");
          //if (srCondation != null || (srCondation.StartDatetime != DateTime.MinValue && srCondation.EndDatetime != DateTime.MinValue))
          //{
          //    whereStr.Append(" AND (tms.f_UpdateTime BETWEEN @StartTime AND @EndTime) ");
          //}
          selectConutQy += whereStr.ToString();

          whereStr.Append(@" AND (tms.f_id >=(
                                        SELECT MAX(tmp.f_id) FROM (
                                        SELECT tmsA.f_id FROM `movehouse`.`socreinfo` AS tmsA  ORDER BY tmsA.f_id LIMIT @PageIndex,1) AS tmp
                                    ))
                                  ORDER BY tms.f_id ASC  
                                  LIMIT @PageSize;");

          selectPageQy += whereStr.ToString();
          #endregion

          #region - sql paras -

          MySqlParameter[] paras = 
           {
               new MySqlParameter("@UID",uID),
               new MySqlParameter("@StartTime",srCondation.StartDatetime.ToString("yyyy-MM-dd 00:00:00")),
               new MySqlParameter("@EndTime",srCondation.EndDatetime.ToString("yyyy-MM-dd 23:59:59")),
               new MySqlParameter("@PageIndex",pageIndex),
               new MySqlParameter("@PageSize",pageSize)
           };
          #endregion

          #region - Excute-
          try
          {
              //记录总数
              count = Convert.ToInt32(DbHelperMySql.ExecuteScalar(DbHelperMySql.connectionStringManager,System.Data.CommandType.Text, selectConutQy, paras));

              //记录查询
              DataTable dataTable = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, selectPageQy, paras).Tables[0];

              if (dataTable != null)
              {
                  scoreList = new List<ScoreInfoModel>();
                  foreach (DataRow row in dataTable.Rows)
                  {
                      scoreList.Add(TransToSocreModel(row));
                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;
          }
          #endregion

          return scoreList;
      } 
     #endregion


     #region - trans model -
      /// <summary>
      /// 转换至ScoreInfoModel
      /// </summary>
      /// <param name="row">数据项</param>
      /// <returns></returns>
      public ScoreInfoModel TransToSocreModel(DataRow row)
      {
          ScoreInfoModel srInfoModel = new ScoreInfoModel();
          srInfoModel.F_ID = row["f_ID"] != System.DBNull.Value ? Convert.ToInt32(row["f_ID"]) : 0;
          srInfoModel.F_ScoreTypeID = row["f_ScoreTypeID"] != System.DBNull.Value ? Convert.ToInt32(row["f_ScoreTypeID"]) : 0;
          srInfoModel.F_Score = row["f_Score"] != System.DBNull.Value ? Convert.ToInt32(row["f_Score"]) : 0;
          return srInfoModel;
      }

      /// <summary>
      /// 转换至ScoreDetail
      /// </summary>
      /// <param name="row"></param>
      /// <returns></returns>
      public ScoreDetailModel TransToScoreInfoModel(DataRow row)
      {
          ScoreDetailModel srDetailModel = new ScoreDetailModel();
          srDetailModel.F_ID = row["f_id"] != System.DBNull.Value ? Convert.ToInt32(row["f_id"]) : 0;
          srDetailModel.F_UID = row["f_Uid"] != System.DBNull.Value ? row["f_Uid"].ToString() : string.Empty;
          srDetailModel.F_Add = row["f_add"] != System.DBNull.Value ? Convert.ToInt32(row["f_add"]) : 0;
          srDetailModel.F_Leval = row["f_leval"] != System.DBNull.Value ? Convert.ToInt32(row["f_leval"]) : 0;
          srDetailModel.F_Time = row["f_time"] != System.DBNull.Value ? Convert.ToDateTime(row["f_time"]) : DateTime.MinValue;
          srDetailModel.F_CastID = row["f_castid"] != System.DBNull.Value ? Convert.ToInt32(row["f_castid"]) : 0;
          srDetailModel.F_Memo = row["f_memo"] != System.DBNull.Value ? row["f_memo"].ToString() : string.Empty;
          return srDetailModel;
      }
     #endregion
    }
}
