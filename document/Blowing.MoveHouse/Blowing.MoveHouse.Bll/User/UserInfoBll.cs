using Blowing.MoveHouse.Common;
using Blowing.MoveHouse.Dal.User;
using Blowing.MoveHouse.Model.Enum;
using Blowing.MoveHouse.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Bll.User
{
   public  class UserInfoBll
    {

       UserInfoDal urInfoDal = new UserInfoDal();


       public UserInfoBll() { }


        #region  - method -

       //public int CheckLogin()
       //{
        
         



       //}
       /// <summary>
       /// 登录用户
       /// </summary>
       /// <param name="urInfoModel"></param>
       /// <returns></returns>
       public int LoginUserInfo(UserInfoModel urInfoModel,LoginType loginType)
       {
           urInfoModel.Pwd = Md5Helper.MD5(urInfoModel.Pwd.Trim().ToLower());

           return urInfoDal.LoginUserInfo(urInfoModel, loginType);
       }
       /// <summary>
       /// 注册用户
       /// </summary>
       /// <param name="urInfoModel">用户信息</param>
       /// <returns>结果0 失败 1 成功</returns>
       public int InserUserInfo(UserInfoModel urInfoModel)
       {
           urInfoModel.Pwd = Md5Helper.MD5(urInfoModel.Pwd.Trim().ToLower());
           return urInfoDal.InserUserInfo(urInfoModel);
       }
        #endregion
    }
}
