using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa.Controllers
{
    public class SendController : Controller
    {
        // GET: Send
        public ActionResult Index()
        {
            return View();
        }

        public void SendEmail(string email)
        {

        }
    }
}