using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
   public class AreaModel
    {
        #region - feild -
        private string _f_id;
        private string _f_name;
        private string _f_parent;
        private int _f_order;
  
        #endregion

        #region - property -
        /// <summary>
        /// 主键
        /// </summary>
        public string F_ID { set { _f_id = value; } get { return _f_id; } }
        /// <summary>
        /// 地点名称
        /// </summary>
        public string F_Name { set { _f_name = value; } get { return _f_name; } }
        /// <summary>
        /// 父级
        /// </summary>
        public string F_Parent { set { _f_parent = value; } get { return _f_parent; } }
        /// <summary>
        /// 排序
        /// </summary>
        public int F_Order { set { _f_order = value; } get { return _f_order; } }

        #endregion



    }
}
