using HNCJ.DY.Common;
using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using HNCJ.DY.Web.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers
{
    [MyActionFilter(IsCheckUserLogin = false)]
    public class UserDoActionController : Controller
    {
        //
        // GET: /UserDoAction/
        public IUserInfoService UserInfoService { get; set; }
        public IActionInfoService ActionInfoService { get; set; }

        #region 上传图片
        public ActionResult UploadImage()
        {
            HttpPostedFileBase postFile = Request.Files["Filedata"];//接收文件
            //文件保存目录路径
            string path = Request["name"];

            String savePath = "/Upload/Images/";
            string fileName = Path.GetFileName(postFile.FileName);//文件名称
            string fileExt = Path.GetExtension(fileName);//文件的扩展名
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            savePath += ymd + "/";            
            String dirPath = Request.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            
            string newfileName = Guid.NewGuid().ToString();//新的文件名
            string fileDir = savePath + newfileName + fileExt;//完整的路径
            postFile.SaveAs(Request.MapPath(fileDir));//保存文件
            if (!string.IsNullOrEmpty(path)) {
                FileInfo file = new FileInfo(Server.MapPath(path));//指定文件路径
                if (file.Exists)//判断文件是否存在
                {
                    file.Attributes = FileAttributes.Normal;//将文件属性设置为普通,比方说只读文件设置为普通
                    file.Delete();//删除文件
                }
            }
            return Json(new { path = fileDir }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 上传文件
        public ActionResult UploadFile()
        {
            HttpPostedFileBase postFile = Request.Files["Filedata"];//接收文件
            string name = Request["name"];
            //文件保存目录路径
            String savePath = "/Upload/Files/";

            string fileName = Path.GetFileName(postFile.FileName);//文件名称
            if (string.IsNullOrEmpty(name))
            {
                string[] dd = fileName.Split('.');
                name = dd[0];
            }
            string fileExt = Path.GetExtension(fileName);//文件的扩展名
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            savePath += ymd + "/";
            string dirpath = Request.MapPath(savePath);
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }

            string newfileName = Guid.NewGuid().ToString();//新的文件名
            string fileDir = savePath + newfileName + fileExt;//完整的路径
            postFile.SaveAs(Request.MapPath(fileDir));//保存文件

            return Json(new { path = fileDir, name = name, format = fileExt }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadFile1()
        {
            HttpPostedFileBase postFile = Request.Files["Filedata"];//接收文件
            string path = Request["path"];
            //文件保存目录路径
            String savePath = "/Upload/Files/";

            string fileName = Path.GetFileName(postFile.FileName);//文件名称
            if (!string.IsNullOrEmpty(path))
            {
                FileInfo file = new FileInfo(Server.MapPath(path));//指定文件路径
                if (file.Exists)//判断文件是否存在
                {
                    file.Attributes = FileAttributes.Normal;//将文件属性设置为普通,比方说只读文件设置为普通
                    file.Delete();//删除文件
                }
            }
            string fileExt = Path.GetExtension(fileName);//文件的扩展名
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            savePath += ymd + "/";
            string dirpath = Request.MapPath(savePath);

            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            string newfileName = Guid.NewGuid().ToString();//新的文件名
            string fileDir = savePath + newfileName + fileExt;//完整的路径
            postFile.SaveAs(Request.MapPath(fileDir));//保存文件

            return Json(new { path = fileDir, name = newfileName, format = fileExt }, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region 下载
        public FileStreamResult DownLoad(string path)
        {
            if (string.IsNullOrEmpty(path)) {
                return null;
            }
            string filepath = Server.MapPath(path);
            FileInfo file = new FileInfo(filepath);
            if (!file.Exists) {
                return null;
            }
            string[] str = path.Split('/');
            return File(new FileStream(filepath, FileMode.Open), "application/octet-stream", str[str.Length - 1]);
        }
        #endregion

        #region 判断是否登陆
        [HttpPost]
        public ActionResult Check_login()
        {
            HttpCookie cookie = Request.Cookies["userLoginId"];
            if (cookie == null)
            {
                return Json(new { status=0});
            }

            string userGuid = cookie.Value;
            if (Common.Cache.CacheHelper.GetCache(userGuid) == null)
            {
                return Json(new { status = 0 });
            }
            return Json(new { status=1});
        }
        #endregion

        #region 注销操作
        public ActionResult Exits()
        {
            HttpCookie cookie = Request.Cookies["userLoginId"];
            string userGuid = cookie.Value;
            Common.Cache.CacheHelper.SetCache(userGuid, "", DateTime.Now.AddMonths(-1));
            if (cookie != null)
            {
                cookie.Value = null;
                cookie.Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cookies.Add(cookie);
            return Redirect("/Content/bigdatalogin/bigdatalogin.html");

        }
        public ActionResult AdminExits()
        {
            HttpCookie cookie = Request.Cookies["userLoginId"];
            string userGuid = cookie.Value;
            Common.Cache.CacheHelper.SetCache(userGuid, "", DateTime.Now.AddMonths(-1));
            if (cookie != null)
            {
                cookie.Value = null;
                cookie.Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("AdminLogin", "UserLogin");

        }
        #endregion

        #region 注册操作
        public ActionResult register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.RegTime = DateTime.Now;
 
                userInfo.DelFlag = true;
                userInfo.UserKey = Utils.GetCheckCode(6); //获得6位的salt加密字符串
                userInfo.Userpwd = DESEncrypt.Encrypt(userInfo.Userpwd, userInfo.UserKey);
                UserInfo user = UserInfoService.Add(userInfo);
                if (user == null)
                {
                    return Content("no");
                }
                string userLoginId = Guid.NewGuid().ToString();
                Common.Cache.CacheHelper.AddCache(userLoginId, user, DateTime.Now.AddMinutes(20));
                //往客户端写入cookie
                Response.Cookies["userLoginId"].Value = userLoginId;
                return Content("ok");
            }
            return Content("no");
        }
        #endregion

        #region 导出表格
//        .doc     application/msword
//.docx   application/vnd.openxmlformats-officedocument.wordprocessingml.document
//.rtf       application/rtf
//.xls     application/vnd.ms-excel	application/x-excel
//.xlsx    application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
//.ppt     application/vnd.ms-powerpoint
//.pptx    application/vnd.openxmlformats-officedocument.presentationml.presentation
//.pps     application/vnd.ms-powerpoint
//.ppsx   application/vnd.openxmlformats-officedocument.presentationml.slideshow
//.pdf     application/pdf
//.swf    application/x-shockwave-flash
//.dll      application/x-msdownload
//.exe    application/octet-stream
//.msi    application/octet-stream
//.chm    application/octet-stream
//.cab    application/octet-stream
//.ocx    application/octet-stream
//.rar     application/octet-stream
//.tar     application/x-tar
//.tgz    application/x-compressed
//.zip    application/x-zip-compressed
//.z       application/x-compress
//.wav   audio/wav
//.wma   audio/x-ms-wma
//.wmv   video/x-ms-wmv
//.mp3 .mp2 .mpe .mpeg .mpg     audio/mpeg
//.rm     application/vnd.rn-realmedia
//.mid .midi .rmi     audio/mid
//.bmp     image/bmp
//.gif     image/gif
//.png    image/png
//.tif .tiff    image/tiff
//.jpe .jpeg .jpg     image/jpeg
//.txt      text/plain
//.xml     text/xml
//.html     text/html
//.css      text/css
//.js        text/javascript
//.mht .mhtml   message/rfc822
        public FileContentResult ExportExcel()
        {
            var data = ActionInfoService.GetEntity(u => u.DelFlag == true).ToList();
            var list = data.Select(u => new { u.ID,u.ActionName, u.Url, u.HttpMethd, IsMenu = (bool)u.IsMenu ? "是" : "否" }).ToList();
            LocalReport lr = new LocalReport();
            //设置报表格式
            string deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
            //设置报表路径
            lr.ReportPath = Server.MapPath("~/Report/Report1.rdlc");
            //设置数据源
            ReportDataSource rd = new ReportDataSource();
            rd.Name = "DataSet1";
            rd.Value = list;
            lr.DataSources.Add(rd);
            byte[] bytes = lr.Render("Excel",deviceInfo);

            return File(bytes,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","MyAction.xls");
        }

        
        #endregion

    }
}
