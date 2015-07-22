using Blowing.MoveHouse.Bll.MoveHouse;
using Blowing.MoveHouse.Model.MoveHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blowing.MoveHouse.WebPoint.Controllers
{
    public class MoveHouseController : Controller
    {

        MoveHouseInfoBll mvhInfoBll = new MoveHouseInfoBll();
        // GET: MoveHouse
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ContentResult PublishMvhInfo( string F_Bj_UID, short F_IsDisplaySex, short F_IsNeedHelpBj, decimal F_BjCostStart, decimal F_BjCostEnd, string F_BjDecription)
        {
            int resultInt = 0;

            #region - paras -
          
            MoveHouseInfo mvhInfoModel = new MoveHouseInfo();
            mvhInfoModel.F_Bj_ID = System.Guid.NewGuid().ToString();
            mvhInfoModel.F_Bj_UID = F_Bj_UID;
            mvhInfoModel.F_IsDisplaySex = F_IsDisplaySex;
            mvhInfoModel.F_IsNeedHelpBj = F_IsNeedHelpBj;
            mvhInfoModel.F_BjCostStart = F_BjCostStart;
            mvhInfoModel.F_BjCostEnd = F_BjCostEnd;
            mvhInfoModel.F_BjDecription = F_BjDecription; 
            #endregion

           resultInt= mvhInfoBll.InsertMvhInfo(mvhInfoModel);

           return Content(resultInt.ToString());
        }
    }
}