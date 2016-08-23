using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiZheAiNa.CommonHelp
{
    /// <summary>
    /// 配置文件帮助类
    /// </summary>
    public static class ConfigurationHelper
    {
        #region 私有变量
        private static string _AiZheAiNaRead;
        private static string _AiZheAiNaWrite;
        private static string _QQAppID;
        private static string _QQAppKey;
        private static string _QQCallBack;
        private static string _QQAuthorizeURL;
        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        static ConfigurationHelper()
        {
            if (ConfigurationManager.ConnectionStrings["AiZheAiNaWrite"] != null)
            {
                _AiZheAiNaWrite = ConfigurationManager.ConnectionStrings["AiZheAiNaWrite"].ConnectionString;
            }
            if (ConfigurationManager.ConnectionStrings["AiZheAiNaRead"] != null)
            {
                _AiZheAiNaRead = ConfigurationManager.ConnectionStrings["AiZheAiNaRead"].ConnectionString;
            }
        }
        #endregion

        #region 数据库连接字符串
        /// <summary>
        /// 
        /// </summary>
        public static string AiZheAiNaRead
        {
            get { return _AiZheAiNaRead; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string AiZheAiNaWrite
        {
            get { return _AiZheAiNaWrite; }
        }
        #endregion

        #region 申请的QQ登录的appid
        /// <summary>
        /// 申请的QQ登录的appid
        /// </summary>
        public static string QQAppID
        {
            get
            {
                if (string.IsNullOrEmpty(_QQAppID))
                {
                    _QQAppID = ConfigurationManager.AppSettings["QQAppID"];
                }
                return _QQAppID;
            }
        }
        #endregion

        #region 申请的QQ登录appkey
        /// <summary>
        /// 申请的QQ登录appkey
        /// </summary>
        public static string QQAppKey
        {
            get
            {
                if (string.IsNullOrEmpty(_QQAppKey))
                {
                    _QQAppKey = ConfigurationManager.AppSettings["QQAppKey"];
                }
                return _QQAppKey;
            }
        }
        #endregion

        #region 设置的回调网址
        /// <summary>
        /// 设置的回调网址
        /// </summary>
        public static string QQCallBack
        {
            get
            {
                if (string.IsNullOrEmpty(_QQCallBack))
                {
                    _QQCallBack = ConfigurationManager.AppSettings["QQCallBack"];
                }
                return _QQCallBack;
            }
        }
        #endregion

        #region QQ登录授权页面
        /// <summary>
        /// QQ登录授权页面
        /// </summary>
        public static string QQAuthorizeURL
        {
            get
            {
                if (string.IsNullOrEmpty(_QQAuthorizeURL))
                {
                    _QQAuthorizeURL = ConfigurationManager.AppSettings["QQAuthorizeURL"];
                }
                return _QQAuthorizeURL;
            }
        }

        #endregion
    }
}
