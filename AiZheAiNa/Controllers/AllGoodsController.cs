using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa.Controllers
{
    /// <summary>
    /// 商品全部，相当于 http://list.mi.com/17 种页
    /// </summary>
    public class AllGoodsController : Controller
    {
        // GET: AllGoods
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回手机电话卡
        /// </summary>
        /// <returns></returns>
        public ActionResult PhoneAndTelcar()
        {

            return View();
        }


        /// <summary>
        /// 返回热门商品
        /// </summary>
        /// <returns></returns>
        public ActionResult ReMen()
        {
            return View();
        }

        /// <summary>
        /// 返回耳机
        /// </summary>
        /// <returns></returns>
        public ActionResult ErJi()
        {

            return View();
        }




    }
}