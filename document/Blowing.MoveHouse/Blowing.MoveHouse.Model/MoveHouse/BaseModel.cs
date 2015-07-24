using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
   public class BaseModel
   {
       #region - feild -
       private DateTime _f_insertTime;
       private DateTime _f_updateTime;
       
       #endregion

       #region - property -
       /// <summary>
       /// 记录生成时间
       /// </summary>
       public DateTime F_InsetTime { set { _f_insertTime = value; } get { return _f_insertTime; } }
       /// <summary>
       /// 记录更新时间
       /// </summary>
       public DateTime F_UpdateTime { set { _f_updateTime = value; } get { return _f_updateTime; } }
       
       #endregion
    }
}
