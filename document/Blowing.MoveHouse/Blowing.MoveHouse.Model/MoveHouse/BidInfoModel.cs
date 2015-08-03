using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
   public   class BidInfoModel
   {
       #region - feild -
       private int _bidID;
       private int _msgID;
       private string _bidUID;
       private string _avg1;
       private string _avg2;
       #endregion

       #region - endregion -
       /// <summary>
       /// 主键
       /// </summary>
       public int BidID { set { _bidID = value; } get { return _bidID; } }
       /// <summary>
       /// 搬家信息ID
       /// </summary>
       public int MsgID { set { _msgID = value; } get { return _msgID; } }
       /// <summary>
       /// 竞标用户ID
       /// </summary>
       public string BidUID { set { _bidUID = value; } get { return _bidUID; } }
       /// <summary>
       /// 扩展字段1
       /// </summary>
       public string Avg1{set{_avg1=value;}get{return _avg1;}}
       /// <summary>
       /// 扩展字段2
       /// </summary>
       public string Avg2 { set { _avg2 = value; } get { return _avg2; } }
       #endregion
   }
}
