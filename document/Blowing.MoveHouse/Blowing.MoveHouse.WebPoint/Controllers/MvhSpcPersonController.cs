using Blowing.MoveHouse.Bll.MoveHouse;
using Blowing.MoveHouse.Model.MoveHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blowing.MoveHouse.WebPoint.Controllers
{
    public class MvhSpcPersonController : Controller
    {

        MvhSpcBll mvhSpcBll = new MvhSpcBll();

        #region - method -

        /// <summary>
        /// 发布搬家专人信息
        /// </summary>
        /// <param name="F_Bj_UID"></param>
        /// <param name="F_IsDisplaySex"></param>
        /// <param name="F_IsNeedHelpBj"></param>
        /// <param name="F_BjCostStart"></param>
        /// <param name="F_BjCostEnd"></param>
        /// <param name="F_BjDecription"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult PublishMvhSpc(int f_BjpCarTypeID, decimal f_BjCostStart, decimal f_BjCostEnd, string f_BjDecription)
        {
            #region - paras -
            int resultInt = 0;
            MvhSpcPersonModel mvhSpcModel = new MvhSpcPersonModel();

            mvhSpcModel.F_Bjp_UID = "000000000000000000";
            mvhSpcModel.F_BjpCarTypeID = f_BjpCarTypeID;
            mvhSpcModel.F_BjpCostStart = f_BjCostStart;
            mvhSpcModel.F_BjpCostEnd = f_BjCostEnd;
            mvhSpcModel.F_BjpDecription = f_BjDecription;
            #endregion

            #region - result -
            resultInt = mvhSpcBll.InserMvhSpcPerson(mvhSpcModel);
            return Content(resultInt.ToString()); 
            #endregion
        }
        // GET: MvhSpcPerson
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 获取搬家专人信息
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public ActionResult GetMvhSpcList(int pageIndex, int pageSize)
        {
            int count = 0;

            #region - 查询分页数据 -
            IList<MvhSpcPersonModel> mvhInfoList = mvhSpcBll.GetMvhSpcPersonList(pageIndex, pageSize, ref count);

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
        #endregion
    }
}