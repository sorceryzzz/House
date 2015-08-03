using Blowing.MoveHouse.Dal.MoveHouse;
using Blowing.MoveHouse.Model.MoveHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Bll.MoveHouse
{
   public  class BidInfoBll
    {
       BidDal bidDal = new BidDal();



       public BidInfoBll() { }


        #region - method -
       /// <summary>
       /// 生成竞标信息
       /// </summary>
       /// <param name="bidInfoModel">竞标信息</param>
       /// <returns>结果:0 失败 1 成功</returns>
       public int InserBidInfo(BidInfoModel bidInfoModel)
       {
           return bidDal.InserBidInfo(bidInfoModel);
       }
        #endregion



    }
}
