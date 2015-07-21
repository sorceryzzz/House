﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
  public class MoveHouseInfo
  {
      #region - feild -
      private string _f_bj_id;
      private string _f_bj_uid;
      private short _f_isDisplaySex;
      private short _f_isNeedHelpBj;
      private decimal _f_bjCostStart;
      private decimal _f_bjCOstEnd;
      private string _f_bjDecription;
      private DateTime _f_insertTime;
      private DateTime _f_updateTime;

      #endregion

      #region - property -
      /// <summary>
      /// 主键
      /// </summary>
      public string F_Bj_ID { set { _f_bj_id = value; } get { return _f_bj_id; } }
      /// <summary>
      /// 用户ID
      /// </summary>
      public string F_Bj_UID { set { _f_bj_id = value; } get { return _f_bj_uid; } }
      /// <summary>
      /// 是否显示性别
      /// </summary>
      public short IsDisplaySex { set { _f_isDisplaySex = value; } get { return _f_isDisplaySex; } }
      /// <summary>
      /// 是否需要搬家
      /// </summary>
      public short IsNeedHelpBj { set { _f_isNeedHelpBj = value; } get { return _f_isNeedHelpBj; } }
      /// <summary>
      /// 最低搬家费用
      /// </summary>
      public decimal BjCostStart{set{_f_bjCostStart=value;}get{return _f_bjCostStart;}}
      /// <summary>
      /// 最高搬家费用
      /// </summary>
      public decimal BjCostEnd { set { _f_bjCOstEnd = value; } get { return _f_bjCOstEnd; } }
      /// <summary>
      /// 描述
      /// </summary>
      public string BjDecription{set{_f_bjDecription=value;}get{return _f_bjDecription;}}
      /// <summary>
      /// 记录生成时间
      /// </summary>
      public DateTime InsertTime { set { _f_insertTime = value; } get { return _f_insertTime; } }
      /// <summary>
      /// 记录更新时间
      /// </summary>
      public DateTime UpdateTime { set { _f_updateTime = value; } get { return _f_updateTime; } }
      #endregion
  }
}
