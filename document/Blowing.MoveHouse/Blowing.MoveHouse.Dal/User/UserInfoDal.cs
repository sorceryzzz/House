using Blowing.MoveHouse.Common;
using Blowing.MoveHouse.Model.Enum;
using Blowing.MoveHouse.Model.User;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Dal.User
{
  public  class UserInfoDal
    {
      public UserInfoDal() { }


      #region - method -
      /// <summary>
      /// 登录
      /// </summary>
      /// <param name="urInfoModel"></param>
      /// <param name="loginType"></param>
      /// <returns></returns>
      public int LoginUserInfo(UserInfoModel urInfoModel,LoginType loginType)
      {
          UserInfoModel urInfoModelTmp = new UserInfoModel();
         

          int resultInt = 0;

          #region - sql qy -
          string selectQy = @"SELECT
                                `ID`,
                                `UserName`,
                                `Pwd`,
                                `Mail`,
                                `Mobile`,
                                `RegisterLogin`,
                                `LastLogin`,
                                `avg1`,
                                `avg2`
                              FROM `movehouse`.`userinfo` AS urInfo";
          StringBuilder sbWhere = new StringBuilder();
          sbWhere.Append(" where ");
         // sbWhere.Append(" urInfo.`Pwd`=@Pwd ");
          switch (loginType)
          {
              case LoginType.用户名:
                  sbWhere.Append("  urInfo.`UserName`=@UserName");
                  break;
              case LoginType.邮箱:
                  sbWhere.Append(" urInfo.`Mail`=@Mail");
                  break;
              case LoginType.手机:
                  sbWhere.Append(" urInfo.`Mobile`=@Mobile");
                  break;
              default:
                  break;
          }
      
          selectQy = selectQy + sbWhere.ToString();
          #endregion

          #region - paras -
          MySqlParameter[] paras = 
           {
               new MySqlParameter("@UserName",urInfoModel.UserName)
           //    new MySqlParameter("@Pwd", urInfoModel.Pwd.ToLower()),
           };
          #endregion


          #region - Excute -

          //记录查询
          DataTable dataTable = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, selectQy, paras).Tables[0];

          if (dataTable != null)
          {
              urInfoModelTmp = new UserInfoModel();
              foreach (DataRow row in dataTable.Rows)
              {
                 urInfoModelTmp=TransUserInfoModel(row);
              }
          }

          #endregion

          if (string.Equals(urInfoModelTmp.Pwd,urInfoModel.Pwd))
          {
              resultInt = 1;
          }
          return resultInt;
      }
      /// <summary>
      /// 记录用户信息
      /// </summary>
      /// <param name="urInfoModel">用户信息</param>
      /// <returns>结果:0 失败 1 成功</returns>
      public int InserUserInfo(UserInfoModel urInfoModel)
      {
          int resultInt = 0;
          #region - sql qy -
          string insertQy = @"INSERT INTO `movehouse`.`userinfo`
                            (`ID`,
                             `UserName`,
                             `Pwd`,
                             `Mail`,
                             `Mobile`,
                             `RegisterLogin`,
                             `LastLogin`,
                             `avg1`,
                             `avg2`)
                             VALUES (@ID,
                                     @UserName,
                                     @Pwd,
                                     @Mail,
                                     @Mobile,
                                     @RegisterLogin,
                                     @LastLogin,
                                     @avg1,
                                     @avg2);";
          #endregion

          #region - paras -
          MySqlParameter[] paras = 
           {
               new MySqlParameter("@ID",urInfoModel.ID),
               new MySqlParameter("@UserName",urInfoModel.UserName),
               new MySqlParameter("@Pwd",urInfoModel.Pwd),
               new MySqlParameter("@Mail",urInfoModel.Mail),
               new MySqlParameter("@Mobile",urInfoModel.Mobile),
               new MySqlParameter("@RegisterLogin",urInfoModel.RegisterLogin),
               new MySqlParameter("@LastLogin",urInfoModel.LastLogin),
               new MySqlParameter("@avg1",string.Empty),
               new MySqlParameter("@avg2",string.Empty)
           };
          #endregion

          #region - Excute -
          try
          {
              resultInt = Convert.ToInt32(DbHelperMySql.ExecuteNonQuery(DbHelperMySql.connectionStringManager, System.Data.CommandType.Text, insertQy, paras));
          }
          catch (Exception ex)
          {
              //记录错误信息

              throw;
          }
          #endregion

          return resultInt;
      }
      #endregion


        #region - trans model -


      /// <summary>
      /// 转换至UserInfoModel
      /// </summary>
      /// <param name="row"></param>
      /// <returns></returns>
      public UserInfoModel TransUserInfoModel(DataRow row)
      {

          UserInfoModel urInfoModel = new UserInfoModel();
          urInfoModel.ID = row["ID"] != null ? row["UserName"].ToString() : string.Empty;
          urInfoModel.UserName = row["UserName"] != null ? row["UserName"].ToString() : string.Empty;

          urInfoModel.Pwd = row["Pwd"] != null ? row["Pwd"].ToString() : string.Empty;
          urInfoModel.Mail = row["Mail"] != null ? row["Mail"].ToString() : string.Empty;
          urInfoModel.Mobile = row["Mobile"] != null ? row["Mobile"].ToString() : string.Empty;
          urInfoModel.RegisterLogin = row["RegisterLogin"] != null ? Convert.ToDateTime(row["RegisterLogin"]) : DateTime.MinValue;
          urInfoModel.LastLogin = row["LastLogin"] != null ? Convert.ToDateTime(row["LastLogin"]) : DateTime.MinValue;

          return urInfoModel;
      }  

        #endregion
    }
}
