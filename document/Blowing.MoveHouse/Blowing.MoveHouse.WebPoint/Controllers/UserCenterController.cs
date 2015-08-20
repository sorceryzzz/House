using Blowing.MoveHouse.Bll.MoveHouse;
using Blowing.MoveHouse.Bll.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blowing.MoveHouse.WebPoint.Controllers
{
    public class UserCenterController : Controller
    {


        UserInfoBll usrInfoBll = new UserInfoBll();
        MvhInfoBll mvhInfoBll = new MvhInfoBll();
        BidInfoBll bidInfoBll = new BidInfoBll();
        #region - method -
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgID"></param>
        /// <returns></returns>
        public ActionResult GetMvhInfoList()
        {
            string uID = "000000000000000000";
            int count;
            var mvhInfoList= usrInfoBll.LoadMvhInfoListBy(uID,1,10,out count);
            return PartialView(mvhInfoList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgID"></param>
        /// <returns></returns>
        public ActionResult GetMvhInfoDetail(int msgID)
        {
            var  bidInfoModel=  bidInfoBll.GetBidInfoListBy(msgID);

            var  mvhInfoModel= mvhInfoBll.GetMvhInfoDetatil(msgID);

            ViewBag.BidInfoModel = bidInfoModel;
            ViewBag.MvhInfoModel = mvhInfoModel;

            return PartialView();
        }
        #endregion
    }
}