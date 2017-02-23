using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using HNCJ.DY.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers
{
    [MyActionFilter(IsRoleAction=false,IsAdmin=false)]
    public class VisitorRecordController : BaseController
    {
        //
        // GET: /VisitorRecord/
        public IVisitorRecordService VisitorRecordService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取全部用户信息
        public ActionResult GetAllVisitorRecords()
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
            var pagedata = VisitorRecordService.LoagPageData(param);
            var tmp = pagedata.Select(u => new { u.ID, u.RegTime,u.UserInfoID,u.VisitorName,u.VisitorIcon,u.VisitorID });
            var data = new { total = param.Total, rows = tmp.ToList() };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加信息
        public ActionResult Add(int UserID=0)
        {
            if (UserID == this.LoginUser.ID) return Json(new { status = 1, errorMsg = "操作成功！！" });
            if (Flalg(UserID)) return Json(new { status = 1, errorMsg = "操作成功！！" });
            VisitorRecord entity = new VisitorRecord();
            entity.UserInfoID =UserID;
            entity.RegTime = DateTime.Now;
            entity.DelFlag = true;
            entity.VisitorID = this.LoginUser.ID;
            entity.VisitorName = this.LoginUser.UserName;
            entity.VisitorIcon = this.LoginUser.Icon;
            VisitorRecordService.Add(entity);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }

        private bool Flalg(int UserID)
        {
            var list=VisitorRecordService.GetEntity(u=>u.UserInfoID==UserID&&u.VisitorID==this.LoginUser.ID).FirstOrDefault();
            if (list == null) return false;
            var entity = VisitorRecordService.GetEntity(u => u.UserInfoID == UserID && u.VisitorID == this.LoginUser.ID).OrderByDescending(u => u.RegTime).FirstOrDefault();
            var t = DateTime.Now.Subtract(entity.RegTime.Value).Duration();
            if (t.Days > 0 || t.Hours > 0 || t.Minutes > 30) return false;
            return true;
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
            VisitorRecordService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        public ActionResult GetAccess() {
            int value = int.Parse(Request["value"] ?? "1");
            int UserID=this.LoginUser.ID;
            var list=VisitorRecordService.GetEntity(u => u.UserInfoID == UserID&&u.DelFlag==true).OrderByDescending(t => t.RegTime).ToList();
            int count = list.Count;
            var list1=list.Where(u =>isToday(u.RegTime.Value)).ToList();
            int datecount = list1.Count;
            if (value == 2) list = list1;
            var html = GetHtml(list);
            return Json(new {html=html,count=count,datecount=datecount },JsonRequestBehavior.AllowGet);
        }
        private  bool isToday(DateTime dt)
        {
            DateTime today = DateTime.Today;
            DateTime tempToday = new DateTime(dt.Year, dt.Month, dt.Day);
            if (today == tempToday)
                return true;
            else
                return false;
        }

       
        private string GetHtml(List<VisitorRecord> list) {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list) {
                sb.Append(string.Format("<div class='myVisitor-new'><div class='list_title'>"));
                sb.Append(string.Format("<h2 class='bg2 c_tx bor2'>{0}</h2></div>",item.RegTime.Value.ToString("yyyy-MM-dd")));
                sb.Append(string.Format("<b class='bubble_trig'></b><div class='list_item'>"));
                sb.Append(string.Format("<div class='list_item-time'><p>{0}</p>",item.RegTime.Value.ToString("HH:mm")));
                sb.Append(string.Format("<img src='../../../img/time1.png' alt=''></div>"));
                sb.Append(string.Format("<div class='list_item-phone'><img src={0} alt=''></div>",item.VisitorIcon));
                sb.Append(string.Format("<div class='list_item-content'><div class='item_trig'> </div>"));
                sb.Append(string.Format("<div class='list_item-border'>"));
                sb.Append(string.Format("<p><a href={0}>{1}</a>访问了您的主页</p></div> </div></div></div>","../otherHome.html?id="+item.VisitorID,item.VisitorName));
            }
            return sb.ToString() ;
        }

    }
}
