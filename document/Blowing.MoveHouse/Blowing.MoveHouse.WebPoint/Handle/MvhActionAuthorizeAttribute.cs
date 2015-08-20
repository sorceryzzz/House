using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blowing.MoveHouse.WebPoint.Handle
{
    public class MvhActionAuthorizeAttribute:FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //int result = BllUser.CheckLogin();
            //if (result < 0)
            //{
            //    bool isajax = filterContext.HttpContext.Request.Headers["X-Requested-With"] != null;
            //    if (isajax)
            //    {
            //        filterContext.Result = new ContentResult { Content = "NL" };
            //    }
            //    else
            //    {
            //        filterContext.Result = new RedirectResult("/Account/Login/");
            //    }
            //}
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}