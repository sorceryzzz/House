using Blowing.MoveHouse.Common;
using Blowing.MoveHouse.Dal.MoveHouse;
using Blowing.MoveHouse.Dal.User;
using Blowing.MoveHouse.Model.Enum;
using Blowing.MoveHouse.Model.MoveHouse;
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
       MvhInfoDal mvhInfoDal = new MvhInfoDal();

       public UserInfoBll() { }


        #region  - method -
       /// <summary>
       /// 获取搬家信息
       /// </summary>
       /// <param name="uid">用户ID</param>
       /// <param name="pageIndex">当前页</param>
       /// <param name="pageSize">页大小</param>
       /// <param name="count">页总数</param>
       /// <returns></returns>
       public IList<MvhInfoModel> LoadMvhInfoListBy(string uid, int pageIndex, int pageSize, out int count)
       {

           return mvhInfoDal.GetMvhInfoRecordsBy(uid, pageIndex, pageSize, out count);
       }
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
