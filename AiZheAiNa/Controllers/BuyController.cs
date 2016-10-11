using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa.Controllers
{
    /// <summary>
    /// 商品购买
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
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ErJi(string  erJiType)
        {
            return View();
        }


        /// <summary>
        /// 返回指定类型的手机购买页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Phone(int phoneType)
        {

            return View();
        }

    }
}