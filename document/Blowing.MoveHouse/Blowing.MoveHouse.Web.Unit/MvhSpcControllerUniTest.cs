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
    /// MvhSpcControllerUniTest 的摘要说明
    /// </summary>
    [TestClass]
    public class MvhSpcControllerUniTest
    {

        [TestMethod]
        public void PublishMvhSpc()
        {

            MvhSpcPersonController mvhSpcController = new MvhSpcPersonController();
            for (int i = 0; i < 100; i++)
            {

                //var o = mvhSpcController.PublishMvhSpc(1, 100, 200, "搬家界的良心");
                //int result = int.Parse(o.Content);
                //Assert.AreEqual(result > 0, true);
            }
        }
       [TestMethod]
        public void GetBidInfoList()
        {
            BidController bidController = new BidController();
            var jsonObj = bidController.GetBidInfoList(2).Content;

            var bidInfoListEntitys = JsonConvert.DeserializeObject<List<BidInfoExtModel>>(jsonObj);

            Assert.IsTrue(bidInfoListEntitys.Count > 0);
        }
    }
}
