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
        private AiZheAiNa_SYS_UserInfoBll bll_User = new AiZheAiNa_SYS_UserInfoBll();
        private AiZheAiNa_SYS_QQUserInfoBll bll_QQUser = new AiZheAiNa_SYS_QQUserInfoBll();
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
            ////获取 完整url （协议名+域名+虚拟目录名+文件名+参数） 
            //string reqUrl = Request.Url.ToString();
            ////获取 虚拟目录名+页面名：
            //string reqUrl2 = Request.Url.AbsolutePath;
            //string reqUrl3 = Request.Path;
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
                        qqOauthInfo.OpenID = QQOAuthHelper.GetOpenID(qqOauthInfo);
                        qqOauthInfo = QQOAuthHelper.GetUserInfo(qqOauthInfo);
                        Session["QQOpenID"] = qqOauthInfo.OpenID;
                        Dictionary<string, string> whereSql = new Dictionary<string, string>();
                        whereSql.Add("UserSource", "1");
                        whereSql.Add("UserSourceOnlySign", qqOauthInfo.OpenID);
                        AiZheAiNa_SYS_UserInfo model_User = bll_User.GetListAiZheAiNa_SYS_UserInfoByParameter(whereSql).FirstOrDefault();
                        if (model_User == null || model_User.ID <= 0)
                        {
                            qqOauthInfo.Access_tokenExpiresDate = DateTime.Now.AddSeconds(Convert.ToInt32(qqOauthInfo.Access_tokenExpiresIn));
                            bll_QQUser.AddAiZheAiNa_SYS_QQUserInfo(qqOauthInfo);
                            model_User = new AiZheAiNa_SYS_UserInfo() { UserImg = qqOauthInfo.Figureurl_qq_1, ShowName = qqOauthInfo.Nickname, UserSourceOnlySign = qqOauthInfo.OpenID, UserSource = 1 };
                            bll_User.AddAiZheAiNa_SYS_UserInfo(model_User);
                        }
                        else
                        {
                            qqOauthInfo.UpdateDate = DateTime.Now;
                            bll_QQUser.UpdateAiZheAiNa_SYS_QQUserInfo(qqOauthInfo);
                        }
                        if (model_User == null || model_User.ID <= 0)
                        {
                            return RedirectPermanent("/Error/Index?errorStatus=loginError");
                        }
                        Session["UserInfo"] = model_User;
                    }
                    catch (Exception ex)
                    {
                        return RedirectPermanent("/Error/Index?errorStatus=loginError");
                    }
                }
                else
                {
                    return RedirectPermanent("/Error/Index?errorStatus=loginError");
                }
            }
            else
            {
                return RedirectPermanent("/Error/Index?errorStatus=loginError");
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
            List<AiZheAiNa_SYS_UserInfo> list_User = bll_User.GetListAiZheAiNa_SYS_UserByLoginName(model_User.LoginName);
            if (list_User.Count > 0)
            {
                return View();
            }
            bll_User.AddAiZheAiNa_SYS_UserInfo(model_User);
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