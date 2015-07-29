using Blowing.MoveHouse.Bll.MoveHouse;
using Blowing.MoveHouse.Model.MoveHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blowing.MoveHouse.WebPoint.Controllers
{
    public class MvhInfoController : Controller
    {

        MvhInfoBll mvhInfoBll = new MvhInfoBll();
        // GET: MoveHouse
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取搬家信息分页
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="pageSize">大小</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMvhInfoList(int pageIndex,int pageSize)
        {
            string uid = "000000000000000000";
            int count=0;
   
            #region - 查询分页数据 -

            IList<MvhInfoModel> mvhInfoList = mvhInfoBll.GetMvhInfoRecordsBy(uid, pageIndex, pageSize, ref count);

            ViewDataDictionary dataDictionary = new ViewDataDictionary
            {
                {"PageIndex", pageIndex},
                {"PageCount", Math.Ceiling(count/(double) pageSize)},
                {"CallBack", "GetMvhInfoList"}
            };
            ViewBag.dataDictionary = dataDictionary;
            #endregion

            return PartialView(mvhInfoList);
        }

        /// <summary>
        ///发布搬家信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PublishMvhInfo()
        {

            return PartialView();
        }
        /// <summary>
        /// 发布搬家信息
        /// </summary>
        /// <param name="F_Bj_UID"></param>
        /// <param name="F_IsDisplaySex"></param>
        /// <param name="F_IsNeedHelpBj"></param>
        /// <param name="F_BjCostStart"></param>
        /// <param name="F_BjCostEnd"></param>
        /// <param name="F_BjDecription"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult PublishMvhInfoPost( string name,string mobile, short isNeedHelpBj, decimal costStart, decimal costEnd, string decription)
        {
            int resultInt = 0;
            string uid = "000000000000000000";
            short F_IsDisplaySex = 0;

            #region - paras -
          
            MvhInfoModel mvhInfoModel = new MvhInfoModel();
            mvhInfoModel.F_Bj_Title =string.Empty;
            mvhInfoModel.F_Mobile = mobile;
            mvhInfoModel.F_Name = name;
            mvhInfoModel.F_Bj_UID = uid;
            mvhInfoModel.F_IsDisplaySex = F_IsDisplaySex;
            mvhInfoModel.F_IsNeedHelpBj = isNeedHelpBj;
            mvhInfoModel.F_BjCostStart = costStart;
            mvhInfoModel.F_BjCostEnd = costEnd;
            mvhInfoModel.F_BjDecription = decription; 
            #endregion

            #region - excute -
            resultInt = mvhInfoBll.InsertMvhInfo(mvhInfoModel); 
            #endregion

           return Content(resultInt.ToString());
        }
    }
}