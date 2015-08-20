using Blowing.MoveHouse.Dal.Score;
using Blowing.MoveHouse.Model.Score;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Bll.Score
{
   public  class ScoreBll
    {
       ScoreDal srDal = new ScoreDal();


       public ScoreBll() { }


      #region - method -
       /// <summary>
       /// 生成积分明细信息
       /// </summary>
       /// <param name="scoreModel">积分明细</param>
       /// <returns></returns>
       public int AddSocreDetail(ScoreDetailModel srDetailModel)
       {
           return srDal.InsertSocreDetail(srDetailModel);
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
       public IList<ScoreDetailModel> LoadScoreDetailRecordBy(string uID, int pageIndex,
            int pageSize, ScoreCondation srCondation, out int count)
       {
           return srDal.GetScoreDetailRecordBy(uID, pageIndex, pageSize, srCondation, out count);
       }
       /// <summary>
       /// 查询积分记录分页(类别)
       /// </summary>
       /// <param name="uID">用户ID</param>
       /// <param name="pageIndex">当前页</param>
       /// <param name="pageSize">页大小</param>
       /// <param name="srCondation">查询条件实体</param>
       /// <param name="count">记录总数</param>
       /// <returns>积分记录分页(类别)</returns>
       public IList<ScoreInfoModel> LoadScoreInfoRecordBy(string uID, int pageIndex,
            int pageSize, ScoreCondation srCondation, out int count)
       {
           return srDal.GetScoreInfoRecordBy(uID, pageIndex, pageSize, srCondation, out count);
       }
        #endregion
    }
}
