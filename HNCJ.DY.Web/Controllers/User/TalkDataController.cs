using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using HNCJ.DY.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers.User
{
    [MyActionFilter(IsRoleAction=false,IsAdmin=false)]
    public class TalkDataController : BaseController
    {
        //
        // GET: /TalkData/
        public ITopicInfoService TopicInfoService { get; set; }
        public IUserInfoService UserInfoService { get; set; }
        public IPaityMemberService PaityMemberService { get; set; }
        #region 热点
        public ActionResult TalkData1()
        {
            int TopicInfoID = int.Parse(Request["TopID"] ?? "1");
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int sort = int.Parse(Request["sort"] ?? "0");
            var list = TopicInfoService.GetEntity(u => u.DelFlag == true && u.TopicInfoID == TopicInfoID).Select(u => new TTData { ID = u.ID, Title = u.Title, Content = u.Content, UserName = u.UserInfo.UserName, Count = u.UserInfo1.Count, Icon = u.UserInfo.Icon, RegTime = u.RegTime, Number = u.TopicInfo1.Count, UserID=u.UserInfoID }).ToList();
            var data = list;
            if (sort == 1)
            {
                data = data.OrderByDescending(t => t.RegTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            }
            else if(sort==2){
                data = data.OrderByDescending(t => t.Count).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            }
            else if (sort == 3)
            {
                data = data.OrderByDescending(t => t.Number).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            }
            else {
                data = data.OrderByDescending(r => r.Count).OrderByDescending(t => t.RegTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            }
            
            var count = Convert.ToInt32(Math.Ceiling((double)list.Count() / pageSize));
            var str=HNCJ.DY.Common.PageBar.GetPageBars(pageIndex, count,"add",sort.ToString());
            var str1 = StrToHtml(data);
            return Json(new {list=data,str=str,str1=str1 },JsonRequestBehavior.AllowGet);
        }
         
        private string StrToHtml(List<TTData> list) {
            int UserId =this.LoginUser.ID;
            var model = UserInfoService.GetEntity(u => u.ID == UserId).FirstOrDefault();
            List<int> allID = new List<int>();
            foreach (var item in model.TopicInfo1) {
                allID.Add(item.ID);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in list) {
                var str1="../../../img/zan1.png";
                var str2 = "../../../img/zan2.png";
                var flag = allID.Contains(item.ID);
                string userinfoID = item.UserID == this.LoginUser.ID ? "../talk.html" : "../otherHome.html?id="+item.UserID;
                sb.Append(string.Format("<div class='user-content-min'><div class='user-phone'>"));
                sb.Append(string.Format("<a href={1}><img src='{0}'></a></div><div class='user-name-talk'>", item.Icon,userinfoID));
                sb.Append(string.Format("<div class='user-name'>{0}</div><div class='user-lv'>{1}</div>", item.UserName,"v1"));
                sb.Append(string.Format("<div class='user-number' >"));
                if (flag)
                {
                    sb.Append(string.Format("<img class='user-img' src='{0}'  alt=''>", str2));
                }
                else {
                    sb.Append(string.Format("<img class='user-img' src='{0}' onclick='good($(this),{1})' alt=''>", str1, item.ID));
                }
                
                sb.Append(string.Format("<span>{0}</span></div></div>",item.Count));
                sb.Append(string.Format("<a href='talkdetail.html?id={0}'><div class='user-content-bottom'>",item.ID));
                sb.Append(string.Format("<p class='user-title'>{0}</p><div class='user-content'><p>{1}</p>", item.Title, "关键字"));
                sb.Append(string.Format("<p class='user-talk-p'>{0}</p></div></div></a></div>",item.Content));
            }
            return sb.ToString();
        }
        #endregion

        #region 发帖
        public ActionResult talkadd(string title,string content) {
            int UserID = this.LoginUser.ID;
            TopicInfo model = new TopicInfo();
            model.Content = content;
            model.DelFlag = true;
            model.ModfiedTime = DateTime.Now;
            model.RegTime = DateTime.Now;
            model.Status = 1;
            model.Title = title;
            model.Type = 1;
            model.TopicInfoID = 1;
            model.UserInfoID = UserID;
            TopicInfoService.Add(model);

            return Json(new { status = 1, msg = "成功" });
        }
        #endregion

        #region 回帖
        public ActionResult talkhuitie(int id, string content)
        {
            int UserID = this.LoginUser.ID;
            TopicInfo model = new TopicInfo();
            model.Content = content;
            model.DelFlag = true;
            model.ModfiedTime = DateTime.Now;
            model.RegTime = DateTime.Now;
            model.Status = 1;
            model.Title = "";
            model.Type = 1;
            model.TopicInfoID = id;
            model.UserInfoID = UserID;
            TopicInfoService.Add(model);

            return Json(new { status = 1, msg = "成功" });
        }
	    #endregion

        #region 我的帖子
        public ActionResult MyTalk() {
            int UserID = this.LoginUser.ID;
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            var user = UserInfoService.GetEntity(u => u.ID == UserID).FirstOrDefault();
            var list = user.TopicInfo.Where(u=>u.DelFlag==true&&u.TopicInfoID==1).Select(u => new { u.ID, u.Title, u.Content,Count=u.TopicInfo1.Count,u.RegTime });
            var data = list.OrderByDescending(t=>t.RegTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            var count = Convert.ToInt32(Math.Ceiling((double)list.Count() / pageSize));
            var str = HNCJ.DY.Common.PageBar.GetPageBars(pageIndex, count, "mytalk");
            return Json(new { list=data,str=str},JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除帖子
        public ActionResult DeleteTalk(int id = 0) {
            TopicInfoService.DeleteListByLogical(new List<int> { id });
            return Json(new { status = 1, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 关注
        public ActionResult GuanZhu() {
            int UserID = this.LoginUser.ID;
            int pageSize = int.Parse(Request["pageSize"] ?? "10");
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            var entity = UserInfoService.GetEntity(u => u.ID == UserID).FirstOrDefault();
            var list=entity.TopicInfo1.Distinct();
            var data = list.OrderByDescending(r => r.RegTime).Select(u => new { u.ID, u.RegTime, u.Title, u.Content }).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            var count = Convert.ToInt32(Math.Ceiling((double)list.Count() / pageSize));
            var str = HNCJ.DY.Common.PageBar.GetPageBars(pageIndex, count, "myPost");
            return Json(new { list = data, str = str },JsonRequestBehavior.AllowGet);
        }
        public ActionResult Onclick(int Tid=0) {
            int UserID = this.LoginUser.ID;
            UserInfoService.SetGuanZhu(UserID, Tid);
            return Json(new {status=1,msg="成功" });
        }
        #endregion

        #region 个人信息
        
        public ActionResult GetUserInfo() {
            var UserId = this.LoginUser.ID;
            var userinfo = UserInfoService.GetEntity(u => u.ID == UserId).FirstOrDefault();
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<li><p>{0}</p><span>{1}</span></li>", userinfo.UserName, "党员"));
            sb.Append(string.Format("<li>账号：<span>{0}</span></li>", userinfo.UserName));
            sb.Append(string.Format("<li>等级：<div class='progress'style='height: 8px'>"));
            sb.Append(string.Format("<div class='progress-bar' role='progressbar' style='width:10%;'></div></div></li>"));
            return Json(new {user=sb.ToString(),Icon=userinfo.Icon },JsonRequestBehavior.AllowGet);
        }
        
        #endregion

        #region 主页
        public ActionResult Index() {
            var userinfo=UserInfoService.GetEntity(u => u.ID == LoginUser.ID).FirstOrDefault();
            var entity=PaityMemberService.GetEntity(u => u.UserInfoID == LoginUser.ID).FirstOrDefault();
            int year = 0;
            try {
                if (!string.IsNullOrEmpty(entity.RegularTime.ToString()))
                {
                    var i = entity.RegularTime.Value.Year;
                    var j = DateTime.Now.Year;
                    year = j - i;
                }
            }
            catch { 
            
            }
            
            if(userinfo.TopicInfo==null) return Json(new {icon=userinfo.Icon,name=userinfo.UserName,year=year,count=0 },JsonRequestBehavior.AllowGet);

            int count = userinfo.TopicInfo.Where(u => u.DelFlag == true && u.TopicInfoID == 1).Count();
            var tip = userinfo.TopicInfo1.Where(u => u.DelFlag == true && u.TopicInfoID == 1).OrderByDescending(t => t.RegTime).Take(20).Select(u => new { u.ID, u.Title }).ToList();
            return Json(new {icon=userinfo.Icon,name=userinfo.UserName,year=year,count=count,tip=tip },JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 他人的主页
        public ActionResult OtherIndex(int id=0) {
            int pageIndex = int.Parse(Request["index"] ?? "1");
            var userinfo=UserInfoService.GetEntity(u => u.ID == id).FirstOrDefault();
            var entity=PaityMemberService.GetEntity(u => u.UserInfoID ==id).FirstOrDefault();
            int year = 0;
            try
            {
                if (!string.IsNullOrEmpty(entity.RegularTime.ToString()))
                {
                    var i = entity.RegularTime.Value.Year;
                    var j = DateTime.Now.Year;
                    year = j - i;
                }
            }
            catch { }
            try
            {
                int length = userinfo.TopicInfo1.Count();
                int count = userinfo.TopicInfo.Where(u => u.DelFlag == true && u.TopicInfoID == 1).Count();
                var tip = userinfo.TopicInfo.Where(u => u.DelFlag == true && u.TopicInfoID == 1).OrderByDescending(t => t.RegTime).Skip(20 * (pageIndex - 1)).Take(20).Select(u => new { u.ID, u.Title, u.Content, time = u.RegTime.Value.ToString("yyyy/MM/dd HH:mm"), count = u.TopicInfo1.Count }).ToList();
                var size = Convert.ToInt32(Math.Ceiling((double)count / 20));
                var html = HNCJ.DY.Common.PageBar.GetPageBars(pageIndex, size, "add");
                return Json(new { icon = userinfo.Icon, name = userinfo.UserName, year = year, count = count, tip = tip, length = length, html = html }, JsonRequestBehavior.AllowGet);
            }
            catch {
                return Json(new { icon = userinfo.Icon, name = userinfo.UserName, year = year, count = 0,  length = 0 }, JsonRequestBehavior.AllowGet);
            }
          }
        #endregion
    }

    #region 辅助类
    public class TTData
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int Count { get; set; }
        public string Icon { get; set; }
        public DateTime? RegTime { get; set; }
        public int Number { get; set; }
        public int UserID { get; set; }

    } 
    #endregion
}
