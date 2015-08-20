using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blowing.MoveHouse.WebPoint.Controllers;
using Newtonsoft.Json;
using Blowing.MoveHouse.Model.Score;

namespace Blowing.MoveHouse.Web.Unit
{
    /// <summary>
    /// ScoreControllerUnitTest 的摘要说明
    /// </summary>
    [TestClass]
    public class ScoreControllerUnitTest
    {
        /// <summary>
        /// 查询积分信息(类别)
        /// </summary>
        [TestMethod]
        public void GetScoreInfoList()
        {
            ScoreController srController = new ScoreController();

            var jsonObj = srController.GetScoreInfoList(1,10,"2015-06-01","2015-07-30").Content;

            var srList = JsonConvert.DeserializeObject<IList<ScoreInfoModel>>(jsonObj);

            Assert.IsTrue(srList.Count>0);
        }
        /// <summary>
        /// 查询积分信息(类别)
        /// </summary>
        [TestMethod]
        public void GetDetailList()
        {
            ScoreController srController = new ScoreController();

            var jsonObj = srController.GetScoreDetailList(1, 10, "2015-06-01", "2015-07-30").Content;

            var srList = JsonConvert.DeserializeObject<IList<ScoreDetailModel>>(jsonObj);

            Assert.IsTrue(srList.Count>0);
        }
        /// <summary>
        /// 添加积分信息
        /// </summary>
        [TestMethod]
        public void AddScoreDetail()
        {
            ScoreDetailModel srDetailModel = new ScoreDetailModel();
            srDetailModel.F_Add = 10;
            srDetailModel.F_CastID = 1;
            srDetailModel.F_Leval = 1;
            srDetailModel.F_Memo = "测试添加方法";
            srDetailModel.F_Time = DateTime.Now;
            srDetailModel.F_UID = "1234567890";

            ScoreController srController = new ScoreController();
           var resultStr= srController.AddScoreDetail(srDetailModel).Content;
           Assert.IsTrue(resultStr=="true");

        }


    }
}
