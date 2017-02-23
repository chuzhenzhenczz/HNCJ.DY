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
    [MyActionFilter(IsCheckUserLogin = false)]
    public class TopicInfoController : BaseController
    {
        //
        // GET: /Template/
        public ITopicInfoService TopicInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取全部用户信息
        public ActionResult GetAllTopicInfos()
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
            var pagedata = TopicInfoService.LoagPageData(param);
            var temp = pagedata.Select(u => new { u.ID,u.Title,u.UserInfo.UserName,u.Type, u.RegTime, u.Status,u.ModfiedTime }).ToList();
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
        public ActionResult Add(TopicInfo entity)
        {
            entity.UserInfoID = LoginUser.ID;
            entity.RegTime = DateTime.Now;
            entity.ModfiedTime = DateTime.Now;
            entity.DelFlag = true;
            TopicInfoService.Add(entity);
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
            TopicInfoService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 修改信息
        public ActionResult Edit(int id = 0)
        {
            ViewData.Model = TopicInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(TopicInfo entity)
        {
            entity.ModfiedTime = DateTime.Now;
            TopicInfoService.Update(entity);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 详细信息
        public ActionResult Details(int id = 0)
        {
            ViewData.Model = TopicInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
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
            TopicInfoService.AlterListStatus(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion
    }
}
