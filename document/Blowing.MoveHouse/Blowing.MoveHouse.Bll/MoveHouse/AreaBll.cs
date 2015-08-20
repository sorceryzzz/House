using Blowing.MoveHouse.Dal.MoveHouse;
using Blowing.MoveHouse.Model.MoveHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Bll.MoveHouse
{
   public  class AreaBll
    {


       AreaDal areaDal=new AreaDal();

       public AreaBll() { }


        #region - method -
       /// <summary>
       /// 加载省市区
       /// </summary>
       /// <param name="parent">父ID</param>
       /// <returns></returns>
       public IList<AreaModel> LoadAreaInfoList(string parent)
       {
           return areaDal.GetAreaInfoList(parent);
       }
        #endregion
    }
}
