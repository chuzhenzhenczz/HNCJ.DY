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
    public class NewsDataController : Controller
    {
        //
        // GET: /NewsData/
        public INewInfoService NewInfoService { get; set; }
        #region 分类数据
        public ActionResult NewsDatas(int id = 0)
        {

            var data = NewInfoService.GetEntity(u => u.DelFlag == true && u.Status == 1 && u.Type == id).Select(u => new { u.ID, u.Title }).ToList();

            return Json(data);
        } 
        #endregion

        #region 详细数据
        public ActionResult Datas(int id = 0)
        {
            var newsinfo = NewInfoService.GetEntity(u => u.DelFlag == true && u.Status == 1 && u.ID == id).FirstOrDefault();
            return Json(newsinfo);
        } 
        #endregion
        #region 大家都看的数据
        public ActionResult NewsData1() {
            var newsinfo = NewInfoService.GetEntity(u => u.DelFlag == true && u.Status == 1).OrderByDescending(u => u.RegTime).Take(8).Select(u => new { u.ID, u.Title }).ToList();
            return Json(newsinfo);
        }
        #endregion
        #region 相关数据
        public ActionResult NewsData2(int id=0) {
            var data = NewInfoService.GetEntity(s => s.ID == id).FirstOrDefault();
            var newsinfo = NewInfoService.GetEntity(u => u.DelFlag == true && u.Status == 1 && u.Type == data.Type).OrderByDescending(u => u.RegTime).Take(8).Select(u => new { u.ID, u.Title }).ToList();
            return Json(newsinfo);
        }
        #endregion

    }
}
