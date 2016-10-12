using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa.Controllers
{
    /// <summary>
    /// 商品购买，相当于 http://item.mi.com/buyphone/mimax 这种页
    /// </summary>
    public class BuyController : Controller
    {
        // GET: Buy
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回指定类型的耳机购买页
        /// </summary>
        /// <param name="shopModel"></param>
        /// <returns></returns>
        public ActionResult ErJi(string shopModel)
        {
            return View();
        }


        /// <summary>
        /// 返回指定类型的手机购买页
        /// </summary>
        /// <param name="shopModel">手机大型号（小米2，小米4）</param>
        /// <returns></returns>
        public ActionResult Phone(string shopModel)
        {

            return View();
        }

    }
}