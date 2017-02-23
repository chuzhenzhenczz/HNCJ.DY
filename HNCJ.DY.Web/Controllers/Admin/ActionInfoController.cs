using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using HNCJ.DY.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers
{
    
    public class ActionInfoController : BaseController
    {
        //
        // GET: /ActionInfo/
        public IActionInfoService ActionInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        #region 获取全部用户信息
        public ActionResult GetAllActionInfos()
        {
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            int itemid = int.Parse(Request["itemid"]??"0");
            string key = Request["key"];
            BaseParam param = new BaseParam()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                ItemId = itemid,
                Key = key
            };
            var pagedata = ActionInfoService.LoagPageData(param);
            var tmp = pagedata.Select(u => new { u.ID, u.ActionName, u.Url, u.HttpMethd,u.MenuIcon,u.IsMenu,u.Sort,u.Status,u.RegTime,u.ModfiedTime });
            var data = new { total = param.Total, rows = tmp.ToList() };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
       
        #endregion

        #region 添加信息
        public ActionResult Add() {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ActionInfo ActionInfo)
        {
            ActionInfo.RegTime = DateTime.Now;
            ActionInfo.ModfiedTime = DateTime.Now;
            ActionInfo.DelFlag = true;
            ActionInfo.IsMenu = Request["IsMenu"] == "true" ? true : false;
            ActionInfoService.Add(ActionInfo);
            return Json(new { status = 1, errorMsg="操作成功！！" });
        }
        #endregion

        #region 删除信息
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
            ActionInfoService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 修改信息
        public ActionResult Edit(int id=0)
        {
            ViewData.Model = ActionInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ActionInfo ActionInfo)
        {
            ActionInfo.ModfiedTime = DateTime.Now;
            ActionInfo.IsMenu = Request["IsMenu"] == "true" ? true : false;
            ActionInfoService.Update(ActionInfo);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 详细信息
        public ActionResult Details(int id=0)
        {
            ViewData.Model = ActionInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
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
            ActionInfoService.AlterListStatus(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

    }
}
