using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
  public  class OrderInfoModel
  {
      #region - feild -
      private int _orderID;
      private string _uID;
      private string _spcUID;
      private string _mvhStarAddr;
      private string _mvhEndAddr;
      private decimal _cost;
      private int _carTypeInfoID;
      private int _isHelpMvh;
      private DateTime _insertTime;
      private DateTime _updateTime;
      private string _avg1;
      private string _avg2;

      #endregion

      #region - property -
      /// <summary>
      /// 主键ID
      /// </summary>
      public int OrderID { set { _orderID = value; } get { return _orderID; } }
      /// <summary>
      /// 搬家人
      /// </summary>
      public string UID { set { _uID = value; } get { return _uID; } }

      /// <summary>
      /// 专人UID
      /// </summary>
      public string SpcUID { set { _spcUID = value; } get { return _spcUID; } }
      /// <summary>
      /// 原地址
      /// </summary>
      public string MvhStarAddr { set { _mvhStarAddr = value; } get { return _mvhStarAddr; } }

     /// <summary>
     /// 目的地址
     /// </summary>
      public string MvhEndAddr { set { _mvhEndAddr = value; } get { return _mvhEndAddr; } }

      /// <summary>
      /// 花费
      /// </summary>
      public decimal Cost { set { _cost = value; } get { return _cost; } }
      /// <summary>
      /// 车型ID
      /// </summary>
      public int CarTypeInfoID { set { _carTypeInfoID = value; } get { return _carTypeInfoID; } }
      /// <summary>
      /// 是否需要帮助搬家(0:不需要1:需要)
      /// </summary>
      public int IsHelpMvh { set { _isHelpMvh = value; } get { return _isHelpMvh; } }

      /// <summary>
      /// 记录生成时间
      /// </summary>
      public DateTime InsertTime { set { _insertTime = value; } get { return _insertTime; } }

      /// <summary>
      /// 更新时间
      /// </summary>
      public DateTime UpdateTime { set { _updateTime = value; } get { return _updateTime; } }

      /// <summary>
      /// 扩展字段2
      /// </summary>
      public string avg1 { set { _avg1 = value; } get { return _avg1; } }
      /// <summary>
      /// 扩展字段2
      /// </summary>
      public string avg2 { set { _avg2 = value; } get { return _avg2; } }
      #endregion




  }
}
