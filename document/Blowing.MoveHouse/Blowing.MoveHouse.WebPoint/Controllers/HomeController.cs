using Blowing.MoveHouse.Bll.User;
using Blowing.MoveHouse.Model.Enum;
using Blowing.MoveHouse.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blowing.MoveHouse.WebPoint.Controllers
{
    public class HomeController : Controller
    {

        UserInfoBll urInfoBll = new UserInfoBll();



        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 注册Register Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {


            return View();
        }
        /// <summary>
        /// 注册Register POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ContentResult RegisterForm(string userName,string pwd,string mail,string mobile)
        {
            int resultInt = 0;

            #region - check paras-
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(mobile))
            {
                return Content("参数错误"); ;
            }
            #endregion

            #region - ecute -
            UserInfoModel urInfoModel = new UserInfoModel();
            urInfoModel.ID = Guid.NewGuid().ToString();
            urInfoModel.UserName = userName.Trim().ToLower();
            urInfoModel.Mail = mail.Trim().ToLower();
            urInfoModel.Pwd = pwd.Trim().ToLower();
            urInfoModel.Mobile = mobile.Trim().ToLower();
            urInfoModel.RegisterLogin = DateTime.Now;
            urInfoModel.LastLogin = DateTime.Now;
            resultInt=  urInfoBll.InserUserInfo(urInfoModel);
            #endregion

            return Content((resultInt>0).ToString());
        }
        /// <summary>
        /// 登录login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 登录login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult LoginForm(string userName,string pwd)
        {

            UserInfoModel urInfoModel = new UserInfoModel();
           // urInfoModel.ID = Guid.NewGuid().ToString();
            urInfoModel.UserName = userName.Trim().ToLower();
            urInfoModel.Pwd = pwd.Trim().ToLower();
            int resultInt=   urInfoBll.LoginUserInfo(urInfoModel,LoginType.用户名);

            if (resultInt > 0)
            {
                Session["LoginUser"] = urInfoModel;
            }
           return Content(resultInt.ToString());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}