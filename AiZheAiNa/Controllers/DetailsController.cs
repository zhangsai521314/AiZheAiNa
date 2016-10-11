using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa.Controllers
{
    /// <summary>
    /// 详情页
    /// </summary>
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回指定类型的手机详情页
        /// </summary>
        /// <param name="phoneType">手机型号</param>
        /// <returns></returns>
        public ActionResult Phone(string phoneType)
        {
            return View();

        }

    }
}