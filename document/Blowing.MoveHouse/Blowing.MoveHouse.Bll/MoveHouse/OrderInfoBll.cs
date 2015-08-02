using Blowing.MoveHouse.Dal.MoveHouse;
using Blowing.MoveHouse.Model.MoveHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Bll.MoveHouse
{
   public  class OrderInfoBll
    {
       OrderInfoDal orDal = new OrderInfoDal();


       public OrderInfoBll() { }

       #region - method -
       /// <summary>
       /// 获取订单信息
       /// </summary>
       /// <param name="orderID">订单主键</param>
       /// <returns></returns>
       public OrderInfoModel GetOrInfoByID(string orderID)
       {
          return  orDal.GetOrInfoByID(orderID);
       }
       /// <summary>
       /// 生成订单信息记录
       /// </summary>
       /// <param name="orInfoModel"></param>
       /// <returns>结果</returns>
       public int InsertOrderInfo(OrderInfoModel orInfoModel)
       {
           return orDal.InsertOrderInfo(orInfoModel);
       }
       #endregion
    }
}
