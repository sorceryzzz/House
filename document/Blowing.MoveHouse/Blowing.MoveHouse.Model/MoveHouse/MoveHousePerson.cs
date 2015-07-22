﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
    public class MoveHousePerson : Base
   {
       #region - feild -
       private string _f_bjp_id;
       private string _f_bjp_uid;
       private int _f_bjpcartypeid;
       private decimal _f_bjpCostStart;
       private decimal _f_bjpCostEnd;
  
       #endregion

       #region - property -
       /// <summary>
       /// 主键
       /// </summary>
       public string F_Bjp_ID { set { _f_bjp_id = value; } get { return _f_bjp_id; } }
      /// <summary>
      /// 用户ID
      /// </summary>
       public string F_Bjp_UID { set { _f_bjp_uid = value; } get { return _f_bjp_uid; } }
      /// <summary>
      /// 车型
      /// </summary>
       public int F_BjpCarTypeID { set { _f_bjpcartypeid = value; } get {return  _f_bjpcartypeid; } }
       /// <summary>
       /// 最低费用
       /// </summary>
       public decimal F_BjpCostStart { set { _f_bjpCostStart = value; } get { return _f_bjpCostStart; } }
      /// <summary>
      /// 最高费用
      /// </summary>
       public decimal F_BjpCostEnd { set { _f_bjpCostEnd = value; } get { return _f_bjpCostEnd; } }
 
       #endregion

   }
}
