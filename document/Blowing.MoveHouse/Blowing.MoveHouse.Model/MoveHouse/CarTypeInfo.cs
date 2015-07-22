using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
  public  class CarTypeInfo:Base
  {
      #region - feild-
      private int _f_id;
      private string _f_carname;
      private string _f_imageurl;
      private string _f_cardecription;
      #endregion

      #region - property -
      /// <summary>
      /// 主键
      /// </summary>
      public int F_ID { set { _f_id = value; } get { return _f_id; } }
      /// <summary>
      /// 车型
      /// </summary>
      public string F_CarName { set { _f_carname = value; } get { return _f_carname; } }
      /// <summary>
      /// 图片链接
      /// </summary>
      public string F_ImageUrl { set { _f_imageurl = value; } get { return _f_imageurl; } }
      /// <summary>
      /// 描述
      /// </summary>
      public string F_CarDecription { set { _f_cardecription = value; } get {return  _f_cardecription; } }
      
      #endregion

  }
}
