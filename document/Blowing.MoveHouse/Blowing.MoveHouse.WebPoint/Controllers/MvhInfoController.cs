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
        public ContentResult PublishMvhInfoPost( string F_Bj_Titile,string F_Bj_UID, short F_IsDisplaySex, short F_IsNeedHelpBj, decimal F_BjCostStart, decimal F_BjCostEnd, string F_BjDecription)
        {
            int resultInt = 0;

            #region - paras -
          
            MvhInfoModel mvhInfoModel = new MvhInfoModel();
            mvhInfoModel.F_Bj_Title = F_Bj_Titile;
            mvhInfoModel.F_Bj_UID = F_Bj_UID;
            mvhInfoModel.F_IsDisplaySex = F_IsDisplaySex;
            mvhInfoModel.F_IsNeedHelpBj = F_IsNeedHelpBj;
            mvhInfoModel.F_BjCostStart = F_BjCostStart;
            mvhInfoModel.F_BjCostEnd = F_BjCostEnd;
            mvhInfoModel.F_BjDecription = F_BjDecription; 
            #endregion

            #region - excute -
            resultInt = mvhInfoBll.InsertMvhInfo(mvhInfoModel); 
            #endregion

           return Content(resultInt.ToString());
        }
    }
}