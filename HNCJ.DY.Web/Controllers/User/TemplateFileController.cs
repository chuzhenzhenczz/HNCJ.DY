using HNCJ.DY.IBLL;
using HNCJ.DY.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers.User
{
    [MyActionFilter(IsCheckUserLogin = false)]
    public class TemplateFileController : Controller
    {
        //
        // GET: /TemplateFile/
        public ITemplateService TemplateService { get; set; }
       
        public ActionResult GetAllFiles()
        {
            string KeyString = Request["key"];
            int pageSize = int.Parse(Request["rows"] ?? "5");
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            var temp = TemplateService.GetEntity(u => u.DelFlag == true && u.Status == 1);
            if (!string.IsNullOrEmpty(KeyString)) {
                temp = temp.Where(u => u.Context.Contains(KeyString));
            }
            var list = temp.OrderByDescending(t => t.RegTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            var data = list.Select(d => new { d.ID, d.Context, d.Path, d.RegTime }).ToList();
            var count = Convert.ToInt32(Math.Ceiling((double)temp.Count() / pageSize));
            var str = HNCJ.DY.Common.PageBar.GetPageBars(pageIndex, count, "upFiles",KeyString);
            return Json(new {data=data,str=str },JsonRequestBehavior.AllowGet);
        }
    }
}
