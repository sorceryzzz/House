using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.Score
{
  public class ScoreInfoModel
    {
        #region - feild-
        private int _f_id;
        private int _f_uid;
        private int _f_scoreTypeId;
        private double _f_score;
        private DateTime _f_insertTime;
        private DateTime _f_updateTime;
        private string avg1;
        private string avg2;
        #endregion

        #region - property-
        /// <summary>
        /// 主键
        /// </summary>
        public int F_ID { set { _f_id = value; } get { return _f_id; } }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int F_UID { set { _f_uid = value; } get { return _f_uid; } }
        /// <summary>
        /// 积分类别ID
        /// </summary>
        public int F_ScoreTypeID { set { _f_scoreTypeId = value; } get { return _f_scoreTypeId; } }
        /// <summary>
        /// 积分
        /// </summary>
        public double F_Score { set { _f_score = value; } get { return _f_score; } }
        /// <summary>
        /// 记录生成时间
        /// </summary>
        public DateTime F_InsertTime { set { _f_insertTime = value; } get { return _f_insertTime; } }
        /// <summary>
        /// 记录更新时间
        /// </summary>
        public DateTime F_UpdateTime { set { _f_updateTime = value; } get { return _f_updateTime; } }

        public string Avg1 { set { avg1 = value; } get { return avg1; } }
        public string Avg2 { set { avg2 = value; } get { return avg2; } }

        #endregion
    }
  /// <summary>
  /// 积分类别
  /// </summary>
  public enum ScoreType
  {
      //作业得分 = 1,
      //附加题得分 = 2,
      //竞赛机会兑换 = 3,
      //竞赛得分 = 4,
      //错题重练 = 5
  }
}
