using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Model.User
{
   public  class UserInfoModel
    {
       #region - feild -
       private string _id;
       private string _userName;
       private string _pwd;
       private string _mail;
       private string _mobile;
       private DateTime _registerLogin;
       private DateTime _lastLogin;
       private string _avg1;
       private string _avg2;
       #endregion

       #region - property -
       /// <summary>
       /// 主键
       /// </summary>
       public string ID { set { _id = value; } get { return _id; } }
       /// <summary>
       /// 用户名
       /// </summary>
       public string UserName { set { _userName = value; } get { return _userName; } }
       /// <summary>
       /// 密码
       /// </summary>
       public string Pwd { set { _pwd = value; } get { return _pwd; } }
       /// <summary>
       /// 邮箱
       /// </summary>
       public string Mail { set { _mail = value; } get { return _mail; } }
       /// <summary>
       /// 手机号
       /// </summary>
       public string Mobile { set { _mobile = value; } get { return _mobile; } }
       /// <summary>
       /// 注册时间
       /// </summary>
       public DateTime RegisterLogin { set { _registerLogin = value; } get { return _registerLogin; } }
       /// <summary>
       /// 最后登录时间
       /// </summary>
       public DateTime LastLogin { set { _lastLogin = value; } get { return _lastLogin; } }
       /// <summary>
       /// 扩展字段1
       /// </summary>
       public string Avg1 { set { _avg1 = value; } get { return _avg1; } }
      /// <summary>
      /// 扩展字段2
      /// </summary>

       public string Avg2 { set { _avg2 = value; } get { return _avg2; } }
        #endregion
    }
}
