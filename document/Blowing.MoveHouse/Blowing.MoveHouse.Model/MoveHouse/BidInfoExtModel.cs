using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.MoveHouse
{
    public class BidInfoExtModel : BidInfoModel
    {

        #region - feild -
        private string _userName;
        #endregion

        #region - -
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set { _userName = value; } get { return _userName; } }
        #endregion

    }
}
