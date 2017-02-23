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
    public class FilesInfoController : BaseController
    {
        //
        // GET: /Template/
        public IFilesInfoService FilesInfoService { get; set; }
        public IPaityMemberService PaityMemberService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取全部用户信息
        public ActionResult GetAllFilesInfos()
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
            var pagedata = FilesInfoService.LoagPageData(param);
            var temp = pagedata.Select(u => new { u.ID,u.FileName,u.FilePath,u.Type, u.RegTime, u.Status }).ToList();
            var data = new { total = param.Total, rows = temp };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 添加信息
        [MyActionFilter(IsRoleAction = false, IsAdmin = false)]
        public ActionResult Add(string name, string path, string format,short type)
        {
            var mem=PaityMemberService.GetEntity(u => u.UserInfoID == LoginUser.ID).FirstOrDefault();
            FilesInfo entity = new FilesInfo();
            entity.RegTime = DateTime.Now;
            entity.ModfiedTime = DateTime.Now;
            entity.Type = type;
            entity.FileName = name;
            entity.FilePath = path;
            entity.FileSize = format;
            entity.Remark = name;
            entity.Status = 1;
            entity.PaityMemberID = mem.ID;
            entity.DelFlag = true;
            FilesInfoService.Add(entity);
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
            FilesInfoService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 修改信息
        public ActionResult Edit(int id = 0)
        {
            ViewData.Model = FilesInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(FilesInfo entity)
        {
            entity.ModfiedTime = DateTime.Now;
            FilesInfoService.Update(entity);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        [MyActionFilter(IsRoleAction=false,IsAdmin=false)]
        public ActionResult Update(int id, string path, string format)
        {
            var entity=FilesInfoService.GetEntity(u => u.ID == id).FirstOrDefault();
            entity.FilePath = path;
            entity.FileSize = format;
            entity.Status = 2;
            entity.ModfiedTime = DateTime.Now;
            FilesInfoService.Update(entity);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 详细信息
        public ActionResult Details(int id = 0)
        {
            ViewData.Model = FilesInfoService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
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
            FilesInfoService.AlterListStatus(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion
    }
}
