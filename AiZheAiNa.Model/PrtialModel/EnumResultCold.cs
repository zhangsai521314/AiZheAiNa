using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiZheAiNa.Model
{
    public class EnumResultCold
    {
        private string _Failure = "000:调用失败";
        private string _succeed = "001:调用成功";
        private string _UnknownFailure = "002:未知错误";
        private string _DataBaseFailure = "003:数据库错误";
        private string _NetFailure = "004:网络错误";
        private string _ProgramFailure = "005:程序错误";
        private string _DataNull = "006:数据为空";
        private string _DataFormatFa = "007:数据格式错误";
        private string _IPNOAccess = "008:客户端IP未被许可访问";
        private string _ValidTicket = "009:验证标识不正确";
        private string _SerClose = "010:调用的服务已关闭";
        private string _CertificateErr = "011:证书错误";
        private string _codeValid = "012:验证码有效";
        private string _LoginSucceed = "013:登录成功";
        private string _loginDefeat = "014:登录失败";
        private string _IsClient = "015:客户已经存在";
        private string _dataExist = "016:登录名,密码或经销商不正确";
        private string _onlineUser = "017:当前账户已在别处登录";
        private string _ParaNull = "100:传递的参数值为空";
        private string _NumberErr = "101:无效数字格式";
        private string _PhoneErr = "102:无效的手机号码";
        private string _EmailErr = "103:无效电子邮箱格式";
        private string _DateErr = "104:无效日期格式";
        private string _PostCodeErr = "105:无效邮政编码格式";
        private string _BGDateGTEnDate = "106:开始日期大于结束日期";
        private string _ParaErr = "107:传递的参数格式不正确";
        private string _ClientIDErr = "108:传递的客户ID不正确";
        private string _UserIDErr = "109:传递的销售人员ID不正确";
        private string _codeInvalid = "110:验证码已过期";
        private string _MethodNonentity = "102:调用的方法不存在";
        private string _TokenErr = "112:传递的Token错误";
        private string _submitTypeError = "113: 上传提交方式错误";
        private string _IDNUll = "200:指定ID值的数据记录不存在";
        private string _IDNoInteger = "201:指定ID值不是一个有效正整数";
        private string _PhoneExist = "202:指定手机号码的数据记录已经存在";
        private string _TelephoneExist = "203:指定座机号码的数据记录已经存在";
        private string _WeChatCodeExistNull = "204:微信ID为空或无效";
        private string _PhoneNull = "205:指定手机号码的数据记录不存在";
        private string _SelectNull = "206:查询的数据不存在";
        private string _SourceExistence = "207:数据已存在";
        private string _shortTimeBeg = "300:两分钟之内只能发送一次验证码";
        private string _sendCountOverrun = "301:当天发送次数超限";


        /// <summary>
        /// 当前账户已在别处登录
        /// </summary>
        public string OnlineUser
        {
            get { return _onlineUser; }
            set { _onlineUser = value; }
        }


        /// <summary>
        /// 登录名或密码或经销商不正确
        /// </summary>
        public string DataExist
        {
            get { return _dataExist; }
            set { _dataExist = value; }
        }

        /// <summary>
        /// 上传提交方式错误
        /// </summary>
        public string SubmitTypeError
        {
            get { return _submitTypeError; }
            set { _submitTypeError = value; }
        }

        /// <summary>
        /// 数据已存在
        /// </summary>s
        public string SourceExistence
        {
            get { return _SourceExistence; }
            set { _SourceExistence = value; }
        }

        /// <summary>
        /// 调用的方法不存在
        /// </summary>
        public string MethodNonentity
        {
            get { return _MethodNonentity; }
            set { _MethodNonentity = value; }
        }

        /// <summary>
        /// 传递的Token错误
        /// </summary>
        public string TokenErr
        {
            get { return _TokenErr; }
            set { _TokenErr = value; }
        }
        /// <summary>
        /// 验证码有效
        /// </summary>
        public string CodeValid
        {
            get { return _codeValid; }
            set { _codeValid = value; }
        }

        /// <summary>
        /// 验证码已过期
        /// </summary>
        public string CodeInvalid
        {
            get { return _codeInvalid; }
            set { _codeInvalid = value; }
        }

        /// <summary>
        /// 当天发送次数超限
        /// </summary>
        public string SendCountOverrun
        {
            get { return _sendCountOverrun; }
            set { _sendCountOverrun = value; }
        }

        /// <summary>
        /// 两分钟之内只能发送一次验证码
        /// </summary>
        public string ShortTimeBeg
        {
            get { return _shortTimeBeg; }
            set { _shortTimeBeg = value; }
        }
        /// <summary>
        /// 查询的数据不存在
        /// </summary>
        public string SelectNull
        {
            get { return _SelectNull; }
        }
        /// <summary>
        /// 指定手机号码的数据记录不存在
        /// </summary>
        public string PhoneNull
        {
            get { return _PhoneNull; }
        }
        /// <summary>
        /// 微信ID为空或无效
        /// </summary>
        public string WeChatCodeExistNull
        {
            get { return _WeChatCodeExistNull; }
        }
        /// <summary>
        /// 指定座机号码的数据记录已经存在
        /// </summary>
        public string TelephoneExist
        {
            get { return _TelephoneExist; }
        }
        /// <summary>
        /// 指定手机号码的数据记录已经存在
        /// </summary>
        public string PhoneExist
        {
            get { return _PhoneExist; }
        }
        /// <summary>
        /// 指定ID值不是一个有效正整数
        /// </summary>
        public string IDNoInteger
        {
            get { return _IDNoInteger; }
        }
        /// <summary>
        /// 指定ID值的数据记录不存在
        /// </summary>
        public string IDNUll
        {
            get { return _IDNUll; }
        }




        /// <summary>
        /// 传递的销售人员ID不正确
        /// </summary>
        public string UserIDErr
        {
            get { return _UserIDErr; }
        }
        /// <summary>
        /// 传递的客户ID不正确
        /// </summary>
        public string ClientIDErr
        {
            get { return _ClientIDErr; }
        }
        /// <summary>
        /// 开始日期大于结束日期
        /// </summary>
        public string BGDateGTEnDate
        {
            get { return _BGDateGTEnDate; }
        }
        /// <summary>
        /// 无效邮政编码格式
        /// </summary>
        public string PostCodeErr
        {
            get { return _PostCodeErr; }
        }
        /// <summary>
        /// 无效日期格式
        /// </summary>
        public string DateErr
        {
            get { return _DateErr; }
        }
        /// <summary>
        /// 无效电子邮箱格式
        /// </summary>
        public string EmailErr
        {
            get { return _EmailErr; }
        }
        /// <summary>
        /// 无效的手机号码
        /// </summary>
        public string PhoneErr
        {
            get { return _PhoneErr; }
        }
        /// <summary>
        /// 无效数字格式
        /// </summary>
        public string NumberErr
        {
            get { return _NumberErr; }
        }
        /// <summary>
        /// 传递的参数值为空
        /// </summary>
        public string ParaNull
        {
            get { return _ParaNull; }
        }
        /// <summary>
        /// 传递的参数格式不正确
        /// </summary>
        public string ParaErr
        {
            get { return _ParaErr; }
            set { _ParaErr = value; }
        }






        /// <summary>
        /// 证书错误
        /// </summary>
        public string CertificateErr
        {
            get { return _CertificateErr; }
        }
        /// <summary>
        /// 调用的服务已关闭
        /// </summary>
        public string SerClose
        {
            get { return _SerClose; }
        }
        /// <summary>
        /// 验证标识不正确
        /// </summary>
        public string ValidTicket
        {
            get { return _ValidTicket; }
        }
        /// <summary>
        /// 客户端IP未被许可访问
        /// </summary>
        public string IPNOAccess
        {
            get { return _IPNOAccess; }
        }
        /// <summary>
        /// 数据格式错误
        /// </summary>
        public string DataFormatFa
        {
            get { return _DataFormatFa; }
        }
        /// <summary>
        /// Json数据为空
        /// </summary>
        public string DataNull
        {
            get { return _DataNull; }
        }
        /// <summary>
        /// 程序错误
        /// </summary>
        public string ProgramFailure
        {
            get { return _ProgramFailure; }
        }
        /// <summary>
        /// 网络错误
        /// </summary>
        public string NetFailure
        {
            get { return _NetFailure; }
        }
        /// <summary>
        /// 数据库错误
        /// </summary>
        public string DataBaseFailure
        {
            get { return _DataBaseFailure; }
        }
        /// <summary>
        /// 未知错误
        /// </summary>
        public string UnknownFailure
        {
            get { return _UnknownFailure; }
        }
        /// <summary>
        /// 调用成功
        /// </summary>
        public string Succeed
        {
            get { return _succeed; }
        }
        /// <summary>
        /// 调用失败
        /// </summary>
        public string Failure
        {
            get { return _Failure; }
        }
        /// <summary>
        /// 用户登录成功
        /// </summary>
        public string LoginSucceed
        {
            get { return _LoginSucceed; }
            set { _LoginSucceed = value; }
        }
        /// <summary>
        /// 用户登录失败
        /// </summary>
        public string LoginDefeat
        {
            get { return _loginDefeat; }
            set { _loginDefeat = value; }
        }

        /// <summary>
        /// 客户已经存在
        /// </summary>
        public string IsClient
        {
            get { return _IsClient; }
            set { _IsClient = value; }
        }
    }
}
