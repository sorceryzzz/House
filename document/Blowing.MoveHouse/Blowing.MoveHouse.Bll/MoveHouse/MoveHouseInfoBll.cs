using Blowing.MoveHouse.Dal.MoveHouse;
using Blowing.MoveHouse.Model.MoveHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Bll.MoveHouse
{
   public  class MoveHouseInfoBll
    {

        MoveHouseDal mvhDal = new MoveHouseDal();

        public MoveHouseInfoBll() { }


        #region - method -
        /// <summary>
        /// 发布搬家信息
        /// </summary>
        /// <param name="mvhInfo">搬家信息实体</param>
        /// <returns>影响行数</returns>
       public int InsertMvhInfo(MoveHouseInfo mvhInfo)
       {
           return mvhDal.InsertMvhInfo(mvhInfo);
       }
        #endregion

    }
}
