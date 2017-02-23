using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers
{
    public class NewInfoController : Controller
    {
        //
        // GET: /NewInfo/
        public INewInfoService NewInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取全部用户信息
        public ActionResult GetAllNewInfos()
        {
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            int itemid = int.Parse(Request["itemid"] ?? "0");
            string key = Request["key"];
            BaseParam param = new BaseParam()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                ItemId = itemid,
                Key = key
            };
            var pagedata = NewInfoService.LoagPageData(param);
            var tmp = pagedata.Select(u => new { u.ID,u.Title,u.Author,u.ImagePath,u.Type, u.Status, u.RegTime, u.ModfiedTime });
            var data = new { total = param.Total, rows = tmp.ToList() };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加信息
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(NewInfo NewInfo)
        {
            NewInfo.RegTime = DateTime.Now;
            NewInfo.ModfiedTime = DateTime.Now;
            NewInfo.DelFlag = true;
            NewInfo.Status = 1;
            NewInfoService.Add(NewInfo);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
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
            NewInfoService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 修改信息
        public ActionResult Edit(int id = 0)
        {
            var model = NewInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "党内即时新闻", Selected = false, Value = "1" });
            list.Add(new SelectListItem() { Text = "党内国内信息公告", Selected = false, Value = "2" });
            foreach (var item in list) {
                if (item.Value.Equals(model.Type.ToString())) {
                    item.Selected = true;
                }
            }
            ViewData.Model = model;
            ViewData["Type"] = list;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewInfo NewInfo)
        {
            NewInfo.ModfiedTime = DateTime.Now;
            NewInfoService.Update(NewInfo);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 详细信息
        public ActionResult Details(int id = 0)
        {
            ViewData.Model = NewInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
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
            NewInfoService.AlterListStatus(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion
    }
}
