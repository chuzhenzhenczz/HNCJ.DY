using HNCJ.DY.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers
{
    [MyActionFilter(IsCheckUserLogin = false)]
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        
        public ActionResult Login()
        {
            return Redirect("/Content/bigdatalogin/bigdatalogin.html");
        }
        public ActionResult admin() {
            return Redirect("/UserLogin/adminLogin");
        
        }

    }
}
