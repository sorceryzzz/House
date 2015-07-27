﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blowing.MoveHouse.WebPoint.Controllers;

namespace Blowing.MoveHouse.Web.Unit
{
    /// <summary>
    /// MoveHouseControllerUnitTest 的摘要说明
    /// </summary>
    [TestClass]
    public class MoveHouseControllerUnitTest
    {

        [TestMethod]
        public void PublishMvhInfo()
        {

            MvhInfoController mvhController = new MvhInfoController();

            for (int i = 0; i < 50; i++)
            {
                var o = mvhController.PublishMvhInfo("帮忙搬家","000000000000000000", 0, 0, 100, 200, "20多个打包，已打包好");
                int result = int.Parse(o.Content);
                Assert.AreEqual(result > 0, true);
            }
        }
    }
}
