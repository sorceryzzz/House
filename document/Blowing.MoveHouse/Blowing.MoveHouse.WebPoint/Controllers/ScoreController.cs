using Blowing.MoveHouse.Bll.Score;
using Blowing.MoveHouse.Model.Score;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blowing.MoveHouse.WebPoint.Controllers
{
    public class ScoreController : Controller
    {
        ScoreBll srBll = new ScoreBll();


        // GET: Score
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加积分明细信息
        /// </summary>
        /// <returns></returns>
        public ContentResult AddScoreDetail(ScoreDetailModel srDetailModel)
        {
            //ScoreDetailModel srDetailModel = new ScoreDetailModel();
            var resultInt = srBll.AddSocreDetail(srDetailModel);
            return Content((resultInt>0).ToString());
        }
        /// <summary>
        /// 查询积分信息分页(类别)
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>积分信息分页(类别)JSON</returns>
        public ContentResult GetScoreDetailList(int pageIndex, int pageSize, string startTime, string endTime)
        {
            #region - paras init -
            int count = 0;
            //用户ID
            string userId = "60008000";

            ScoreCondation scoreCondation = null;
            #endregion

            #region - check paras-
            if (pageIndex <= 0 || pageSize <= 0 || startTime == null || endTime == null)
            {
                return null;
            }

            ViewData["startTime"] = startTime;
            ViewData["endTime"] = endTime;

            if (startTime != null && endTime != null)
            {
                scoreCondation = new ScoreCondation()
                {
                    StartDatetime = Convert.ToDateTime(startTime),
                    EndDatetime = Convert.ToDateTime(endTime)

                };
            }
            #endregion


            #region - excute -
            IList<ScoreDetailModel> scoreModelList = srBll.LoadScoreDetailRecordBy(userId, pageIndex, pageSize, scoreCondation, out count);

            var jsonObj = JsonConvert.SerializeObject(scoreModelList);
            #endregion

            return Content(jsonObj);

        }
        /// <summary>
        /// 查询积分信息分页(类别)
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>积分信息分页(类别)JSON</returns>
        public ContentResult GetScoreInfoList(int pageIndex, int pageSize, string startTime, string endTime)
        {
            #region - paras init -
            int count = 0;
            //用户ID
            string userId = "60008000";

            ScoreCondation scoreCondation = null; 
            #endregion

            #region - check paras-
            if (pageIndex <= 0 || pageSize <= 0 || startTime == null || endTime == null)
            {
                return null;
            }

            ViewData["startTime"] = startTime;
            ViewData["endTime"] = endTime;

            if (startTime != null && endTime != null)
            {
                scoreCondation = new ScoreCondation()
                {
                    StartDatetime = Convert.ToDateTime(startTime),
                    EndDatetime = Convert.ToDateTime(endTime)

                };
            }
            #endregion

            #region - excute -
            IList<ScoreInfoModel> scoreModelList = srBll.LoadScoreInfoRecordBy(userId, pageIndex, pageSize, scoreCondation, out count);

            var jsonObj = JsonConvert.SerializeObject(scoreModelList); 
            #endregion

            return Content(jsonObj);
        }
    }
}