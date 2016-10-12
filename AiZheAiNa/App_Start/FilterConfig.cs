using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa
{
    /// <summary>
    /// 过滤器配置，配置在此就启用全局过滤
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //添加自定义全局过滤器
            //filters.Add(new Filters.MyActionFilterAttribute());
            //filters.Add(new Filters.MyResultFilterattribute());
            //filters.Add(new Filters.MyAuthorizeAttribute());
            //filters.Add(new Filters.MyHandleErrorAttibute());
        }
    }
}
