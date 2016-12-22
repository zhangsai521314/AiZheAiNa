using AiZheAiNa.CommonHelp;
using AiZheAiNa.Model.BusinessModel;
using AiZheAiNa.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AiZheAiNa.Controllers
{
    public class SendController : Controller
    {
        private static string edmAccountName;
        private static string edmAccountPwd;
        private static string edmAccountAlias;
        private static string edmSmtpHost;
        private static string EDMTitle;
        private static int edmSmtpPort;
        private static bool edmSmtpSSL;
        static SendController()
        {
            edmAccountName = ConfigurationHelper.EDMAccountName;
            edmAccountPwd = ConfigurationHelper.EDMAccountPwd;
            edmAccountAlias = ConfigurationHelper.EDMAccountAlias;
            edmSmtpHost = ConfigurationHelper.SmtpHost;
            edmSmtpPort = ConfigurationHelper.SmtpPort;
            edmSmtpSSL = ConfigurationHelper.SmtpSSL;

        }
        // GET: Send
        public ActionResult Index()
        {
            return View();
        }

        public void SendEmail(AiZheAiNa_SYS_UserInfo userInfo)
        {
            string code = RandomCodeHelper.GenerateRandomNumber(6);
            string str = System.AppDomain.CurrentDomain.BaseDirectory;
            EDMTitle = "爱这爱那网注册邮件";
            StreamReader sr = new StreamReader(str + @"\Files\SendTemlate\SendEmailTemplate.txt", Encoding.Default);
            string Content = sr.ReadToEnd().Replace("$name$", userInfo.LoginName).Replace("$code$", code);
            string[] emails = new string[1] { userInfo.Email };
            EDMStatus status = SendMsgHelper.SendEmail(edmAccountName, edmAccountPwd, edmAccountAlias, edmSmtpHost, edmSmtpPort, edmSmtpSSL, emails, Content, EDMTitle);
            if (status == EDMStatus.EDMSendSuccess)
            {
                CookieHelper.SetCookie("user_register_" + userInfo.Email, code, DateTime.Now.AddMinutes(20));
            }
        }
    }
}