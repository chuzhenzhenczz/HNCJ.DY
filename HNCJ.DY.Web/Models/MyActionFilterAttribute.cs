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

namespace HNCJ.DY.Web.Models
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public bool IsCheckUserLogin = true;
        public bool IsAdmin = true;
        public bool IsRoleAction = true;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsCheckUserLogin)
            {
                string cookie=Utils.GetCookie("userLoginId");
                if (string.IsNullOrEmpty(cookie))
                {
                    if (IsAdmin)
                    {
                        filterContext.HttpContext.Response.Redirect("/UserLogin/AdminLogin");
                        return;
                    }
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Login");
                    return;
                }
                string userGuid = cookie;
                UserInfo userInfo = Common.Cache.CacheHelper.GetCache<UserInfo>(userGuid);
                if (userInfo == null)
                {
                    if (IsAdmin)
                    {
                        filterContext.HttpContext.Response.Redirect("/UserLogin/AdminLogin");
                        return;
                    }
                    filterContext.HttpContext.Response.Redirect("/Content/bigdatalogin/bigdatalogin.html");
                    return;
                }
                //滑动窗口机制
                Common.Cache.CacheHelper.SetCache(userGuid, userInfo, DateTime.Now.AddMinutes(20));
                if (IsRoleAction)
                {
                    string url = HttpContext.Current.Request.Url.AbsolutePath.ToLower();
                    string[] str = url.Split('/');
                    string URL = "/" + str[1] + "/" + str[2];
                    string httpMethod = HttpContext.Current.Request.HttpMethod.ToLower();
                    IApplicationContext ctx = ContextRegistry.GetContext();
                    IActionInfoService ActionInfoService = ctx.GetObject("ActionInfoService") as IActionInfoService;
                    IUserActionInfoService UserActionInfoService = ctx.GetObject("UserActionInfoService") as IUserActionInfoService;
                    IRoleInfoService RoleInfoService = ctx.GetObject("RoleInfoService") as IRoleInfoService;
                    IUserInfoService UserInfoService = ctx.GetObject("UserInfoService") as IUserInfoService;
                    var actionInfo = ActionInfoService.GetEntity(a => a.Url.ToLower() == URL && a.HttpMethd.ToLower() == httpMethod).FirstOrDefault();
                    if (actionInfo == null)
                    {
                       actionInfo=ActionInfoService.Add(URL, httpMethod);
                        //HttpContext.Current.Response.Redirect("/Error.html");
                    }
                    if (userInfo.UserName == "admin") return;
                    var rUAs = UserActionInfoService.GetEntity(u => u.UserInfoID == userInfo.ID);
                    var item = (from a in rUAs
                                where a.ActionInfoID == actionInfo.ID
                                select a).FirstOrDefault();
                    if (item != null)
                    {

                        if (item.HasPermissin == 1&&item.DelFlag==true) { return; }
                        else { HttpContext.Current.Response.Redirect("/Error.html"); }
                    }
                    var user = UserInfoService.GetEntity(u => u.ID == userInfo.ID).FirstOrDefault();
                    var allRoles = from r in user.RoleInfo
                                   select r;
                    var actions = from r in allRoles
                                  from a in r.ActionInfo
                                  select a;
                    var temp = (from a in actions
                                where a.ID == actionInfo.ID
                                select a).Count();
                    if (temp <= 0)
                    {
                        HttpContext.Current.Response.Redirect("/Error.html");
                    }
                }
            }

        }
    }
}