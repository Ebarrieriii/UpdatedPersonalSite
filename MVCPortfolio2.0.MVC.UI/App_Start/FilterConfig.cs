using System.Web;
using System.Web.Mvc;

namespace MVCPortfolio2._0.MVC.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
