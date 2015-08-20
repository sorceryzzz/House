using Blowing.MoveHouse.Bll.MoveHouse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blowing.MoveHouse.WebPoint.Controllers
{
    public class AreaController : Controller
    {

        AreaBll areaBll = new AreaBll();

        /// <summary>
        /// 查询地点信息
        /// </summary>
        /// <param name="parentID">父ID</param>
        /// <returns></returns>
        public ContentResult GetAreaList(string parentID)
        {

            if (string.IsNullOrEmpty(parentID))
            {
                return null;
            }

            var areaList = areaBll.LoadAreaInfoList(parentID);
            var areaJsonObj = JsonConvert.SerializeObject(areaList);

            return Content(areaJsonObj);
        }
    }
}