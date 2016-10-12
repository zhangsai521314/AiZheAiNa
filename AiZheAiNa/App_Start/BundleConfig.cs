using System.Web;
using System.Web.Optimization;

namespace AiZheAiNa
{
    /// <summary>
    /// 合并js，cs
    /// </summary>
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));







            BundleTable.EnableOptimizations = true;//开启合并js文件,cs文件的合并默认就是开启的

            //合并js文件
            bundles.Add(new ScriptBundle("~/bundles/MyCheck").Include(
                            "~/Scripts/jquery-1.7.1.min.js",
                            "~/Scripts/jquery.validate.min.js",
                            "~/Scripts/jquery.validate.unobtrusive.min.js",
                            "~/Scripts/jquery.unobtrusive-ajax.min.js"

                ));
            //合并cs
            bundles.Add(new StyleBundle("~/bundles/MyCss").Include(
                                      "~/Content/HeBingCss1.css",
                                      "~/Content/HeBingCss2.css"

                ));


            bundles.Add(new ScriptBundle("~/bundles/urljs").Include(
                "~/Scripts/MyScripts/url.js"

                ));
            bundles.Add(new StyleBundle("~/bundles/urlcss").Include(
                "~/Content/MyCss/url.css "
                ));


















        }
    }
}
