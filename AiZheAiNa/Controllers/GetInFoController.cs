using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AiZheAiNa.Model;
using Newtonsoft.Json;

namespace AiZheAiNa.Controllers
{
    public class GetInFoController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        #region 获取已登录的用户信息
        /// <summary>
        /// 获取已登录的用户信息
        /// </summary>
        /// <returns></returns>
        public string GetUserInfo()
        {
            object s = Session["UserInfo"];
            return JsonConvert.SerializeObject((AiZheAiNa_SYS_UserModel)Session["UserInfo"]);
        } 
        #endregion
    }
}