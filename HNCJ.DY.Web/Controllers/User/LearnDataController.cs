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
    public class LearnDataController : Controller
    {
        //
        // GET: /LearnData/
        public IStudyOnlineService StudyOnlineService { get; set; }
        public IStudyItemService StudyItemService { get; set; }
        public ICategoryService CategoryService { get; set; }
        public IContentInfoService ContentInfoService { get; set; }
        public ActionResult GetAllLearns()
        {
            short? type = short.Parse(Request["type"] ?? "1");
            int size = short.Parse(Request["size"] ?? "14");
            var data = StudyOnlineService.GetEntity(u => u.DelFlag == true && u.Status == type).OrderByDescending(u => u.RegTime).Take(size).Select(u => new { u.ID, u.Name }).ToList();
            return Json(data);
        }

        public ActionResult GetStudyItems() {

            int  StudyOnlineID = int.Parse(Request["key"]??"0");
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            var dd = StudyOnlineService.GetEntity(u => u.ID == StudyOnlineID).FirstOrDefault();
            var temp = StudyItemService.GetEntity(u => u.DelFlag == true && u.StudyOnlineID == StudyOnlineID);
            var list = temp.OrderByDescending(t => t.RegTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            var data = list.Select(d => new { d.ID, d.Context, d.RegTime,d.UserInfo.Icon,d.UserInfoID }).ToList();
            var count = Convert.ToInt32(Math.Ceiling((double)temp.Count() / pageSize));
            var str = HNCJ.DY.Common.PageBar.GetPageBar(pageIndex, count, "talk", StudyOnlineID);
            return Json(new { datas = data, str = str,Title=dd.Name,Content=dd.Content },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(int id=0,string content="") {
            StudyItem model = new StudyItem();
            model.RegTime = DateTime.Now;
            model.ModfiedTime = DateTime.Now;
            model.StudyOnlineID = id;
            model.DelFlag = true;
            model.Context = content;
            model.UserInfoID = 1;
            StudyItemService.Add(model);
            return Json(new { status = 1, msg = "成功" });
        }
        public ActionResult AddContent(int id = 0, string content = "")
        {
            ContentInfo model = new ContentInfo();
            model.RegTime = DateTime.Now;
            model.ModfiedTime = DateTime.Now;
            model.CategoryID = id;
            model.DelFlag = true;
            model.dContent = content;
            model.UserInfoID = 1;
            ContentInfoService.Add(model);
            return Json(new { status = 1, msg = "成功" });
        }

        public ActionResult GetAllVedios()
        {
            short? type = short.Parse(Request["type"] ?? "1");
            int size = short.Parse(Request["size"] ?? "14");
            var data = CategoryService.GetEntity(u => u.DelFlag == true && u.Status == type).OrderByDescending(u => u.RegTime).Take(size).Select(u => new { u.ID, u.Name }).ToList();
            return Json(data);
        }
        public ActionResult GetContentInfos()
        {

            int StudyOnlineID = int.Parse(Request["key"] ?? "0");
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            var dd = CategoryService.GetEntity(u => u.ID == StudyOnlineID).FirstOrDefault();
            var temp = ContentInfoService.GetEntity(u => u.DelFlag == true && u.CategoryID == StudyOnlineID);
            var list = temp.OrderByDescending(t => t.RegTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            var data = list.Select(d => new { d.ID, d.dContent, d.RegTime,d.UserInfo.Icon,d.UserInfoID }).ToList();
            var count=Convert.ToInt32(Math.Ceiling((double)temp.Count() / pageSize));
            var str = HNCJ.DY.Common.PageBar.GetPageBar(pageIndex, count, "talk", StudyOnlineID);
            return Json(new { datas=data,str=str,Title=dd.Name,Path=dd.Path },JsonRequestBehavior.AllowGet);
        }

        #region 分页
        private string GetPageBar(int id, int pageIndex, int pageCount)
        {
            if (pageCount == 1||pageCount==0)
            {
                return string.Empty;
            }
            var index = pageIndex;
            int start = pageIndex - 5;//起始位置要求显示10个数字页码
            start = start < 1 ? 1 : start;
            int end = start + 4; //终止位置
            end = end > pageCount ? pageCount : end;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<ul class='pagination pagination-lg'>"));

            if (1 == index)
            {
                sb.Append(string.Format("<li class='disabled'><a href='?id={0}&page={1}'>&lt;</a></li>", id, 1));
            }
            else
            {
                sb.Append(string.Format("<li ><a href='?id={0}&page={1}'>&lt;</a></li>", id, --pageIndex));
            }
            for (int i = start; i <= end; i++)
            {
                if (i == index)
                {
                    sb.Append(string.Format("<li class='active'><a href=''>{0}</a></li>", i));
                }
                else
                {
                    sb.Append(string.Format("<li><a href='?id={0}&page={1}'>{2}</a></li>", id, i, i));
                }



            }
            if (pageCount == index)
            {
                sb.Append(string.Format("<li class='disabled' ><a href=''>&gt;</a></li>"));
            }
            else
            {
                sb.Append(string.Format("<li ><a href='?id={0}&page={1}'>&gt;</a></li>", id, ++pageIndex));
            }

            sb.Append(string.Format("</ul>"));
            return sb.ToString();
        } 
        #endregion

        #region 点赞
        public ActionResult ClickZan1(int id = 0)
        {
            var entity = StudyOnlineService.GetEntity(u => u.ID == id).FirstOrDefault();
            var count = entity.Count;
            entity.Count = ++count;
            StudyOnlineService.Update(entity);
            return Json(new { status = 1, msg = "成功" });

        }
        public ActionResult ClickZan2(int id = 0)
        {
            var entity = CategoryService.GetEntity(u => u.ID == id).FirstOrDefault();
            var count = entity.Count;
            entity.Count = ++count;
            CategoryService.Update(entity);
            return Json(new { status = 1, msg = "成功" });

        } 
        #endregion
    }
}
