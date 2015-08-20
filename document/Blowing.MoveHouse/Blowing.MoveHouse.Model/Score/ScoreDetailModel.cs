using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.Score
{
   [Serializable]
   public  class ScoreDetailModel
    {
        #region  -feild -
        private int _f_id;
        private string _f_uid;
        private int _f_add;
        private int _f_leval;
        private DateTime _f_datetime;
        private int _f_castId;
        private string _f_memo;
        #endregion

        #region  -property -
        /// <summary>
        /// 主键
        /// </summary>
        public int F_ID { set { _f_id = value; } get { return _f_id; } }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string F_UID { set { _f_uid = value; } get { return _f_uid; } }
        /// <summary>
        /// 积分明细记录
        /// </summary>
        public int F_Add { set { _f_add = value; } get { return _f_add; } }
        /// <summary>
        /// 积分剩余
        /// </summary>
        public int F_Leval { set { _f_leval = value; } get { return _f_leval; } }

        /// <summary>
        /// 积分明细生成时间
        /// </summary>
        public DateTime F_Time { set { _f_datetime = value; } get { return _f_datetime; } }
        /// <summary>
        /// 积分类别ID
        /// </summary>
        public int F_CastID { set { _f_castId = value; } get { return _f_castId; } }
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string F_Memo { set { _f_memo = value; } get { return _f_memo; } }
        #endregion
    }
}
