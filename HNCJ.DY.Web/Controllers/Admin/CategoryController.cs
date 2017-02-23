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
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ICategoryService CategoryService { get; set; }
        public IStudyOnlineService StudyOnlineService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Head() {
            return View();
        }
        public ActionResult doclist()
        {
            ViewData.Model=StudyOnlineService.GetEntity(u => u.DelFlag == true).ToList();
            return View();
        }
        public ActionResult docdetail(int id=0)
        {
            var entity=StudyOnlineService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            ViewData.Model =entity;
            ViewBag.List = entity.StudyItem.Where(u => u.DelFlag == true).OrderByDescending(t => t.RegTime).ToList();
            return View();
        }
        public ActionResult movlist()
        {
            
            ViewData.Model = CategoryService.GetEntity(u => u.DelFlag == true).ToList();
            
            return View();
        }
        public ActionResult movdetail(int id=0)
        {
            var entity=CategoryService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            ViewData.Model = entity;
            ViewBag.List = entity.ContentInfo.Where(u => u.DelFlag == true).OrderByDescending(t => t.RegTime).ToList();
            return View();
        }
        public ActionResult test() {
            return View();
        }
        #region 获取全部用户信息
        public ActionResult GetAllCategorys()
        {

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
       
        #endregion
        #region 添加信息
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category entity)
        {
            entity.Name = "new item1";
            entity.RegTime = DateTime.Now;
            entity.ModfiedTime = DateTime.Now;
            entity.DelFlag = true;
            CategoryService.Add(entity);
            return Json(new { status = 1,id=entity.ID,text=entity.Name });
        }
       
        #endregion
        #region 学习资料
        public ActionResult StudyAdd()
        {
            return View();
        }
        public ActionResult StudyEdit(int id = 0)
        {
            ViewData.Model = StudyOnlineService.GetEntity(u => u.ID == id).FirstOrDefault();
            return View();
        }
        public ActionResult StudyDelete(int id = 0)
        {
            List<int> list = new List<int>() { id };
            StudyOnlineService.DeleteListByLogical(list);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 学习视频
        public ActionResult CategoryAdd()
        {
            return View();
        }
        public ActionResult CategoryEdit(int id = 0)
        {
            ViewData.Model = CategoryService.GetEntity(u => u.ID == id).FirstOrDefault();
            return View();
        }
        public ActionResult CategoryDelete(int id = 0)
        {
            List<int> list = new List<int>() { id };
            CategoryService.DeleteListByLogical(list);
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
            CategoryService.DeleteListByLogical(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 修改信息
       
        [HttpPost]
        public ActionResult Edit(int id, string name)
        {
            var entity=CategoryService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
            entity.ModfiedTime = DateTime.Now;
            entity.Name = name;
            CategoryService.Update(entity);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

        #region 详细信息
        public ActionResult Details(int id = 0)
        {
            ViewData.Model = CategoryService.GetEntity(u => u.DelFlag == true && u.ID == id).FirstOrDefault();
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
            CategoryService.AlterListStatus(idList);
            return Json(new { status = 1, errorMsg = "操作成功！！" });
        }
        #endregion

    }

    #region 树节点的辅助类
    public class Categorys
    {
        public int id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public List<Categorys> children { get; set; }
    } 
    #endregion
}
