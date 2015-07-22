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
        /// 获取搬家信息分页
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="pageSize">大小</param>
        /// <param name="count">总条数</param>
        /// <returns>搬家信息集合</returns>
        public IList<MoveHouseInfo> GetMoveHouseInfoRecordsBy(string uid, int pageIndex, int pageSize, ref int count)
        {
            return mvhDal.GetMoveHouseInfoRecordsBy(uid, pageIndex, pageSize, ref count);
        }
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
