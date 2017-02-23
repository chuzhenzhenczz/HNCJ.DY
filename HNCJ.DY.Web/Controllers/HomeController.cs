using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using HNCJ.DY.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IUserInfoService UserInfoService { get; set; }
        public IRoleInfoService RoleInfoService { get; set; }
        public IActionInfoService ActionInfoService { get; set; }
        
        //
        // GET: /Home/
        
        public ActionResult Layout() {
            ViewData.Model = this.LoginUser;
            ViewBag.AllMenu = LoadUserMenu();
            return View();
        }
        public ActionResult Index()
        {
            ViewData.Model = this.LoginUser;
            ViewBag.AllMenu = LoadUserMenu();
            return View();
        }
        #region 加载菜单图标
        public List<ActionInfo> LoadUserMenu()
        {
            int userId = this.LoginUser.ID;
            var user = UserInfoService.GetEntity(u => u.ID == userId && u.DelFlag == true).FirstOrDefault();
            var allRole = user.RoleInfo;
            var allRoleActionIds = (from r in allRole
                                    from a in r.ActionInfo
                                    select a.ID).ToList();
            var allDenyActionIds = (from r in user.UserActionInfo
                                    where r.HasPermissin == 0
                                    select r.ActionInfoID).ToList();
            var allActionIds = (from a in allRoleActionIds
                                where !allDenyActionIds.Contains(a)
                                select a).ToList();
            var allUserActionIds = (from t in user.UserActionInfo
                                    where t.HasPermissin == 1 && t.DelFlag == true
                                    select t.ActionInfoID).ToList();
            //把当前用户所有权限拿到
            allActionIds.AddRange(allUserActionIds.AsEnumerable());
            allActionIds = allActionIds.Distinct().ToList();//去重复值
            var actionList = ActionInfoService.GetEntity(a => allActionIds.Contains(a.ID) && a.IsMenu == true && a.DelFlag == true).ToList();
            if (LoginUser.UserName == "admin")
            {
                actionList = ActionInfoService.GetEntity(a => a.IsMenu == true && a.DelFlag == true).ToList();
            }

            return actionList;
        } 
        #endregion

        public ActionResult center() {
            return View();
        }
        public ActionResult Print() {
            ViewData.Model = LoginUser;
            return View();
        }
        public ActionResult details() {
            ViewData.Model = LoginUser;
            return View();
        }
        [MyActionFilter(IsCheckUserLogin = false)]
        public ActionResult IndexPage() {
            return Redirect("/Content/home/code/first_page.html");
        }
        
    }
}
