using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Models
{
    public class MyExceptionFilterAttibut : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Common.LogHelper.WriteLog(filterContext.Exception.ToString() );

        }
    }
}