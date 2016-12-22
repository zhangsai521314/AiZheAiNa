using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiZheAiNa.Model.CommonModel
{
    public class SendEDMInfo
    {
        public SendEDMInfo()
        { }
        /// <summary>
        /// 是否使用安全套接字(SSL)加密连接
        /// </summary>
        private bool _enableSsl = false;
        private string _userName;
        private string _password;
        private string _host;
        private int _port;
        private string _AccountAlias;
        /// <summary>
        /// 邮件主题
        /// </summary>
        private string _subject = null;

        /// <summary>
        /// 邮件内容
        /// </summary>
        private string _content = null;

        /// <summary>
        /// 邮件附件(绝对路径)
        /// </summary>
        private string[] _attchments = null;

        /// <summary>
        /// 收件人地址
        /// </summary>
        private string[] _toAddresses = null;

        /// <summary>
        /// 抄送收件人地址列表
        /// </summary>
        private string[] _ccAddresses = null;

        /// <summary>
        /// 秘密抄送收件人地址列表
        /// </summary>
        private string[] _bccAddresses = null;
        /// <summary>
        /// 收件人地址
        /// </summary>
        public string[] ToAddresses
        {
            get
            {
                return _toAddresses;
            }
            set
            {
                _toAddresses = value;
            }
        }
        /// <summary>
        /// 邮件附件(绝对路径)(多个附件)
        /// </summary>
        public string[] Attchments
        {
            get
            {
                return _attchments;
            }
            set
            {
                _attchments = value;
            }
        }
        /// <summary>
        /// 邮件附件(绝对路径)
        /// </summary>
        public string Attchment
        {
            set
            {
                _attchments = new string[1];
                _attchments[0] = value;
            }
            get
            {
                if (_attchments != null && _attchments.Length > 0)
                    return _attchments[0];
                else
                    return "";
            }
        }
        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }
        /// <summary>
        /// 抄送收件人地址列表
        /// </summary>
        public string[] CcAddresses
        {
            get
            {
                return _ccAddresses;
            }
            set
            {
                _ccAddresses = value;
            }
        }
        /// <summary>
        /// 秘密抄送收件人地址列表
        /// </summary>
        public string[] BccAddresses
        {
            get
            {
                return _bccAddresses;
            }
            set
            {
                _bccAddresses = value;
            }
        }
        /// <summary>
        /// 发送账户用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        /// <summary>
        /// 发送账户用昵称
        /// </summary>
        public string AccountAlias
        {
            get
            {
                return _AccountAlias;
            }
            set
            {
                _AccountAlias = value;
            }
        }
        /// <summary>
        /// 发送账户密码
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        /// <summary>
        /// 用于 SMTP 事务的主机的名称或 IP 地址
        /// </summary>
        public string Host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
            }
        }
        /// <summary>
        /// 要在 host 上使用的端口
        /// </summary>
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }
        /// <summary>
        /// 是否使用安全套接字(SSL)加密连接
        /// </summary>
        public bool EnableSsl
        {
            get
            {
                return _enableSsl;
            }
            set
            {
                _enableSsl = value;
            }
        }
    }
}
