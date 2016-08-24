using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AiZheAiNa.Model;
using AiZheAiNa.BLL;
using AiZheAiNa.CommonHelp;
using System.Configuration;
using AiZheAiNa.Plug.QQ;
using QConnectSDK.Context;
using QConnectSDK;
using AiZheAiNa.Filters;

namespace AiZheAiNa.Controllers
{
    public class HomeController : Controller
    {
        #region 私有变量
        private AiZheAiNa_SYS_UserBll bll_User = new AiZheAiNa_SYS_UserBll();
        private EnumResultCold resultcode = new EnumResultCold();
        private ResultInfo resultInfo = new ResultInfo();
        #endregion

        #region 视图

        #region 首页
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            AiZheAiNa_SYS_UserInfo m = (AiZheAiNa_SYS_UserInfo)Session["UserInfo"];
            if (Session["UserInfo"] != null)
            {
                ViewBag.LoginStatus = 1;
                ViewBag.LoginMsg = "登录成功";
            }
            return View();
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [NoPageCache]
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region 用户注册
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model_User"></param>
        /// <returns></returns>
        [NoPageCache]
        public ActionResult Register()
        {
            return View();
        }
        #endregion

        #region 用户退出
        /// <summary>
        /// 用户退出
        /// </summary>
        public ActionResult LoginOut()
        {
            Session["UserInfo"] = null;
            object s = Session["UserInfo"];
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #endregion

        #region 操作

        #region 本站用户登录
        /// <summary>
        /// 本站用户登录
        /// </summary>
        /// <param name="model_User"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult Login(AiZheAiNa_SYS_UserInfo model_User)
        {
            List<AiZheAiNa_SYS_UserInfo> list_User = bll_User.GetListAiZheAiNa_SYS_UserByLoginName(model_User.LoginName);
            model_User = list_User.Where(u => u.PassWord == StringHelper.GetMd5Str32(model_User.PassWord)).FirstOrDefault();
            if (model_User == null)
            {
                return RedirectPermanent("/Home/Register");
            }
            Session["UserInfo"] = model_User;
            //1把passWord转换MD5然后和用户名一起在结果集中查找
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region QQ登录，自写帮助类
        /// <summary>
        /// QQ登录，自写帮助类
        /// </summary>
        /// <returns></returns>
        public ActionResult QQLogin()
        {
            string state = Guid.NewGuid().ToString().Replace("-", "");
            Session["QQState"] = state;
            string appID = ConfigurationHelper.QQAppID;
            string qqAuthorizeURL = ConfigurationHelper.QQAuthorizeURL;
            string callback = ConfigurationHelper.QQCallBack;
            string authenticationUrl = string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}&state={3}", qqAuthorizeURL, appID, callback, state);
            return new RedirectResult(authenticationUrl);
        }
        #endregion

        #region  QQ回调页面，自写帮助类
        /// <summary>
        /// QQ回调页面，自写帮助类
        /// </summary>
        public ActionResult QQConnect()
        {
            if (!string.IsNullOrEmpty(Request.Params["code"]) && !string.IsNullOrEmpty(Request.Params["state"]))
            {
                var code = Request.Params["code"];
                var state = Request.Params["state"];
                string requestState = Session["QQState"] == null ? "" : Session["QQState"].ToString();
                if (state == requestState)
                {
                    try
                    {
                        AiZheAiNa_SYS_QQUserInfo qqOauthInfo = QQOAuthHelper.GetOauthInfo(code);
                        string openID = QQOAuthHelper.GetOpenID(qqOauthInfo);
                        qqOauthInfo = QQOAuthHelper.GetUserInfo(qqOauthInfo, openID);
                        Session["QQOpenID"] = openID;
                        Dictionary<string, string> whereSql = new Dictionary<string, string>();
                        whereSql.Add("UserSource", "1");
                        whereSql.Add("UserSourceOnlySign", openID);
                        AiZheAiNa_SYS_UserInfo model_User = bll_User.GetListAiZheAiNa_SYS_UserByParameter(whereSql).FirstOrDefault();
                        if (model_User == null || model_User.ID <= 0)
                        {
                            model_User = new AiZheAiNa_SYS_UserInfo() { UserImg = qqOauthInfo.Figureurl_qq_1, ShowName = qqOauthInfo.Nickname, UserSourceOnlySign = openID, UserSource = 1 };
                            bll_User.AddAiZheAiNa_SYS_User(model_User);
                        }
                        if (model_User == null || model_User.ID <= 0)
                        {
                            //失败
                        }
                        Session["UserInfo"] = model_User;
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("CommonError", "Error");
                    }
                }
                else
                {
                    return RedirectToAction("CommonError", "Error");
                }
            }
            else
            {
                return RedirectToAction("CommonError", "Error");
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region QQ登录，QConnectSDK博客园张善友
        //#region QQ登录，QConnectSDK博客园张善友
        ///// <summary>
        ///// QQ登录，QConnectSDK博客园张善友
        ///// </summary>
        //[HttpGet]
        //public ActionResult QQLogin(string returnUrl)
        //{
        //    Session["RETURNURL"] = returnUrl;
        //    var context = new QzoneContext();
        //    string state = Guid.NewGuid().ToString().Replace("-", "");
        //    Session["requeststate"] = state;
        //    string scope = "get_user_info,add_share,list_album,upload_pic,check_page_fans,add_t,add_pic_t,del_t,get_repost_list,get_info,get_other_info,get_fanslist,get_idolist,add_idol,del_idol,add_one_blog,add_topic,get_tenpay_addr";
        //    var authenticationUrl = context.GetAuthorizationUrl(state, scope);
        //    return new RedirectResult(authenticationUrl);
        //}
        //#endregion

        //#region 回调页面，QConnectSDK博客园张善友
        ///// <summary>
        ///// 回调页面，QConnectSDK博客园张善友
        ///// </summary>
        //public ActionResult QQConnect()
        //{
        //    if (Request.Params["code"] != null)
        //    {
        //        QOpenClient qzone = null;
        //        var verifier = Request.Params["code"];
        //        var state = Request.Params["state"];
        //        string requestState = Session["requeststate"].ToString();
        //        if (state == requestState)
        //        {
        //            qzone = new QOpenClient(verifier, state);
        //            var currentUser = qzone.GetCurrentUser();
        //            if (Session["QzoneOauth"] == null)
        //            {
        //                Session["QzoneOauth"] = qzone;
        //            }
        //            var friendlyName = currentUser.Nickname;
        //            return Redirect(Url.Action("Index", "Home"));
        //        }
        //    }
        //    return View();
        //}
        //#endregion 
        #endregion

        #region 用户注册
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model_User"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(AiZheAiNa_SYS_UserInfo model_User)
        {
            model_User.MingPassWord = model_User.PassWord;
            model_User.PassWord = StringHelper.GetMd5Str32(model_User.PassWord);
            bll_User.AddAiZheAiNa_SYS_User(model_User);
            if (model_User != null && model_User.ID > 0)
            {
                Session["UserInfo"] = model_User;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        #endregion 

        #endregion
    }
}