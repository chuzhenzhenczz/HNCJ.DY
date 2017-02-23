using HNCJ.DY.Common;
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
    [MyActionFilter(IsCheckUserLogin=false)]
    public class UserLoginController : Controller
    {
        //
        // GET: /UserLogin/
        public IUserInfoService UserInfoService { get; set; }

        
        #region 验证码
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns>返回一张图片</returns>
        public ActionResult ShowVcode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["code"] = code;
            byte[] image = validateCode.CreateValidateGraphic(code);
            return File(image, @"image/jpeg");
        } 
        #endregion

        #region 管理员登陆
        public ActionResult adminLogin()
        {
            return View();
        }
        
        /// <summary>
        /// 管理员登录请求
        /// </summary>
        /// <returns></returns>
        public ActionResult adminProcessLogin()
        {
            string code = Session["code"] as string;
            Session["code"] = null;
            string vcode = Request["vCode"] as string;
            if (string.IsNullOrEmpty(code))
            {
                return Json(new { status = 0, msg = "验证码为空！" });
            }
            if (string.IsNullOrEmpty(vcode))
            {
                return Json(new { status = 0, msg = "验证码为空！" });
            }
            if (!code.Equals(vcode))
            {
                return Json(new { status = 0, msg = "验证码错误！" });
            }
            string name = Request["LoginCode"];
            string pwd = Request["LoginPwd"];
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(pwd)) {
                return Json(new { status = 0, msg = "用户名或密码不能为空？？" });
            }
            if (!UserInfoService.Exits(name)) {
                return Json(new { status = 0, msg = "用户不存在？？" });
            }
            UserInfo userInfo = UserInfoService.GetModel(name, pwd, true);
            if (userInfo == null)
            {
                return Json(new { status = 0, msg = "密码错误！" });
            }
            //立即分配一个标志Guid，把标志作为memcache存储数据的key，把用户对象放到memcache.把Guid写到客户端cookie里面去。
            string userLoginId = Guid.NewGuid().ToString();
            Common.Cache.CacheHelper.AddCache(userLoginId, userInfo, DateTime.Now.AddMinutes(20));
            //往客户端写入cookie
            Utils.WriteCookie("userLoginId", userLoginId, 14400);

            //Response.Cookies["userLoginId"].Value = userLoginId;
            return Json(new { status = 1, msg = "登陆成功！" });

        } 
        #endregion

        #region 用户登陆
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 用户登录请求
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ProcessLogin()
        {
            string code = Session["code"] as string;
            Session["code"] = null;
            string vcode = Request["ucode"] as string;
            if (string.IsNullOrEmpty(code))
            {
                return Json(new { status = 0, msg = "验证码为空！" });
            }
            if (string.IsNullOrEmpty(vcode))
            {
                return Json(new { status = 0, msg = "验证码为空！" });
            }
            if (!code.Equals(vcode))
            {
                return Json(new { status = 0, msg = "验证码错误！" });
            }
            string name = Request["tel"];
            string pwd = Request["pwd"];
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(pwd))
            {
                return Json(new { status = 0, msg = "用户名或密码不能为空？？" });
            }
            if (!UserInfoService.Exits(name))
            {
                return Json(new { status = 0, msg = "用户不存在？？" });
            }
            UserInfo userInfo = UserInfoService.GetModel(name, pwd, true);
            if (userInfo == null)
            {
                return Json(new { status = 0, msg = "密码错误？？" });
            }
            //立即分配一个标志Guid，把标志作为memcache存储数据的key，把用户对象放到memcache.把Guid写到客户端cookie里面去。
            string userLoginId = Guid.NewGuid().ToString();
            Common.Cache.CacheHelper.AddCache(userLoginId, userInfo, DateTime.Now.AddMinutes(20));
            //往客户端写入cookie
            Utils.WriteCookie("userLoginId", userLoginId, 14400);

            //Response.Cookies["userLoginId"].Value = userLoginId;
            return Json(new { status = 1, msg = "登陆成功！" });

        } 
        #endregion

        #region 用户注册
        public ActionResult registsubmit()
        {
            string code = Session["code"] as string;
            Session["code"] = null;
            string vcode = Request["vucode"] as string;
            if (string.IsNullOrEmpty(code))
            {
                return Json(new { status = 0, msg = "验证码为空！" });
            }
            if (string.IsNullOrEmpty(vcode))
            {
                return Json(new { status = 0, msg = "验证码为空！" });
            }
            if (!code.Equals(vcode))
            {
                return Json(new { status = 0, msg = "验证码错误！" });
            }
            string name = Request["tel"];
            string pwd = Request["pwd"];
            string pwd1 = Request["pwd1"];
            if (UserInfoService.Exits(name))
            {
                return Json(new { status = 0, msg = "用户名已存在！！" }); 
            }
            if (!pwd.Equals(pwd1)) {
                return Json(new { status = 0, msg = "两次密码不一致！！" }); 
            }
            UserInfo userInfo =new UserInfo();
            userInfo.UserName = name;
            userInfo.RegTime = DateTime.Now;
            userInfo.ModfiedTime = DateTime.Now;
            userInfo.DelFlag = true;
            userInfo.Status = 1;
            userInfo.UserKey = Utils.GetCheckCode(6); //获得6位的salt加密字符串
            userInfo.Userpwd = DESEncrypt.Encrypt(pwd, userInfo.UserKey);
            UserInfoService.Add(userInfo);
            UserInfoService.AddPaityMember(userInfo.ID);            
            
            //立即分配一个标志Guid，把标志作为memcache存储数据的key，把用户对象放到memcache.把Guid写到客户端cookie里面去。
            string userLoginId = Guid.NewGuid().ToString();
            Common.Cache.CacheHelper.AddCache(userLoginId, userInfo, DateTime.Now.AddMinutes(20));
            //往客户端写入cookie
            Utils.WriteCookie("userLoginId", userLoginId, 14400);

            //Response.Cookies["userLoginId"].Value = userLoginId;
            return Json(new { status = 1, msg = "登陆成功！" });
            
        }
        #endregion
    }
}
