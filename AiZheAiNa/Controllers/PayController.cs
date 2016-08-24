using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 支付宝回调
        /// </summary>
        /// <returns></returns>
        public ActionResult ZhiFuBao()
        {
            return View();
        }
    }
}