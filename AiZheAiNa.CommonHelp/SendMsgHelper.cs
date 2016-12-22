using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.Model.CommonModel;
using System.Net.Mail;
using System.Net;

namespace AiZheAiNa.CommonHelp
{
    public class SendMsgHelper
    {

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="edmAccountName">账号名</param>
        /// <param name="edmAccountPwd">账户密码</param>
        /// <param name="edmAccountAlias">昵称</param>
        /// <param name="edmSmtpHost"></param>
        /// <param name="edmSmtpPort"></param>
        /// <param name="edmSmtpSSL"></param>
        /// <param name="email"></param>
        /// <param name="content"></param>
        /// <param name="subj"></param>
        /// <returns></returns>
        public static EDMStatus SendEmail(string edmAccountName, string edmAccountPwd, string edmAccountAlias, string edmSmtpHost, int edmSmtpPort, bool edmSmtpSSL, string[] email, string content, string subj)
        {
            try
            {
                SendEDMInfo info = new SendEDMInfo();
                info.UserName = edmAccountName;
                info.Password = edmAccountPwd;
                info.AccountAlias = edmAccountAlias;
                info.Host = edmSmtpHost;
                info.Port = edmSmtpPort;
                info.EnableSsl = edmSmtpSSL;
                info.Subject = subj;
                info.ToAddresses = email;
                info.Content = content;
                return SendEmail(info);
            }
            catch (Exception ex)
            {
                return EDMStatus.EDMException;
            }
        }
        private static EDMStatus SendEmail(SendEDMInfo edm)
        {
            try
            {
                if (string.IsNullOrEmpty(edm.Subject))
                {
                    return EDMStatus.EDMSubjectEmpty;
                }
                if (string.IsNullOrEmpty(edm.Content))
                {
                    return EDMStatus.EDMContentEmpty;
                }
                if (edm.ToAddresses == null || edm.ToAddresses.Length <= 0)
                {
                    return EDMStatus.EDMToAddressEmpty;
                }

                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = edm.EnableSsl;
                client.Port = edm.Port;
                client.Host = edm.Host;
                client.Credentials = new NetworkCredential(edm.UserName, edm.Password);
                MailMessage message = new MailMessage();
                if (string.IsNullOrEmpty(edm.AccountAlias))
                {
                    message.From = new MailAddress(edm.UserName);
                }
                else
                {
                    message.From = new MailAddress(edm.UserName, edm.AccountAlias);
                }

                String toAddrs = "";
                for (int i = 0; edm.ToAddresses != null && i < edm.ToAddresses.Length; i++)
                {
                    if (!string.IsNullOrEmpty(edm.ToAddresses[i]))
                    {
                        message.To.Add(edm.ToAddresses[i]);
                        if (i < edm.ToAddresses.Length - 1)
                        {
                            toAddrs += edm.ToAddresses[i] + ",";
                        }
                        else
                        {
                            toAddrs += edm.ToAddresses[i];
                        }
                    }
                }

                for (int i = 0; edm.CcAddresses != null && i < edm.CcAddresses.Length; i++)
                {
                    message.CC.Add(edm.CcAddresses[i]);
                }
                for (int i = 0; edm.BccAddresses != null && i < edm.BccAddresses.Length; i++)
                {
                    message.Bcc.Add(edm.BccAddresses[i]);
                }
                for (int i = 0; edm.Attchments != null && i < edm.Attchments.Length; i++)
                {
                    Attachment item = new Attachment(edm.Attchments[i]);
                    message.Attachments.Add(item);
                }
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                message.Subject = edm.Subject;
                message.Body = edm.Content;

                client.Send(message);

                return EDMStatus.EDMSendSuccess;
            }
            catch (Exception ex)
            {
                return EDMStatus.EDMException;
            }
        }
        #endregion
    }
}
