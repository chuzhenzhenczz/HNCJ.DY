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
    public class PaityMemberController : BaseController
    {
        //
        // GET: /PaityMember/
        public IPaityMemberService PaityMemberService { get; set; }
        public IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取全部用户信息
        public ActionResult GetAllPaityMembers()
        {
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            int itemid = int.Parse(Request["itemid"] ?? "0");
            string key = Request["key"]??"";
            BaseParam param = new BaseParam()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                ItemId = itemid,
                Key = key
            };
            var pagedata = PaityMemberService.LoagPageData(param);
            var temp = pagedata.Select(u => new { u.ID, u.Name, u.Sex, u.Brithday,u.IDCard, u.Telphone, u.RegTime, u.Status }).ToList();
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
        public ActionResult Add(PaityMember PaityMember)
        {
            PaityMember.RegTime = DateTime.Now;
            PaityMember.ModfiedTime = DateTime.Now;
            PaityMember.DelFlag = true;
            PaityMemberService.Add(PaityMember);
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
            PaityMemberService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 修改信息
        public ActionResult Edit(int id = 0)
        {
            ViewData.Model = PaityMemberService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(PaityMember PaityMember)
        {
            PaityMember.ModfiedTime = DateTime.Now;
            PaityMemberService.Update(PaityMember);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        [MyActionFilter(IsRoleAction = false, IsAdmin = false)]
        public ActionResult Update(PaityMember entity)
        {
            var mem = PaityMemberService.GetEntity(u => u.UserInfoID == LoginUser.ID).FirstOrDefault();
            mem.RegTime = DateTime.Now;
            mem.ModfiedTime = DateTime.Now;
            mem.Brithday = entity.Brithday;
            mem.ClassNO = entity.ClassNO;
            mem.ClassPosition = entity.ClassPosition;
            mem.EndTime = entity.EndTime;
            mem.FailedSubject = entity.FailedSubject;
            mem.IDCard = entity.IDCard;
            mem.JoinYLTime = entity.JoinYLTime;
            mem.Name = entity.Name;
            mem.RegularTime = entity.RegularTime;
            mem.Remark = entity.Remark;
            mem.RewardPunishment = entity.RewardPunishment;
            mem.Sex = entity.Sex;
            mem.StartTime = entity.StartTime;
            mem.SubmitTime = entity.SubmitTime;
            mem.Telphone = entity.Telphone;
            PaityMemberService.Update(mem);
            return Redirect("/Content/home/code/branch/files.html");
        }
        #endregion

        #region 详细信息
        public ActionResult Details(int id = 0)
        {
            ViewData.Model = PaityMemberService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
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
            PaityMemberService.AlterListStatus(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

    }
}
