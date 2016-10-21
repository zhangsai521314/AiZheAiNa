using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa.Controllers
{

    /// <summary>
    /// 详情页，相当于 http://www.mi.com/bluetooth-headset/ 这种页
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
        /// <param name="shopModel">手机型号</param>
        /// <returns></returns>
        public ActionResult Phone(string shopModel)
        {
            return View("../AllGoods/ErJi");

        }

        /// <summary>
        /// 返回指定类型物品的大图介绍 相当于  http://www.mi.com/miwifi3/
        /// </summary>
        /// <param name="shopModel">物品类型</param>
        /// <returns></returns>
        public ActionResult datu(string shopModel)
        {
            return View("../AllGoods/ErJi");

        }
    }
}