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
    [MyActionFilter(IsCheckUserLogin = false)]
    public class FriendController : BaseController
    {
        //
        // GET: /Friend/
        public IFriendService FriendService { get; set; }
        public IUserInfoService UserInfoService { get; set; }
        public IMessageService MessageService { get; set; }
        public ActionResult Add(Friend entity)
        {
            entity.DelFlag = true;
            entity.RegTime = DateTime.Now;
            entity.Status = 1;
            FriendService.Add(entity);
            return Json(new {status=1,msg="成功" });
        }
        public ActionResult AddFriend(int FriendID) {
            Friend entity = new Friend();
            entity.FriendID = FriendID;
            entity.UserInfoID = LoginUser.ID;
            entity.DelFlag = true;
            entity.RegTime = DateTime.Now;
            entity.Status = 1;
            var user=FriendService.GetEntity(u => u.FriendID == FriendID && u.UserInfoID == LoginUser.ID).FirstOrDefault();
            if (user == null) {
                FriendService.Add(entity);
                return Json(new { status = 1, msg = "成功" });
            }
            return Json(new { status = 0, msg = "你们已经是好友了！！" });
            
        }
        public ActionResult GetFriends() {
            int UserId = LoginUser.ID;
            var entity=UserInfoService.GetEntity(u => u.ID == UserId).FirstOrDefault();
            var myfriend = entity.Friend.Where(u => u.DelFlag == true).Select(u => u.FriendID).ToList();
            var data = UserInfoService.GetEntity(u => u.DelFlag == true && myfriend.Contains(u.ID)).Select(u=>new {u.ID,u.UserName,u.Icon,u.ModfiedTime }).ToList();

            return Json(new {list=data,str=""},JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUsers(int id=0) {
            var entity = UserInfoService.GetEntity(u => u.ID == id).FirstOrDefault();
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<li><img src={0} alt='' ></li>", entity.Icon));
            sb.Append(string.Format("<li>{0}</li>", entity.UserName));
            sb.Append(string.Format("<li>{0}<input type='hidden' value={1} id='user' /></li>", "党员",id));
            sb.Append(string.Format("<li><img src={0} alt='' ></li>", "../../../img/add1.png"));
            var message = GetMessage(id);
            return Json(new { user = sb.ToString(), message = message },JsonRequestBehavior.AllowGet);
        }

        #region 发送消息
        public ActionResult AddMessage(Message entity)
        {
            int UserID = LoginUser.ID;
            entity.DelFlag = true;
            entity.RegTime = DateTime.Now;
            entity.Status = 1;
            entity.SenderID = UserID;
            MessageService.Add(entity);
            return Json(new { status = 1, msg = "成功" });
        } 
        #endregion

        #region 消息
        private string GetMessage(int RecipientID)
        {
            int UserID = LoginUser.ID;
            List<Message> list = new List<Message>();
            var data1 = MessageService.GetEntity(u => u.DelFlag == true && u.SenderID == UserID && u.RecipientID == RecipientID).ToList();
            var data2 = MessageService.GetEntity(u => u.DelFlag == true && u.SenderID == RecipientID && u.RecipientID == UserID).ToList();
            list.AddRange(data1);
            list.AddRange(data2);
            list=list.OrderBy(t => t.RegTime).ToList();
            var str = GetMessageHtml(list, RecipientID, UserID);
            return str;
        }

       
        private string GetMessageHtml(List<Message> list, int RecipientID, int SenderID) {
            var Recipient = UserInfoService.GetEntity(u => u.ID == RecipientID).FirstOrDefault();
            var Sender = UserInfoService.GetEntity(u => u.ID == SenderID).FirstOrDefault();
            List<int> statuslist = new List<int>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var item in list) {
                if (item.Status == 1 && item.RecipientID == SenderID)
                {
                    statuslist.Add(item.ID);
                }
                //string Icon=Sender.Icon,UserName=Sender.UserName;
                if (item.SenderID != SenderID)
                {
                    //Icon=Recipient.Icon;
                    //UserName=Recipient.UserName;
                    sb.Append(string.Format("<div class='other-talk'><img src={0} alt=''>", Recipient.Icon));
                    sb.Append(string.Format("<div class='talk-content-bottom'><p class='talk-one'></p>"));
                    sb.Append(string.Format("<div class='talk-content'>{0}</div></div></div>", item.Msg));
                }
                else { 
                sb.Append(string.Format("<div class='other-talk2'><div class='talk-content-bottom2'>"));
                    sb.Append(string.Format("<div class='talk-content2'>{0}</div> <p class='talk-one2'></p>",item.Msg));
                    sb.Append(string.Format("</div><img src={0} alt=''></div>", Sender.Icon));
                }
                
            }

            MessageService.AlterListStatus(statuslist);
            return sb.ToString();
        }
        #endregion

        #region 未读消息

        public ActionResult GeTNoReadMessage() {
            int UserID = LoginUser.ID;
            var noreaddata=MessageService.GetEntity(u => u.DelFlag == true && u.RecipientID == UserID && u.Status == 1).Select(u=>u.SenderID).Distinct().ToList();
            var list=UserInfoService.GetEntity(u => noreaddata.Contains(u.ID)).ToList();
            var data = GetReadHtml(list);
            return Json(data);
        }
      
        private string GetReadHtml(List<UserInfo> list) {
            var data = MessageService.GetEntity(u => u.DelFlag == true && u.Status == 1).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in list) {
                var count = data.Where(u => u.SenderID == item.ID).Count();
                var time = item.RegTime;
                sb.Append(string.Format("<a href='#' onclick='ClickUser({0})'><div class='myFriend-one'>",item.ID));
                sb.Append(string.Format("<img src={0} alt=''><div class='myFriend-name'>", item.Icon));
                sb.Append(string.Format("<div class='Friend-name'><p>{0}</p></div>", item.UserName));
                sb.Append(string.Format("<div class='name'><div class='time' >未读消息({0})</div></div></div></div></a>", count));
            }
            return sb.ToString();
        }
        #endregion

    }
}
