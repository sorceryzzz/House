using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
  public class MoveHouseInfo:Base
  {
      #region - feild -
      private string _f_bj_id;
      private string _f_bj_uid;
      private int _f_isDisplaySex;
      private int _f_isNeedHelpBj;
      private decimal _f_bjCostStart;
      private decimal _f_bjCOstEnd;
      private string _f_bjDecription;


      #endregion

      #region - property -
      /// <summary>
      /// 主键
      /// </summary>
      public string F_Bj_ID { set { _f_bj_id = value; } get { return _f_bj_id; } }
      /// <summary>
      /// 用户ID
      /// </summary>
      public string F_Bj_UID { set { _f_bj_uid = value; } get { return _f_bj_uid; } }
      /// <summary>
      /// 是否显示性别
      /// </summary>
      public int F_IsDisplaySex { set { _f_isDisplaySex = value; } get { return _f_isDisplaySex; } }
      /// <summary>
      /// 是否需要搬家
      /// </summary>
      public int F_IsNeedHelpBj { set { _f_isNeedHelpBj = value; } get { return _f_isNeedHelpBj; } }
      /// <summary>
      /// 最低搬家费用
      /// </summary>
      public decimal F_BjCostStart{set{_f_bjCostStart=value;}get{return _f_bjCostStart;}}
      /// <summary>
      /// 最高搬家费用
      /// </summary>
      public decimal F_BjCostEnd { set { _f_bjCOstEnd = value; } get { return _f_bjCOstEnd; } }
      /// <summary>
      /// 描述
      /// </summary>
      public string F_BjDecription{set{_f_bjDecription=value;}get{return _f_bjDecription;}}
      #endregion
  }
}
