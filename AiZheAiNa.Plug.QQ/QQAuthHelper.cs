using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using AiZheAiNa.CommonHelp;
using AiZheAiNa.Model;
using Newtonsoft.Json;

namespace AiZheAiNa.Plug.QQ
{
    public static class QQOAuthHelper
    {

        #region 获取oauth信息
        /// <summary>
        /// 获取oauth信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static AiZheAiNa_SYS_QQUserInfo GetOauthInfo(string code)
        {
            string callback = HttpUtility.UrlEncode(ConfigurationHelper.QQCallBack, Encoding.UTF8);
            string url = string.Format("https://graph.qq.com/oauth2.0/token?grant_type={0}&client_id={1}&client_secret={2}&code={3}&redirect_uri={4}", "authorization_code", ConfigurationHelper.QQAppID, ConfigurationHelper.QQAppKey, code, ConfigurationHelper.QQCallBack);
            string res = LoadHtmlUserGetType(url, Encoding.UTF8);
            AiZheAiNa_SYS_QQUserInfo AiZheAiNa_SYS_QQUserInfo = new AiZheAiNa_SYS_QQUserInfo();
            AiZheAiNa_SYS_QQUserInfo.Access_token = CutString(res, "access_token=", "&expires_in=");
            AiZheAiNa_SYS_QQUserInfo.Access_tokenExpiresIn = CutString(res, "&expires_in=", "&refresh_token=");
            AiZheAiNa_SYS_QQUserInfo.Refresh_token = res.Split(new string[] { "&refresh_token=" }, StringSplitOptions.None)[1];
            return AiZheAiNa_SYS_QQUserInfo;
        }
        #endregion

        #region 截取字符串中两个字符串中的字符串
        /// <summary>
        /// 截取字符串中两个字符串中的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="startStr">开始字符串</param>
        /// <param name="endStr">结束字符串</param>
        /// <returns></returns>
        private static string CutString(string str, string startStr, string endStr)
        {
            int begin, end;
            begin = str.IndexOf(startStr, 0) + startStr.Length; //开始位置
            end = str.IndexOf(endStr, begin); //结束位置
            return str.Substring(begin, end - begin); //取搜索的条数，用结束的位置-开始的位置,并返回
        }
        #endregion

        #region get请求
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="urlString">请求的URL</param>
        /// <param name="encoding">页面编码</param>
        /// <returns></returns>
        public static string LoadHtmlUserGetType(string urlString, Encoding encoding)
        {

            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebRespones = null;
            Stream stream = null;
            string htmlString = string.Empty;
            try
            {
                httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
            }
            catch (Exception ex)
            {
                throw new Exception("建立页面请求时发生错误！", ex);
            }
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; Maxthon 2.0)";
            try
            {
                httpWebRespones = (HttpWebResponse)httpWebRequest.GetResponse();
                stream = httpWebRespones.GetResponseStream();
            }
            catch (Exception ex)
            {
                throw new Exception("接受服务器返回页面时发生错误！", ex);
            }
            StreamReader streamReader = new StreamReader(stream, encoding);
            try
            {
                htmlString = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("读取页面数据时发生错误！", ex);
            }
            streamReader.Close();
            stream.Close();
            return htmlString;
        }
        #endregion

        #region 获取QQ账号的OpenID
        /// <summary>
        /// 获取QQ账号的OpenID,这个ID是QQ给我们的用户的唯一ID，可以作为我们系统用户唯一性的判断存在我们自己的库中
        /// </summary>
        /// <param name="AiZheAiNa_SYS_QQUserInfo"></param>
        /// <returns></returns>
        public static string GetOpenID(AiZheAiNa_SYS_QQUserInfo AiZheAiNa_SYS_QQUserInfo)
        {
            string res = LoadHtmlUserGetType("https://graph.qq.com/oauth2.0/me?access_token=" + AiZheAiNa_SYS_QQUserInfo.Access_token, Encoding.UTF8);
            return CutString(res, @"openid"":""", @"""}");
        }
        #endregion

        #region 获取QQ昵称
        /// <summary>
        /// 获取QQ昵称
        /// </summary>
        /// <param name="AiZheAiNa_SYS_QQUserInfo"></param>
        /// <param name="openID"></param>
        /// <returns></returns>
        public static AiZheAiNa_SYS_QQUserInfo GetUserInfo(AiZheAiNa_SYS_QQUserInfo AiZheAiNa_SYS_QQUserInfo)
        {
            string urlGetInfo = string.Format(@"https://graph.qq.com/user/get_user_info?access_token={0}&oauth_consumer_key={1}&openid={2}", AiZheAiNa_SYS_QQUserInfo.Access_token, ConfigurationHelper.QQAppID, AiZheAiNa_SYS_QQUserInfo.OpenID);
            string resUserInfo = LoadHtmlUserGetType(urlGetInfo, Encoding.UTF8);
            string OpenID = AiZheAiNa_SYS_QQUserInfo.OpenID;
            string Access_token = AiZheAiNa_SYS_QQUserInfo.Access_token;
            string Access_tokenExpiresIn = AiZheAiNa_SYS_QQUserInfo.Access_tokenExpiresIn;
            string Refresh_token = AiZheAiNa_SYS_QQUserInfo.Refresh_token;
            AiZheAiNa_SYS_QQUserInfo = JsonConvert.DeserializeObject<AiZheAiNa_SYS_QQUserInfo>(resUserInfo);
            AiZheAiNa_SYS_QQUserInfo.Access_token = Access_token;
            AiZheAiNa_SYS_QQUserInfo.Access_tokenExpiresIn = Access_tokenExpiresIn;
            AiZheAiNa_SYS_QQUserInfo.Refresh_token = Refresh_token;
            AiZheAiNa_SYS_QQUserInfo.OpenID = OpenID;
            return AiZheAiNa_SYS_QQUserInfo;
        }
        #endregion
    }
}