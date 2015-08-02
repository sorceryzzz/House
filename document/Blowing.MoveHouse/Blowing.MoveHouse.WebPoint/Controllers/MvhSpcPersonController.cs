using Blowing.MoveHouse.Bll.MoveHouse;
using Blowing.MoveHouse.Model.Enum;
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
        // GET: MvhSpcPerson
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 发布搬家专人信息
        /// </summary>
        /// <returns></returns>
        public ActionResult PublishMvhSpc()
        {

            return PartialView();
        }
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
        public ContentResult PublishMvhSpc(string txtName,string txtMvhSpcType,string txtPlace,string txtMoblie,string carTypeInfo, decimal txtCostStart, string decription)
        {
            #region - paras -
            int resultInt = 0;
            MvhSpcPersonModel mvhSpcModel = new MvhSpcPersonModel();

            mvhSpcModel.F_Bjp_UID = "000000000000000000";
            mvhSpcModel.F_BjpCarTypeID = (int)(CarTypeInfoEnum)Enum.Parse(typeof(CarTypeInfoEnum), carTypeInfo);
            mvhSpcModel.F_BjpCostStart = txtCostStart;
            mvhSpcModel.F_BjpDecription = decription;
            mvhSpcModel.F_Name = txtName;
            mvhSpcModel.F_Place = txtPlace;

            mvhSpcModel.F_MvhSpcType = (int)(MvhSpcType)Enum.Parse(typeof(MvhSpcType), txtMvhSpcType);
            mvhSpcModel.F_Mobile = txtMoblie;
            #endregion

            #region - result -
            resultInt = mvhSpcBll.InserMvhSpcPerson(mvhSpcModel);
            return Content((resultInt>0).ToString()); 
            #endregion
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
                {"CallBack", "GetMvhSpcePersonList"}
            };
            ViewBag.dataDictionary = dataDictionary;
            #endregion

            return PartialView(mvhInfoList);
        } 
        #endregion
    }
}