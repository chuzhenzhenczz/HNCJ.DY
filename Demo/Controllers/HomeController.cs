using HNCJ.DY.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        TopicInfoService server = new TopicInfoService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetJson() {
            int pageSize = int.Parse(Request["pagesize"] ?? "20");
            int pageIndex = int.Parse(Request["index"] ?? "1");
            var list=server.GetEntity(u => u.DelFlag == true).ToList();
            var data = list.Skip(pageSize * (pageIndex - 1)).Take(pageSize).Select(u => u.RegTime.Value.ToString("yyyyMMdd")).ToList();
            return Json(data);
        }

    }
}
