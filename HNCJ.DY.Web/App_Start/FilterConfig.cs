using HNCJ.DY.Web.Models;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionFilterAttibut());
            filters.Add(new MyActionFilterAttribute());
        }
    }
}