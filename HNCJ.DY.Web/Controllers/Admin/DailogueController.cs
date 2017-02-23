using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers
{
    public class DailogueController : Controller
    {
        //
        // GET: /Template/
        public IDailogueService DailogueService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取全部用户信息
        public ActionResult GetAllDailogues()
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
            var pagedata = DailogueService.LoagPageData(param);
            var temp = pagedata.Select(u => new { u.ID,u.Name, u.RegTime, u.Status }).ToList();
            var data = new { total = param.Total, rows = temp };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 添加信息
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Dailogue entity)
        {
            entity.RegTime = DateTime.Now;
            entity.ModfiedTime = DateTime.Now;
            entity.DelFlag = true;
            DailogueService.Add(entity);
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
            DailogueService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 修改信息
        public ActionResult Edit(int id = 0)
        {
            ViewData.Model = DailogueService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Dailogue entity)
        {
            entity.ModfiedTime = DateTime.Now;
            DailogueService.Update(entity);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 详细信息
        public ActionResult Details(int id = 0)
        {
            ViewData.Model = DailogueService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            return View();
        }
        #endregion
    }
}
