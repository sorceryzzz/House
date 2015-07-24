using Blowing.MoveHouse.Dal.MoveHouse;
using Blowing.MoveHouse.Model.MoveHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Bll.MoveHouse
{
    public class MvhSpcBll
    {

        MvhSpcPersonDal mvhSpcDal = new MvhSpcPersonDal();

        public MvhSpcBll() { }

        #region - method -
        /// <summary>
       /// 获取搬家专人信息分页
       /// </summary>
       /// <param name="pageIndex">当前索引</param>
       /// <param name="pageSize">页大小</param>
       /// <param name="count">总条数</param>
       /// <returns></returns>
        public IList<MvhSpcPersonModel> GetMvhSpcPersonList(int pageIndex, int pageSize, ref int count)
        {
            return mvhSpcDal.GetMvhSpcPersonList(pageIndex, pageSize, ref count);
        }
       /// <summary>
       /// 记录搬家专人信息
       /// </summary>
       /// <param name="mvhSpcModel">搬家专人信息实体</param>
       /// <returns></returns>
        public int InserMvhSpcPerson(MvhSpcPersonModel mvhSpcModel)
        {
            return mvhSpcDal.InserMvhSpcPerson(mvhSpcModel);
        }
        #endregion

    }
}
