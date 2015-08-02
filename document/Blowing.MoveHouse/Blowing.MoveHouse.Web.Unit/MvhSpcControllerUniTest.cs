using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blowing.MoveHouse.WebPoint.Controllers;

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
    }
}
