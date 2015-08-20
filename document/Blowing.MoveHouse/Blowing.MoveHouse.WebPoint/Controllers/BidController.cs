using Blowing.MoveHouse.Bll.MoveHouse;
using Blowing.MoveHouse.Model.MoveHouse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blowing.MoveHouse.WebPoint.Controllers
{
    public class BidController : Controller
    {


        BidInfoBll bidInfoBll = new BidInfoBll();

        // GET: Bid
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ContentResult GetBidInfoList(int msgID)
        {
            #region - check paras -
            if (msgID<0)
            {
                return null; 
            }
            #endregion

            #region - excute  -
            var  bidInfoList= bidInfoBll.GetBidInfoListBy(msgID);

            var bidInfoJson = JsonConvert.SerializeObject(bidInfoList);
            #endregion

            return Content(bidInfoJson);
        }
        /// <summary>
        /// 竞标
        /// </summary>
        /// <param name="msgID">信息ID</param>
        /// <returns>结果</returns>
        [HttpPost]
        public ContentResult AddBidInfo(string msgID)
        {
            string uID = "aa897dd5-f352-4395-8fd5-250cba00598d";
            int tmpInt = 0;

            #region - check paras -
            if (!int.TryParse(msgID,out tmpInt))
            {
                return Content("参数错误!");

            }
            #endregion

            #region - excute -
            BidInfoModel bidInfoModel = new BidInfoModel();
            bidInfoModel.BidUID = uID;
            bidInfoModel.MsgID = int.Parse(msgID);

            int resultInt = bidInfoBll.InserBidInfo(bidInfoModel);
            
            #endregion

            return Content(resultInt.ToString());

        }
    }
}