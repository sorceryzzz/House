using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.Score
{
  public  class ScoreCondation
    {
        #region - feid-
        private DateTime _startDatetime;
        private DateTime _endDateTime;
        #endregion

        #region -property-
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDatetime { set { _startDatetime = value; } get { return _startDatetime; } }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDatetime { set { _endDateTime = value; } get { return _endDateTime; } }

        #endregion
    }
}
