using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blowing.MoveHouse.WebPoint.Controllers;
using Newtonsoft.Json;
using Blowing.MoveHouse.Model.MoveHouse;

namespace Blowing.MoveHouse.Web.Unit
{
    /// <summary>
    /// AreaControllerUnitTest 的摘要说明
    /// </summary>
    [TestClass]
    public class AreaControllerUnitTest
    {


        /// <summary>
        /// 获取省市区信息
        /// </summary>
        [TestMethod]
        public void GetAreaList()
        {

            string parentID = "000000";

            AreaController arController = new AreaController();

            var jsonObj = arController.GetAreaList(parentID).Content;

            var areaList = JsonConvert.DeserializeObject<IList<AreaModel>>(jsonObj);
            Assert.IsTrue(areaList.Count > 0);
        }
    }
}
