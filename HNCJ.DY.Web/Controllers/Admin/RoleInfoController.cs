using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers
{
    public class RoleInfoController : BaseController
    {
        //
        // GET: /RoleInfo/
        IRoleInfoService RoleInfoService { get; set; }
        IActionInfoService ActionInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        #region 获取全部用户信息
        public ActionResult GetAllRoleInfos()
        {
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            int itemid = int.Parse(Request["itemid"] ?? "0");
            string key = Request["key"] ?? "";
            BaseParam param = new BaseParam()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                ItemId = itemid,
                Key = key
            };
            var pagedata = RoleInfoService.LoagPageData(param);
            var tmp = pagedata.Select(u => new { u.ID, u.RoleName, u.DelFlag, u.RegTime,u.ModfiedTime, u.Status });
            var data = new { total = param.Total, rows = tmp.ToList() };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加角色
        public ActionResult Add() {
            return View();
        }
        [HttpPost]
        public ActionResult Add(RoleInfo roleInfo)
        {
            roleInfo.RegTime = DateTime.Now;
            roleInfo.ModfiedTime = DateTime.Now;
            roleInfo.DelFlag = true;
            RoleInfoService.Add(roleInfo);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 删除角色信息
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
            RoleInfoService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion
        
        #region 修改角色信息
        public ActionResult Edit(int id=0)
        {
            ViewData.Model = RoleInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            return View();

        }
        [HttpPost]
        public ActionResult Edit(RoleInfo RoleInfo)
        {
            RoleInfo.ModfiedTime = DateTime.Now;
            RoleInfoService.Update(RoleInfo);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 详细信息
        public ActionResult Details(int id=0)
        {
            ViewData.Model = RoleInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            return View();
        }
        #endregion

        #region 给角色赋予权限
        public ActionResult SetAction(int id=0) {
            ViewData.Model = RoleInfoService.GetEntity(u => u.ID == id).FirstOrDefault();
            return View();
        }
        public ActionResult Action(int id, string actionlist)
        {
            List<int> setActionIdList = new List<int>();
            string[] list = actionlist.Split(',');
            foreach (var key in list)
            {
                int actionId = int.Parse(key);
                setActionIdList.Add(actionId);

            }
            RoleInfoService.SetAction(id, setActionIdList);
            return Json(new { status =1, msg = "操作成功" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getaction(int id=0) {
            var model = RoleInfoService.GetEntity(u => u.ID == id).FirstOrDefault();
            var data=model.ActionInfo.Select(u=>u.ID).ToList();
            return Json(new {status=1,data=data });
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
            RoleInfoService.AlterListStatus(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion
        
    }
}
