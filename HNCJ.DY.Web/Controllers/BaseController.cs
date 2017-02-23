using HNCJ.DY.BLL;
using HNCJ.DY.Common;
using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers
{
    public class BaseController : Controller
    {
        public UserInfo LoginUser { get; set; }
        public bool IsCheckUserLogin = true;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsCheckUserLogin) {
                string userGuid = Utils.GetCookie("userLoginId");
                UserInfo userInfo = Common.Cache.CacheHelper.GetCache<UserInfo>(userGuid);
                LoginUser = userInfo;
                
            }
        }
        

    }
}
