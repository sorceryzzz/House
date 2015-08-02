using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
    public class MvhSpcPersonModel : BaseModel
   {
       #region - feild -
        private int _f_bjp_id;
       private string _f_bjp_uid;
       private int _f_bjpcartypeid;
       private string _f_name;
       private int _f_mvhSpcType;
       private string _f_place;
       private string _f_moblie;
       private decimal _f_bjpCostStart;
       private decimal _f_bjpCostEnd;
       private string _f_bjpDecription;
  
       #endregion

       #region - property -
       /// <summary>
       /// 主键
       /// </summary>
       public int F_Bjp_ID { set { _f_bjp_id = value; } get { return _f_bjp_id; } }
      /// <summary>
      /// 用户ID
      /// </summary>
       public string F_Bjp_UID { set { _f_bjp_uid = value; } get { return _f_bjp_uid; } }
      /// <summary>
      /// 车型
      /// </summary>
       public int F_BjpCarTypeID { set { _f_bjpcartypeid = value; } get {return  _f_bjpcartypeid; } }
      /// <summary>
      /// 姓名
      /// </summary>
       public string F_Name { set { _f_name = value; } get { return _f_name; } }
       /// <summary>
       /// 专人类型
       /// </summary>
       public int F_MvhSpcType { set { _f_mvhSpcType = value; } get { return _f_mvhSpcType; } }
       /// <summary>
       /// 地点
       /// </summary>
       public string F_Place { set { _f_place = value; } get { return _f_place; } }
        /// <summary>
        /// 联系电话
        /// </summary>
       public string F_Mobile { set { _f_moblie = value; } get { return _f_moblie; } }

       /// <summary>
       /// 最低费用
       /// </summary>
       public decimal F_BjpCostStart { set { _f_bjpCostStart = value; } get { return _f_bjpCostStart; } }
      /// <summary>
      /// 最高费用
      /// </summary>
       public decimal F_BjpCostEnd { set { _f_bjpCostEnd = value; } get { return _f_bjpCostEnd; } }
        /// <summary>
        /// 描述
        /// </summary>
       public string F_BjpDecription { set { _f_bjpDecription = value; } get { return _f_bjpDecription; } }
       #endregion

   }
}
