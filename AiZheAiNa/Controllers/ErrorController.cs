using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            //返回网址
            ViewBag.errorStatus = Request.QueryString["errorStatus"] ?? "";
            return View();
        }

        public ActionResult CommonError()
        {
            return View();
        }
    }
}