using HNCJ.DY.Common;
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
    public class UserInfoController : BaseController
    {
        //
        // GET: /UserInfo/
        public IUserInfoService UserInfoService { get; set; }
        public IRoleInfoService RoleInfoService { get; set; }
        public IActionInfoService ActionInfoService { get; set; }
        public IUserActionInfoService UserActionInfoService { get; set; }
        public UserInfoController(){
            
        }
        public ActionResult Index()
        {
            return View();
        }

        #region 获取全部用户信息
        public ActionResult GetAllUserInfos()
        {
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            
            int itemid = int.Parse(Request["itemid"] ?? "0");
            string key = Request["key"];
            BaseParam param = new BaseParam()
            {
            PageSize=pageSize,
            PageIndex=pageIndex,
            Total = total,
            ItemId = itemid,
            Key=key
            };
            var pagedata = UserInfoService.LoagPageData(param);
            var tmp = pagedata.Select(u => new { u.ID, u.UserName,u.Status,u.RegTime,u.ModfiedTime,u.DelFlag });
            var data = new { total = param.Total, rows = tmp.ToList() };
            return Json(data, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region 添加用户
        public ActionResult Add() {
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserInfo userInfo)
        {
            if (UserInfoService.Exits(userInfo.UserName)) {
                return Json(new { status = 0, errorMsg = "用户名已存在！！" }); ;
            }
            userInfo.RegTime = DateTime.Now;
            userInfo.ModfiedTime = DateTime.Now;
            userInfo.DelFlag = true;
            userInfo.Status = 1;
            userInfo.UserKey = Utils.GetCheckCode(6); //获得6位的salt加密字符串
            userInfo.Userpwd = DESEncrypt.Encrypt(userInfo.Userpwd, userInfo.UserKey);
            UserInfoService.Add(userInfo);
            UserInfoService.AddPaityMember(userInfo.ID);
            return Json(new { status = 1, errorMsg = "操作成功！！" }); 
        } 
        #endregion

        #region 删除用户信息
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Json(new { status = 0, errorMsg = "请选中要移除的行？？" });
            }
            string[] strIds = id.Split(',');
            List<int> idList = new List<int>();
            foreach (var item in strIds)
            {
                idList.Add(int.Parse(item));
            }
            UserInfoService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 修改用户信息
        public ActionResult Edit(int id) {
            ViewData.Model = UserInfoService.GetEntity(u=>u.DelFlag==true&&u.ID==id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(UserInfo userInfo)
        {
            userInfo.ModfiedTime = DateTime.Now;
            userInfo.UserKey = Utils.GetCheckCode(6); //获得6位的salt加密字符串
            userInfo.Userpwd = DESEncrypt.Encrypt(userInfo.Userpwd, userInfo.UserKey);
            UserInfoService.Update(userInfo);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        } 
        #endregion

        #region 详细信息
        public ActionResult Details(int id=0)
        {
            ViewData.Model = UserInfoService.GetEntity(u => u.ID == id).FirstOrDefault();
            return View();
        }
        #endregion

        #region 改变状态
        public ActionResult AlterListStatus(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Json(new { status = 0, errorMsg = "请至少选中一行？？" });
            }
            string[] strIds = id.Split(',');
            List<int> idList = new List<int>();
            foreach (var item in strIds)
            {
                idList.Add(int.Parse(item));
            }
            UserInfoService.AlterListStatus(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 设置角色
        public ActionResult SetRole(int id)
        {
            //int userId = id;
            UserInfo user = UserInfoService.GetEntity(u => u.ID == id).FirstOrDefault(); ;
            ViewBag.AllRoles = RoleInfoService.GetEntity(u => u.DelFlag == true).ToList();
            ViewBag.ExitsRoles = (from r in user.RoleInfo select r.ID).ToList();
            return View(user);
        }
        public ActionResult ProcessSetRole(int Uid)
        {
            List<int> setRoleIdList = new List<int>();
            foreach (var key in Request.Form.AllKeys)
            {
                if (key.StartsWith("ckb_"))
                {
                    int roleId = int.Parse(key.Replace("ckb_", ""));
                    setRoleIdList.Add(roleId);
                }
            }
            UserInfoService.SetRole(Uid, setRoleIdList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        } 
        #endregion
        #region 给用户直接赋予权限
    
        public ActionResult SetAction(int id)
        {
            UserInfo user = UserInfoService.GetEntity(u => u.ID == id).FirstOrDefault(); ;
            ViewBag.AllActions = ActionInfoService.GetEntity(u => u.DelFlag == true).ToList();
            ViewBag.AllUserActions = UserActionInfoService.GetEntity(a => a.DelFlag == true).ToList();
            return View(user);
        }

        public ActionResult DeleteAction(int userId, int ActionId)
        {
            var UserAction = UserActionInfoService.GetEntity(r => r.DelFlag == true && r.ActionInfoID == ActionId && r.UserInfoID == userId).FirstOrDefault();
            if (UserAction != null)
            {
                UserActionInfoService.DeleteListByLogical(new List<int>() { UserAction.ID });
            }
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        public ActionResult SetUserAction(int userId, int ActionId, int Value)
        {
            var UserAction = UserActionInfoService.GetEntity(r => r.ActionInfoID == ActionId && r.UserInfoID == userId && r.DelFlag == true).FirstOrDefault();
            var item = Value == 1 ? 1 : 0;
            if (UserAction != null)
            {

                UserAction.HasPermissin = (short)item;
                UserActionInfoService.Update(UserAction);
            }
            else
            {
                UserActionInfo ruserActionInfo = new UserActionInfo();
                ruserActionInfo.ActionInfoID = ActionId;
                ruserActionInfo.UserInfoID = userId;
                ruserActionInfo.HasPermissin = (short)item;
                ruserActionInfo.DelFlag = true;
                UserActionInfoService.Add(ruserActionInfo);
            }
            return Json(new { status = 1, errorMsg = "操作成功！！" });

        }
        #endregion

        public ActionResult Restore(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Json(new { status = 0, errorMsg = "请至少选中一行？？" });
            }
            string[] strIds = id.Split(',');
            List<int> idList = new List<int>();
            foreach (var item in strIds)
            {
                idList.Add(int.Parse(item));
            }
            UserInfoService.Restore(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
    }
}
